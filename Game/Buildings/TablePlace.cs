using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    class TablePlace : BuildingsModel
    {
        public TablePlace(Village v, BuildingsList List, string name)
            : base(v)
        {

        }
        //public void SetTablePosition()
        //{
        //    //TODO : Define the Table position 
        //    prop.HorizontalPos = 3;
        //    prop.VerticalPos = 4;
        //}
        //public void SetFaith()
        //{
        //    prop.AddFaith = 4;
        //}
    }
}
