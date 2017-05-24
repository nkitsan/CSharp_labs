using System;
using System.Linq;
using static System.Console;

namespace CowsAndBullS
{
    class GameFunctions
    {
        public int TheNumber, UserAnswer = 0;
        int cows, bulls;
        int[] NumeralsOfTheNumber = new int[4];
        int[] NumeralsOfUserAnswer = new int[4];
        int round = 1;

        ~GameFunctions()
        { }

        public void GenerateNumber()
        {
            do
            {
                Random generate = new Random();
                TheNumber = generate.Next(1000, 10000);
                NumeralsOfTheNumber[0] = TheNumber / 1000;
                NumeralsOfTheNumber[1] = TheNumber / 100 - NumeralsOfTheNumber[0] * 10;
                NumeralsOfTheNumber[3] = TheNumber % 10;
                NumeralsOfTheNumber[2] = (TheNumber % 100 - NumeralsOfTheNumber[3]) / 10;
            }
            while (NumeralsOfTheNumber.Distinct().Count() != NumeralsOfTheNumber.Count());
        }

        void CheckAnswer()
        {
            string answer = ReadLine();
            if (!int.TryParse(answer, out UserAnswer))
            {
                WriteLine("Unacceptable symbols! Input again:");
                CheckAnswer();
            }
            if (UserAnswer>9999 || UserAnswer<1000)
            {
                WriteLine("More or less then 4 digits! Input again:");
                CheckAnswer();
            }
        }

        public void AcceptAnswer()
        {
            int flag = 0;
            do
            {
                if (flag>0)
                    WriteLine("Remember, that digits must not repeat:");
                CheckAnswer();
                NumeralsOfUserAnswer[0] = UserAnswer / 1000;
                NumeralsOfUserAnswer[1] = UserAnswer / 100 - NumeralsOfUserAnswer[0] * 10;
                NumeralsOfUserAnswer[3] = UserAnswer % 10;
                NumeralsOfUserAnswer[2] = (UserAnswer % 100 - NumeralsOfUserAnswer[3]) / 10;
                flag++;
            }
            while (NumeralsOfUserAnswer.Distinct().Count() != NumeralsOfUserAnswer.Count());
        }

        public void PrintScore()
        {
            if (TheNumber == UserAnswer)
               return;

            bulls = NumeralsOfTheNumber.Where((numeral, index) => NumeralsOfUserAnswer[index] == numeral).Count();
            cows = NumeralsOfTheNumber.Intersect(NumeralsOfUserAnswer).Count() - bulls;

            WriteLine(round + ". " + UserAnswer + "; " + bulls + " - bulls; " + cows + " - cows");
            round++;
        }
    }
}
