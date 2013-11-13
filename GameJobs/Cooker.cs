using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJobs
{
    public class Cooker : JobsModel //: INotifyPropertyChanged
    {
        public Cooker()
        {
            _job = Jobs.COOKER;
            jobName = "Cuisiner";
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
                v.AddOrRemoveHappiness(10);
            }*/

            foreach (Villager person in _workers)
            {
                person.AddOrRemoveHappiness(-10);
            }
        }

        // public event PropertyChangedEventHandler PropertyChanged;
    }
}
