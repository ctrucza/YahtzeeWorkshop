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
            game.Add(new Player("Joe"));
            game.Add(new Player("Jane"));

            game.Start();
            Console.WriteLine("game started");

            while (!game.IsOver)
            {
                // do stuff: Play current player, move to next player
                
                game.CurrentPlayer.Play();
                game.MoveToNextPlayer();
                Console.WriteLine(game.CurrentPlayer + " is playing");
            }

            Console.WriteLine("game over");
        }
    }
}
