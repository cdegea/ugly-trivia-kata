namespace Trivia
{
    public class Player
    {
        public Player(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public int Place { get; set; }
        public int Points { get; set; }
        public bool InPenaltyBox { get; set; }
    }
}