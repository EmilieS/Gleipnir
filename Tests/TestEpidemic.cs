﻿using NUnit.Framework;
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
            Family family = selectedVillage.FamiliesList[1];
            Villager villager = family.FamilyMembers[0];
            double lifeExpectancyIni = villager.LifeExpectancy;
            epidemic = new Game.GodSpell.Epidemic(g, villager);
            selectedVillage.JobsList.Tailor.AddPerson2(villager);
            JobsModel job = villager.Job;
            epidemic.LaunchEpidemic();
            g.NextStep();
            Assert.That(villager.LifeExpectancy < lifeExpectancyIni);
            g.NextStep();
            Assert.That(villager.LifeExpectancy == lifeExpectancyIni - 2);
            List<Villager> sickVillagers= new List<Villager>();
            for (int i = 0; i < 16; i++)
            {
                g.NextStep();
            }
            Assert.That(family != null, "family is already dead");
            foreach (Villager v in family.FamilyMembers)
            {
                if((v.Health & Healths.SICK)!=0)
                sickVillagers.Add(v);
            }
            Assert.That((sickVillagers.Count>1 || family.FamilyMembers.Count<2), "no family members got sick!!!");
            sickVillagers.Clear();
            foreach (Villager v in job.Workers)
            {
                if ((v.Health & Healths.SICK) != 0)
                    sickVillagers.Add(v);
                         }
            Assert.That((sickVillagers.Count > 1 || job.Workers.Count < 2), "no workers got sick!!!");

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
