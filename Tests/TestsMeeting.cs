using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;

namespace Tests
{
    [TestFixture]
    class TestsMeeting
    {
            
        [Test]
        public void TestChangingActivity()
        {
            var MyGame = new Game.Game();
            var village = MyGame.Villages[0];
            Family family = village.FamiliesList[0];
            Villager mother = family.Mother;
            Villager father = family.Father;
            Family family2 = village.FamiliesList[1];
            Villager mother2 = family2.Mother;
            Villager father2 = family2.Father;
            var meeting = new Meeting(family2);

            meeting.Convocate();

            Assert.That(mother2.ActivityStatus == ActivityStatus.CONVOCATED);
            Assert.That(father2.ActivityStatus == ActivityStatus.CONVOCATED);
            var meeting2 = new Meeting(family);
            meeting2.Convocate();

            Assert.That((mother2.ActivityStatus & ActivityStatus.CONVOCATED) == 0);
            Assert.That((father2.ActivityStatus & ActivityStatus.CONVOCATED) == 0);

            Assert.That(mother.ActivityStatus == ActivityStatus.CONVOCATED);
            Assert.That(father.ActivityStatus == ActivityStatus.CONVOCATED);
            

        }
        [Test]
        public void TestConvocationReleaser()
        {
            var MyGame = new Game.Game();
            var village = MyGame.Villages[0];
            Family family = village.FamiliesList[0];
            Villager mother = family.Mother;
            Villager father = family.Father;

            var meeting = new Meeting(family);

            meeting.Convocate();

            Assert.That(mother.ActivityStatus == ActivityStatus.CONVOCATED);
            Assert.That(father.ActivityStatus == ActivityStatus.CONVOCATED);

            meeting.ReleaseConvocated(meeting.ActualConvocated);

            Assert.That((mother.ActivityStatus & ActivityStatus.CONVOCATED) == 0);
            Assert.That((father.ActivityStatus & ActivityStatus.CONVOCATED) == 0);
        }
    }
}