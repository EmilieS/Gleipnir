using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Village
    {
        List<Family> _family;
        List<Jobs> _jobs;
        double _familiesGold;
        double _villageFaith;
        double _villageHappiness;
        int _offeringsPoints;

        public Village(List<Family> families)
        {
            //TODO: Families List
            _family = families;

            //TODO: Jobs List
            foreach (Jobs job in _jobs)
            {
                _jobs.Add(job);
            }

            //TODO: Set village's Gold
            _familiesGold = CalculateVillageGold();

            //TODO: Set village's faith
            _villageFaith = CalculateAverageVillageFaith();

            //TODO: Set village's happiness
            _villageHappiness = CalculateAverageVillageHappiness();

            //TODO: Set village's offerings points
            _offeringsPoints = 10;
        }

        /// <summary>
        /// Add a family to the village
        /// </summary>
        /// <param name="family"></param>
        public void addFamily(Family family)
        {
            if (!_family.Equals(family))
            {
                _family.Add(family);
            }
        }

        /// <summary>
        /// Remove a familyfrom the village
        /// </summary>
        /// <param name="family"></param>
        public void removeFamily(Family family)
        {
            if(_family.Equals(family))
            {
                _family.Remove(family);
            }
        }

        /// <summary>
        /// Gets the total gold for the village.
        /// Addition of all families' gold
        /// </summary>
        public double Gold { get { return _familiesGold; } }

        /// <summary>
        /// Addition of all gold of all families
        /// </summary>
        /// <returns></returns>
        public double CalculateVillageGold()
        {
            double result = 0;
            foreach (Family fam in _family)
            {
                result += fam.GoldStash;
            }
            return result;
        }

        /// <summary>
        /// Gets average faith of all families in the village.
        /// </summary>
        public double Faith { get { return _villageFaith; } }

        /// <summary>
        /// Dertermine average faith for all families in the village.
        /// </summary>
        /// <returns></returns>
        public double CalculateAverageVillageFaith()
        {
            double result = 0;
            foreach (Family fam in _family)
            {
                result += fam.FaithAverage();
            }
            return result = result / _family.Count;
        }

        /// <summary>
        /// Gets the happiness of all the village
        /// </summary>
        public double Happiness { get { return _villageHappiness; } }

        /// <summary>
        /// Dertermine the happiness of the village.
        /// </summary>
        /// <returns></returns>
        public double CalculateAverageVillageHappiness()
        {
            double result = 0;
            foreach (Family fam in _family)
            {
                result += fam.HappinessAverage();
            }
            return result = result / _family.Count;
        }

        /// <summary>
        /// Modify number offering points generated
        /// </summary>
        /// <returns></returns>
        public void SetOfferingsPoints(int playerChoice)
        {
            if (playerChoice <= 0)
            {
                _offeringsPoints = 1;
            }
            else if (playerChoice >= 100)
            {
                _offeringsPoints = 100;
            }
            else
            {
                _offeringsPoints = playerChoice;
            }

            if (_offeringsPoints >= 1 && _offeringsPoints <= 100)
            {
                foreach (Family fam in _family)
                {
                    fam.takeFromGoldStash(playerChoice);
                }
            }
        }
    }
}
