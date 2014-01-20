using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    class TestFest
    {
        [Test]
        public void fest()
        {
            var game = new Game.Game();
            //new Game.SamhainFest(game.Villages[0]);
            new Game.Buildings.PartyRoom(game.Villages[0]);
            game.Villages[0].FestStart();
            int argent = game.Villages[0].FamiliesList[0].GoldStash;
            int argent2 = argent - game.Villages[0].FamiliesList[0].FamilyMembers.Count;
            Game.Villager fa=game.Villages[0].FamiliesList[0].Father;
            Assert.That(fa.ActivityStatus == Game.ActivityStatus.PARTYING);
            Assert.That(!fa.IsWorking);
            game.NextStep();
            Assert.AreEqual(argent2, game.Villages[0].FamiliesList[0].GoldStash);


            for (int i = 0; i < 20; i++)
            {
                game.NextStep();
            }
            Assert.That(game.Villages[0].FamiliesList[0].Father.ActivityStatus == Game.ActivityStatus.NONE);
        }
    }
}
