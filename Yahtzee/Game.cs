using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee
{
    public class Game
    {
        private readonly List<Player> players = new List<Player>();
        private bool isRunning = false;

        public void Add(Player joe)
        {
            if (isRunning)
                throw new InvalidOperationException(GameExceptions.CannotAddPlayerToRunningGame);
            players.Add(joe);
        }

        public IEnumerable<Player> Players
        {
            get { return players; }
        }

        public Player CurrentPlayer { get; private set; }

        public bool IsOver
        {
            get { return players.All(player => player.IsCompleted); }
        }

        public void Start()
        {
            if (!players.Any())
            {
                throw new InvalidOperationException(GameExceptions.CannotStartGamesWithoutPlayers);
            }

            CurrentPlayer = players.First();
            isRunning = true;
        }

        public void MoveToNextPlayer()
        {
            if (!isRunning)
                throw new InvalidOperationException(GameExceptions.CannotMoveWhenGameIsNotStarted);
            int index = players.IndexOf(CurrentPlayer) + 1;
            if (index == players.Count)
                index = 0;
            CurrentPlayer = players[index];
        }
    }
}