using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Game
{
    [Serializable]
    public partial class Villager : GameItem
    {
        internal Villager(Game g, Family parentFamily, string name)
            : base(g)
        {
            _faith = new HistorizedValue<double, Villager>(this, "_faith", 20);
            _happiness = new HistorizedValue<double, Villager>(this, "_happiness", 20);
            _health = new HistorizedValue<Healths, Villager>(this, "_health", 20);
            _statusInFamily = new HistorizedValue<Status, Villager>(this, "_statusInFamily", 20);
            _statusInFamily.Current = Status.SINGLE;
            
            
            g.VillagerAdded();
            parentFamily.OwnerVillage.VillagerAdded();
            Debug.Assert(g != null);
            if (Game.Rand.Next(101) < 2)
            {
                _faith.Current = 13;
            }
            else
            {
                _faith.Current = parentFamily.FaithAverage();
            }
            if (_faith.Current <= 15)
            {
                _health.Current = Healths.HERETIC;
            }
            switch (Game.Rand.Next(2))
            {
                case 0: _gender = Genders.MALE;
                    if (parentFamily.Father != null)
                    {
                        if (parentFamily.Father.Job != null)
                        {
                            parentFamily.Father.Job.AddPerson(this);
                        }
                    }
                    g.AddSingleMan(this); break;
                case 1: _gender = Genders.FEMALE;
                    if (parentFamily.Mother != null)
                    {
                        if (parentFamily.Mother.Job != null)
                        {
                            parentFamily.Mother.Job.AddPerson(this);
                        }
                    }
                    Engage(this, parentFamily); break;
            }
            _happiness.Current = parentFamily.HappinessAverage();
            //_job = Jobs.FARMER;
            _age = 0;
            //_lifeExpectancy = 85;
            _lifeExpectancy = 85 * 12;
            _name = name;

        }
        public Villager(Game g, Genders gender, string name)
            : base(g)
        {
            _faith = new HistorizedValue<double, Villager>(this, "_faith", 20);
            _happiness = new HistorizedValue<double, Villager>(this, "_happiness", 20);
            _health = new HistorizedValue<Healths, Villager>(this, "_health", 20);
            _statusInFamily = new HistorizedValue<Status, Villager>(this, "_statusInFamily", 20);
            g.VillagerAdded();
            _faith.Current = 100;
            _happiness.Current = 80;
            // _lifeExpectancy = 85;
            _lifeExpectancy = 85 * 12;
            _gender = gender;
            _statusInFamily.Current = Status.SINGLE;
            _name = name;//_health.Conclude();
            Game.Villages[0].VillagerAdded();//hmmmmm
            Game.Villages[0].JobsList.Farmer.AddPerson(this);
        }

        readonly string _name;
        Family _parentFamily;
        Genders _gender;
        JobsModel _job;
        double _lifeExpectancy;
        double _age;
        Villager _fiance;
        public Healths Health { get { return _health.Current; } }
        ActivityStatus _villagerActivity;
        Missions _mission = Missions.NONE; 
        Virus _virus;

        readonly HistorizedValue<double, Villager> _faith; //scale from 0 to 100.
        readonly HistorizedValue<double, Villager> _happiness; //scale from 0 to 100.
        readonly HistorizedValue<Healths, Villager> _health;
        readonly HistorizedValue<Status, Villager> _statusInFamily;

        public double Age { get { return _age; } }
        public double Faith { get { return _faith.Current; } }
        public double Happiness { get { return _happiness.Current; } }
        public Genders Gender { get { return _gender; } }
        public JobsModel Job { get { return _job; } }
        public double LifeExpectancy { get { return _lifeExpectancy; } }

        public Status StatusInFamily
        {
            get { return _statusInFamily.Current; }
            internal set { _statusInFamily.Current = value; }
        }
        public Missions Mission
        {
            get { return _mission; }
            set { _mission = value; }
        }
        public Family ParentFamily
        {
            get { return _parentFamily; }
            internal set { _parentFamily = value; }
        }
        internal void setJob(JobsModel NewJob)
        {
            _job = NewJob;
        }
        public bool RemoveJob()
        {
            return _job.RemovePerson2(this);
        }
        public bool AddToJob(JobsModel job)
        {
            if (_job != null)
                _job.RemovePerson2(this);
            return job.AddPerson2(this);
        }
        public ActivityStatus ActivityStatus
        {
            get
            {
                return _villagerActivity;
            }
            set
            {
                _villagerActivity = value;
            }
        }
        public bool IsWorking
        {
            get
            {
                return (!((_villagerActivity & ActivityStatus.CONVOCATED) !=0 || (_villagerActivity & ActivityStatus.PARTYING) != 0));
            }
        }

        /// <summary>
        /// Gets the villager's name
        /// </summary>
        public string FirstName { get { return _name; } }
        /// <summary>
        /// Gets the family name
        /// </summary>
        public string Name { get { return _parentFamily.Name; } }

        /// <summary>
        /// Sets the new life expectancy no matter what time was left.
        /// </summary>
        /// <param name="lifeExpectancy"></param>
        public void SetLifeExpectancy(double lifeExpectancy)
        {
            if (lifeExpectancy < 0)
            {
                throw new IndexOutOfRangeException();
            }
            _lifeExpectancy = lifeExpectancy;
        }

        /// <summary>
        /// Sets the new life expectancy based on the time left you want. only if shorter than before.
        /// </summary>
        /// <param name="lifeExpectancy"></param>
        public void SetLifeExpectancyLeft(double timeLeft)
        {

            if (_age < _lifeExpectancy && _age + timeLeft < _lifeExpectancy)
            {
                _lifeExpectancy = _age + timeLeft;
            }

        }

        /// <summary>
        /// Reduces the life expectancy by 'time'.(minimum is 0)
        /// </summary>
        /// <param name="time"></param>
        public void ReduceLifeExpectancy(double timeleft)
        {
            if (_lifeExpectancy > timeleft)
            {
                _lifeExpectancy -= timeleft;
            }
            else
            {
                _lifeExpectancy = 0;
            }
        }

        /// <summary>
        /// kill a villager.
        /// </summary>
        public void Kill()
        {
            _lifeExpectancy = 0;
        }
        internal void HouseCollapsed()
        {
            _health.Current = _health.Current | Healths.EARTHQUAKE_INJURED;
            SetLifeExpectancyLeft(0);
        }
        internal void EarthquakeInjure()
        {
            _health.Current = _health.Current | Healths.EARTHQUAKE_INJURED;
            SetLifeExpectancyLeft(3);
        }
        /// <summary>
        /// can be negative to take away happiness.
        /// </summary>
        /// <param name="amount"></param>
        public void AddOrRemoveHappiness(double amount)
        {
            if (_happiness.Current + amount < 0)
            {
                _happiness.Current = 0;
            }
            else if (_happiness.Current + amount > 100)
            {
                _happiness.Current = 100;
            }
            else
            {
                _happiness.Current += amount;
            }
        }
        internal bool IsDead()
        {
            return ((_health.Current & Healths.DEAD) != 0);
        }
        internal bool IsHeretic()
        {
            return ((_health.Current & Healths.HERETIC) != 0);
        }
        /// <summary>
        /// can be negative to take away faith.
        /// </summary>
        /// <param name="amount"></param>
        public void AddOrRemoveFaith(double amount)
        {
            double result = _faith.Current + amount;
            if ((_health.Current & Healths.HERETIC) == 0)
            {
                if (result <= 15)
                {
                    _health.Current = _health.Current | Healths.HERETIC;
                    if (_job != null)
                    {
                        _job.addHereticWorker();
                    }
                }
            }
            else
            {
                if (result > 15)
                {
                    _health.Current = _health.Current & ~Healths.HERETIC;
                    if (_job != null)
                    {
                        _job.removeHereticWorker();
                    }
                }
            }
            if (result < 0)
            {
                _faith.Current = 0;
            }
            else if (result > 100)
            {
                _faith.Current = 100;
            }
            else
            {
                _faith.Current = result;
            }
            Debug.Assert((Faith <= 15) == ((Health & Healths.HERETIC) != 0), "(JobModel/villagerdestroyed) heretism is not right!");
        }

        public bool GenerateGoldPrerequisitesFromVillager()//VERY sensitive
        {
            //if (this.ActivityStatus != ActivityStatus.WORKING || IsDead() || this.ActivityStatus == ActivityStatus.PARTYING)
            if (IsWorking && !IsDead()) 
                return true;
            else
                return false;
        }

        //====================WORLD=TICK=STUFF============================
        #region called by ImpactHappiness
        private void SickHappinessImpact()
        {
            if ((_health.Current & Healths.SICK) != 0)
            {
                AddOrRemoveHappiness(0.1);
                ParentFamily.FamilyMemberIsSick();
            }
        }
        private void ImpactGeneralFaithAdditionOrSubstraction()
        {
            AddOrRemoveFaith(Game.FaithToBeAddedOrRemovedForAllVillagersThisRound);
        }

        #endregion
        #region called by Evolution
        private void HereticFaithImpact()
        {
            if ((_health.Current & Healths.HERETIC) != 0)
            {
                ParentFamily.FamilyMemberIsHeretic();
            }
        }
        internal void HandInOfferings()
        {
            int amount = _parentFamily.OwnerVillage.OfferingsPointsPerTick;
            if ((_health.Current & Healths.HERETIC) == 0)
            {
                Game.AddOrTakeFromOfferings(ParentFamily.TakeFromGoldStash(amount));
            }

        }
        internal void AgeTick(double time)
        {
            _age += time;
        }
        int _sickTimer;
        internal void CheckIfSick()
        {
            if ((_health.Current & Healths.SICK) != 0)
            {
                int nbApothecaries = _parentFamily.OwnerVillage.JobsList.Apothecary.Workers.Count;
                int maxtimer;
                if (this._virus != null)//....
                {
                    maxtimer = _virus.MaxTimer;
                    ReduceLifeExpectancy(_virus.LifeExpectencyReduced/1+(nbApothecaries/2));
                }
                else
                {
                    maxtimer = 30;
                }
                if (_sickTimer > maxtimer)
                {
                    _sickTimer = 0;
                    SetLifeExpectancyLeft(0);
                    if (_virus != null)
                    {
                        _virus.Epidemic.SickVillagerList.Remove(this);
                    }
                }
                else
                {
                  
                   if (nbApothecaries > 0)
                   {
                       if (Game.Rand.Next(nbApothecaries) == 0)//The presence of apothecaries relieves the villagers
                       {
                           _sickTimer++;
                       }
                   }
                   else { _sickTimer++; }
                }


            }
            else { _sickTimer = 0; }
        }

         void Heal()//sert à rien
        {
            _health.Current = Healths.NONE;
        }
        public void SetVirus(Virus virus)
        {
            Debug.Assert(virus != null, "(villager SetVirus) virus is null !!!");
            if ((_health.Current & Healths.SICK) != 0)
                throw new InvalidOperationException("This villager is already sick");
            _virus = virus;
            virus.Epidemic.SickVillagerList.Add(this);
            _health.Current = _health.Current | Healths.SICK;
        }
        public void SetHealed( int amount=0)
        {
            Debug.Assert(amount >= 0, "SetHealed, amount was negative");
            if (_virus != null)
            {
                _virus.Epidemic.SickVillagerList.Remove(this);
                _virus = null;
            }
            _health.Current = _health.Current & ~Healths.SICK;
            _lifeExpectancy += amount;
        }
        internal void FestStarted()
        {
            _villagerActivity = _villagerActivity | ActivityStatus.PARTYING;
        }
        internal void FestEnded()
        {
            _villagerActivity = _villagerActivity & ~ActivityStatus.PARTYING;
        }
        internal void MeetingStarted()
        {
            _villagerActivity = _villagerActivity | ActivityStatus.CONVOCATED;
        }

        internal void MeetingEnded()
        {
            _villagerActivity = _villagerActivity & ~ActivityStatus.CONVOCATED;
        }

        int _callForHelpTickTimer;
        private void CallForHelpCheck()
        {
            if ((_health.Current & Healths.UNHAPPY) == 0)
            {
                CallForHelp();
            }
            if ((_health.Current & Healths.UNHAPPY) != 0)
            {
                if (_callForHelpTickTimer == 20)//can get adjusted
                {
                    _callForHelpTickTimer = 0;
                    CallForHelpEnded();
                }
                else { _callForHelpTickTimer++; }
            }

        }
        private void CallForHelp()
        {
            if (_happiness.Current < 25 && (_health.Current & Healths.UNHAPPY) == 0)
            {
                _health.Current = _health.Current | Healths.UNHAPPY;

            }
        }
	private void CallForHelpEnded()
        {
            if (_happiness.Current > 27)
            {
                AddOrRemoveFaith(20);
            }
            else if (_happiness.Current < 25)
            {
                AddOrRemoveFaith(-20);
            }
            _health.Current = _health.Current & ~Healths.UNHAPPY;
        }
        private void MatchMaking()
        {
            if (_gender == Genders.MALE || _statusInFamily.Current != Status.SINGLE)
                return;
            Engage(this, _parentFamily);
        }
        private void Suicide()
        {
            if (_happiness.Current == 0 && (_health.Current & Healths.DEPRESSED) == 0)
            {
                SetLifeExpectancyLeft(1);
                _health.Current = _health.Current | Healths.DEPRESSED;
            }
        }
        #endregion
        #region called by Creation
        private void RegularBirths(double time, List<IEvent> eventList)
        {
            if (StatusInFamily != Status.MARRIED || _gender != Genders.FEMALE)
                return;
            Debug.Assert(_parentFamily != null);

            int i = 0;
            int count = Game._regularBirthDates.Count();
            while (i < count && Game._regularBirthDates[i] <= _age)
            {
                if (_age - time < Game._regularBirthDates[i])
                {
                    eventList.Add(new VillagerBirthEvent(_parentFamily.NewFamilyMember()));
                }
                i++;
            }
        }
        int _engagedTickTimer;
        private void RegularFamilyCreation(List<IEvent> eventList)
        {
            if (_statusInFamily.Current != Status.ENGAGED)
                return;
            if (_engagedTickTimer == 45)
            {
                if (_gender == Genders.FEMALE)
                {
                    eventList.Add(new FamilyBirthEvent(_parentFamily.OwnerVillage.CreateFamily(this, _fiance)));
                }
                else
                {
                    eventList.Add(new FamilyBirthEvent(_parentFamily.OwnerVillage.CreateFamily(_fiance, this)));
                }
            }
            else { _engagedTickTimer++; }

        }
        #endregion
        #region called by DieOrIsAlive
        override internal void OnDestroy()
        {
            Debug.Assert(IsDead(), "the villager is still alive!");
            if ((Gender == Genders.MALE) && (StatusInFamily == Status.SINGLE))
            {
                Debug.Assert(_fiance == null);
                Debug.Assert(Game.SingleMen.Contains(this));
                Game.SingleManDestroyed(this);
            }
            if (_virus != null)
            {
                if (_virus.Epidemic != null)
                {
                    _virus.Epidemic.SickVillagerList.Remove(this);
                }
                _virus = null;
            }

            if (_fiance != null)
            {
                _fiance.FianceDestroyed();
                Debug.Assert(_fiance == null);
            }
            if (_job != null)
                _job.WorkerDestroyed(this);
            Debug.Assert(_fiance == null, "he still has a fiance Oo !");
            _parentFamily.OwnerVillage.VillagerRemoved(this);
            _parentFamily.FamilyMemberDestroyed(this);
            Debug.Assert(_parentFamily == null, "he still has a parentfamily Oo !");
            Game.VillagerRemoved(this);
        }
        #endregion
        #region worldtickcalls
        override internal void ImpactHappiness()
        {
            ImpactGeneralFaithAdditionOrSubstraction();
            SickHappinessImpact();
            _parentFamily.OwnerVillage.JobHappiness(this);
        }
        internal override void Evolution()
        {
            double time = Game._ageTickTime;
            AgeTick(time);
            HandInOfferings();
            CallForHelpCheck();
            MatchMaking();
            CheckIfSick();
            HereticFaithImpact();
            Suicide();
        }
        internal override void Creation(List<IEvent> eventList)
        {
            double time = Game._ageTickTime;
            RegularBirths(time, eventList);//has to be after AgeTick.
            RegularFamilyCreation(eventList);
        }
        /// <summary>
        /// should only be called at world tick. If you want to kill a villager, use kill.
        /// </summary>
        override internal void DieOrIsAlive(List<IEvent> eventList)
        {
            if (_lifeExpectancy <= _age)
            {
                _health.Current = _health.Current | Healths.DEAD;
                if (ParentFamily != null)
                {
                    ParentFamily.FamilyMemberDied(this);
                }
            }
            Debug.Assert(((StatusInFamily == Status.ENGAGED || StatusInFamily == Status.MARRIED) && _fiance != null) || ((StatusInFamily == Status.SINGLE || StatusInFamily == Status.MOURNING) && _fiance == null), "Dans DieOrIsAlive");
            if (IsDead()) { eventList.Add(new VillagerDyingEvent(this, _parentFamily.Name)); Destroy(); }
        }
        override internal void CloseStep(List<IEvent> eventList)
        {
            if (_statusInFamily.Conclude()) { eventList.Add(new EventProperty<Villager>(this, "StatusInFamily")); }
            if (_happiness.Conclude()) { eventList.Add(new EventProperty<Villager>(this, "Happiness")); }
            if (_faith.Conclude()) { eventList.Add(new EventProperty<Villager>(this, "Faith")); }
            if (_health.Conclude())
            {
                if ((_health.Current & Healths.UNHAPPY) != 0)
                {
                    if (_health.Historic.Count > 1)
                    {
                        if ((_health.Historic[1] & Healths.UNHAPPY) == 0)
                            eventList.Add(new VillagerCallForHelp(this));
                    }
                    else
                    {
                        eventList.Add(new VillagerCallForHelp(this));
                    }
                }
                else { eventList.Add(new EventProperty<Villager>(this, "Health")); }
            }
        }
        #endregion
        //=================================================================
    }
}
