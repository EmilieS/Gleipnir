using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Buildings.Hobbies;
using Buildings.Management;
using Buildings.Believing;
using Game;

namespace Tests
{
    [TestFixture]
    class TestBuildings
    {
        [Test]
        public void TestBaths()
        {
            var f = new Family();
            var b = new Baths();
            var v = new Villager();

            v.AddOrRemoveHappiness(b.SetHappiness);
            Assert.That(v.Happiness, Is.EqualTo(83));

            f.addTOGoldStash(250);
            b.SetNewGoldStash(f.GoldStash);
            Assert.That(f.GoldStash == 50);
            b.SetNewGoldStash(f.GoldStash);
            Assert.That(f.GoldStash == 0);
        }
        [Test]
        public void TestBrothel()
        {
            var b = new Brothel();
            var v = new Villager();

            v.AddOrRemoveHappiness(b.SetHappiness);
            Assert.That(v.Happiness, Is.EqualTo(88));
        }
        [Test]
        public void TestTavern()
        {
            var t = new Tavern();
            var v = new Villager();

            v.AddOrRemoveHappiness(t.SetHappiness);
            Assert.That(v.Happiness, Is.EqualTo(86));

            v.AddOrRemoveFaith(-50);
            v.AddOrRemoveFaith(t.SetFaith);
            Assert.That(v.Faith, Is.EqualTo(54));

        }
        [Test]
        public void TestTheater()
        {
            var t = new Theater();
            var v = new Villager();

            v.AddOrRemoveHappiness(t.SetHappiness);
            Assert.That(v.Happiness, Is.EqualTo(85));
        }
        [Test]
        public void TestChapel()
        {
            var t = new Chapel();
            var v = new Villager();
            v.AddOrRemoveFaith(-50);
            v.AddOrRemoveFaith(t.SetFaith);
            Assert.That(v.Faith, Is.EqualTo(54));
        }


    }
}
