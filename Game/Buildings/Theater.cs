﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    public class Theater : BuildingsModel
    {
        public Theater(Village v)
            : base(v)
        {
            Name = "Théâtre";
            Hp = MaxHp = 50;
        }
        public double SetHappiness
        {
            get { return 5; }
        }
        //public void SetEnterPrice()
        //{
        //    EnterPrice = 50;
        //}
        override internal void AddToList()
        {
            Village.Buildings.Add(this);
        }
        internal override void OnOnDestroy()
        {
            Village.Buildings.Remove(this);
        }
    }
}
