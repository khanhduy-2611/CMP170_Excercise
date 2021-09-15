using System;

namespace Excercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input A = ");
                float a = float.Parse(Console.ReadLine());
                Console.Write("Input B = ");
                float b = float.Parse(Console.ReadLine());
                Console.Write("Summation = ");
                Console.WriteLine(a + b);
                Console.Write("Subtraction = ");
                Console.WriteLine(a - b);
                Console.Write("Multiplication = ");
                Console.WriteLine(a * b);
                Console.Write("Division = ");
                Console.WriteLine(a / b);
        }
    }
}