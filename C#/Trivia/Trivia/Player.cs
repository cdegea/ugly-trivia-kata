namespace Trivia
{
    public class Player
    {
        public int place = 0;
        public int points = 0;
        public bool inPenaltyBox = false;

        public Player(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}