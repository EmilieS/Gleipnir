using Game;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    class TestVillageFest
    {

        [Test]
        public void TestStatuschanged()
        {
            var MyGame = new Game.Game();
            var village = MyGame.Villages[0];
            Family family = village.FamiliesList[0];
            Villager mother = family.Mother;
            Villager father = family.Father;
            Family family2 = MyGame.Villages[0].FamiliesList[1];
            Villager mother2 = family2.Mother;
            Villager father2 = family2.Father;

            father.SetHeretic();
            mother.SetHeretic();

            SamhainFest fest = new SamhainFest();
            fest.ActOnvillagers(village);

            Assert.That((mother2.ActivityStatus == ActivityStatus.PUSHINGOUT));
            Assert.That((father2.ActivityStatus == ActivityStatus.PUSHINGOUT));
            Assert.That((father.ActivityStatus != ActivityStatus.PUSHINGOUT));
            Assert.That((mother.ActivityStatus != ActivityStatus.PUSHINGOUT));
        }
        [Test]
        public void TestRessourcesEvolution()
        {
            var MyGame = new Game.Game();
            var village = MyGame.Villages[0];
            Family family = village.FamiliesList[0];
            Villager mother = family.Mother;
            Villager father = family.Father;
            Family family2 = MyGame.Villages[0].FamiliesList[1];
            Villager mother2 = family2.Mother;
            Villager father2 = family2.Father;

            double primaryHappiness1 = father2.Happiness;
            double primaryHappiness2 = father.Happiness;
            double primaryHappiness3 = mother2.Happiness;
            double primaryHappiness4 = mother.Happiness;
            double primaryFaith1 = father2.Faith;
            double primaryFaith2 = mother2.Faith;
            double primaryFaith3 = father.Faith;
            double primaryFaith4 = mother.Faith;



            father.SetHeretic();
            mother.SetHeretic();

            SamhainFest fest = new SamhainFest();
            fest.ActOnvillagers(village);



            //test happiness
            Assert.That(mother.Happiness == primaryHappiness4);
            Assert.That(father.Happiness == primaryHappiness2);
            Assert.That(father2.Happiness == primaryHappiness1 + 15);
            Assert.That(mother2.Happiness == primaryHappiness3 + 15);

            //test Faith 
            Assert.That(mother.Faith == primaryFaith4);
            Assert.That(father.Faith == primaryFaith3);
            Assert.That(father2.Faith == primaryFaith1 + RessourceAdded(primaryFaith1));
            Assert.That(mother2.Faith == primaryFaith2 + RessourceAdded(primaryFaith2));
        }

        public double RessourceAdded(double primaryRessource)
        {
            double delta = 15 - (100 - primaryRessource);
            delta = 15 - delta;
            if (delta >= 0) return delta;
            else return 15;
        }
    }
}
