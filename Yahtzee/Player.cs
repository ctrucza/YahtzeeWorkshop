using System.Collections.Generic;

namespace Yahtzee
{
    public class Player
    {
        private readonly string name;
        public Dictionary<string, int> Scorecard = null; //new Dictionary<string, int>(); 

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
            Scorecard[selection] = 42;
            IsCompleted = true;
        }

        public bool HasScoreFor(string selection)
        {
            return Scorecard[selection] > 0;
        }
    }
}