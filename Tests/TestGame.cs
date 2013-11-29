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
            var myGame = new Game.Game();
            var MyWindow = new Tests.IWindowImplementationForTests();
            do
            {
                myGame.NextStep();
                foreach (IEvent e in myGame.EventList)
                {
                    e.PublishMessage(MyWindow);
                    e.Do(MyWindow);
                }
            } while(MyWindow.nb_pushAlert == 0);
            //Assert.That(MyWindow.nb_pushAlert, Is.EqualTo(1));
        }
    }
}
