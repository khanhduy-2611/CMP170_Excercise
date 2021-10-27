using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Final_Project
{
    public class SearchTeacherViewModel : BaseViewModel
    {
        public class Teacher
        {
            public int TeacherID { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string email { get; set; }
            public string gender { get; set; }
            public string Class { get; set; }
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
                OnPropertyChanged(nameof(SelectedClass));
            }
        }
        private Teacher m_selectedTeacher;
        public Teacher SelectedTeacher
        {
            get => m_selectedTeacher;
            set
            {
                m_selectedTeacher = value;
                OnPropertyChanged(nameof(SelectedTeacher));
            }
        }
        public void DoOpenDetail()
        {
            var TeacherDetailViewModel = new TeacherDetailViewModel(SelectedTeacher);
            Window1 window1 = new Window1();
            window1.DataContext = TeacherDetailViewModel;
            window1.ShowDialog();
        }
        public ObservableCollection<Teacher> teacher { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        public ICommand OpenDetailCommand { get; set; }
        public ICommand AddDetailCommand { get; set; }
        private ITeacherService m_teacherSrv;
        public SearchTeacherViewModel()
        {
            m_teacherSrv = new TeacherServiceWithEF();
            teacher = new ObservableCollection<Teacher>(m_teacherSrv.SearchTeacher(string.Empty, string.Empty));
            OpenDetailCommand = new ConditionalCommand(x => DoOpenDetail());
            SearchCommand = new ConditionalCommand(x => DoSearch());
            ResetCommand = new ConditionalCommand(x => DoReset());
        }
        public void DoReset()
        {
            teacher.Clear();
            SearchKeyword = null;
            m_selectedClass = null;
            var result = m_teacherSrv.SearchTeacher(SearchKeyword, SelectedClass);
            foreach (var s in result)
            {
                teacher.Add(s);
            }
        }
        public void DoSearch()
        {
            teacher.Clear();
            var result = m_teacherSrv.SearchTeacher(SearchKeyword, SelectedClass);
            foreach (var s in result)
            {
                teacher.Add(s);
            }
        }
    }
}
