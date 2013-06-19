using System.Collections.Generic;

namespace Yahtzee
{
    public class Player
    {
        private readonly string name;
        private Dictionary<string, int> scoreCard = new Dictionary<string, int>(); 

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
            scoreCard[selection] = 42;
            IsCompleted = true;
        }

        public bool HasScoreFor(string selection)
        {
            return scoreCard[selection] > 0;
        }
    }
}