using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        private readonly List<Player> players = new List<Player>();
        private int currentPlayerIndex;
        private bool isGettingOutOfPenaltyBox;
        private readonly QuestionCollection questionCollection;

        public Game()
        {
            questionCollection = new QuestionCollection();
        }

        private Player CurrentPlayer => players[currentPlayerIndex];

        public bool Add(string playerName)
        {
            players.Add(new Player(playerName));

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + players.Count);
            return true;
        }

        public void Roll(int roll)
        {
            Console.WriteLine(CurrentPlayer.Name + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (CurrentPlayer.InPenaltyBox)
            {
                isGettingOutOfPenaltyBox = roll % 2 != 0;
                if (isGettingOutOfPenaltyBox)
                {
                    Console.WriteLine(CurrentPlayer.Name + " is getting out of the penalty box");
                }
                else
                {
                    Console.WriteLine(CurrentPlayer.Name + " is not getting out of the penalty box");
                    return;
                }
            }

            MoveToNextPlace(roll);

            Console.WriteLine(CurrentPlayer.Name
                              + "'s new location is "
                              + CurrentPlayer.Place);
            Console.WriteLine("The category is " + CurrentCategory());
            questionCollection.GetNextQuestion(CurrentCategory());
        }


        private void MoveToNextPlace(int roll)
        {
            CurrentPlayer.Place += roll;
            if (CurrentPlayer.Place > 11)
                CurrentPlayer.Place -= 12;
        }

        private string CurrentCategory()
        {
            switch (CurrentPlayer.Place)
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
            if (CurrentPlayer.InPenaltyBox && !isGettingOutOfPenaltyBox)
            {
                SetNextCurrentPlayer();
                return true;
            }

            Console.WriteLine("Answer was correct!!!!");
            CurrentPlayer.Points++;
            Console.WriteLine(CurrentPlayer.Name
                              + " now has "
                              + CurrentPlayer.Points
                              + " Gold Coins.");

            var notWinner = CurrentPlayer.Points != 6;
            SetNextCurrentPlayer();
            return notWinner;
        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(CurrentPlayer.Name + " was sent to the penalty box");
            CurrentPlayer.InPenaltyBox = true;

            SetNextCurrentPlayer();
            return true;
        }

        private void SetNextCurrentPlayer()
        {
            if (++currentPlayerIndex == players.Count) 
                currentPlayerIndex = 0;
        }
    }
}
