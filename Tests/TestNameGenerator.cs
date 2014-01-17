using Game;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    class TestNameGenerator
    {
        [Test]
        public void FamilyName()
        {
            var myGame = new Game.Game();
            var village = myGame.Villages[0];
            var families = village.FamiliesList;

            // Check families ever created
            for (int i = 1; i < 5; i++)
            {
                Assert.That(families[i].Name, Is.Not.Empty);
                if (i == 0)
                    Assert.That(families[i].Name, Is.Not.EqualTo(families[i - 1].Name));
                else
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (j != i)
                            Assert.That(families[i].Name, Is.Not.EqualTo(families[j].Name));
                    }
                }
            }

            // Add new family
            village.CreateFamilyFromScratch();
            for (int i = 0; i < 5; i++)
            {
                Assert.That(families[5].Name, Is.Not.EqualTo(families[i].Name));
            }
        }

        [Test]
        public void FirstName()
        {
            var myGame = new Game.Game();
            var village = myGame.Villages[0];
            var families = village.FamiliesList;
            var f = families[0];

            // Check family members' name
            Assert.That(f.FamilyMembers[0].FirstName, Is.Not.Empty);
            Assert.That(f.FamilyMembers[1].FirstName, Is.Not.Empty);
            Assert.That(f.FamilyMembers[1].FirstName, Is.Not.EqualTo(f.FamilyMembers[0]));

            // Add new villager in family
            f.NewFamilyMember();
            Assert.That(f.FamilyMembers[2].FirstName, Is.Not.Empty);
            Assert.That(f.FamilyMembers[2].FirstName, Is.Not.EqualTo(f.FamilyMembers[0]));
            Assert.That(f.FamilyMembers[2].FirstName, Is.Not.EqualTo(f.FamilyMembers[1]));
        }
    }
}