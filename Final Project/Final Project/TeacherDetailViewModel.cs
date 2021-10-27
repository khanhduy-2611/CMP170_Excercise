using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Final_Project.SearchTeacherViewModel;

namespace Final_Project
{
    class TeacherDetailViewModel : BaseViewModel
    {
        private string classdetail;
        private bool ismale;
        private int teacherIddetail;
        private string firstnamedetail;
        private string lastnamedetail;
        private string emaildetail;
        private string genderdetail;

        public int TeacherIddetail
        {
            get => teacherIddetail;
            set
            {
                teacherIddetail = value;
                OnPropertyChanged(nameof(TeacherIddetail));
            }
        }
        public string Firstnamedetail
        {
            get => firstnamedetail;
            set
            {
                firstnamedetail = value;
                OnPropertyChanged(nameof(Firstnamedetail));
            }
        }
        public string Lastnamedetail
        {
            get => lastnamedetail; set
            {
                lastnamedetail = value;
                OnPropertyChanged(nameof(Lastnamedetail));

            }
        }
        public string Emaildetail
        {
            get => emaildetail; set
            {
                emaildetail = value;
                OnPropertyChanged(nameof(Emaildetail));

            }
        }
        public string Genderdetail
        {
            get => genderdetail; set
            {
                genderdetail = value;
                OnPropertyChanged(nameof(Genderdetail));

            }
        }
        public string Classdetail
        {
            get => classdetail; set
            {
                classdetail = value;
                OnPropertyChanged(nameof(Classdetail));

            }
        }
        public ICommand Savedetail { get; set; }
        public Boolean Ismale
        {
            get => ismale; set
            {
                ismale = value;
                OnPropertyChanged(nameof(Ismale));

            }
        }
        public Boolean IsFemale
        {
            get => !ismale; set
            {
                ismale = !value;
                OnPropertyChanged(nameof(IsFemale));

            }
        }
        public TeacherDetailViewModel(Teacher teacher)
        {
            TeacherIddetail = teacher.TeacherID;
            Firstnamedetail = teacher.firstname;
            Lastnamedetail = teacher.lastname;
            Emaildetail = teacher.email;
            Genderdetail = teacher.gender;
            Classdetail = teacher.Class;
            Ismale = (Genderdetail == "Male");
        }
    }
}
