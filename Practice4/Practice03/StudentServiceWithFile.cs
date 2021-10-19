using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practice03.SearchStudentViewModel;
using System.Text.Json;

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

        IList<Student> IStudentService.SearchStudent(string keyword, string hutechClass)
        {
            var result = m_students.Where(s => s.Class == hutechClass && (s.firstname == keyword || s.lastname == keyword))
                               .OrderBy(s => s.firstname)
                               .Select(s => s.firstname + " " + s.lastname + " - " + s.studentId);

            foreach (var s in result)
            {
                Console.WriteLine(s);
            }
            return m_students;
        }

        public void UpdateOrCreateStudent(Student student)
        {
            if (student.studentId > 0)
            {
                var updatedStudent = LoadStudentById(student.studentId);
                updatedStudent.lastname = student.lastname;
                updatedStudent.firstname = student.firstname;
                updatedStudent.gender = student.gender;
                updatedStudent.Class = student.Class;
                updatedStudent.email = student.email;
            }
            else
            {
                var newStudentId = m_students.Select(s => s.studentId).OrderByDescending(s => s).FirstOrDefault();
                student.studentId = newStudentId + 1;
                m_students.Add(student);
            }
        }

        public object SearchStudent(object searchKeyword, string selectedClass)
        {
            throw new NotImplementedException();
        }
    }
}
