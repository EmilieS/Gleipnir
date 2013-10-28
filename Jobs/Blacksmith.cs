using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJobs
{
    class Blacksmith : INotifyPropertyChanged
    {
        float _gold;
        List<Villager> _workers;
        Jobs _job;

        public Blacksmith()
        {
            _gold = 50;
            _job = Jobs.CONSTRUCTION_WORKER;
        }

        /// <summary>
        /// Add a job to villager
        /// </summary>
        /// <param name="person"></param>
        public void AddPerson(Villager person)
        {
            if (person.Job == 0)
            {
                person.setJob(_job);
                _workers.Add(person);
            }
        }

        /// <summary>
        /// Remove the villager from the job
        /// </summary>
        /// <param name="person"></param>
        public void RemovePerson(Villager person)
        {
            if (person.Job > 0)
                person.setJob(Jobs.NONE);
        }

        /// <summary>
        /// Set gold generation per tick
        /// </summary>
        public void GenerateGold()
        {
            _gold = ModifyGoldGeneration(_gold);
            foreach (Villager person in _workers)
            {
                person.Wallet(_gold);
            }
        }

        /// <summary>
        /// Sets a new value for gold.
        /// More blacksmiths less gold generation.
        /// </summary>
        public float ModifyGoldGeneration(float lastGoldGeneration)
        {
            return lastGoldGeneration - _workers.Count;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
