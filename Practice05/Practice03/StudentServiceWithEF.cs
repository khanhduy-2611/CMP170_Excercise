﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practice03.SearchStudentViewModel;

namespace Practice03
{
    public class StudentServiceWithEF : IStudentService
    {
        public StudentServiceWithEF()
        {
            using (var ctx = new UniversityContext())
            {
                ctx.Database.EnsureCreated();
            }
        }

        public void DeleteStudentById(int id)
        {
            using (var ctx = new UniversityContext())
            {
                var deletedStudent = ctx.Students.Find(id);
                ctx.Students.Remove(deletedStudent);
                ctx.SaveChanges();
            }
        }

        public Student LoadStudentById(long id)
        {
            using (var ctx = new UniversityContext())
            {
                return ctx.Students.Find(id);
            }
        }

        public IList<Student> SearchStudent(string keyword, string hutechclass)
        {
            using (var ctx = new UniversityContext())
            {
                var result = ctx.Students.Where(s => (s.Class == hutechclass || String.IsNullOrEmpty(hutechclass)) && (s.firstname == keyword || s.lastname == keyword || string.IsNullOrEmpty(keyword)))
                              .OrderBy(s => s.firstname).ToList();

                return result;
            }
        }

        public void UpdateOrCreateStudent(Student student)
        {
            using (var ctx = new UniversityContext())
            {
                if (student.studentId > 0)
                {
                    var dbStudent = ctx.Students.Find(student.studentId);
                    dbStudent.firstname = student.firstname;
                    dbStudent.lastname = student.lastname;
                    dbStudent.email = student.email;
                    dbStudent.gender = student.gender;
                    dbStudent.Class = student.Class;
                    dbStudent.gpa = student.gpa;
                }
                else
                {
                    ctx.Students.Add(student);
                }
                ctx.SaveChanges();
            }
        }

        Student IStudentService.LoadStudentById(long id)
        {
            throw new NotImplementedException();
        }

        IList<Student> IStudentService.SearchStudent(string keyword, string hutechClass)
        {
            throw new NotImplementedException();
        }
    }
}
