using System;
using System.Collections.Generic;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Text.Json;

namespace Practice03
{
    class SearchStudentViewModel : BaseViewModel
    {
        public class Student
        {
            public int studentId { get; set; }
            public String firstname { get; set; }
            public String lastname { get; set; }
            public String email { get; set; }
            public String gender { get; set; }
            public String Class { get; set; }
            public decimal gpa { get; set; }
            internal static void Add(Student s)
            {

            }

            internal static void Clear()
            {
                Console.Clear();
            }


        }
        private String m_Searchkeyword;

        public String Searchkeyword
        {
            get => m_Searchkeyword;
            set
            {
                m_Searchkeyword = value;
                OnPropertyChanged(nameof(Searchkeyword));
            }
        }
        private String m_selectedclass;
        public String SelectedClass
        {
            get => m_Searchkeyword;
            set
            {
                m_selectedclass = value;
                OnPropertyChanged(nameof(m_selectedclass));
            }
        }
        private Student m_selectedstudent;
        public Student SelectedStudent
        {
            get => m_selectedstudent;
            set
            {
                m_selectedstudent = value;
                OnPropertyChanged(nameof(m_selectedstudent));
            }
        }

        public ObservableCollection<Student> Students { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        public ICommand OpenDetailCommand { get; set; }

        public void DoReset()
        {
            Searchkeyword = null;
            SelectedClass = null;
        }

        private void DoSearch()
        {
            Student.Clear();
            var result = m_studentSrv.SearchStudent(Searchkeyword, SelectedClass);
            foreach (var s in result)
            {
                Student.Add(s);
            }
        }

        private IStudentService m_studentSrv;
        public SearchStudentViewModel()
        {
            m_studentSrv = new StudentServiceWithFile();
            Students = new ObservableCollection<Student>(m_studentSrv.SearchStudent(String.Empty, string.Empty));

            OpenDetailCommand = new ConditionalCommand(x => DoOpenDetail());
            SearchCommand = new ConditionalCommand(x => DoSearch());
            ResetCommand = new ConditionalCommand(x => DoReset());
        }
        public void DoOpenDetail()
        {
            var studentDetailViewModel = new StudentDetailViewModel(SelectedStudent);
            Window1 studentDetail = new Window1();
            studentDetail.DataContext = studentDetailViewModel;
            studentDetail.ShowDialog();
        }

        public SearchStudentViewModel()
        {
            var jsonString = File.ReadAllText("Student_Data.json");
            var students = JsonSerializer.Deserialize<List<Student>>(jsonString);
            Students = new ObservableCollection<Student>(students);
            OpenDetailCommand = new ConditionalCommand(x => DoOpenDetail());

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}