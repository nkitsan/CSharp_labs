using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithUnmanagedCode
{
    class Checker
    {
        public static int CheckOfInt(string ToCheck)
        {
            int result;
            while (!int.TryParse(ToCheck, out result))
            {
                Console.WriteLine("Incorrect input! Try again");
                ToCheck = Console.ReadLine();
            }
            return result;
        }
    }
}
