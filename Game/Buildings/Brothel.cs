﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    [Serializable]
    public class Brothel : BuildingsModel
    {

        public Brothel(Village v)
            : base(v)
        {
            Name = "Maison Close";
            Hp = MaxHp = 50;
            this.CostPrice = 300;
        }

        public double SetHappiness
        {
            get { return 8; }
        }
        public int SetEnterPrice
        {
            get { return 12; }
        }

        override internal void AddToList()
        {
            Village.BuildingsList.Add(this);
        }
        internal override void OnOnDestroy()
        {
            Village.BuildingsList.Remove(this);
        }
    }
}
