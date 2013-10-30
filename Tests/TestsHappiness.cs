using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Game;

namespace Tests
{
    [TestFixture]
    class TestsHappiness
    {
        [Test]
        public void death()
        {
            Villager mother = new Villager();
            Villager father = new Villager();
            mother.Gender = Genders.FEMALE;
            mother.Fiance = father;
            father.Fiance = mother;
            Family family = new Family(mother, father);

            mother.ParentFamily = family;
            Assert.That(mother.Fiance.Fiance == mother);
            Assert.That(family.Mother.ParentFamily == family);
            Assert.That(family.Mother == mother && family.Father == father);
            Assert.That(mother.StatusInFamily == Status.MARRIED && mother.StatusInFamily == Status.MARRIED);

            Villager kid=family.newFamilyMember();

            for (int i = 0; i < family.FamilyMembers.Count; i++)
            {
                Assert.That(family.FamilyMembers[i].Happiness == 80, "The happiness his not 80");
            }
            Assert.That(family.HappinessAverage() == 80, "family average is not 80");
            Assert.That(family.FamilyMembers.Count == 3);
            mother.Kill();
            mother.DieOrIsAlive();
            Assert.That(family.FamilyMembers.Count == 2);
            for (int i = 0; i < family.FamilyMembers.Count; i++)
            {
                Assert.That(family.FamilyMembers[i].Happiness == 75, "The happiness his not 75");
            }
            Assert.That(family.HappinessAverage() == 75, "family average is not 75");
        }

    }
}
