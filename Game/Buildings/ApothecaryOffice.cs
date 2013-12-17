using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;

namespace Game.Buildings
{
     public class ApothecaryOffice : BuildingsModel
    {
        public ApothecaryOffice(Village v ,BuildingsList List, string name)
            : base(v)
        {

        }
        public void SetGoodHealth(Villager sickVillager)
        {
            sickVillager.Heal();
        }

        override internal void AddToList()
        {
            Village.Buildings.Add(this);
        }
        internal override void OnOnDestroy()
        {
            Village.Buildings.Remove(this);
        }
        override internal void OnDamage() 
        {
           
           foreach(Villager v in Village.Jobs.Apothecary.Workers)
           {
               if (Game.Rand.Next(100) == 1)
               {
                   v.EarthquakeInjure();
               }
           }
        }
    }
}
