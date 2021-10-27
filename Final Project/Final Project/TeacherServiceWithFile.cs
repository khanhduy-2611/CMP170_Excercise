using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Final_Project.SearchTeacherViewModel;

namespace Final_Project
{
     class TeacherServiceWithFile : ITeacherService
    {
        private IList<Teacher> m_teacher;

        public void DeleteTeacherById(int id)
        {
            var deletedTeacher = LoadTeacherById(id);
            if (deletedTeacher != null)
            {
                m_teacher.Remove(deletedTeacher);
            }
        }

        public Teacher LoadTeacherById(long id)
        {
            return m_teacher.FirstOrDefault(x => x.TeacherID == id);
        }

        public IList<Teacher> SearchTeacher(string keyword, string hutechClass)
        {
            var result = m_teacher.Where(s => (s.Class == hutechClass || hutechClass == null) && (s.firstname == keyword || s.lastname == keyword || keyword == null))
                               .OrderBy(s => s.firstname).ToList();
            foreach (var s in result)
            {
                Console.WriteLine(s);
            }
            return result;
        }

        public void UpdateOrCreateTeacher(Teacher teacher)
        {
            if(teacher.TeacherID > 0)
            {
                var dbTeacher = LoadTeacherById(teacher.TeacherID);
                dbTeacher.lastname = teacher.lastname;
                dbTeacher.firstname = teacher.firstname;
                dbTeacher.gender = teacher.gender;
                dbTeacher.Class = teacher.Class;
                dbTeacher.email = teacher.email;              
            }
            else
            {
                var newTeacherID = m_teacher.Select(s => s.TeacherID).OrderByDescending(s => s).FirstOrDefault();
                teacher.TeacherID = newTeacherID + 1;
                m_teacher.Add(teacher);
            }
        }
       
       
    }
}
