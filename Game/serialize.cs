using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Game
{
    public static class Serialize
    {
        static public void Save(Game g)
        {

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("SAVED.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, g);
            stream.Close();
        }

        static public Game Load()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("SAVED.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            Game g = (Game)formatter.Deserialize(stream);
            stream.Close();

            return g;
        }
    }
}
