using Game;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{/*
    [TestFixture]
    class TestsVillage
    {
        [Test]
        public void familyTests()
        {
            var myGame = new Game.Game();
            List<Family> families = new List<Family>();
            Village village = new Village(families, myGame);

            #region CreatedFamilies
            Villager m1 = new Villager();
            m1.Gender = Genders.FEMALE;
            Villager f1 = new Villager();
            f1.Gender = Genders.MALE;
            Family family1 = new Family(m1, f1);
            family1.addTOGoldStash(100);

            Villager m2 = new Villager();
            m2.Gender = Genders.FEMALE;
            Villager f2 = new Villager();
            f2.Gender = Genders.MALE;
            Family family2 = new Family(m2, f2);
            family2.addTOGoldStash(100);
            #endregion

            // Add new familly
            Assert.That(village.FamiliesList.Count, Is.EqualTo(0));
            village.AddFamily(family1);
            Assert.That(village.FamiliesList.Count, Is.EqualTo(1));

            // Try add the same family
            Assert.Throws<InvalidOperationException>(() => village.AddFamily(family1), "Add Family Issue!");
            Assert.That(village.FamiliesList.Count, Is.EqualTo(1));

            // Add more families
            village.AddFamily(family2);
            Assert.That(village.FamiliesList.Count, Is.EqualTo(2));

            // Remove families
            village.RemoveFamily(family1);
            Assert.That(village.FamiliesList.Count, Is.EqualTo(1));

            // Try remove the family ever removed
            Assert.Throws<InvalidOperationException>(() => village.RemoveFamily(family1), "Remove family Issue!");
            Assert.That(village.FamiliesList.Count, Is.EqualTo(1));
        }

        [Test]
        public void goldTests()
        {
            var myGame = new Game.Game();
            List<Family> families = new List<Family>();
            Village village = new Village(families, myGame);

            #region CreatedFamilies
            Villager m1 = new Villager();
            m1.Gender = Genders.FEMALE;
            Villager f1 = new Villager();
            f1.Gender = Genders.MALE;
            Family family1 = new Family(m1, f1);
            family1.addTOGoldStash(100);
            village.AddFamily(family1);

            Villager m2 = new Villager();
            m2.Gender = Genders.FEMALE;
            Villager f2 = new Villager();
            f2.Gender = Genders.MALE;
            Family family2 = new Family(m2, f2);
            family2.addTOGoldStash(100);
            village.AddFamily(family2);
            #endregion

            village.CalculateVillageGold();
            Assert.That(village.Gold, Is.EqualTo(200));
            // Less gold
            family1.takeFromGoldStash(50);
            village.CalculateVillageGold();
            Assert.That(village.Gold, Is.EqualTo(150));
            // More gold
            family1.addTOGoldStash(50);
            village.CalculateVillageGold();
            Assert.That(village.Gold, Is.EqualTo(200));
            // No gold
            family1.takeFromGoldStash(100);
            family2.takeFromGoldStash(100);
            village.CalculateVillageGold();
            Assert.That(village.Gold, Is.EqualTo(0));
            // Negative gold -> 0
            family1.takeFromGoldStash(1);
            village.CalculateVillageGold();
            Assert.That(village.Gold, Is.EqualTo(0));
        }

        [Test]
        public void faithTests()
        {
            var myGame = new Game.Game();
            List<Family> families = new List<Family>();
            Village village = new Village(families, myGame);

            #region CreatedFamilies
            Villager m1 = new Villager();
            m1.Gender = Genders.FEMALE;
            Villager f1 = new Villager();
            f1.Gender = Genders.MALE;
            Family family1 = new Family(m1, f1);
            family1.addTOGoldStash(100);
            village.AddFamily(family1);

            Villager m2 = new Villager();
            m2.Gender = Genders.FEMALE;
            Villager f2 = new Villager();
            f2.Gender = Genders.MALE;
            Family family2 = new Family(this, m2, f2);
            family2.addTOGoldStash(100);
            village.AddFamily(family2);
            #endregion

            village.CalculateAverageVillageFaith();
            Assert.That(village.Faith, Is.EqualTo(100));
            // Less faith
            m1.AddOrRemoveFaith(-50); // family1 = 75% family2 = 100%
            village.CalculateAverageVillageFaith();
            Assert.That(village.Faith, Is.EqualTo(87.5));
            // More faith
            m1.AddOrRemoveFaith(50); // family1 = family2 = 100%
            village.CalculateAverageVillageFaith();
            Assert.That(village.Faith, Is.EqualTo(100));
            // No faith
            m1.AddOrRemoveFaith(-100);
            m2.AddOrRemoveFaith(-100);
            f1.AddOrRemoveFaith(-100);
            f2.AddOrRemoveFaith(-100);
            village.CalculateAverageVillageFaith();
            Assert.That(village.Faith, Is.EqualTo(0));
        }
    }*/
}
