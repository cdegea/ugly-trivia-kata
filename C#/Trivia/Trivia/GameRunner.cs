using System;

namespace Trivia
{
    public class GameRunner
    {
        private static bool notAWinner;

        public static void Main(string[] args)
        {
            Run(Convert.ToInt32(args[0]));
        }

        private static void Run(int seed)
        {
            var game = new Game();

            game.AddPlayer("Chet");
            game.AddPlayer("Pat");
            game.AddPlayer("Sue");

            var rand = new Random(seed);

            do
            {
                game.Roll(rand.Next(5) + 1);

                if (rand.Next(9) == 7)
                {
                    notAWinner = game.WrongAnswer();
                }
                else
                {
                    notAWinner = game.WasCorrectlyAnswered();
                }
            } while (notAWinner);
        }
    }
}