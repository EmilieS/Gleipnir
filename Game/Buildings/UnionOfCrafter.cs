using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
     public class UnionOfCrafter : BuildingsModel
    {
        public UnionOfCrafter(Village v)
            : base(v)
        {
            Name = "Syndicat";
            Hp = MaxHp = 50;
        }
        // Syndicat des ouvriers 
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

            foreach (Villager v in Village.Jobs.Construction_worker.Workers)
            {
                if (Game.Rand.Next(100) == 1)
                {
                    v.EarthquakeInjure();
                }
            }
        }
    }
}
