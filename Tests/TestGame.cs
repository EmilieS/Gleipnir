using Game;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class TestGame
    {
        [Test]
        public void killPopulation()
        {
            int nb_pushAlert = 0;
            var myGame = new Game.Game();
            do
            {
                myGame.NextStep();
            } while(nb_pushAlert == 0);
            Assert.That(nb_pushAlert, Is.EqualTo(1));
        }
    }
}
