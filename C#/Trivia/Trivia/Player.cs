namespace Trivia
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public int Place { get; set; }
        public int Points { get; set; }
        public bool InPenaltyBox { get; set; }

        public void MoveToNextPlace(int roll)
        {
            Place += roll;
            if (Place > 11)
                Place -= 12;
        }

        public string GetCategoryByCurrentPlace()
        {
            switch (Place)
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