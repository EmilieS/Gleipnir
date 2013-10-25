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
            Random rand=new Random();//to be moved elsewhere.

            switch (rand.Next(2))
            {
                case 0: _gender = Genders.MALE; _job = parentFamily.Father.Job; break; 
                case 1: _gender = Genders.FEMALE; _job = parentFamily.Mother.Job; break;
            }
            if (rand.Next(101) < 2)
                _faith = 13;
            else
                _faith = parentFamily.FaithAverage();

            _happiness = parentFamily.HapinessAverage();            
            _job = Jobs.FARMER;
            _health = Healths.HEATHY;
            _age = 0;
            _lifeExpectancy = 85;
            _parentFamily = parentFamily;
            _statusInFamily = Status.SINGLE;
            _fiance = null;

            _name = "Afaire";

            _fiance.PropertyChanged += (sender, e) =>
            {
                _fiance = null;
            };
        }
        public Villager()
        { }
        


        //TODO : generate name.
        string _name;
        Family _parentFamily;
        Genders _gender;
        Jobs _job;
        float _lifeExpectancy;
        float _age;

        Status _statusInFamily; //!! 
        Villager _fiance; //!!!!!


        Healths _health; //a death has numerous consequences. Once they are fullfilled, this object is dropped.
        float _faith; //scale from 0 to 100.
        float _happiness; //scale from 0 to 100.

        public float Faith  { get { return _faith; } }
        public float Happiness { get { return _happiness; } }
        public Genders Gender { get { return _gender; } set { _gender = value; } } //obligé d'avoir le set pour les tests...
        public Jobs Job { get { return _job; } }
        public float LifeExpectancy { get { return _lifeExpectancy; } }


        /// <summary>
        /// if single, this will return an exeption!
        /// </summary>
        public Villager Fiance //public pour tests
        {
            get
            {
                if (_statusInFamily == Status.SINGLE || _fiance == null)
                {
                    throw new InvalidOperationException();
                }
                return _fiance;
            }
            set
            {
                if (_statusInFamily != Status.SINGLE)
                {
                    throw new InvalidOperationException();
                }
                _fiance = value;
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
        public void SetLifeExpectancyLeft(float timeLeft)
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

        #region worldtick

        /// <summary>
        /// should only be called at world tick. If you want to kill a villager, use kill.
        /// </summary>
        public void DieOrIsAlive()
        {
            if (_lifeExpectancy <= _age) 
            {
                _health = Healths.DEAD;
                if (_statusInFamily == Status.ENGAGED)
                {
                    _fiance.StatusInFamily = Status.SINGLE;
                    _fiance.Fiance = null;
                }
                else if (_statusInFamily == Status.MARRIED)
                {
                  //  _fiance.Fiance = null;//we keep the married status.
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

        public float GoldGeneration()
        {
            //TODO: gold gain calculation
            return 1;
        }
        #endregion



        public event PropertyChangedEventHandler PropertyChanged;
    }

}
