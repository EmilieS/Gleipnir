using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    public class Theater : BuildingsModel
    {
        public Theater(Game g, BuildingsList List, string name)
            : base(g)
        {

        }
        public double SetHappiness
        {
            get { return 5; }
        }
        //public void SetEnterPrice()
        //{
        //    EnterPrice = 50;
        //}
    }
}
