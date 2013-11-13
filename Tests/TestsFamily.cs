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
                
                Assert.That(1+1==2);

            }

            [Test]
            public void Death()
            {
                var MyGame = new Game.Game();
                Family family = MyGame.Villages[0].CreateFamilyFromScratch();

                Assert.That(family.Mother.Fiance.Fiance == family.Mother);
                Assert.That(family.Mother.ParentFamily == family);
                Assert.That(family.Mother == family.Mother && family.Father == family.Father);
                Assert.That(family.Mother.StatusInFamily == Status.MARRIED && family.Mother.StatusInFamily == Status.MARRIED);
                Assert.That(family.FamilyMembers.Count == 2);

                Villager mother=family.Mother;
                family.Mother.Kill();
                family.Mother.DieOrIsAlive();
                MyGame.CloseStep();


                Assert.That(family.FamilyMembers.Count == 1);
                Assert.That(family.Mother == null);

                Assert.That(mother.Fiance.Fiance == null);
                Assert.That(family.Father.Fiance == null);
                Assert.That(family.Father.StatusInFamily == Status.MARRIED);
            }


            
            
            [Test]
            public void Fiance()
            {
                var MyGame = new Game.Game();
                Family family1 = MyGame.Villages[0].CreateFamilyFromScratch();
                Family family2 = MyGame.Villages[0].CreateFamilyFromScratch();

                Villager girlf1;
                do
                {
                girlf1=family1.newFamilyMember();
                }while(girlf1.Gender!=Genders.FEMALE);
                Villager guy1f2;
                do
                {
                guy1f2=family1.newFamilyMember();
                }while(guy1f2.Gender!=Genders.MALE);

                Villager guy2f2;
                do
                {
                guy2f2=family1.newFamilyMember();
                }while(guy2f2.Gender!=Genders.MALE);

                Assert.That(girlf1.StatusInFamily == Status.SINGLE);

                girlf1.Fiance = guy1f2;//hmmm accessibility?
                Assert.That(girlf1.StatusInFamily == Status.ENGAGED);

                girlf1.Fiance = guy2f2;
                Assert.That(girlf1.StatusInFamily == Status.ENGAGED);

                guy1f2.Kill();
                guy1f2.DieOrIsAlive();
                MyGame.CloseStep();

                 Assert.That(girlf1.StatusInFamily == Status.ENGAGED);
                 Assert.That(girlf1.Fiance==guy2f2);

                 guy2f2.Kill();
                 guy2f2.DieOrIsAlive();
                 MyGame.CloseStep();

                 Assert.That(girlf1.StatusInFamily == Status.SINGLE);
                 Assert.That(girlf1.Fiance == null);

                 
            }
/*
            [Test]
            public void NewFamily()
            {
                var MyGame = new Game.Game();
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
                fatherf1.CloseStep();
                motherf1.CloseStep();
                family1.CloseStep();
                Assert.Throws<InvalidOperationException>(() => family1.newFamilyMember(), "missing parent");


                //TODO job check.

            }

            [Test]
            public void EngagementTest()
            {
                var MyGame= new Game.Game();
                var village = new Village(MyGame);
                Villager motherf1 = new Villager();
                Villager fatherf1 = new Villager();
                motherf1.Gender = Genders.FEMALE;
                motherf1.Fiance = fatherf1;
                fatherf1.Fiance = motherf1;
                Family family1 = new Family(motherf1, fatherf1, village);

                Villager motherf2 = new Villager();
                Villager fatherf2 = new Villager();
                motherf2.Gender = Genders.FEMALE;
                motherf2.Fiance = fatherf2;
                fatherf2.Fiance = motherf2;
                Family family2 = new Family(motherf2, fatherf2, village);
                Assert.That(family1.OwnerVillage != null, "family1.OwnerVillage is Null");
                Assert.That(family1.OwnerVillage.ThisGame != null, "family1.OwnerVillage.ThisGame is Null");

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

            }*/
            
    }
}
