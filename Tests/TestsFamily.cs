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
    public class TestsFamily
    {
            [Test]
            public void dummy()
            {
                Villager villager = new Villager();
                Assert.That(villager.Gender == Genders.MALE);

            }

            [Test]
            public void Death()
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
                Assert.That(family.Mother == mother && family.Father== father);
                Assert.That(mother.StatusInFamily == Status.MARRIED && mother.StatusInFamily == Status.MARRIED);

                mother.DieOrIsAlive();

                Assert.That(family.Mother == null);

                //Assert.That(family.Father.Fiance == null);



            }

    }
}
