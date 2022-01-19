using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        private readonly List<string> players = new List<string>();

        private readonly int[] places = new int[6];
        private readonly int[] points = new int[6];

        private readonly bool[] inPenaltyBox = new bool[6];

        private int currentPlayer;
        private bool isGettingOutOfPenaltyBox;
        private readonly QuestionCollection questionCollection;

        public Game()
        {
            questionCollection = new QuestionCollection();
        }

        public bool Add(string playerName)
        {
            players.Add(playerName);
            places[players.Count] = 0;
            points[players.Count] = 0;
            inPenaltyBox[players.Count] = false;

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + players.Count);
            return true;
        }

        public void Roll(int roll)
        {
            Console.WriteLine(players[currentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (inPenaltyBox[currentPlayer])
            {
                isGettingOutOfPenaltyBox = roll % 2 != 0;
                if (isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine(players[currentPlayer] + " is getting out of the penalty box");
                }
                else
                {
                    Console.WriteLine(players[currentPlayer] + " is not getting out of the penalty box");
                    return;
                }
            }

            MoveToNextPlace(roll);

            Console.WriteLine(players[currentPlayer]
                              + "'s new location is "
                              + places[currentPlayer]);
            Console.WriteLine("The category is " + CurrentCategory());
            AskQuestion();
        }

        private void MoveToNextPlace(int roll)
        {
            places[currentPlayer] += roll;
            if (places[currentPlayer] > 11)
                places[currentPlayer] -= 12;
        }

        private void AskQuestion()
        {
            if (CurrentCategory() == "Pop")
            {
                Console.WriteLine(questionCollection.popQuestions.First());
                questionCollection.popQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Science")
            {
                Console.WriteLine(questionCollection.scienceQuestions.First());
                questionCollection.scienceQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Sports")
            {
                Console.WriteLine(questionCollection.sportsQuestions.First());
                questionCollection.sportsQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Rock")
            {
                Console.WriteLine(questionCollection.rockQuestions.First());
            }
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
