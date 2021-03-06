﻿using System;
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
            foreach (Family f in village.FamiliesList)
            {
                foreach (Villager v in f.FamilyMembers)
                {
                    if (v.Job != null)
                    {
                        v.Job.RemovePerson2(v);
                    }
                }
            }
            Villager mother = family.Mother;
            Villager father = family.Father;


            Assert.That(mother.ParentFamily == family);
            Assert.That(mother.GetFiance().GetFiance() == mother);
            Assert.That(family.Mother.ParentFamily == family);
            Assert.That(family.Mother == mother && family.Father == father);
            Assert.That(mother.StatusInFamily == Status.MARRIED && mother.StatusInFamily == Status.MARRIED);

            Villager kid=family.NewFamilyMember();

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
            /*double tmp;
            for (int i = 0; i < family.FamilyMembers.Count; i++)
            {
                tmp = family.FamilyMembers[i].Happiness;
                Assert.AreEqual(75, tmp, "The happiness his not 75");
            }*/
            //Assert.AreEqual(75, family.HappinessAverage(), "family average is not 75");
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
            family.AddToGoldStash(110);
            Assert.That(family.GoldStash == 130);
            Assert.That(MyGame.TotalPop == 10);
            Assert.AreEqual(210, MyGame.TotalGold);//4families 20gold, 1 family 130
            Assert.AreEqual(80, family.HappinessAverage(), "family average is not 80");
            foreach (Family f in village.FamiliesList)
            {
                foreach (Villager v in f.FamilyMembers)
                {
                    if (v.Job != null)
                    {
                        v.Job.RemovePerson2(v);
                    }
                }
            }
            MyGame.NextStep();//-1 gold per villager
            Assert.AreEqual(128, family.GoldStash);//2villagers in family128
            Assert.AreEqual(200, MyGame.TotalGold);//10villagers200
            Assert.AreEqual(80.1, family.HappinessAverage(), "family average is not 80,1");
            Assert.AreEqual(200, MyGame.LastTotalGold);//200

            Villager kid = family.NewFamilyMember();
            Assert.AreEqual(80.1,family.HappinessAverage(), "family average is not 80,1");
            Assert.That(MyGame.TotalPop == 11);
            MyGame.NextStep();//4 other families of 2.each family has 20-3*2
            Assert.That(family.HappinessAverage() == 80.1, "family average is not 80,1");
            Assert.AreEqual(125, family.GoldStash);//3villagers in family125
            Assert.AreEqual(189, MyGame.TotalGold);//11villagers189

            family.AddToGoldStash(3003-125);
            MyGame.NextStep();//3villagers in family
            Assert.AreEqual(3000, family.GoldStash);//3000
            Assert.AreEqual(3056, MyGame.TotalGold);//4 other families of 2.each family has 20-2*2*2 3056
            //double nb1 = 3056;
            //double nb2 = 11;
            //double totest = nb1 / nb2;//278
            Assert.AreEqual(1000, family.LastGoldStash / family.FamilyMembers.Count);//1000
            Assert.AreEqual(277, MyGame.LastTotalGold / MyGame.TotalPop);//..HAHAHA...YOU KIDDING ME?
            //Assert.AreEqual(80.2*3/3, family.HappinessAverage(), "family average is not 80.2");//..HAHAHA...

            family.TakeFromGoldStash(2937);
            Assert.AreEqual(14, MyGame.Villages[0].FamiliesList[1].LastGoldStash);//14
            MyGame.Villages[0].FamiliesList[1].AddToGoldStash(1255+91-14+36+3);
            /*while (MyGame.TotalPop < 100)
            {
                MyGame.Villages[0].FamiliesList[1].newFamilyMember();
            }
            MyGame.NextStep();
            

            Assert.AreEqual(1294, MyGame.Villages[0].FamiliesList[1].LastGoldStash);//1294
            Assert.AreEqual(60, family.LastGoldStash);//60
            Assert.AreEqual(20, family.LastGoldStash / family.FamilyMembers.Count);//20
            MyGame.Villages[0].FamiliesList[1].addTOGoldStash(5000);
            Assert.AreEqual(1390, MyGame.LastTotalGold);//60+1255+12*3...(12)*3=36  1390
            Assert.AreEqual(6390, MyGame.TotalGold);//6390
            double isequalto = 13.9;//13.9
            Assert.AreEqual(isequalto, MyGame.LastTotalGold / MyGame.TotalPop);//..HAHAHA...YOU KIDDING ME?
            Assert.AreEqual(3, family.FamilyMembers.Count());
            Assert.AreEqual(80.2, family.HappinessAverage(), "family average is not 80.2");//..HAHAHA... 80.2
            //not enough now.
            //MyGame.Villages[0].FamiliesList[1].addTOGoldStash(10000);
            MyGame.NextStep();
            Assert.AreEqual( 80.1, family.HappinessAverage(), "family average is not 80.1");*/

            MyGame.NextStep();
            Assert.AreEqual(1383, MyGame.Villages[0].FamiliesList[1].LastGoldStash);//1294
            Assert.AreEqual(80.1, family.HappinessAverage(), "family average is not 80.1");
            MyGame.Villages[0].FamiliesList[1].AddToGoldStash(10000);
            MyGame.NextStep();
            Assert.AreEqual(80, family.HappinessAverage(), "family average is not 80");
        }
    }
}
