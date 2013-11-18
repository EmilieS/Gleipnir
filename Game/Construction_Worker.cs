using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Construction_Worker : JobsModel
    {
        public Construction_Worker()
        {
            _job = Jobs.CONSTRUCTION_WORKER;
            jobName = "Constructeur";
            _workers = new List<Villager>();
            coefficient = 10;
            _gold = ModifyGoldGeneration();
        }
    }
}
