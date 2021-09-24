using System;
using System.IO;

namespace ReadTextFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input Something to file: ");
            string userName = Console.ReadLine();

            string[] lines = { userName };
            File.WriteAllLines(@"C:\Users\ACER\Downloads\texttoppic5\toppic5.txt", lines);
            foreach (string line in lines)
            {
                Console.WriteLine("\t" + line);
            }
            Console.WriteLine("the contents of the file: ");
            string[] readText = File.ReadAllLines(@"C:\Users\ACER\Downloads\texttoppic5\toppic5.txt");
            foreach (string s in readText)
            {
                Console.WriteLine("\t" + s);
            }
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
