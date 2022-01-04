using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Game
    {
        private readonly List<string> players = new List<string>();

        private readonly int[] _places = new int[6];
        private readonly int[] _purses = new int[6];

        private readonly bool[] _inPenaltyBox = new bool[6];

        private readonly LinkedList<string> popQuestions = new LinkedList<string>();
        private readonly LinkedList<string> scienceQuestions = new LinkedList<string>();
        private readonly LinkedList<string> sportsQuestions = new LinkedList<string>();
        private readonly LinkedList<string> rockQuestions = new LinkedList<string>();

        private int currentPlayer;
        private bool isGettingOutOfPenaltyBox;

        public Game()
        {
            for (var i = 0; i < 50; i++)
            {
                popQuestions.AddLast("Pop Question " + i);
                scienceQuestions.AddLast(("Science Question " + i));
                sportsQuestions.AddLast(("Sports Question " + i));
                rockQuestions.AddLast("Rock Question " + i);
            }
        }

        public bool Add(string playerName)
        {
            players.Add(playerName);
            _places[players.Count] = 0;
            _purses[players.Count] = 0;
            _inPenaltyBox[players.Count] = false;

            Console.WriteLine(playerName + " was added");
            Console.WriteLine("They are player number " + players.Count);
            return true;
        }

        public void Roll(int roll)
        {
            Console.WriteLine(players[currentPlayer] + " is the current player");
            Console.WriteLine("They have rolled a " + roll);

            if (_inPenaltyBox[currentPlayer])
            {
                if (roll % 2 != 0)
                {
                    isGettingOutOfPenaltyBox = true;

                    Console.WriteLine(players[currentPlayer] + " is getting out of the penalty box");
                    _places[currentPlayer] = _places[currentPlayer] + roll;
                    if (_places[currentPlayer] > 11) _places[currentPlayer] = _places[currentPlayer] - 12;

                    Console.WriteLine(players[currentPlayer]
                            + "'s new location is "
                            + _places[currentPlayer]);
                    Console.WriteLine("The category is " + CurrentCategory());
                    AskQuestion();
                }
                else
                {
                    Console.WriteLine(players[currentPlayer] + " is not getting out of the penalty box");
                    isGettingOutOfPenaltyBox = false;
                }
            }
            else
            {
                _places[currentPlayer] = _places[currentPlayer] + roll;
                if (_places[currentPlayer] > 11) _places[currentPlayer] = _places[currentPlayer] - 12;

                Console.WriteLine(players[currentPlayer]
                        + "'s new location is "
                        + _places[currentPlayer]);
                Console.WriteLine("The category is " + CurrentCategory());
                AskQuestion();
            }
        }

        private void AskQuestion()
        {
            if (CurrentCategory() == "Pop")
            {
                Console.WriteLine(popQuestions.First());
                popQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Science")
            {
                Console.WriteLine(scienceQuestions.First());
                scienceQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Sports")
            {
                Console.WriteLine(sportsQuestions.First());
                sportsQuestions.RemoveFirst();
            }
            if (CurrentCategory() == "Rock")
            {
                Console.WriteLine(rockQuestions.First());
                rockQuestions.RemoveFirst();
            }
        }

        private string CurrentCategory()
        {
            switch (_places[currentPlayer])
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
            if (_inPenaltyBox[currentPlayer] && isGettingOutOfPenaltyBox)
            {
                Console.WriteLine("Answer was correct!!!!");
                Console.WriteLine(players[currentPlayer]
                                  + " now has "
                                  + _purses[currentPlayer]
                                  + " Gold Coins.");
            }

            Console.WriteLine("Answer was corrent!!!!");
            _purses[currentPlayer]++;
            Console.WriteLine(players[currentPlayer]
                              + " now has "
                              + _purses[currentPlayer]
                              + " Gold Coins.");

            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;

            return DidPlayerWin();
        }

        public bool WrongAnswer()
        {
            Console.WriteLine("Question was incorrectly answered");
            Console.WriteLine(players[currentPlayer] + " was sent to the penalty box");
            _inPenaltyBox[currentPlayer] = true;

            currentPlayer++;
            if (currentPlayer == players.Count) currentPlayer = 0;
            return true;
        }


        private bool DidPlayerWin()
        {
            return _purses[currentPlayer] != 6;
        }
    }

}
