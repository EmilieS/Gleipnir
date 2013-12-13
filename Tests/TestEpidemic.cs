using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;

namespace Tests
{
    [TestFixture]
    public class TestEpidemic
    {
        Game.GodSpell.Epidemic epidemic;
        [Test]
        public void TestEverybodySet()
        {
            Game.Game g = new Game.Game();
            
            //int rand = g.Rand.Next();
            Village selectedVillage = g.Villages[0];
            Family family = selectedVillage.FamiliesList[0];
            Villager villager = family.FamilyMembers[0];
            double lifeExpectancyIni = villager.LifeExpectancy;
            epidemic = new Game.GodSpell.Epidemic(g, villager);

            epidemic.LaunchEpidemic();

            Assert.That(villager.LifeExpectancy < lifeExpectancyIni);
            g.NextStep();
            Assert.That(villager.LifeExpectancy == lifeExpectancyIni - 2);
        }
    }
}
