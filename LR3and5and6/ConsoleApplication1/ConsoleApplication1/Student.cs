using System;
using System.Collections.Generic;
using static System.Console;

namespace ConsoleApplication1
{
    public class Student : PeopleClass, IInputClass<Student>, IComparer<Student>
    {
        protected int[] ExamsScore;
        public double AverageScore;
        protected double Scholarship;

        public Student(string FirstName, string LastName, string City, string BirthDate, string score = "0")
            : base(FirstName, LastName, City, BirthDate)
        {
            InitExamsScore(score);
            CountAverageScore();
            CountScholarship();
        }

        public Student()
        { }

        protected void InitExamsScore(string score)
        {
            var exams = score.Split();
            ExamsScore = new int[exams.Length];
            int i = 0;
            foreach (var mark in exams)
            {
                ExamsScore[i] = Convert.ToInt32(mark);
                i++;
            }
        }

        protected void CountAverageScore()
        {
            int rank = 0;
            foreach (var mark in ExamsScore)
            {
                AverageScore += mark;
                rank++;
            }
            AverageScore /= rank;
        }

        virtual protected void CountScholarship()
        {
            if (AverageScore >= 5)
                Scholarship = 58.86;
            else Scholarship = 0;

            if (AverageScore >= 6 && AverageScore < 8)
                Scholarship *= 1.2;
            else if (AverageScore >= 8 && AverageScore < 9)
                Scholarship *= 1.4;
            else if (AverageScore >= 9)
                Scholarship *= 1.6;
        }

        public override void Info()
        {
            base.Info();
            WriteLine("In this term scholarship is " + Scholarship);
        }

        void IInputClass<Student>.InputArray(Student[] student, int n)
        {
            for (int i = 0; i < n; i++)
            {
                WriteLine("Input name");
                string name = ReadLine();
                WriteLine("Input lastname");
                string secondname = ReadLine();
                WriteLine("Input city");
                string city = ReadLine();
                WriteLine("Input birth date");
                string birthDate = ReadLine();
                DateTime checker = new DateTime();
                while (!DateTime.TryParse(birthDate, out checker))
                {
                    WriteLine("Incorrect input of Birth Date! Try again: ");
                    birthDate = ReadLine();
                }
                WriteLine("Input exams score from previouse semester");
                string score = ReadLine();
                student[i] = new Student(name, secondname, city, birthDate, score);
                Clear();
            }
        }

        public int Compare(Student firstStudent, Student secondStudent)
        {
            if (firstStudent.AverageScore > secondStudent.AverageScore)
                return -1;
            else if (firstStudent.AverageScore < secondStudent.AverageScore)
                return 1;
            else
                return 0;
        }
    }
}
