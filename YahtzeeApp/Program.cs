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
            game.Add(new Player());
            game.Add(new Player());

            game.Start();

            while (!game.IsOver)
            {
                // do stuff: Play current player, move to next player
                
                // game.CurrentPlayer.Play();
                game.MoveToNextPlayer();
                Console.WriteLine(game.CurrentPlayer);
            }

            Console.WriteLine("game over");
        }
    }
}
