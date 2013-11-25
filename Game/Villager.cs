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
    public partial class Villager : GameItem
    {
        internal Villager(Game g, Family parentFamily, string name)    //TODO: autre constructeur pour le début...
            : base(g)
        {
            _faith = new HistorizedValue<double, Villager>(this, "_faith", 20);
            _happiness = new HistorizedValue<double, Villager>(this, "_happiness", 20);
            _health = new HistorizedValue<Healths, Villager>(this, "_health", 20);
            _statusInFamily = new HistorizedValue<Status, Villager>(this, "_statusInFamily", 20);
            _statusInFamily.Current = Status.SINGLE;
            g.VillagerAdded();

            Random rand = new Random();//to be moved elsewhere.
            Debug.Assert(g != null);
            switch (rand.Next(2))
            {
                case 0: _gender = Genders.MALE; _job = parentFamily.Father.Job; g.AddSingleMan(this); break; //changera    
                case 1: _gender = Genders.FEMALE; _job = parentFamily.Mother.Job; Engage(this, parentFamily); break;
            }
            if (rand.Next(101) < 2)
                _faith.Current = 13;
            else
                _faith.Current = parentFamily.FaithAverage();

            _happiness.Current = parentFamily.HappinessAverage();
            //_job = Jobs.FARMER;
            _health.Current = Healths.NONE;
            _age = 0;
            _lifeExpectancy = 85;

            _name = parentFamily.FirstNameList.NextName;
        }
        public Villager(Game g, Genders gender)
            : base(g)
        {
            _faith = new HistorizedValue<double, Villager>(this, "_faith", 20);
            _happiness = new HistorizedValue<double, Villager>(this, "_happiness", 20);
            _health = new HistorizedValue<Healths, Villager>(this, "_health", 20);
            _statusInFamily = new HistorizedValue<Status, Villager>(this, "_statusInFamily", 20);
            g.VillagerAdded();
            _faith.Current = 100;
            _happiness.Current = 80;
            _lifeExpectancy = 85;
            _gender = gender;
            _statusInFamily.Current = Status.SINGLE;
        }

        //TODO : generate name.
        string _name;
        Family _parentFamily;
        Genders _gender;
        Jobs _job;
        double _lifeExpectancy;
        double _age;
        double _goldInWallet;
        Villager _fiance; //!!!!!
        public Healths Health{get{return _health.Current;}}

        readonly HistorizedValue<double, Villager> _faith; //scale from 0 to 100.
        readonly HistorizedValue<double, Villager> _happiness; //scale from 0 to 100.
        readonly HistorizedValue<Healths, Villager> _health;
        readonly HistorizedValue<Status, Villager> _statusInFamily; //!! TODO : update !

        public double Age { get { return _age; } }
        public double Faith { get { return _faith.Current; } } //hmm
        public double Happiness { get { return _happiness.Current; } } //hmm
        public Genders Gender { get { return _gender; } }
        public Jobs Job { get { return _job; } }
        public double LifeExpectancy { get { return _lifeExpectancy; } }

        public Status StatusInFamily
        {
            get { return _statusInFamily.Current; }
            internal set { _statusInFamily.Current = value; }
        }
        public Family ParentFamily
        {
            get { return _parentFamily; }
            internal set { _parentFamily = value; } 
        }
        public void setJob(Jobs NewJob)
        {
            _job = NewJob;
        }

        #region death & family issues.
        //=====================================================================================


        /// <summary>
        /// should only be called at world tick.
        /// </summary>
        /// <param name="time"></param>
        internal void AgeTick(float time)
        {
            _age += time;
        }


        //======================================================================================
        #endregion
        /// <summary>
        /// Gets or Sets the villager's name
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Get amount of gold the villager have
        /// </summary>
        public double Wallet
        {
            get { return _goldInWallet; }
        }

        /// <summary>
        /// Sets the new life expectancy no matter what time was left.
        /// </summary>
        /// <param name="lifeExpectancy"></param>
        public void SetLifeExpectancy(float lifeExpectancy)
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
        public void ReduceLifeExpectancy(float timeleft)
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

        #region worldtick
        #region WhenWorldUpdate

        private void Suicide()
        {
            if (_happiness.Current == 0 && (_health.Current & Healths.DEPRESSED) == 0) //a revoir
            {
                SetLifeExpectancyLeft(0.4);
                _health.Current = _health.Current | Healths.DEPRESSED;
            }
        }

        #endregion
        #region happiness & faith evolution

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
        internal void Sickly()
        {
            if ((_health.Current & Healths.SICK) != 0)
            {
                AddOrRemoveHappiness(0.1);
                ParentFamily.FamilyMemberIsSick();
            }
        }

        private void CallForHelp() //TODO : add timer /brainstorm how to use this.
        {
            if (_happiness.Current < 25 && (_health.Current & Healths.UNHAPPY) == 0)
            {
                _health.Current = _health.Current | Healths.UNHAPPY;

            }
        }

        private void CallForHelpEnded() //once the CallForHelp timer is ended.
        {
            if (_happiness.Current > 27)
            {
                _health.Current = _health.Current & ~Healths.UNHAPPY;
                AddOrRemoveFaith(20);
            }
            else if (_happiness.Current < 25)
            {
                AddOrRemoveFaith(-20);
            }
        }

        /// <summary>
        /// can be negative to take away faith.
        /// </summary>
        /// <param name="amount"></param>
        public void AddOrRemoveFaith(double amount)
        {
            if (_faith.Current + amount < 0)
            {
                _faith.Current = 0;
            }
            else if (_faith.Current + amount > 100)
            {
                _faith.Current = 100;
            }
            else
            {
                _faith.Current += amount;
            }
        }

        #endregion

        /// <summary>
        /// Add money the villager earn
        /// </summary>
        /// <param name="goldAdd"></param>
        public void AddGoldInWallet(double goldAdd)
        {
            _goldInWallet += goldAdd;
        }

        /// <summary>
        /// amount set by player. Returns the true amount taken.(imagine family is broke)
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        internal double HandInOfferings(double amount)//see if we can do this in a more intelligent manner.
        {
            if ((_health.Current & Healths.HERETIC) == 0)
            {
                return ParentFamily.takeFromGoldStash(amount);
            }
            return 0;
        }
        #endregion

        override internal void OnDestroy()
        {
            Debug.Assert(IsDead(), "the villager is still alive!");
            if ((Gender == Genders.MALE) && (StatusInFamily == Status.SINGLE))
            {
                Debug.Assert(_fiance == null);
                Debug.Assert(Game.SingleMen.Contains(this));
                Game.SingleManDestroyed(this);
            }

            if (_fiance != null)
            {
                _fiance.FianceDestroyed();
                Debug.Assert(_fiance == null);
            }
            Debug.Assert(_fiance == null);
            _parentFamily.FamilyMemberDestroyed(this);
            Debug.Assert(_parentFamily == null);

            Game.VillagerRemoved(this);
            //_job = null;
        }

        /// <summary>
        /// should only be called at world tick. If you want to kill a villager, use kill.
        /// </summary>
        override internal void DieOrIsAlive(List<IEvent> eventList)
        {
            if (_lifeExpectancy <= _age)
            {
                _health.Current = Healths.DEAD;
                if (ParentFamily != null)
                {
                    ParentFamily.FamilyMemberDied(this);
                }

            }
            Debug.Assert(((StatusInFamily == Status.ENGAGED || StatusInFamily == Status.MARRIED) && _fiance != null) || ((StatusInFamily == Status.SINGLE || StatusInFamily == Status.MOURNING) && _fiance == null), "Dans DieOrIsAlive");
            if (IsDead()) { eventList.Add(new VillagerDyingEvent(this)); Destroy(); }
        }

        override internal void CloseStep(List<IEvent> eventList)
        {
            if (_statusInFamily.Conclude()) { eventList.Add(new EventProperty<Villager>(this, "StatusInFamily")); }
            if (_happiness.Conclude()) { eventList.Add(new EventProperty<Villager>(this, "Happiness")); }        
            if (_faith.Conclude()){eventList.Add(new EventProperty<Villager>(this, "Faith")); }
            if (_health.Conclude()){eventList.Add(new EventProperty<Villager>(this, "Health")); }
                  
        }
    }

}
