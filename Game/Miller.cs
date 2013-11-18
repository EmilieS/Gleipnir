using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Miller : JobsModel
    {
        public Miller()
        {
            _job = Jobs.MILLER;
            jobName = "Meunier";
            _workers = new List<Villager>();
            coefficient = 13;
            _gold = ModifyGoldGeneration();
        }
        
        /// <summary>
        /// Add amount of happiness for all others villagers
        /// </summary>
        /// <param name="person"></param>
        public override void AddHappiness()
        {
            /*foreach (Villager v in Village) // DONT WORK FOR THE MOMENT
            {
                v.AddOrRemoveHappiness(7);
            }*/

            foreach (Villager person in _workers)
            {
                person.AddOrRemoveHappiness(-7);
            }
        }
    }
}
