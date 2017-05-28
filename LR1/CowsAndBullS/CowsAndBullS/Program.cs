using static System.Console;

namespace CowsAndBullS
{
    class Program
    {
        static void Main(string[] args)
        {
            string ContinueGame;
            do
            {
                Clear();
                GameFunctions StartGame = new GameFunctions();
                StartGame.GenerateNumber();
                WriteLine("Welcome to game Bulls and Cows!\nYou should guess 4-digit number. Digits can\'t repeat.\nWrite number:");
                while(StartGame.TheNumber!=StartGame.UserAnswer)
                {
                    StartGame.AcceptAnswer();
                    StartGame.PrintScore();
                }
                WriteLine("\nRight answer is {0}\nCongratulate! You won!\nIf you want to play again input \'y\'", StartGame.TheNumber);
                ContinueGame = ReadLine();
            }
            while (ContinueGame == "y");  
        }
    }
}
