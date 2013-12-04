using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;

namespace Game.Buildings
{
    class ApothecaryOffice : BuildingsModel
    {
        public ApothecaryOffice(Village v ,BuildingsList List, string name)
            : base(v)
        {

        }
        public void SetGoodHealth(Villager sickVillager)
        {
            sickVillager.Heal();
        }



    }
}
