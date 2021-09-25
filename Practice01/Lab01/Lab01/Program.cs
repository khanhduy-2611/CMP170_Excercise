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
        private float averageScore;
        private string faculty;

        public string StudentID { get; set; }
        public string Fullname { get; set; }
        public float AverageScore { get; set; }
        public string Faculty { get; set; }

        public Student()
        {

        }
        public Student(string id, string name, float Score, string faculty)
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
            AverageScore = float.Parse(Console.ReadLine());
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

            //Console.Write("Nhập tổng số sinh viên N = ");
            //int N = Convert.ToInt32(Console.ReadLine());
            //Student[] arrStudents = new Student[N];
            //Console.WriteLine("\n ====Nhập Danh Sách sinh viên====");
            //for (int i = 0; i < N; i++)
            //{
               //Console.WriteLine("\n - Nhập sinh viên thứ {0}", i + 1);
               //arrStudents[i] = new Student();
                //arrStudents[i].Input();
            //}
            //Console.WriteLine("\n ====Xuất Danh Sách sinh viên====");
            //foreach (Student sv in arrStudents)
            //{
                //sv.Show();
            //}
            //Console.ReadKey();

            List<Student> cnttstudents = new List<Student>();
            cnttstudents.Add(new Student("SV01", "Nguyen Van A", 7, "CNTT"));
            cnttstudents.Add(new Student("SV02", "Nguyen Van B", 8, "QTKS"));
            cnttstudents.Add(new Student("SV03", "Nguyen Van C", 9, "CNTT"));
            cnttstudents.Add(new Student("SV04", "Nguyen Van D", 10, "CNTT"));
            cnttstudents.Add(new Student("SV05", "Nguyen Van E", 6, "DUOC"));
            cnttstudents.Add(new Student("SV06", "Nguyen Van F", 8, "LAW"));
            cnttstudents.Add(new Student("SV07", "Nguyen Van G", 7, "NHKST"));
            cnttstudents.Add(new Student("SV08", "Nguyen Van H", 9, "CNTT"));

            var cnttStudents = cnttstudents.FindAll(x => x.Faculty == "CNTT");
            var tbScore = cnttstudents.FindAll(x => x.AverageScore >= 5);
            var cau3 = cnttstudents.OrderBy(x => x.AverageScore).ToList();
            Console.WriteLine("------1.1------");
            foreach (var item in cnttStudents)
            {
                Console.WriteLine(item.StudentID +" "+ item.Faculty);
            }
            Console.WriteLine("------1.2------");
            foreach(var item in tbScore)
            {
                Console.WriteLine(item.StudentID + " " + item.AverageScore);
            }
            Console.WriteLine("------1.3------");
            foreach (var item in cau3)
            {
                Console.WriteLine(item.studentID + " " + item.AverageScore);
            }
            Console.WriteLine("------1.4------");
            foreach(var item in tbScore)
            {
                if (item.Faculty == "CNTT")
                    Console.WriteLine(item.studentID + " " + item.AverageScore + " " + item.Faculty);
            }
            var findmax = cnttstudents.Max(x => x.AverageScore);
            var cau5 = cnttstudents.FindAll(x => x.AverageScore == findmax && x.Faculty == "CNTT");
            Console.WriteLine("------1.5------");
            foreach(var item in cau5)
            {
                Console.WriteLine(item.studentID + " " + item.AverageScore + " " + item.Faculty);
            }    
        }
    }
}
