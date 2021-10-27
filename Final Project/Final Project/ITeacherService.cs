using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Final_Project.SearchTeacherViewModel;

namespace Final_Project
{
    public interface ITeacherService
    {  

        IList<Teacher> SearchTeacher(string keyword, string hutechClass);
        Teacher LoadTeacherById(long id);
        void UpdateOrCreateTeacher(Teacher teacher);
        void DeleteTeacherById(int id);
    }
}

