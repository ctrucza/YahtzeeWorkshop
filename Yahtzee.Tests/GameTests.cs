using System;
using NUnit.Framework;

namespace Yahtzee.Tests
{
    [TestFixture]
    public class GameTests
    {
        private Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game();
        }

        [Test]
        public void Game_can_be_created()
        {
            Assert.IsNotNull(game);
        }

        [Test]
        public void Add_adds_new_player()
        {
            Player joe = new Player();
            game.Add(joe);

            CollectionAssert.Contains(game.Players, joe);
        }

        [Test]
        public void Start_sets_CurrentPlayer_to_first_player()
        {
            Player joe = new Player();
            Player jane = new Player();

            game.Add(joe);
            game.Add(jane);

            game.Start();

            Assert.AreEqual(joe, game.CurrentPlayer);
        }

        [Test]
        public void Start_throws_when_there_are_no_players()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => game.Start());
            Assert.AreEqual(GameExceptions.CannotStartGamesWithoutPlayers, exception.Message);
        }

        [Test]
        public void Add_throws_if_the_game_is_already_started()
        {
            game.Add(new Player());
            game.Start();
            var exception = Assert.Throws<InvalidOperationException>(() => game.Add(new Player()));
            Assert.AreEqual(GameExceptions.CannotAddPlayerToRunningGame, exception.Message);
        }

        [Test]
        public void Game_is_not_over_after_start()
        {
            Player joe = new Player();
            game.Add(joe);

            game.Start();

            Assert.IsFalse(game.IsOver);
        }

        [Test]
        public void Game_is_over_when_all_players_is_completed()
        {
            Player joe = new Player();
            Player jane = new Player();
            game.Add(joe);
            game.Add(jane);

            game.Start();

            joe.IsCompleted = true;
            jane.IsCompleted = true;

            Assert.IsTrue(game.IsOver);
        }

        [Test]
        public void MoveToNextPlayer_moves_to_next_player()
        {
            Player joe = new Player();
            Player jane = new Player();
            Player jim = new Player();
            game.Add(joe);
            game.Add(jane);
            game.Add(jim);

            game.Start();
            game.MoveToNextPlayer();
            Assert.AreEqual(jane, game.CurrentPlayer);            

            game.MoveToNextPlayer();
            Assert.AreEqual(jim, game.CurrentPlayer);
        }

        [Test]
        public void MoveToNextPlayer_wraps()
        {
            Player joe = new Player();
            Player jane = new Player();
            game.Add(joe);
            game.Add(jane);

            game.Start();
            game.MoveToNextPlayer(); // jane

            game.MoveToNextPlayer();
            Assert.AreEqual(joe, game.CurrentPlayer);
        }

        [Test]
        public void MoveToNext_throws_if_game_not_started()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => game.MoveToNextPlayer());
            Assert.AreEqual(GameExceptions.CannotMoveWhenGameIsNotStarted, exception.Message);
        }

        [Test]
        public void Add_Sets_Scorecard_for_player()
        {
            Player joe = new Player();
            game.Add(joe);
            Assert.IsNotNull(joe.Scorecard);
        }
    }
}
