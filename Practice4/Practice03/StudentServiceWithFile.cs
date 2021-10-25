using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static Practice03.SearchStudentViewModel;

namespace Practice03
{
    class StudentServiceWithFile : IStudentService
    {
        private IList<Student> m_students;

        public StudentServiceWithFile()
        {
            var data = File.ReadAllText("Student_Data.json");
            m_students = JsonSerializer.Deserialize<List<Student>>(data);
           
        }

        public void DeleteStudentById(int id)
        {
            var deletedStudent = LoadStudentById(id);
            if (deletedStudent != null)
            {
                m_students.Remove(deletedStudent);
            }
        }

        public Student LoadStudentById(long id)
        {

            return m_students.FirstOrDefault(x => x.studentId == id);
        }


        //private IList<Student> m_SearchStudent;
        public IList<Student> SearchStudent(string keyword, string hutechClass)
        {

            var result = m_students.Where(s => (s.Class == hutechClass || hutechClass == null) && (s.firstname == keyword || s.lastname == keyword || keyword == null))
                               .OrderBy(s => s.firstname).ToList();
            foreach (var s in result)
            {
                Console.WriteLine(s);
            }
            //return m_students;
            return result;
            //return m_SearchStudent;
        }

        public void UpdateOrCreateStudent(Student student)
        {
            //using (var UC = new UniversityContext())
            {
                if (student.studentId > 0)
                {
                    var upStudent = LoadStudentById(student.studentId);
                    upStudent.lastname = student.lastname;
                    upStudent.firstname = student.firstname;
                    upStudent.gender = student.gender;
                    upStudent.Class = student.Class;
                    upStudent.email = student.email;
                    upStudent.gpa = student.gpa;

                    //var dbStudent = UC.Students.Find(student.studentId);
                    //dbStudent.lastname = student.lastname;
                    //dbStudent.firstname = student.firstname;
                    //dbStudent.gender = student.gender;
                    //dbStudent.Class = student.Class;
                    //dbStudent.email = student.email;
                    //dbStudent.gpa = student.gpa;

                }
                else
                {
                    var newStudentId = m_students.Select(s => s.studentId).OrderByDescending(s => s).FirstOrDefault();
                    student.studentId = newStudentId + 1;
                    m_students.Add(student);
                  //  UC.Students.Add(student);
                }
               // UC.SaveChanges();
            }
        }
    }
}
