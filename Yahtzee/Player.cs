using System;
using System.Collections.Generic;

namespace Yahtzee
{
    public class Player
    {
        private readonly string name;
        public Dictionary<string, int> Scorecard = null; //new Dictionary<string, int>(); 
        private int scores = 0;

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
            if (!Scorecard.ContainsKey(selection))
                throw new InvalidOperationException();

            if (HasScoreFor(selection))
                throw new InvalidOperationException();

            Scorecard[selection] = 42;
            scores++;
            IsCompleted = (scores == Scorecard.Count);
        }

        public bool HasScoreFor(string selection)
        {
            return Scorecard[selection] > 0;
        }
    }
}