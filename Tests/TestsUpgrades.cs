using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestsUpgrades
    {
        [Test]
        public void TestUpgradesWithCookers()
        {
            Game.Game g = new Game.Game();
            Game.Buildings.Restaurant resto = new Game.Buildings.Restaurant(g.Villages[0]);
            int _initialCoeff = g.Villages[0].Jobs.Cooker.Coefficient;
           
            g.AddOrTakeFromOfferings(200);
            Assert.That(g.Offerings > 200);
            g.Villages[0].Upgrades.Level1.Buy();
            g.Villages[0].BuildingsList.Add(resto);
            Assert.That(g.Villages[0].Upgrades.Level1.IsActivated);
            Assert.That(_initialCoeff != g.Villages[0].Jobs.Cooker.Coefficient);

        }
    }
}
