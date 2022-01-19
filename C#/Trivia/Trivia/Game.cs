using System;
using System.Collections.Generic;

namespace Trivia
{
    public class Game
    {
        private readonly List<Player> players = new List<Player>();
        private readonly QuestionCollection questionCollection = new QuestionCollection();
        private int currentPlayerIndex;
        private bool isGettingOutOfPenaltyBox;

        private Player CurrentPlayer => players[currentPlayerIndex];
        public bool HasNotAWinner => CurrentPlayer.Points != 6;

        public void AddPlayer(string playerName)
        {
            players.Add(new Player(playerName));

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + players.Count);
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

            CurrentPlayer.MoveToNextPlace(roll);

            Console.WriteLine(CurrentPlayer.Name
                              + "'s new location is "
                              + CurrentPlayer.Place);
            Console.WriteLine("The category is " + CurrentPlayer.CurrentCategory());

            questionCollection.GetNextQuestion(CurrentPlayer.CurrentCategory());
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

            var notWinner = HasNotAWinner;
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
            if (!this.HasNotAWinner) return;

            if (++currentPlayerIndex == players.Count)
                currentPlayerIndex = 0;
        }
    }
}