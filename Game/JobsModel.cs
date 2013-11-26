using Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class JobsModel : GameItem
    {
        protected Village _ownerVillage;
        protected List<Villager> _workers;
        protected Jobs _job;
        protected readonly string _jobName;
        protected internal int goldBase;
        protected int _coefficient;
        protected int _gold;

        internal JobsModel(Game game, string name)
            : base(game)
        {
            goldBase = 5;
            _jobName = name;
            _workers = new List<Villager>();
            _gold = ModifyGoldGeneration();
        }

        public int GoldGenerated { get { return _gold; } }
        public string Name { get { return _jobName; } }
        public double Coefficient { get { return _coefficient; } }

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
            if (person == null) throw new ArgumentNullException();
            if (!_workers.Contains(person))
            {
                person.setJob(_job);
                _workers.Add(person);
                _gold = ModifyGoldGeneration();
            }
            else throw new InvalidOperationException();
        }

        /// <summary>
        /// Remove the Villager from the Job
        /// </summary>
        /// <param name="person"></param>
        public void RemovePerson(Villager person)
        {
            if (person == null) throw new ArgumentNullException();
            if (_workers.Contains(person))
            {
                person.setJob(Jobs.NONE);
                _workers.Remove(person);
                _gold = ModifyGoldGeneration();
            }
            else throw new InvalidOperationException();
        }

        /// <summary>
        /// Add gold to workers
        /// </summary>
        public void GenerateGold()
        {
            _gold = ModifyGoldGeneration();
            foreach (Villager person in _workers)
            {
                person.ParentFamily.addTOGoldStash(_gold);
            }
        }

        /// <summary>
        /// Less Gold generation if many job workers
        /// </summary>
        /// <returns></returns>
        public int ModifyGoldGeneration()
        {
            int result;
            if (_workers.Count > 1 && _workers.Count <= 35)
                result = (goldBase * _coefficient) - (_workers.Count - 1);
            else if (_workers.Count > 35) result = (goldBase * 5);
            else result = (goldBase * _coefficient);
            return result;
        }

        /// <summary>
        /// Add amount of happiness for all others villagers
        /// </summary>
        /// <param name="person"></param>
        public virtual void AddHappiness() {}

        internal override void OnDestroy()
        {
            Debug.Assert(_workers.Count == 0, "There is still someone in this Job!");
            _ownerVillage.DestroyJobs(this);
        }

        internal override void CloseStep(List<IEvent> eventList)
        {
        }
    }
}