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

        public void MoveToNextPlace(int roll)
        {
            this.Place += roll;
            if (this.Place > 11)
                this.Place -= 12;
        }

        public string GetCategoryByCurrentPlace()
        {
            switch (this.Place)
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
    }
}