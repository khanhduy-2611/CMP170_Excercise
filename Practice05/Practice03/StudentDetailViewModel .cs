using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Practice03.SearchStudentViewModel;

namespace Practice03
{
    class StudentDetailViewModel : BaseViewModel
    {
        private string classdetail;
        private bool ismale1;
        private int studentIddetail;
        private string firstnamedetail;
        private string lastnamedetail;
        private string emaildetail;
        private string genderdetail;
        private StudentDetailViewModel studentStudentDetailViewModel;

        public int StudentIddetail
        {
            get => StudentIddetail; set
            {
                StudentIddetail = value;
                OnPropertyChanged(nameof(StudentIddetail));

            }
        }
        public string Firstnamedetail
        {
            get => firstnamedetail; set
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
            get => ismale1; set
            {
                ismale1 = value;
                OnPropertyChanged(nameof(Ismale));

            }
        }
        public Boolean IsFemale
        {
            get => !ismale1; set
            {
                ismale1 = !value;
                OnPropertyChanged(nameof(IsFemale));

            }
        }
        public StudentDetailViewModel(IStudentService m_studentSrv, Student student)
        {
            StudentIddetail = student.studentId;
            Firstnamedetail = student.firstname;
            Lastnamedetail = student.lastname;
            Emaildetail = student.email;
            Genderdetail = student.gender;
            Classdetail = student.Class;
            Ismale = (Genderdetail == "Male");
        }
      
    }
}