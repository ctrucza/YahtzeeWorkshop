using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yahtzee;

namespace YahtzeeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Player joe = new Player("Joe");
            game.Add(joe);
            Player jane = new Player("Jane");
            game.Add(jane);

            joe.Scorecard = new Dictionary<string, int>
                {
                    {"ONES", 0}, 
                    {"TWOS", 0}
                };
            jane.Scorecard = new Dictionary<string, int>
                {
                    {"ONES", 0}, 
                    {"TWOS", 0}
                };

            game.Start();
            Console.WriteLine("game started");

            while (!game.IsOver)
            {
                //Dice dice = ThrowDiceThreeTimes();
                //Selection selection = PickSelection();

                game.CurrentPlayer.Score(new Dice(), "ONES");

                game.MoveToNextPlayer();
                Console.WriteLine(game.CurrentPlayer + " is playing");
            }

            Console.WriteLine("game over");
        }
    }
}
