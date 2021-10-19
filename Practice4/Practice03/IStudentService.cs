using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practice03.SearchStudentViewModel;

namespace Practice03
{
    interface IStudentService
    {
        IList<Student> SearchStudent(String keyword, string hutechClass);

        Student LoadStudentById(long id);

        void UpdateOrCreateStudent(Student student);

        void DeleteStudentById(int id);
        object SearchStudent(object searchKeyword, string selectedClass);
    }
}
