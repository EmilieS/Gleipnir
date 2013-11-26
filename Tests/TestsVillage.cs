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
    class TestsVillage
    {
        [Test]
        public void familyTests()
        {
            var myGame = new Game.Game();
            var village = myGame.Villages[0];
            var families = village.FamiliesList;

            // Add new familly
            Assert.That(village.FamiliesList.Count, Is.EqualTo(5));
            var family1 = village.CreateFamilyFromScratch();
            Assert.That(village.FamiliesList.Count, Is.EqualTo(6));

            // Kill a family
            family1.FamilyMembers[0].Kill();
            family1.FamilyMembers[1].Kill();
            myGame.NextStep();
            Assert.That(village.FamiliesList.Count, Is.EqualTo(5));
        }
        
        [Test]
        public void goldTests()
        {
            var myGame = new Game.Game();
            var village = myGame.Villages[0];
            var families = village.FamiliesList;
            var family1 = families[0];
            var family2 = families[1];

            village.CalculateVillageGold();
            Assert.That(village.Gold, Is.EqualTo(100));

            // Less gold
            family1.takeFromGoldStash(10);
            village.CalculateVillageGold();
            Assert.That(village.Gold, Is.EqualTo(90));

            // More gold
            family1.addTOGoldStash(10);
            village.CalculateVillageGold();
            Assert.That(village.Gold, Is.EqualTo(100));

            // No gold
            int i;
            for(i=0; i<families.Count; i++) families[i].takeFromGoldStash(20);

            village.CalculateVillageGold();
            Assert.That(village.Gold, Is.EqualTo(0));

            // Negative gold -> 0
            family1.takeFromGoldStash(1);
            Assert.That(family1.GoldStash, Is.EqualTo(0));
            village.CalculateVillageGold();
            Assert.That(village.Gold, Is.EqualTo(0));
        }

        [Test]
        public void faithTests()
        {
            var myGame = new Game.Game();
            var village = myGame.Villages[0];
            var families = village.FamiliesList;
            var m1 = families[0].FamilyMembers[0];
            var m2 = families[1].FamilyMembers[0];
            var f1 = families[0].FamilyMembers[1];
            var f2 = families[1].FamilyMembers[1];

            village.CalculateAverageVillageFaith();
            Assert.That(village.Faith, Is.EqualTo(100));
            // Less faith
            m1.AddOrRemoveFaith(-50); // family1 = 75% family2 = 100%
            village.CalculateAverageVillageFaith();
            Assert.That(village.Faith, Is.EqualTo(95));
            // More faith
            m1.AddOrRemoveFaith(50); // family1 = family2 = 100%
            village.CalculateAverageVillageFaith();
            Assert.That(village.Faith, Is.EqualTo(100));
            // No faith
            m1.AddOrRemoveFaith(-100);
            m2.AddOrRemoveFaith(-100);
            f1.AddOrRemoveFaith(-100);
            f2.AddOrRemoveFaith(-100);
            families[2].FamilyMembers[0].AddOrRemoveFaith(-100);
            families[2].FamilyMembers[1].AddOrRemoveFaith(-100);
            families[3].FamilyMembers[0].AddOrRemoveFaith(-100);
            families[3].FamilyMembers[1].AddOrRemoveFaith(-100);
            families[4].FamilyMembers[0].AddOrRemoveFaith(-100);
            families[4].FamilyMembers[1].AddOrRemoveFaith(-100);

            village.CalculateAverageVillageFaith();
            Assert.That(village.Faith, Is.EqualTo(0));
        }

        [Test]
        public void happinessTests()
        {
            var myGame = new Game.Game();
            var village = myGame.Villages[0];
            var families = village.FamiliesList;
            var family1 = families[0];

            Assert.That(village.CalculateAverageVillageHappiness(), Is.EqualTo(80));

            // Less happiness for one family
            family1.FamilyMembers[0].AddOrRemoveHappiness(-50);
            family1.FamilyMembers[1].AddOrRemoveHappiness(-50);
            Assert.That(village.CalculateAverageVillageHappiness(), Is.EqualTo(70));

            // More happiness for one family
            family1.FamilyMembers[0].AddOrRemoveHappiness(100);
            family1.FamilyMembers[1].AddOrRemoveHappiness(100);
            Assert.That(village.CalculateAverageVillageHappiness(), Is.EqualTo(84));
        }

        [Test]
        public void offeringsTests()
        {
            var myGame = new Game.Game();
            var village = myGame.Villages[0];
            var families = village.FamiliesList;
            var family1 = families[0];

            // Default
            Assert.That(myGame.Offerings, Is.EqualTo(100));
            Assert.That(village.OfferingsPointsPerTick, Is.EqualTo(1));

            // Modify gold take per tick
            village.SetOfferingsPoints(5);
            Assert.That(village.OfferingsPointsPerTick, Is.EqualTo(5));

            // Take gold in families and add offering to player
            Assert.That(family1.GoldStash, Is.EqualTo(20));
            Assert.That(myGame.Offerings, Is.EqualTo(100));
            village.TransformGoldToOfferingsPoints(village.OfferingsPointsPerTick);
            Assert.That(family1.GoldStash, Is.EqualTo(15));
            Assert.That(myGame.Offerings, Is.EqualTo(125));
        }
    }
}