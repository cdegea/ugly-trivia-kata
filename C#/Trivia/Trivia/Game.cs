using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        private List<Player> players = new List<Player>();
        private Player currentPlayer;
        private bool isGettingOutOfPenaltyBox;
        private readonly QuestionCollection questionCollection;

        public Game()
        {
            questionCollection = new QuestionCollection();
        }

        public bool Add(string playerName)
        {
            players.Add(new Player(playerName));

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + players.Count);
            return true;
        }

        public void Roll(int roll)
        {
            Console.WriteLine(currentPlayer + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (currentPlayer.inPenaltyBox)
            {
                isGettingOutOfPenaltyBox = roll % 2 != 0;
                if (isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine(currentPlayer + " is getting out of the penalty box");
                }
                else
                {
                    Console.WriteLine(currentPlayer + " is not getting out of the penalty box");
                    return;
                }
            }

            MoveToNextPlace(roll);

            Console.WriteLine(currentPlayer
                              + "'s new location is "
                              + currentPlayer.place);
            Console.WriteLine("The category is " + CurrentCategory());
            questionCollection.GetNextQuestion(CurrentCategory());
        }

        private void MoveToNextPlace(int roll)
        {
            places[currentPlayer] += roll;
            if (places[currentPlayer] > 11)
                places[currentPlayer] -= 12;
        }

        private string CurrentCategory()
        {
            switch (places[currentPlayer])
            {
                case 0:
                case 4:
                case 8:
                    return "Pop";
                case 1:
                case 5:
                case 9:
                    return "Science";
                case 2:
                case 6:
                case 10:
                    return "Sports";
                default:
                    return "Rock";
            }
        }

        public bool WasCorrectlyAnswered()
        {
            if (inPenaltyBox[currentPlayer] && !isGettingOutOfPenaltyBox)
            {
                SetNextCurrentPlayer();
                return true;
            }

            Console.WriteLine("Answer was correct!!!!");
            points[currentPlayer]++;
            Console.WriteLine(players[currentPlayer]
                              + " now has "
                              + points[currentPlayer]
                              + " Gold Coins.");

            var notWinner = points[currentPlayer] != 6;
            SetNextCurrentPlayer();
            return notWinner;
        }
        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(players[currentPlayer] + " was sent to the penalty box");
            inPenaltyBox[currentPlayer] = true;

            SetNextCurrentPlayer();
            return true;
        }

        private void SetNextCurrentPlayer()
        {
            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;
        }
    }
}
