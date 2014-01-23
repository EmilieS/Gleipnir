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
            Assert.That(1 + 1 == 2);
        }

        [Test]
        public void Death()
        {
            var MyGame = new Game.Game();
            Family family = MyGame.Villages[0].CreateFamilyFromScratch();

            Assert.That(family.Mother.GetFiance().GetFiance() == family.Mother);
            Assert.That(family.Mother.ParentFamily == family);
            Assert.That(family.Mother == family.Mother && family.Father == family.Father);
            Assert.That(family.Mother.StatusInFamily == Status.MARRIED && family.Mother.StatusInFamily == Status.MARRIED);
            Assert.That(family.FamilyMembers.Count == 2);

            Villager mother = family.Mother;
            family.Mother.Kill();
                //family.Mother.DieOrIsAlive();
                MyGame.NextStep();

            Assert.That(family.FamilyMembers.Count == 1);
            Assert.That(family.Mother == null);
            Assert.Throws<InvalidOperationException>(() => mother.GetFiance(), "villager is mourning!");
            Assert.Throws<InvalidOperationException>(() => family.Father.GetFiance(), "villager is mourning!");
            Assert.That(family.Father.StatusInFamily == Status.MOURNING);

                MyGame.NextStep();
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
                girlf1 = family1.NewFamilyMember();
            } while (girlf1.Gender != Genders.FEMALE);

            Assert.That(girlf1.StatusInFamily == Status.SINGLE);
            Villager guy1f2;

            do
            {
                guy1f2 = family1.NewFamilyMember();
            } while (guy1f2.Gender != Genders.MALE);

            Villager guy2f2;

            do
            {
                guy2f2 = family1.NewFamilyMember();
            } while (guy2f2.Gender != Genders.MALE);

            Assert.That(girlf1.StatusInFamily == Status.SINGLE);

            girlf1.Engage(guy1f2);//hmmm accessibility?
            Assert.That(girlf1.StatusInFamily == Status.ENGAGED);
            Assert.That(!MyGame.SingleMen.Contains(guy1f2));

            guy1f2.Kill();
                //guy1f2.DieOrIsAlive();
                MyGame.NextStep();//
                MyGame.NextStep();
                MyGame.NextStep();
            Assert.That(girlf1.StatusInFamily == Status.SINGLE, "is not single!");
            Assert.Throws<InvalidOperationException>(() => girlf1.GetFiance(), "is single");

            girlf1.Engage(guy2f2);
            Assert.That(girlf1.StatusInFamily == Status.ENGAGED);
            Assert.That(girlf1.GetFiance() == guy2f2);

            Assert.That(guy2f2.StatusInFamily == Status.ENGAGED);
            Assert.That(girlf1.GetFiance() == guy2f2);
            Assert.That(guy2f2.GetFiance() == girlf1);

            guy2f2.Kill();
                 //guy2f2.DieOrIsAlive();
                 MyGame.NextStep();

            Assert.That(girlf1.StatusInFamily == Status.SINGLE);
            Assert.Throws<InvalidOperationException>(() => girlf1.GetFiance(), "fiance is single");

            Assert.That(!MyGame.SingleMen.Contains(guy1f2));
            Assert.That(!MyGame.SingleMen.Contains(guy2f2));
        }

        [Test]
        public void NewFamily()
        {
            var MyGame = new Game.Game();
            Family family1 = MyGame.Villages[0].CreateFamilyFromScratch();
            Family family2 = MyGame.Villages[0].CreateFamilyFromScratch();

            family1.TakeFromGoldStash(100);
            Assert.That(family1.GoldStash, Is.EqualTo(0));
            family1.AddToGoldStash(100);
            Assert.That(family1.GoldStash, Is.EqualTo(100));
            family2.TakeFromGoldStash(100);
            Assert.That(family2.GoldStash, Is.EqualTo(0));
            family2.AddToGoldStash(100);
            Assert.That(family2.GoldStash, Is.EqualTo(100));

            Villager girlf1;
            do
            {
                girlf1 = family1.NewFamilyMember();
            } while (girlf1.Gender != Genders.FEMALE);

            Assert.That(girlf1.StatusInFamily == Status.SINGLE);
            Villager boyf2;

            do
            {
                boyf2 = family2.NewFamilyMember();
            } while (boyf2.Gender != Genders.MALE);

            Assert.That(family2.FamilyMembers.Contains(boyf2));

            Family family3 = MyGame.Villages[0].CreateFamily(girlf1, boyf2);
            Assert.That(family3 != null);
            Assert.That(family3.GoldStash == 20);
            Assert.That(family1.GoldStash == 90);
            Assert.That(family2.GoldStash == 90);
            Assert.That(!family2.FamilyMembers.Contains(boyf2));
            Assert.That(family3.FamilyMembers.Contains(boyf2));

            //maybe the single list needs to be cleaned.
            //TODO : check that when a guy dies, he is out of the single list.
            Villager girl2f1;
            do
            {
                girl2f1 = family1.NewFamilyMember();
            } while (girl2f1.Gender != Genders.FEMALE);

            Villager girl2f2;
            do
            {
                girl2f2 = family2.NewFamilyMember();
            } while (girl2f2.Gender != Genders.FEMALE);
                MyGame.NextStep();

            Action Totest = delegate() { MyGame.Villages[0].CreateFamily(girl2f1, girl2f2); };

            Assert.Throws<InvalidOperationException>(() => MyGame.Villages[0].CreateFamily(girl2f1, girl2f2), "gender issue!");
            Assert.That(!MyGame.SingleMen.Contains(family1.Father));
                MyGame.NextStep();

            Villager boy2f1;
            do
            {
                boy2f1 = family1.NewFamilyMember();
            } while (boy2f1.Gender != Genders.MALE);

            Assert.Throws<InvalidOperationException>(() => MyGame.Villages[0].CreateFamily(girl2f1, boy2f1), "same family!");

            family1.Mother.Kill();
                //family1.Mother.DieOrIsAlive();
                MyGame.NextStep();

            Assert.Throws<InvalidOperationException>(() => family1.NewFamilyMember(), "missing parent");
        }

        [Test]
        public void EngagementTest()
        {
            var MyGame = new Game.Game();
            var village = MyGame.Villages[0];
            Family family1 = MyGame.Villages[0].FamiliesList[0];
            Villager motherf1 = family1.Mother;
            Villager fatherf1 = family1.Father;

            Family family2 = MyGame.Villages[0].FamiliesList[1];
            Villager motherf2 = family2.Mother;
            Villager fatherf2 = family2.Father;

            Assert.That(family1.OwnerVillage != null, "family1.OwnerVillage is Null");
            Assert.That(family1.OwnerVillage.Game != null, "family1.OwnerVillage.Game is Null");

            Villager kidf1;
            do
            {
                kidf1 = family1.NewFamilyMember();
            } while (kidf1.Gender != Genders.MALE);

            Villager kidf2;
            do
            {
                kidf2 = family2.NewFamilyMember();
            } while (kidf1.Gender == kidf2.Gender);

            Assert.That(kidf1.StatusInFamily == Status.ENGAGED);
            Assert.That(kidf2.StatusInFamily == Status.ENGAGED);
        }
    }
}
