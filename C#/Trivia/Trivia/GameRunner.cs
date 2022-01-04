using System;

namespace Trivia
{
    public class GameRunner
    {
        private static bool notAWinnerYet;

        public static void Main(string[] args)
        {
            var game = new Game();

            game.Add("Chet");
            game.Add("Pat");
            game.Add("Sue");

            var rand = new Random();

            do
            {
                game.Roll(rand.Next(5) + 1);

                if (rand.Next(9) == 7)
                    notAWinnerYet = game.WrongAnswer();
                else
                    notAWinnerYet = game.WasCorrectlyAnswered();
            } while (notAWinnerYet);
        }
    }
}