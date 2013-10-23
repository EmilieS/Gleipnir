using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family
{

    class Villager
    {
        public Villager(Family parentFamily)
        {
            Random rand=new Random();//to be moved elsewhere.

            switch (rand.Next(2))
            {
                case 0: _gender = Genders.MALE; _job = parentFamily.Father.Job; break; 
                case 1: _gender = Genders.FEMALE; _job = parentFamily.Mother.Job; break;
            }
            //TODO if new villager is a man, his job is the same as his father, same for woman->mother's job
            _job = Jobs.FARMER;
            _health = Healths.HEATHY;
            _age = 0;
            _lifeExpectancy = 85;
            _parentFamily = parentFamily;
            _statusInFamily = Status.SINGLE;

        }
        public float GoldGeneration()
        {
            //TODO: gold gain claculation
            return 1;
        }

        Family _parentFamily;
        Genders _gender;
        Jobs _job;
        float _lifeExpectancy;
        float _age;
        Status _statusInFamily;
        Healths _health; //a death has numerous consequences. Once they are fullfilled, this object is dropped.

        public Genders Gender { get { return _gender; } }
        public Jobs Job { get { return _job; } }
        public float LifeExpectancy { get { return _lifeExpectancy; } }

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
        internal Family ParentFamily
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
        /// Sets the new life expectancy based on the time left you want. if shorter than before.
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
        public void ReduceLifeExpectancy(float time)
        {
            if (_lifeExpectancy > time)
            {
                _lifeExpectancy -= time;
            }
            else
            {
                _lifeExpectancy = 0;
            }
        }
        /// <summary>
        /// should only be called at world tick. If you want to kill a villager, use kill.
        /// </summary>
        internal void DieOrIsAlive()
        {
            if (_lifeExpectancy <= _age) 
            {
                _health = Healths.DEAD;
            }
        }
        public void Kill()
        {
            _lifeExpectancy = 0;
        }
    }

}
