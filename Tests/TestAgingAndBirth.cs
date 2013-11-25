using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Game;

namespace Tests
{
    [TestFixture]
    class TestAgingAndBirth
    {
        [Test]
        public void Birth()
        {
            var MyGame = new Game.Game();
            Assert.AreEqual(10, MyGame.TotalPop);
            for (int i = 0; i < 12*18; i++)
            {
                MyGame.NextStep();
            }
            Assert.AreEqual(15, MyGame.TotalPop);
        }
    }
}
