using static System.Console;

namespace TaskRationalNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumeratorA;
            int NumeratorB;
            int DenominatorA;
            int DenominatorB;

            WriteLine("Input numerator of a: ");
            NumeratorA = RationalNumber.CheckInput(ReadLine());
            WriteLine("Input denominator of a: ");
            DenominatorA = RationalNumber.CheckInput(ReadLine());
            WriteLine("Input numerator of b: ");
            NumeratorB = RationalNumber.CheckInput(ReadLine());
            WriteLine("Input denominator of b: ");
            DenominatorB = RationalNumber.CheckInput(ReadLine());

            RationalNumber a = new RationalNumber(NumeratorA, DenominatorA);
            RationalNumber b = new RationalNumber(NumeratorB, DenominatorB);
            RationalNumber c = new RationalNumber();

            WriteLine("A = " + a);
            WriteLine("B = " + b);
            WriteLine("A * B = " + (c = a * b));
            WriteLine("A / B = " + (c = a / b));

            double x = (double)c;
            WriteLine("C in doudle " + x);
            if (a == b)
                WriteLine("a = b");
            else
                WriteLine("a != b");

            WriteLine("Input fraction: ");
            string fraction = ReadLine();
            WriteLine(RationalNumber.Parse(fraction));

            ReadKey();
        }
    }
}
