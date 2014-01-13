using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class save
    {
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
    }
}
