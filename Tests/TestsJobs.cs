﻿using Game;
using Game.Buildings;
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
    {
        [Test]
        public void Job()
        {
            // Create game
            Game.Game game = new Game.Game();
            var village = game.Villages[0];
            var farm = new Farm(village, village.JobsList.Farmer);
            new Restaurant(village, village.JobsList.Cooker);
            foreach (Family f in village.FamiliesList)
            {
                foreach (Villager v in f.FamilyMembers)
                {
                    if (v.Job!=null)
                    {
                    v.Job.RemovePerson2(v);
                    }
                }
            }
            

            var v0 = village.FamiliesList[0].FamilyMembers[0];
            var v1 = village.FamiliesList[0].FamilyMembers[1];
            var v2 = village.FamiliesList[1].FamilyMembers[0];
            var v3 = village.FamiliesList[1].FamilyMembers[1];
            var v4 = village.FamiliesList[2].FamilyMembers[0];
            var v5 = village.FamiliesList[2].FamilyMembers[1];
            var cooker = village.JobsList.Cooker;

            // Jobs are created
            int i;
            for(i=0; i<8; i++)
                Assert.That(village.JobsList[i], Is.Not.Null);

            // Add new worker to job
            Assert.That(cooker.Workers.Count, Is.EqualTo(0));
            cooker.AddPerson2(v0);
            Assert.That(cooker.Workers.Count, Is.EqualTo(1));
            Assert.That(v0.Job==cooker);

            // Try add the same worker to Apothecary job
            //Assert.Throws<InvalidOperationException>(() => cooker.AddPerson(v0), "Add worker issue!");
            Assert.That( cooker.AddPerson2(v0)==false);
            Assert.That(cooker.Workers.Count, Is.EqualTo(1));

            game.NextStep();

            // See gold generation
            Assert.AreEqual(130, cooker.GoldGenerated);// /!\ should never be called. //was 65
            cooker.GenerateGold();
            Assert.That(v0.ParentFamily.GoldStash, Is.EqualTo(278));//65+20
            Assert.That(v1.ParentFamily.GoldStash, Is.EqualTo(278));//65+20
            Assert.That(v2.ParentFamily.GoldStash, Is.EqualTo(18));//0+20

            // Add other worker
            cooker.AddPerson2(v2);
            Assert.That(cooker.Workers.Count, Is.EqualTo(2));

            // New Gold generation
            cooker.GenerateGold();
            Assert.That(cooker.GoldGenerated, Is.EqualTo(65));//64
            Assert.That(v0.ParentFamily.GoldStash, Is.EqualTo(343));//129+20
            Assert.That(v2.ParentFamily.GoldStash, Is.EqualTo(83));//64+20

            // Remove worker
            cooker.RemovePerson2(v0);
            Assert.That(cooker.Workers.Count, Is.EqualTo(1));
            Assert.That(v0.Job==null);

            // Try remove the same worker
            //Assert.Throws<InvalidOperationException>(() => cooker.RemovePerson2(v0), "Remove worker issue!");
            Assert.That(cooker.RemovePerson2(v0)==false);
            Assert.That(cooker.Workers.Count, Is.EqualTo(1));

            // Gold generation up
            cooker.GenerateGold();
            Assert.That(cooker.GoldGenerated, Is.EqualTo(130));//65
            Assert.That(v2.ParentFamily.GoldStash, Is.EqualTo(213));//129+20
        }
    }
}
