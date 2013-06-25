using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee
{
    public class Game
    {
        private readonly List<Player> players = new List<Player>();
        private bool isRunning = false;

        public void Add(Player player)
        {
            if (isRunning)
                throw new InvalidOperationException(GameExceptions.CannotAddPlayerToRunningGame);
            players.Add(player);

            player.Scorecard = new Dictionary<string, int>(); // TODO: step one: Game has a private property for scorecard template, step two: this template is injected/loaded
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