using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementWithWS.Services
{
    public interface ITeacherService
    {
        IList<Teacher> SearchTeacher(string keyword, string hutechClass);
        Teacher LoadTeacherById(long id);
        void UpdateOrCreateTeacher(Teacher teacher);
        void DeleteTeacherById(int id);
    }
}
