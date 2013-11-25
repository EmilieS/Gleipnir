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
            for (int i = 0; i < /*12*18*/216; i++)
            {
                MyGame.NextStep();
            }
            Assert.AreEqual(15, MyGame.TotalPop);
            Assert.AreEqual(5, MyGame.Villages[0].FamiliesList.Count);

            for (int i = 0; i < 11; i++)
            {
                MyGame.NextStep();
            }
            int j = 0;
            while (MyGame.Villages[0].FamiliesList.Count == 5)
            {
                MyGame.NextStep();
                j++;
            }
            Assert.Greater(MyGame.Villages[0].FamiliesList.Count, 5);
            //Assert.AreEqual(6, MyGame.Villages[0].FamiliesList.Count);
        }
        [Test]
        public void Events()
        {
            var MyGame = new Game.Game();
            var MyWindow = new Tests.IWindowImplementationForTests();
            Villager villager1=MyGame.Villages[0].FamiliesList[0].Mother;

            foreach (IEvent Event in MyGame.EventList)
            {
                Event.PublishMessage(MyWindow);
            }
            MyGame.NextStep();
            Assert.AreEqual(0, MyWindow.nb_pushAlert);
            Assert.AreEqual(0, MyWindow.nb_pushTrace);

            MyGame.NextStep();

            foreach (IEvent Event in MyGame.EventList)
            {
                Event.PublishMessage(MyWindow);
            }
            Assert.AreEqual(15, MyWindow.nb_pushTrace);
            Assert.AreEqual(0, MyWindow.nb_pushAlert);
            villager1.Kill();
            MyGame.NextStep();
            foreach (IEvent Event in MyGame.EventList)
            {
                Event.PublishMessage(MyWindow);
            }
            Assert.AreEqual(34, MyWindow.nb_pushTrace);
            Assert.AreEqual(1, MyWindow.nb_pushAlert);
        }
    }
}
