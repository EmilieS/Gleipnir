﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    [Serializable]
    public class ClothesShop : BuildingsModel
    {
        internal string _name;
        internal JobsModel _job;

        public ClothesShop(Village v, JobsModel job)
            : base(v)
        {
            Name = "Magasin";
            _name = Name;
            Hp = MaxHp = 50;
            _job = job;
            this.CostPrice = 300;
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
            foreach (Villager v in Village.JobsList.Apothecary.Workers)
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
