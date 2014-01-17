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
    class TestTime
    {
        [Test]
        public void time()
        {
            var game = new Game.Game(2);
            var MyWindow = new Tests.IWindowImplementationForTests();
            game.StartTime();
            //need to wait for all threads...
            foreach (IEvent e in game.EventList)
            {
                e.PublishMessage(MyWindow);
                e.Do(MyWindow);
            }
            Assert.That(MyWindow.nb_pushTrace > 1);

        }

    }
}
