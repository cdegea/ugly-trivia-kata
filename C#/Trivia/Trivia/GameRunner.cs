using System;

namespace Trivia
{
    public class GameRunner
    {
        private static bool notAWinnerYet;

        public static void Main(string[] args)
        {
            var aGame = new Game();

            aGame.Add("Chet");
            aGame.Add("Pat");
            aGame.Add("Sue");

            var rand = new Random();

            do
            {
                aGame.Roll(rand.Next(5) + 1);

                if (rand.Next(9) == 7)
                    notAWinnerYet = aGame.WrongAnswer();
                else
                    notAWinnerYet = aGame.WasCorrectlyAnswered();
            } while (notAWinnerYet);
        }
    }
}