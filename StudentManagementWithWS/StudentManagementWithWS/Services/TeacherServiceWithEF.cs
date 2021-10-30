using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManagementWithWS;
using StudentManagementWithWS.Models;
using StudentManagementWithWS.Services;

namespace teacherManagementWithWS.Services
{
    public class teacherServiceWithEF : ITeacherService
    {
        public teacherServiceWithEF()
        {
            using (var ctx = new UniversityContext())
            {
                ctx.Database.EnsureCreated();
            }
        }

       
        public void DeleteTeacherById(int id)
        {
            using (var ctx = new UniversityContext())
            {
                var deletedteacher = ctx.Teachers.Find(id);
                ctx.Teachers.Remove(deletedteacher);
                ctx.SaveChanges();
            }
        }

      

        public Teacher LoadTeacherById(long id)
        {
            using (var ctx = new UniversityContext())
            {
                return ctx.Teachers.FirstOrDefault(s => s.TeacherID == id);
            }
        }

        public IList<Teacher> SearchTeacher(string keyword, string hutechClass)
        {
            using (var ctx = new UniversityContext())
            {
                var result = ctx.Teachers.Where(s => (s.Class == hutechClass || string.IsNullOrEmpty(hutechClass)) && (s.firstname == keyword || s.lastname == keyword || string.IsNullOrEmpty(keyword)))
                                .OrderBy(s => s.TeacherID).ToList();
                return result.ToList();
            }
        }

        public void UpdateOrCreateTeacher(Teacher teacher)
        {
            using (var ctx = new UniversityContext())
            {
                if (teacher.TeacherID > 0)
                {
                    var dbteacher = ctx.Teachers.Find(teacher.TeacherID);
                    dbteacher.firstname = teacher.firstname;
                    dbteacher.lastname = teacher.lastname;
                    dbteacher.gender = teacher.gender;
                    dbteacher.email = teacher.email;
                    dbteacher.Class = teacher.Class;
                }
                else
                {
                    ctx.Teachers.Add(teacher);
                }
                ctx.SaveChanges();
            }
        }
    }
}
