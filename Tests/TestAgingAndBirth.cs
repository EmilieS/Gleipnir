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
    class TestAgingAndBirth
    {
        [Test]
        public void Birth()
        {
            var MyGame = new Game.Game();
            Assert.AreEqual(10, MyGame.TotalPop);
            for (int i = 0; i < 12*18; i++)
            {
                MyGame.NextStep();
            }
            Assert.AreEqual(15, MyGame.TotalPop);
            Assert.AreEqual(5, MyGame.Villages[0].FamiliesList.Count);

            for (int i = 0; i < 11; i++)
            {
                MyGame.NextStep();
            }
            int j = 0;
            Family family1 = MyGame.Villages[0].CreateFamilyFromScratch();
            Family family2 = MyGame.Villages[0].CreateFamilyFromScratch();
            Family family3 = MyGame.Villages[0].CreateFamilyFromScratch();
            while (MyGame.Villages[0].FamiliesList.Count == 8)
            {
                MyGame.NextStep();
                j++;
            }
            //Assert.AreEqual(15, MyGame.TotalPop);
            //Assert.AreEqual(1, j);
           //Assert.AreEqual(4, MyGame.SingleMen.Count);
            //Assert.AreEqual(6, MyGame.Villages[0].FamiliesList.Count);
        }
    }
}
