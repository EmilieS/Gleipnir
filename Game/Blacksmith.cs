using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Blacksmith : JobsModel
    {
        public Blacksmith()
        {
            _job = Jobs.CONSTRUCTION_WORKER;
            jobName = "Forgeron";
            _workers = new List<Villager>();
            coefficient = 10;
            _gold = ModifyGoldGeneration();
        }
    }
}
