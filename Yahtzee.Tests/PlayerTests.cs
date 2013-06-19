using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Yahtzee.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void Score_completes_player()
        {
            Player player = new Player();
            player.Scorecard = new Dictionary<string, int>
                {
                    {"Ones", 0}
                };
            player.Score(new Dice(), "Ones");
            Assert.IsTrue(player.IsCompleted);
        }

        [Test]
        public void Player_displays_name()
        {
            Player player = new Player("Joe");
            Assert.AreEqual("Joe", player.ToString());
        }

        [Test]
        public void Score_scores_something()
        {
            Player joe = new Player();
            joe.Scorecard = new Dictionary<string, int>
                {
                    {"ONES", 0}
                };
            joe.Score(new Dice(), "ONES");
            Assert.IsTrue(joe.HasScoreFor("ONES"));
        }

        [Test]
        public void Player_can_play_more_than_one_rounds()
        {
            Player joe = new Player();
            joe.Scorecard = new Dictionary<string, int>
                {
                    {"ONES", 0}, 
                    {"TWOS", 0}
                };

            joe.Score(new Dice(), "TWOS");
            Assert.IsFalse(joe.IsCompleted);
        }

        [Test]
        public void Score_throws_if_line_does_not_exist()
        {
            Player joe = new Player();
            joe.Scorecard = new Dictionary<string, int>();
            Assert.Throws<InvalidOperationException>(() => joe.Score(new Dice(), "NONEXISTENT"));
        }

        [Test]
        public void Score_throws_if_line_was_already_scored()
        {
            Player joe = new Player();
            joe.Scorecard = new Dictionary<string, int>
                {
                    {"ONES", 0}
                };
            joe.Score(new Dice(), "ONES");
            Assert.Throws<InvalidOperationException>(() => joe.Score(new Dice(), "ONES"));
        }
    }
}
