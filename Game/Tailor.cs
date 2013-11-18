using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Tailor : JobsModel
    {
        public Tailor()
        {
            _job = Jobs.TAILOR;
            jobName = "Tailleur";
            _workers = new List<Villager>();
            coefficient = 15;
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
                v.AddOrRemoveHappiness(15);
            }*/

            foreach (Villager person in _workers)
            {
                person.AddOrRemoveHappiness(-15);
            }
        }
    }
}
