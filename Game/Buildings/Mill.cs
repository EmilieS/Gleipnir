using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
     public class Mill : BuildingsModel
    {
        public Mill(Village v)
            : base(v)
        {
            Name = "Moulin";
            Hp = MaxHp = 50;
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

            foreach (Villager v in Village.Jobs.Miller.Workers)
            {
                if (Game.Rand.Next(100) == 1)
                {
                    v.EarthquakeInjure();
                }
            }
        }
    }
}
