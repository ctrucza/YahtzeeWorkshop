namespace Yahtzee
{
    public class Player
    {
        private readonly string name;

        public Player(string name = "")
        {
            this.name = name;
        }

        public bool IsCompleted { get; set; }

        public void Play()
        {
            IsCompleted = true;
        }

        public override string ToString()
        {
            return name;
        }
    }
}