using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Apothecary : JobsModel
    {
        public Apothecary()
        {
            _job = Jobs.APOTHECARY;
            jobName = "Apothicaire";
            _workers = new List<Villager>();
            coefficient = 15;
            _gold = ModifyGoldGeneration();
        }
    }
}
