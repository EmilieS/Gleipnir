﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Villager : INotifyPropertyChanged
    {
        internal Villager(Family parentFamily)    //TODO: autre constructeur pour le début...
        {
            _statusInFamily = Status.SINGLE;

            Random rand=new Random();//to be moved elsewhere.

            switch (rand.Next(2))
            {
                case 0: _gender = Genders.MALE; _job = parentFamily.Father.Job; Game._singleMen.Add(this); break; //changera    
                case 1: _gender = Genders.FEMALE; _job = parentFamily.Mother.Job; break; 
            }
            if (rand.Next(101) < 2)
                _faith = 13;
            else
                _faith = parentFamily.FaithAverage();

            _happiness = parentFamily.HappinessAverage();            
            _job = Jobs.FARMER;
            _health = Healths.NONE;
            _age = 0;
            _lifeExpectancy = 85;
            _fiance = null;
            _name = "Afaire";
        }
        public Villager()
        {
            _faith = 100;
            _happiness = 80;
            _lifeExpectancy = 85;
            _statusInFamily = Status.SINGLE;
        }
        
         //TODO : generate name.
        string _name;
        Family _parentFamily;
        Genders _gender;
        Jobs _job;
        double _lifeExpectancy;
        float _age;
        float _goldInWallet;
        Status _statusInFamily; //!! 
        Villager _fiance; //!!!!!

        Healths _health; //a death has numerous consequences. Once they are fullfilled, this object is dropped.
        double _faith; //scale from 0 to 100.
        double _happiness; //scale from 0 to 100.
        public event PropertyChangedEventHandler PropertyChanged;

        public double Faith  { get { return _faith; } }
        public double Happiness { get { return _happiness; } }
        public Genders Gender { get { return _gender; } set { _gender = value; } } //obligé d'avoir le set pour les tests...
        public Jobs Job { get { return _job; } }
        public double LifeExpectancy { get { return _lifeExpectancy; } }

        public Status StatusInFamily
        {
            get { return _statusInFamily; }
            internal set { _statusInFamily = value; }//riqueraque
        }
        public Family ParentFamily
        {
            get { return _parentFamily; }
            set { _parentFamily = value; } //riqueraque
        }
        public void setJob(Jobs NewJob)
        {
            _job = NewJob;
        }

       

        #region death & family issues.
        //=====================================================================================
        //public for tests... should be internal.
        /// <summary>
        /// should only be called at world tick. If you want to kill a villager, use kill.
        /// </summary>
        public void DieOrIsAlive()
        {
            if (_lifeExpectancy <= _age) 
            {
                _health = Healths.DEAD;
                if (_parentFamily != null)
                {

                    _parentFamily.FamilyMemberDied(this);
                    _parentFamily.FamilyMembers.Remove(this);
                }
                PropertyChangedEventHandler h = PropertyChanged;
                if (h != null) { h(this, new PropertyChangedEventArgs("died")); }                
            }
        }
        /// <summary>
        /// should only be called at world tick.
        /// </summary>
        /// <param name="time"></param>
        internal void AgeTick(float time)
        {
            _age += time;
        }
        /// <summary>
        /// If single, this will return an exeption!
        /// </summary>
        public Villager Fiance //public pour tests //cannot catch this with an Assert.Throws...
        {
            get
            {
                //if (_statusInFamily == Status.SINGLE) { throw new InvalidOperationException("villager is single"); } 
                //if (_fiance == null) { throw new NullReferenceException(); }
                return _fiance;
            }
            set
            {
                _fiance = value;
                if (value != null)
                {
                    if (StatusInFamily == Status.SINGLE) { StatusInFamily = Status.ENGAGED; }
                    _fiance.PropertyChanged += (sender, e) =>
                    {
                        if (e.PropertyName == "died" && _fiance == sender)
                        {
                            _fiance = null;
                            if (StatusInFamily == Status.ENGAGED) { _statusInFamily = Status.SINGLE; }
                        }
                    };
                }
            }
        }
        //======================================================================================
        #endregion
        /// <summary>
        /// Gets or Sets the villager's name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                string[] nameTab = File.ReadAllLines(@"D:\LS4Tonio\IN'TECH_INFO\PI\Gleipnir\Gleipnir\name_list.txt");
                Random randomInt = new Random();    // Random number

                _name = nameTab[randomInt.Next(nameTab.Count())];
            }
        }

       
        /// <summary>
        /// Define if the villager is single/engaged/married
        /// </summary>
        /// <summary>
        /// Family's villager
        /// </summary>
        /// <summary>
        /// Get amount of gold the villager have
        /// </summary>
        public float Wallet
        {
            get { return _goldInWallet; }
        }

        /// <summary>
        /// Define which job the villager is
        /// </summary>
        /// <param name="NewJob"></param>

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
            if (_happiness == 0 && (_health & Healths.DEPRESSED) == 0) //a revoir
            {
                SetLifeExpectancyLeft(0.4);
                _health = _health | Healths.DEPRESSED;
            }
        }
        //======================================================================================
        #endregion
        #region happiness & faith evolution
        //------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// can be negative to take away happiness.
        /// </summary>
        /// <param name="amount"></param>
        public void AddOrRemoveHappiness(double amount)
        {
            if (_happiness + amount < 0)
            {
                _happiness = 0;
            }
            else if (_happiness + amount > 100)
            {
                _happiness = 100;
            }
            else
            {
                _happiness += amount;
            }
        }

        internal void IsSick()
        {
            if ((_health & Healths.SICK) != 0) //need to see if we can attach this to an event in an intelligent manner.
            {
                AddOrRemoveHappiness(0.1);
                ParentFamily.FamilyMemberIsSick();
            }
        }

        private void CallForHelp() //TODO : add timer /brainstorm how to use this.
        {
            if (_happiness < 25 && (_health & Healths.UNHAPPY) == 0)
            {
                _health = _health | Healths.UNHAPPY;
                PropertyChangedEventHandler h = PropertyChanged;
                if (h != null) { h(this, new PropertyChangedEventArgs("unhappy")); }
            }
        }

        private void CallForHelpEnded() //once the CallForHelp timer is ended.
        {
            if (_happiness > 27)
            {
                _health = _health & ~Healths.UNHAPPY;
                AddOrRemoveFaith(20);
            }
            else if (_happiness < 25)
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
            if (_faith + amount < 0)
            {
                _faith = 0;
            }
            else if (_faith + amount > 100)
            {
                _faith = 100;
            }
            else
            {
                _faith += amount;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------
        #endregion
  
        /// <summary>
        /// Add money the villager earn
        /// </summary>
        /// <param name="goldAdd"></param>
        public void AddGoldInWallet(float goldAdd)
        {
            _goldInWallet += goldAdd;
        }
        /// <summary>
        /// amount set by player. Returns the true amount taken.(imagine family is broke)
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        internal int HandInOfferings(int amount)//see if we can do this in a more intelligent manner.
        {
            if ((_health & Healths.HERETIC) == 0)
            {
                return ParentFamily.takeFromGoldStash(amount);
            }
            return 0;
        }
        #endregion
    }

}