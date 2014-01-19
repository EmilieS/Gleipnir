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
            var villager = myGame.Villages[0].FamiliesList[0].Father;
            Game.GodSpell.Epidemic epidemic = new Game.GodSpell.Epidemic(myGame, villager);
            var MyWindow = new Tests.IWindowImplementationForTests();
            do
            {
                myGame.NextStep();
                foreach (IEvent e in myGame.EventList)
                {
                    e.PublishMessage(MyWindow);
                    e.Do(MyWindow);
                }
            } while (MyWindow.nb_pushAlert == 0);
            //Assert.That(MyWindow.nb_pushAlert, Is.EqualTo(1));
        }

        [Test]
        public void ToSee()
        {
            var myGame = new Game.Game();
            var MyWindow = new Tests.IWindowImplementationForTests();
            Village selectedVillage = myGame.Villages[0];
            Family family = selectedVillage.FamiliesList[1];
            Villager villager = family.FamilyMembers[0];
            new Game.GodSpell.Epidemic(myGame, villager);
            do
            {
                myGame.NextStep();
                foreach (IEvent e in myGame.EventList)
                {
                    e.PublishMessage(MyWindow);
                    e.Do(MyWindow);
                }
            } while (myGame.TotalPop < 3000 && myGame.TotalPop>0);
            //Assert.That(MyWindow.nb_pushAlert, Is.EqualTo(1));
        }
       /* [Test]
        public void ToSee2()
        {
            Game.Game myGame;
            var MyWindow = new Tests.IWindowImplementationForTests();

            for (int i = 0; i < 300; i++)
            {
                myGame = new Game.Game();

                do
                {
                    myGame.NextStep();
                    foreach (IEvent e in myGame.EventList)
                    {
                        e.PublishMessage(MyWindow);
                        e.Do(MyWindow);
                    }
                } while (myGame.TotalPop < 500 && myGame.TotalPop>0);
            }
            //Assert.That(MyWindow.nb_pushAlert, Is.EqualTo(1));
        }*/
        /*[Test]
        public void bitflag()
        {
            Healths _health = Healths.HERETIC;
            double _faith = 1;
            Assert.That((_faith <= 15) == ((_health & Healths.HERETIC) != 0), " heretism is not right!");

            _health = _health & ~Healths.HERETIC;
            _faith = 50;
            Assert.That((_health & Healths.HERETIC) == 0);
            Assert.That((_faith <= 15) == ((_health & Healths.HERETIC) != 0), " heretism is not right!");
        }*/
    }
}
