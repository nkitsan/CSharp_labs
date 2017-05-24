using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithUnmanagedCode
{
    class Program
    {
        [DllImport("C:\\CSharp\\LR4\\DinamicLibrary\\Debug\\SomeFunctions.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int BinPow(int BaseOfPower, int power);

        [DllImport("C:\\CSharp\\LR4\\DinamicLibrary\\Debug\\SomeFunctions.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GreatestCommonDivisor(int FirstNumber, int SecondNumber);

        static void Main(string[] args)
        {
            Console.WriteLine("Input number, which you want to involute");
            string check = Console.ReadLine();
            int Base = Checker.CheckOfInt(check);
            Console.WriteLine("Input power, in which you want to involute");
            check = Console.ReadLine();
            int Power = Checker.CheckOfInt(check);
            int answer = BinPow(Base, Power);
            Console.WriteLine("{0} in {1} power is {2}", Base, Power, answer);

            Console.WriteLine("\nInput first number to count greatest common divisor");
            check = Console.ReadLine();
            int FirstNumber = Checker.CheckOfInt(check);
            Console.WriteLine("Input second number to count greatest common divisor");
            check = Console.ReadLine();
            int SecondNumber = Checker.CheckOfInt(check);
            answer = GreatestCommonDivisor(FirstNumber, SecondNumber);
            Console.WriteLine("Greatest common divisor of {0} and {1} is {2}", FirstNumber, SecondNumber, answer);

            Console.ReadKey();
        }
    }
}
