using System;
using System.Collections.Generic;
using static System.Console;

namespace ConsoleApplication1
{
    public class BSUIRStudent : Student, IComparer<BSUIRStudent>, IInputClass<BSUIRStudent>
    {
        public struct CTExams
        {
            public int Physics;
            public int Math;
            public int Language;
            public int FullScore;

            public void CountFullScore()
            {
                FullScore = Physics + Math + Language;
            }
        }

        public CTExams ExamPoints;

        public BSUIRStudent(string FirstName, string LastName, string City, string BirthDate, string Score, int Physics, int Math, int Language)
            : base(FirstName, LastName, City, BirthDate, Score)
        {
            ExamPoints.Physics = Physics;
            ExamPoints.Math = Math;
            ExamPoints.Language = Language;
            ExamPoints.CountFullScore();
        }

        public BSUIRStudent()
        { }

        override protected void CountScholarship()
        {
            if (ExamPoints.FullScore > 250)
                base.CountScholarship();
            else Scholarship = 0;
        }

        void IInputClass<BSUIRStudent>.InputArray(BSUIRStudent[] bsuirstudent, int n)
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
                string check = ReadLine();
                int physic;
                while (!int.TryParse(check, out physic) || (physic > 100) || (physic < 0))
                {
                    WriteLine("Incorrect input of score! Try again: ");
                    check = ReadLine();
                }
                check = ReadLine();
                int math;
                while (!int.TryParse(check, out math) || (math > 100) || (math < 0))
                {
                    WriteLine("Incorrect input of score! Try again: ");
                    check = ReadLine();
                }
                check = ReadLine();
                int language;
                while (!int.TryParse(check, out language) || (language > 100) || (language < 0))
                {
                    WriteLine("Incorrect input of score! Try again: ");
                    check = ReadLine();
                }
                bsuirstudent[i] = new BSUIRStudent(name, secondname, city, birthDate, score, physic, math, language);
                Clear();
            }      
        }

        public int Compare(BSUIRStudent firstStudent, BSUIRStudent secondStudent)
        {
            if (firstStudent.ExamPoints.FullScore > secondStudent.ExamPoints.FullScore)
                return 1;
            else if (firstStudent.ExamPoints.FullScore < secondStudent.ExamPoints.FullScore)
                return -1;
            else
                return 0;
        }
    }

}
 
