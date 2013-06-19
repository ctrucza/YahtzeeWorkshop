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
        public void Play_completes_player()
        {
            Player player = new Player();
            player.Play();
            Assert.IsTrue(player.IsCompleted);
        }

        [Test]
        public void Player_displays_name()
        {
            Player player = new Player("Joe");
            Assert.AreEqual("Joe", player.ToString());
        }
    }
}
