using System;
using static System.Console;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace TaskRationalNumbers
{
    class RationalNumber : IComparer<RationalNumber>
    {
        private int Numerator;
        private int Denominator;

        public RationalNumber() : this(0, 1)
        { }

        public RationalNumber(int numerator, int denominator) 
        {
            Numerator = numerator;
            while (denominator <= 0)
            {
                WriteLine("Denominator must be greater then 0. Try again");
                denominator = CheckInput(ReadLine());
            }
            Denominator = denominator;
            Reduce();
        }

        void Reduce()
        {
            int GCD = GreatestCommonDivisor(Numerator, Denominator);
            Numerator /= GCD;
            Denominator /= GCD; 
        }

        public override string ToString()
        {
            if (Numerator % Denominator == 0)
                return (string.Format("{0}", Numerator/Denominator));
            else if (Numerator/Denominator != 0)
                return (string.Format("{0}({1}/{2})", Numerator/Denominator, Math.Abs(Numerator)%Denominator, Denominator));
            else if (GreatestCommonDivisor(Numerator, Denominator) != 1)
                return (string.Format("{0}/{1}", Numerator/GreatestCommonDivisor(Numerator, Denominator), Denominator / GreatestCommonDivisor(Numerator, Denominator)));
            else
                return (string.Format("{0}/{1}", Numerator, Denominator));
        }

        public static RationalNumber operator +(RationalNumber a, RationalNumber b)
        {
            int GCD = GreatestCommonDivisor(a.Denominator, b.Denominator);
            int denominator = a.Denominator * b.Denominator / GCD;
            int numerator = (a.Numerator * b.Denominator  + b.Numerator * a.Denominator) / GCD; 
            return new RationalNumber(numerator, denominator);
        }

        public static RationalNumber operator -(RationalNumber a, RationalNumber b) => a + (RationalNumber)(-1)*b;

        public static RationalNumber operator *(RationalNumber a, RationalNumber b)
        {
            RationalNumber c = new RationalNumber(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
            c.Reduce();      
            return c;
        }

        public static RationalNumber operator /(RationalNumber a, RationalNumber b)
        {
            RationalNumber c = new RationalNumber(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
            c.Reduce();
            return c;
        }

        public static bool operator >(RationalNumber a, RationalNumber b)
        {
            int GCD = GreatestCommonDivisor(a.Denominator, b.Denominator);
            int numerator_a = a.Numerator * b.Denominator / GCD;
            int numerator_b = b.Numerator * a.Denominator / GCD;
            if (numerator_a > numerator_b)
                return true;
            else return false;
        }

        public static bool operator <(RationalNumber a, RationalNumber b) => b > a;

        public static bool operator >=(RationalNumber a, RationalNumber b)
        {
            int GCD = GreatestCommonDivisor(a.Denominator, b.Denominator);
            int numerator_a = a.Numerator * b.Denominator / GCD;
            int numerator_b = b.Numerator * a.Denominator / GCD;
            if (numerator_a >= numerator_b)
                return true;
            else return false;
        }

        public static bool operator <=(RationalNumber a, RationalNumber b) => b >= a;

        public static bool operator ==(RationalNumber a, RationalNumber b)
        {
            int GCD = GreatestCommonDivisor(a.Denominator, b.Denominator);
            int numerator_a = a.Numerator * b.Denominator / GCD;
            int numerator_b = b.Numerator * a.Denominator / GCD;
            if (numerator_a == numerator_b)
                return true;
            else return false;
        }

        public static bool operator !=(RationalNumber a, RationalNumber b) => !(a == b);

        public static explicit operator double(RationalNumber a) => (double)a.Numerator/a.Denominator;

        public static explicit operator int(RationalNumber a) => a.Numerator/a.Denominator;

        public static explicit operator RationalNumber(int number) => new RationalNumber(number, 1);

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            return true;
        }

        public int Compare(RationalNumber a, RationalNumber b)
        {
            int GCD = GreatestCommonDivisor(a.Denominator, b.Denominator);
            int numerator_a = a.Numerator * b.Denominator / GCD;
            int numerator_b = b.Numerator * a.Denominator / GCD;

            if (numerator_a > numerator_b)
                return -1;
            else if (numerator_a < numerator_b)
                return 1;
            else
                return 0;
        }

        public static RationalNumber Parse(string input)
        {
            if (!Regex.IsMatch(input, "^-?[0-9]+(/)?[0-9]+$"))
            {
                return new RationalNumber();
            }
            var numeratorAndDenumerator = input.Split('/');
            var numerator = int.Parse(numeratorAndDenumerator[0]);
            var denumerator = int.Parse(numeratorAndDenumerator[1]);
            return new RationalNumber(numerator, denumerator);
        }

        public static bool TryParse(string input, RationalNumber c)
        {
            if ((c.Numerator == 0) && (input[0] != '0'))
                return false;
            else return true;
        }

        public static int GreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                a %= b;
                int temp = b;
                b = a;
                a = temp;
            }
            return Math.Abs(a);
        }

        public static int CheckInput(string input)
        {
            int check;
            while (!int.TryParse(input, out check))
            {
                WriteLine("Incorrect input of number! Try again: ");
                input = ReadLine();
            }
            return check;
        }
    }
}
