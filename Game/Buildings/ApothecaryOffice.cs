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
        public ApothecaryOffice(Game g)
            : base(g)
        {

        }
        public void SetGoodHealth(Villager sickVillager)
        {
            sickVillager.Heal();
        }



    }
}
