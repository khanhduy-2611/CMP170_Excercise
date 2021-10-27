using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public class TeacherServiceWithEF : ITeacherService
    {
        public TeacherServiceWithEF()
        {
            using (var ctx = new TeacherContext())
            {
                ctx.Database.EnsureCreated();
            }
        }

        public void DeleteTeacherById(int id)
        {
            using (var ctx = new TeacherContext())
            {
                var deletedTeacher = ctx.Teachers.Find(id);
                ctx.Teachers.Remove(deletedTeacher);
                ctx.SaveChanges();
            }
        }

        public SearchTeacherViewModel.Teacher LoadTeacherById(long id)
        {
            using (var ctx = new TeacherContext())
            {
                return ctx.Teachers.Find(id);
            }
        }

        public IList<SearchTeacherViewModel.Teacher> SearchTeacher(string keyword, string hutechClass)
        {
            using (var ctx = new TeacherContext())
            {
                var result = ctx.Teachers.Where(s => (s.Class == hutechClass || string.IsNullOrEmpty(hutechClass)) && (s.firstname == keyword || string.IsNullOrEmpty(keyword)))
                                    .OrderBy(s => s.TeacherID).ToList();

                return result;
            }
        }

        public void UpdateOrCreateTeacher(SearchTeacherViewModel.Teacher teacher)
        {
            using (var ctx = new TeacherContext())
            {
                if (teacher.TeacherID > 0)
                {
                    var dbTeacher = ctx.Teachers.Find(teacher.TeacherID);
                    dbTeacher.firstname = teacher.firstname;
                    dbTeacher.lastname = teacher.lastname;
                    dbTeacher.email = teacher.email;
                    dbTeacher.gender = teacher.gender;
                    dbTeacher.Class = teacher.Class;                   
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
