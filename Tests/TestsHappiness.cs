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
            var MyGame = new Game.Game();
            var village = MyGame.Villages[0];
            Family family = MyGame.Villages[0].FamiliesList[0];
            Villager mother = family.Mother;
            Villager father = family.Father;


            Assert.That(mother.ParentFamily == family);
            Assert.That(mother.GetFiance().GetFiance() == mother);
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
            //mother.DieOrIsAlive();
            MyGame.NextStep();
            MyGame.NextStep();
            MyGame.NextStep();
            Assert.That(family.FamilyMembers.Count == 2);
            for (int i = 0; i < family.FamilyMembers.Count; i++)
            {
                Assert.That(family.FamilyMembers[i].Happiness == 75, "The happiness his not 75");
            }
            Assert.That(family.HappinessAverage() == 75, "family average is not 75");
        }
        
        [Test]
        public void familyRichOrPoor()//totalpop & totalgold don't work yet
        {
            var MyGame = new Game.Game();
            Assert.That(MyGame.TotalPop == 10);

            var village = MyGame.Villages[0];
            Family family = MyGame.Villages[0].FamiliesList[0];
            Villager mother = family.Mother;
            Villager father = family.Father;

            Assert.That(mother.ParentFamily == family);
            Assert.That(mother.GetFiance().GetFiance() == mother);
            Assert.That(family.Mother == mother && family.Father == father);
            Assert.That(mother.StatusInFamily == Status.MARRIED && mother.StatusInFamily == Status.MARRIED);
            Assert.AreEqual(10, MyGame.TotalPop);
            Assert.AreEqual(20, family.GoldStash);
            Assert.AreEqual(100, MyGame.TotalGold);// 5 families, 20 gold per family
            family.addTOGoldStash(100);
            Assert.That(family.GoldStash == 120);
            Assert.That(MyGame.TotalPop == 10);
            Assert.AreEqual(200, MyGame.TotalGold);
            MyGame.NextStep();
            Assert.AreEqual(200, MyGame.LastTotalGold);

            Villager kid = family.newFamilyMember();
            Assert.That(family.HappinessAverage() == 80, "family average is not 80");
            Assert.That(MyGame.TotalPop == 11);
            MyGame.NextStep();
            Assert.That(family.HappinessAverage() == 80, "family average is not 80");

            family.addTOGoldStash(3000-120);
            MyGame.NextStep();
            Assert.AreEqual(3080, MyGame.TotalGold);
            Assert.AreEqual(1000, family.LastGoldStash / family.FamilyMembers.Count);
            Assert.AreEqual(280, MyGame.LastTotalGold / MyGame.TotalPop);
            Assert.AreEqual(80.1, family.HappinessAverage(), "family average is not 80.1");

            family.takeFromGoldStash(2940);
            MyGame.Villages[0].FamiliesList[1].addTOGoldStash(2940+2000);
            while (MyGame.TotalPop < 100)
            {
                MyGame.Villages[0].FamiliesList[1].newFamilyMember();
            }
            MyGame.NextStep();
            Assert.AreEqual(60, family.LastGoldStash);
            Assert.AreEqual(20, family.LastGoldStash / family.FamilyMembers.Count);
            Assert.AreEqual(5080, MyGame.LastTotalGold);
            double isequalto = 50.8;
            Assert.AreEqual(isequalto, MyGame.LastTotalGold / MyGame.TotalPop);
            Assert.AreEqual(3, family.FamilyMembers.Count());
            Assert.AreEqual(80, family.HappinessAverage(), "family average is not 80");
            MyGame.NextStep();
            Assert.That(family.HappinessAverage() == 79.9, "family average is not 79.9");
        }
    }
}
