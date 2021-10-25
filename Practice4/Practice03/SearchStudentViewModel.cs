using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Practice03
{
    class SearchStudentViewModel : BaseViewModel
    {
        public class Student
        {
            public int studentId { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string email { get; set; }
            public string gender { get; set; }
            public string Class { get; set; }
            public decimal gpa { get; set; }
        }
        private string m_searchKeyword;
        public string SearchKeyword
        {
            get => m_searchKeyword;
            set
            {
                m_searchKeyword = value;
                OnPropertyChanged(nameof(SearchKeyword));
            }
        }
        private string m_selectedClass;
        public string SelectedClass
        {
            get => m_selectedClass;
            set
            {
                m_selectedClass = value;
                OnPropertyChanged(nameof(m_selectedClass));
            }
        }
        private Student m_selectedStudent;
        public Student SelectedStudent
        {
            get => m_selectedStudent;
            set
            {
                m_selectedStudent = value;
                OnPropertyChanged(nameof(m_selectedStudent));
            }
        }

        public void DoOpenDetail()
        {
            var studentDetailViewModel = new StudentDetailViewModel(SelectedStudent);
            Window1 studenDetail = new Window1();
            studenDetail.DataContext = studentDetailViewModel;
            studenDetail.ShowDialog();
        }

        private void DoSearch()
        {
            Students.Clear();
            //var result = m_studentSrv.SearchStudent(SearchKeyword , m_selectedClass);
            var result = m_studentSrv.SearchStudent(SearchKeyword, SelectedClass);
            foreach (var s in result)
            {
                Students.Add(s);
            }
        }

        public void DoReset()
        {

            SearchKeyword = null;
            m_selectedClass = null;
        }

        public ObservableCollection<Student> Students { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        public ICommand OpenDetailCommand { get; set; }

        private IStudentService m_studentSrv;

        public SearchStudentViewModel()
        {
            var jsonString = File.ReadAllText("Student_Data.json");
            m_studentSrv = new StudentServiceWithFile();
            Students = new ObservableCollection<Student>(m_studentSrv.SearchStudent(string.Empty, string.Empty));
            OpenDetailCommand = new ConditionalCommand(x => DoOpenDetail());
            SearchCommand = new ConditionalCommand(x => DoSearch());
            ResetCommand = new ConditionalCommand(x => DoReset());
        }


    }
}