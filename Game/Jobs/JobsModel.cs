using Game;
using Game.Buildings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    public abstract class JobsModel : GameItem
    {
        //protected Village _ownerVillage;
        protected List<Villager> _workers;
        protected Jobs _job;
        protected readonly string _jobName;
        protected internal int goldBase;
        protected int _coefficient;
        protected int _gold;
        JobList _owner;
        bool _workerListChanged;
        internal int _nbHeretics;
        protected BuildingsModel _building;
        internal JobList Owner { get { return _owner; } }
        double _happinessAddition;
        internal JobsModel(Game game, JobList list, string name)
            : base(game)
        {
            goldBase = 5;
            _jobName = name;
            _workers = new List<Villager>();
            // _gold = ModifyGoldGeneration();
            _owner = list;
        }

        public int GoldGenerated { get { return _gold; } internal set { _gold = value; } } //do we really want to communicate this everchanging value??
        public string Name { get { return _jobName; } }
        public int Coefficient { get { return _coefficient; } internal set { _coefficient = value; } }
        public double HappinessToAdd { get { return _happinessAddition; } set { _happinessAddition = value; } }

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
        internal void AddPerson(Villager person)
        {
            if (!AddPersonPrerequisites())
                return;
            if (person == null) throw new ArgumentNullException();
            if (!_workers.Contains(person))
            {
                person.setJob(this);
                _workerListChanged = true;
                _workers.Add(person);
                if ((person.Health & Healths.HERETIC) != 0)
                {
                    addHereticWorker();
                }
                Debug.Assert(_workers.Contains(person), "(AddPerson) the person was not added Oo");
                //_gold = ModifyGoldGeneration();//not usefull here really...
            }
            else throw new InvalidOperationException();
        }
        public bool AddPerson2(Villager person)
        {
            if (!AddPersonPrerequisites())
                return false;
            if (person == null)
                return false;
            if (!_workers.Contains(person))
            {
                person.setJob(this);
                _workerListChanged = true;
                _workers.Add(person);
                if ((person.Health & Healths.HERETIC) != 0)
                {
                    addHereticWorker();
                }
                Debug.Assert(_workers.Contains(person), "(AddPerson) the person was not added Oo");
                //_gold = ModifyGoldGeneration();//not usefull here really...
                return true;
            }
            else
                return false;
        }
        //TODO (check if building)
        public abstract bool AddPersonPrerequisites();

        /// <summary>
        /// Remove the Villager from the Job
        /// </summary>
        /// <param name="person"></param>
        internal void RemovePerson(Villager person)
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
        public bool RemovePerson2(Villager person)
        {
            if (person == null)
                return false;
            if (_workers.Contains(person))
            {
                if ((person.Health & Healths.HERETIC) != 0)
                {
                    removeHereticWorker();
                }
                person.setJob(null);
                _workerListChanged = true;
                _workers.Remove(person);
                //_gold = ModifyGoldGeneration();//not usefull here really
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Add gold to workers
        /// </summary>
        public void GenerateGold()
        {
            if (_workers.Count == 0)
                return;
            if (!GenerateGoldPrerequisites())
                return;
            _gold = ModifyGoldGeneration();
            foreach (Villager person in _workers)
            {
                if (person.GenerateGoldPrerequisitesFromVillager())
                {
                    person.ParentFamily.AddToGoldStash(_gold);
                }
            }
        }
        internal virtual bool GenerateGoldPrerequisites()
        {
            return true;
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
            Debug.Assert(_owner.Owner != null, "(ModifyGoldGeneration) _owner._owner is null");
            Debug.Assert(_workers.Count != 0, "(ModifyGoldGeneration) there are no workers");
            result = _owner.Owner._villagePop.Current * _coefficient;
            result = result / (_workers.Count * 2);
            return result;
        }

        public BuildingsModel Building
        {
            get { return _building; }
            set { _building = value; }
        }

        internal void addHereticWorker()
        {
            Debug.Assert(_nbHeretics <= Workers.Count, "(addHereticWorker) there are more heretic workers than workers Oo");
            _nbHeretics++;
        }
        internal void removeHereticWorker()
        {
            Debug.Assert(_nbHeretics <= Workers.Count, "(removeHereticWorker) there are more heretic workers than workers Oo");
            Debug.Assert(_nbHeretics >= 0, "(removeHereticWorker) negative !");
            _nbHeretics--;
        }

        /// <summary>
        /// Add amount of happiness for all others villagers
        /// </summary>
        /// <param name="person"></param>
        public virtual void AddHappiness(Villager villager) { }

        internal void HereticFaithImpact()
        {
            if (_nbHeretics < 0)
            {
                int nbHeretics = _nbHeretics;
                foreach (Villager v in _workers)
                {
                    v.AddOrRemoveFaith(-0.4 * nbHeretics);
                }
            }
        }

        #region called by DieOrIsAlive
        internal void WorkerDestroyed(Villager dead)
        {
            Debug.Assert(dead != null, "(JobsModel) villager is null");
            Debug.Assert(dead.IsDead(), "(JobsModel) villager is not dead ?!");
            Debug.Assert(_workers.Contains(dead), "(JobModel) villager isn't even in the workerlist!");
            Debug.Assert((dead.Faith <= 15) == ((dead.Health & Healths.HERETIC) != 0), "(JobModel/villagerdestroyed) heretism is not right!");
            if ((dead.Health & Healths.HERETIC) != 0)
            {
                removeHereticWorker();
            }
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
        override internal void ImpactHappiness()
        {
            HereticFaithImpact();
        }
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
            Debug.Assert(_workers.Count == 0, "There is still someone in this Job!");

            /* _owner = null; joblist & different jobs ONLY get destroyed with the village.
             * so it only gets destroyed WITH its owner, so no need to separate them.*/
        }
    }
}