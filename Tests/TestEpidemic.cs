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
            JobsModel job = villager.Job;
            epidemic.LaunchEpidemic();
            g.NextStep();
            Assert.That(villager.LifeExpectancy < lifeExpectancyIni);
            g.NextStep();
            Assert.That(villager.LifeExpectancy == lifeExpectancyIni - 2);

            foreach (Villager v in villager.ParentFamily.FamilyMembers)
            {
                Assert.That(((v.Health & Healths.SICK)!=0), "villager is not sick!!!");
            }
            foreach (Villager v in villager.Job.Workers)
            {
                Assert.That(((v.Health & Healths.SICK)!=0), "villager is not sick!!!");
            }

            for (int i = 0; i < 16; i++)
            {
                g.NextStep();
            }

            foreach (Villager v in job.Workers)
            {
                Assert.That(v.Faith < 91, "villager's faith has not changed!");
            }
        }
    }
}
