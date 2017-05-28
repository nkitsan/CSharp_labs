using System;
using static System.Console;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("How much students profile you want to input?");
            string check = ReadLine();
            int n;

            while (!int.TryParse(check, out n))
            {
                WriteLine("Incorrect input of n! Try again: ");
                check = ReadLine();
            }
            
            IInputClass<Student> ElementOfInterfaice = new Student();
            Student[] students = new Student[n];
            ElementOfInterfaice.InputArray(students, n);
            Array.Sort(students, new Student());

            foreach (Student student in students)
            {
                student.Info();
            }
            ReadKey();
        }

    }
}
