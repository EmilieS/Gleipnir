using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Game;
using System.Timers;

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

                mother.Kill();
                mother.DieOrIsAlive();

                Assert.That(family.Mother == null);

                Assert.That(mother.Fiance.Fiance == null);
                Assert.That(family.Father.Fiance == null);
                Assert.That(father.StatusInFamily == Status.MARRIED);
            }




            [Test]
            public void Fiance()
            {
                Villager girl = new Villager();
                girl.Gender = Genders.FEMALE;
                Villager guy1 = new Villager();
                Villager guy2 = new Villager();
                guy1.Gender = Genders.MALE;
                guy2.Gender = Genders.MALE;

                Assert.That(girl.StatusInFamily == Status.SINGLE);

                girl.Fiance = guy1;
                Assert.That(girl.StatusInFamily == Status.ENGAGED);

                girl.Fiance = guy2;
                Assert.That(girl.StatusInFamily == Status.ENGAGED);

                guy1.Kill();
                guy1.DieOrIsAlive();
                Assert.That(girl.StatusInFamily == Status.ENGAGED);
                Assert.That(girl.Fiance==guy2);

                guy2.Kill();
                guy2.DieOrIsAlive();
                Assert.That(girl.StatusInFamily == Status.SINGLE);
                Assert.That(girl.Fiance == null);

                
            }

            [Test]
            public void NewFamily()
            {
                /*var MyGame=*/ new Game.Game();
                Villager motherf1 = new Villager();
                Villager fatherf1 = new Villager();
                motherf1.Gender = Genders.FEMALE;
                motherf1.Fiance = fatherf1;
                fatherf1.Fiance = motherf1;
                Family family1 = new Family(motherf1, fatherf1);

                family1.addTOGoldStash(100);

                Villager girlf1=family1.newFamilyMember();
                girlf1.Gender = Genders.FEMALE;

                Villager motherf2 = new Villager();
                Villager fatherf2 = new Villager();
                motherf2.Gender = Genders.FEMALE;
                motherf2.Fiance = fatherf2;
                fatherf2.Fiance = motherf2;
                Family family2 = new Family(motherf2, fatherf2);

                family2.addTOGoldStash(100);

                Villager boyf2 = family2.newFamilyMember();
                boyf2.Gender = Genders.MALE;

                Assert.That(family2.FamilyMembers.Contains(boyf2));

                Family family3 = new Family(girlf1, boyf2);
                Assert.That(family3.GoldStash == 20);
                Assert.That(family1.GoldStash == 90);
                Assert.That(family2.GoldStash == 90);
                Assert.That(!family2.FamilyMembers.Contains(boyf2));
                Assert.That(family3.FamilyMembers.Contains(boyf2));
               




                Villager girl2f1 = family1.newFamilyMember();
                girl2f1.Gender = Genders.FEMALE;

                Villager girl2f2 = family1.newFamilyMember();
                girl2f2.Gender = Genders.FEMALE;


                Assert.Throws<InvalidOperationException>(() => new Family(girl2f1, girl2f2), "gender issue!");

                Villager boy2f1 = family1.newFamilyMember();
                boy2f1.Gender = Genders.MALE;
                Assert.Throws<InvalidOperationException>(() => new Family(girl2f1, boy2f1), "same family!");

                motherf1.Kill();
                motherf1.DieOrIsAlive();
                Assert.Throws<InvalidOperationException>(() => family1.newFamilyMember(), "missing parent");


                //TODO job check.

            }

            [Test]
            public void EngagementTest()
            {
                /*var MyGame=*/
                new Game.Game();
                Villager motherf1 = new Villager();
                Villager fatherf1 = new Villager();
                motherf1.Gender = Genders.FEMALE;
                motherf1.Fiance = fatherf1;
                fatherf1.Fiance = motherf1;
                Family family1 = new Family(motherf1, fatherf1);

                Villager motherf2 = new Villager();
                Villager fatherf2 = new Villager();
                motherf2.Gender = Genders.FEMALE;
                motherf2.Fiance = fatherf2;
                fatherf2.Fiance = motherf2;
                Family family2 = new Family(motherf2, fatherf2);

                Villager kidf1;
                do
                {
                    kidf1 = family1.newFamilyMember();
                } while (kidf1.Gender != Genders.MALE);

                Villager kidf2;

                do
                {
                    kidf2=family2.newFamilyMember();
                }while (kidf1.Gender == kidf2.Gender);
                Assert.That(kidf1.StatusInFamily == Status.ENGAGED);
                Assert.That(kidf2.StatusInFamily == Status.ENGAGED);

                

            }
            
    }
}
