using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJobs
{
    public class Militia : INotifyPropertyChanged
    {
        float _gold;
        List<Villager> _workers;
        Jobs _job;

        public Militia()
        {
            _gold = 40;
            _job = Jobs.MILITIA;
            _workers = new List<Villager>();
        }

        /// <summary>
        /// Gets Gold amount is generate per tick
        /// </summary>
        public float Gold
        {
            get { return _gold; }
        }

        /// <summary>
        /// Gets the Workers list
        /// </summary>
        public List<Villager> Workers
        {
            get { return _workers; }
        }

        /// <summary>
        /// Add a Villager to the Job
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
        /// Remove the Villager from the Job
        /// </summary>
        /// <param name="person"></param>
        public void RemovePerson(Villager person)
        {
            if (person.Job > 0)
            {
                person.setJob(Jobs.NONE);
                _workers.Remove(person);
            }
        }

        /// <summary>
        /// Add gold to workers
        /// </summary>
        public void GenerateGold()
        {
            _gold = ModifyGoldGeneration();
            foreach (Villager person in _workers)
            {
                person.AddGoldInWallet(_gold);
            }
        }

        /// <summary>
        /// Less Gold generation if many job workers
        /// </summary>
        /// <returns></returns>
        public float ModifyGoldGeneration()
        {
            if (_workers.Count > 1)
            {
                _gold = _gold - (_workers.Count - 1);
            }
            else
            {
                _gold = 75;
            }
            return _gold;
        }

        /// <summary>
        /// Add amount of happiness for all others villagers
        /// </summary>
        /// <param name="person"></param>
        public void AddHappiness(Villager person)
        {
            person.Happiness += 10;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
