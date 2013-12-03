using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    public class Baths : BuildingsModel
    {
        public Baths(Game g, BuildingsList List, string name)
            : base(g)
        {

        }
        public double SetHappiness
        {
            get { return 3; }
        }
        private int SetEnterPrice
        {
            get { return 200; }
        }

    }
}
