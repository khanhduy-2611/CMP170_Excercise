using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab01
{
    class Student
    {

        private string studentID;
        private string fullname;
        private string averageScore;
        private string faculty;

        public string StudentID { get; set; }
        public string Fullname { get; set; }
        public string AverageScore { get; set; }
        public string Faculty { get; set; }

    
        public Student()
        {

        }
        public Student(string id, string name, string Score, string faculty)
        {
            StudentID = id;
            Fullname = name;
            AverageScore = Score;
            Faculty = faculty;
        }
        public void Input()
        {
            Console.Write("Input MSSV:");
            StudentID = Console.ReadLine();
            Console.Write("Input AverageScore:");
            float v = float.Parse(Console.ReadLine());
            Console.Write("Input Fullname:");
            Fullname = Console.ReadLine();

            Console.Write("Input faculty:");
            Faculty = Console.ReadLine();

        }
        public void Show()
        {
            Console.WriteLine("MSSV:{0} Fullname:{1} Faculty:{2} AverageScore:{3}", this.StudentID, this.Fullname, this.Faculty, this.AverageScore);
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.Write("Nhập tổng số sinh viên N = ");
            int N = Convert.ToInt32(Console.ReadLine());
            Student[] arrStudents = new Student[N];
            Console.WriteLine("\n ====Nhập Danh Sách sinh viên====");
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("\n - Nhập sinh viên thứ {0}", i + 1);
                arrStudents[i] = new Student();
                arrStudents[i].Input();
            }
            Console.WriteLine("\n ====Xuất Danh Sách sinh viên====");
            foreach (Student sv in arrStudents)
            {
                sv.Show();
            }
            Console.ReadKey();
        }
    }
}
