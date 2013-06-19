using System.Collections.Generic;

namespace Yahtzee
{
    public class Player
    {
        private readonly string name;
        private List<string> scoreCard = new List<string>();

        public Player(string name = "")
        {
            this.name = name;
        }

        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            return name;
        }

        public void Score(Dice dice, string selection)
        {
            scoreCard.Add(selection);
            IsCompleted = true;
        }

        public bool HasScoreFor(string selection)
        {
            return scoreCard.Contains(selection);
        }
    }
}