using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJobs
{
    class Apothecary : INotifyPropertyChanged
    {
        float _gold;
        List<Villager> _workers;
        Jobs _job;

        public Apothecary()
        {
            _gold = 75;
            _job = Jobs.APOTHECARY;
        }

        public void AddPerson(Villager person)
        {
            if (person.Job == 0)
            {
                person.setJob(_job);
                _workers.Add(person);
            }
        }

        public void RemovePerson(Villager person)
        {
            if (person.Job > 0)
                person.setJob(Jobs.NONE);
        }

        public void GenerateGold()
        {
            _gold = ModifyGoldGeneration(_gold);
            foreach (Villager person in _workers)
            {
                person.Wallet(_gold);
            }
        }

        public float ModifyGoldGeneration(float lastGoldGeneration)
        {
            return lastGoldGeneration - _workers.Count;
        }

        public void AddHappiness(Villager person)
        {
            person.Happiness += 5;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
