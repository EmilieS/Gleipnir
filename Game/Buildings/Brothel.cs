using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    public class Brothel : BuildingsModel
    {

        public Brothel(Game g,BuildingsList List, string name)
            : base(g)
        {

        }
        public double SetHappiness
        {
            get { return 8; }
        }

        public int SetEnterPrice
        {
            get { return 12; }
        }
    }
}
