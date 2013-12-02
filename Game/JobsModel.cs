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
    public abstract class JobsModel : GameItem
    {
        //protected Village _ownerVillage;
        protected List<Villager> _workers;
        protected Jobs _job;
        protected readonly string _jobName;
        protected internal int goldBase;
        protected int _coefficient;
        protected int _gold;
        internal readonly JobList _owner;
        bool _workerListChanged;

        internal JobsModel(Game game, JobList list, string name)
            : base(game)
        {
            goldBase = 5;
            _jobName = name;
            _workers = new List<Villager>();
            //_gold = ModifyGoldGeneration();
            _owner = list;
        }

        public int GoldGenerated { get { return _gold; } }//do we really want to communicate this everchanging value??
        public string Name { get { return _jobName; } }
        public double Coefficient { get { return _coefficient; } }

        /// <summary>
        /// Gets the Workers list
        /// </summary>
        public IReadOnlyList<Villager> Workers
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
                person.setJob(this);
                _workerListChanged = true;
                _workers.Add(person);
                Debug.Assert(_workers.Contains(person), "(AddPerson) the person was not added Oo");
                //_gold = ModifyGoldGeneration();//not usefull here really...
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
                person.setJob(null);
                _workerListChanged = true;
                _workers.Remove(person);
                //_gold = ModifyGoldGeneration();//not usefull here really
            }
            else throw new InvalidOperationException();
        }

        /// <summary>
        /// Add gold to workers
        /// </summary>
        public void GenerateGold()
        {
            if (_workers.Count == 0)
                return;
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
            int result;/*
            if (_workers.Count > 1 && _workers.Count <= 35)
                result = (goldBase * _coefficient) - (_workers.Count - 1);
            else if (_workers.Count > 35) result = (goldBase * 5);
            else result = (goldBase * _coefficient);*/


            /*
              ((pop totale)/(nbr de villageois avec même métier)) * cste
              */
            Debug.Assert(_owner != null, "(ModifyGoldGeneration) _owner is null");
            Debug.Assert(_owner._owner != null, "(ModifyGoldGeneration) _owner._owner is null");
            Debug.Assert(_workers.Count != 0, "(ModifyGoldGeneration) there are no workers");

            result = (_owner._owner._villagePop.Current / _workers.Count) * _coefficient;

            return result;
        }

        /// <summary>
        /// Add amount of happiness for all others villagers
        /// </summary>
        /// <param name="person"></param>
        public virtual void AddHappiness(Villager villager) { }

        internal void WorkerIsHeretic()
        {
            foreach (Villager v in _workers)
            {
                v.AddOrRemoveFaith(-0.1);
            }
        }


        #region called by DieOrIsAlive
        internal void WorkerDestroyed(Villager dead)
        {
            Debug.Assert(dead != null, "(JobsModel) villager is null");
            Debug.Assert(dead.IsDead(),"(JobsModel) villager is not dead ?!");
            Debug.Assert(_workers.Contains(dead), "(JobModel) villager isn't even in the workerlist!");
            RemovePerson(dead);
        }
        #endregion
        #region called by CloseStep
        bool WorkerListConclude()
        {
            bool changed = _workerListChanged;
            _workerListChanged = false;
            return changed;
        }
        #endregion

        #region worldtickcalls
        internal override void Evolution()
        {
            GenerateGold();
        }
        internal override void CloseStep(List<IEvent> eventList)
        {
            if (WorkerListConclude()) { eventList.Add(new EventProperty<JobsModel>(this, "Workers")); }
        }
        #endregion

        internal override void OnDestroy()
        {
            /*  Debug.Assert(_workers.Count == 0, "There is still someone in this Job!");
              _ownerVillage.DestroyJobs(this);*/
            //TO think about.
        }
    }
}