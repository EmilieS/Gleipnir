using Game;
using GameJobs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    class TestsJobs
    {/*
        [Test]
        public void ApothecaryTests()
        {
            Villager a = new Villager();
            Villager b = new Villager();
            Villager c = new Villager();
            Apothecary apothecary = new Apothecary();

            // Add new worker to Apothecary job
            Assert.That(apothecary.Workers.Count, Is.EqualTo(0));
            apothecary.AddPerson(a);
            Assert.That(apothecary.Workers.Count, Is.EqualTo(1));
            Assert.That(a.Job, Is.EqualTo(Jobs.APOTHECARY));

            // Try add the same worker to Apothecary job
            apothecary.AddPerson(a);
            Assert.That(apothecary.Workers.Count, Is.EqualTo(1));

            // See gold generation
            Assert.That(apothecary.Gold, Is.EqualTo(75));
            apothecary.GenerateGold();
            Assert.That(a.Wallet, Is.EqualTo(75));
            Assert.That(c.Wallet, Is.EqualTo(0));

            // Add other worker
            apothecary.AddPerson(b);
            Assert.That(apothecary.Workers.Count, Is.EqualTo(2));

            // New Gold generation
            apothecary.GenerateGold();
            Assert.That(apothecary.Gold, Is.EqualTo(74));
            Assert.That(a.Wallet, Is.EqualTo(149));
            Assert.That(b.Wallet, Is.EqualTo(74));

            // Remove worker
            apothecary.RemovePerson(a);
            Assert.That(apothecary.Workers.Count, Is.EqualTo(1));
            Assert.That(a.Job, Is.EqualTo(Jobs.NONE));

            // Try remove the same worker
            apothecary.RemovePerson(a);
            Assert.That(apothecary.Workers.Count, Is.EqualTo(1));

            // Gold generation up
            apothecary.GenerateGold();
            Assert.That(apothecary.Gold, Is.EqualTo(75));
            Assert.That(b.Wallet, Is.EqualTo(149));
        }

        [Test]
        public void CookerTests()
        {
            Villager a = new Villager();
            Villager b = new Villager();
            Villager c = new Villager();
            Cooker cooker = new Cooker();

            cooker.AddPerson(a);
            cooker.AddPerson(b);

            Assert.That(c.Happiness, Is.EqualTo(80));
            cooker.AddHappiness(c);
            Assert.That(c.Happiness, Is.EqualTo(90));
        }*/
    }
}
