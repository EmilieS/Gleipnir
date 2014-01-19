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
            var game = new Game.Game(1000);
            var MyWindow = new Tests.IWindowImplementationForTests();
            game._timer.AutoReset = true;
            game.StartTime();
            GC.KeepAlive(game._timer);

            //need to wait for all threads...
            Assert.That(game.EventList.Count>0);
            foreach (IEvent e in game.EventList)
            {
                e.PublishMessage(MyWindow);
                e.Do(MyWindow);
            }
            Assert.That(MyWindow.nb_pushTrace > 1);
            //game._timer.Join
        }

    }
}
