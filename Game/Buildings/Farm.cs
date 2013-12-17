﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    public class Farm : BuildingsModel
    {
        public Farm(Village v, BuildingsList List, string name)
            : base(v)
        {

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

            foreach (Villager v in Village.Jobs.Farmer.Workers)
            {
                if (Game.Rand.Next(100) == 1)
                {
                    v.EarthquakeInjure();
                }
            }
        }
    }
}
