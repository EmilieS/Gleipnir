using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    public class Tavern : BuildingsModel
    {
        public Tavern(Game g, BuildingsList List, string name)
            : base()
        {
        }

        public double SetFaith
        {
            get { return 4; }
        }

        public double SetHappiness
        {
            get { return 6; }
        }

        //public void SetEnterPrice()
        //{
        //    prop.EnterPrice = 2;
        //}
    }
}
