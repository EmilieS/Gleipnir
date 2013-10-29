using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            _happiness = parentFamily.HapinessAverage();            
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

        Status _statusInFamily; //!! 
        Villager _fiance; //!!!!!


        Healths _health; //a death has numerous consequences. Once they are fullfilled, this object is dropped.
        float _faith; //scale from 0 to 100.
        double _happiness; //scale from 0 to 100.

        public float Faith  { get { return _faith; } }
        public double Happiness { get { return _happiness; } }
        public Genders Gender { get { return _gender; } set { _gender = value; } } //obligé d'avoir le set pour les tests...
        public Jobs Job { get { return _job; } }
        public double LifeExpectancy { get { return _lifeExpectancy; } }


        /// <summary>
        /// if single, this will return an exeption!
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
                        if (e.PropertyName =="died" && _fiance == sender)
                        {                            
                            _fiance = null;
                           if(StatusInFamily == Status.ENGAGED ){ _statusInFamily=Status.SINGLE;}
                        }
                    };
                }
            }
        }
        public Status StatusInFamily
        {
            get
            {
                return _statusInFamily;
            }
            internal set
            {
                _statusInFamily = value; //riqueraque
            }
        }
        public Family ParentFamily
        {
            get
            {
                return  _parentFamily;
            }
            set
            {
                _parentFamily = value; //riqueraque
            }
        }

        public void setJob(Jobs NewJob)
        {
            _job = NewJob;
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
        public void Kill()
        {
            _lifeExpectancy = 0;
        }

        private void Suicide()
        {
            if (_happiness == 0 && (_health & Healths.DEPRESSED)==0) //a revoir
            {
                SetLifeExpectancyLeft(0.4);
                _health = _health | Healths.DEPRESSED;
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
        /// <summary>
        /// can be negative to take away faith.
        /// </summary>
        /// <param name="amount"></param>
        public void AddOrRemoveFaith(double amount)
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
        #region worldtick 
        //public for tests... should be internal.
        /// <summary>
        /// should only be called at world tick. If you want to kill a villager, use kill.
        /// </summary>
        public void DieOrIsAlive()
        {
            if (_lifeExpectancy <= _age) 
            {
                _health = Healths.DEAD;
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

        public float GoldGeneration()
        {
            //TODO: gold gain calculation
            return 1;
        }

        internal void IsSick() 
        {
            if ((_health & Healths.SICK) != 0) //need to see if we can attach this to an event in an intelligent manner.
            {
                //TODO

            }
        }




        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
    }

}
