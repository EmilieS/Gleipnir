using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using NUnit.Framework;
using Game;

namespace Tests
{
    [Serializable]
    public class wall
    {
        public wall()
        {
            bricksUsed = new List<brick>();
            height = 5;
            width = 2;
            depth = 1;
        }
        public int height;
        public int width;
        public int depth;
        public List<brick> bricksUsed;
    }
    [Serializable]
    public class brick
    {
        public brick()
        {
                height = 5;
                width = 2;
                depth = 1;
        }
        public int height;
        public int width;
        public int depth;
    }
    
    [TestFixture]
    public class save
    {
        [Test]
        public void testSaveLoad()
        {
            wall wall = new wall();
            wall.depth = 20;
            wall.height = 200;
            wall.bricksUsed.Add(new brick());
            wall.bricksUsed[0].height = 20;
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("wall.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, wall);
                stream.Close();
            }
            wall.depth = 3;
            wall.height = 30;
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("wall.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                wall = (wall)formatter.Deserialize(stream);
                stream.Close();
            }
            Assert.AreEqual(20, wall.depth);
            Assert.AreEqual(200, wall.height);
            Assert.AreEqual(1, wall.bricksUsed.Count);


        }

        [Test]
        public void saveSerialize()
        {
            Game.Game g = new Game.Game();


            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("SAVED.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, g);
            stream.Close();
        }
        [Test]
        public void zloadSerialize()
        {

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("SAVED.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            Game.Game g = (Game.Game)formatter.Deserialize(stream);
            stream.Close();
        }

        [Test]
        public void saveTest()
        {
            Game.Game myGame = new Game.Game();
            var MyWindow = new Tests.IWindowImplementationForTests();
            Village selectedVillage = myGame.Villages[0];
            Family family = selectedVillage.FamiliesList[1];
            Villager villager = family.FamilyMembers[0];
            do
            {
                myGame.NextStep();
                foreach (IEvent e in myGame.EventList)
                {
                    e.PublishMessage(MyWindow);
                    e.Do(MyWindow);
                }
            } while (myGame.TotalPop < 30);


            Game.Serialize.Save(myGame);
            /*{
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("SAVED.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, myGame);
                stream.Close();
            }*/

            do
            {
                myGame.NextStep();
                foreach (IEvent e in myGame.EventList)
                {
                    e.PublishMessage(MyWindow);
                    e.Do(MyWindow);
                }
            } while (myGame.TotalPop < 70);
            myGame = null;
           /* {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("SAVED.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                myGame = (Game.Game)formatter.Deserialize(stream);
                stream.Close();
            }*/
            myGame=Game.Serialize.Load();
            Assert.That(myGame.TotalPop < 65 && myGame.TotalPop > 29);

        }
    }
}
