﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    [Serializable]
    public class Mill : BuildingsModel
    {
        internal string _name;
        internal JobsModel _job;

        public Mill(Village v, JobsModel job)
            : base(v)
        {
            Name = "Moulin";
            _name = Name;
            Hp = MaxHp = 50;
            _job = job;
            this.CostPrice = 375;
        }

        override internal void AddToList()
        {
            Village.BuildingsList.Add(this);
        }
        internal override void OnOnDestroy()
        {
            Village.BuildingsList.Remove(this);
        }
        override internal void OnDamage()
        {

            foreach (Villager v in Village.JobsList.Miller.Workers)
            {
                if (Game.Rand.Next(100) == 1)
                {
                    v.EarthquakeInjure();
                }
            }
        }

        public string BuildingName { get { return _name; } }
        public JobsModel Job { get { return _job; } }
    }
}
