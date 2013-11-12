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

        public Village(Game thisGame)
        {
            _familiesList=new FamilyInVillageList(this);
            _thisGame = thisGame;
            
            //TODO: Jobs List
            /*foreach (Jobs job in _jobs)
            {
                _jobs.Add(job);
            }

            //TODO: Set village's Gold
            CalculateVillageGold();

            //TODO: Set village's faith
            CalculateAverageVillageFaith();

            //TODO: Set village's happiness
            _villageHappiness = CalculateAverageVillageHappiness();

            //TODO: Set village's offerings points
            _offeringsPoints = 10;
             */
             
        }
        public Village(List<Family> families, Game thisGame)
        {
            _familiesList = new FamilyInVillageList(this);
            for (int i=0; i<families.Count; i++)
            {
            _familiesList.Add(families[i]);
            }
        }

        Game _thisGame;
        public Game ThisGame { get { return _thisGame; } }
        FamilyInVillageList _familiesList;
        public FamilyInVillageList FamiliesList { get { return _familiesList; } }

        public void AddFamily(Family family)
        {
            _familiesList.Add(family);
        }
        public void RemoveFamily(Family family)
        {
            _familiesList.Remove(family);
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
        public void CalculateVillageGold()
        {
            double result = 0;
            foreach (Family fam in _family)
            {
                result += fam.GoldStash;
            }

            if (result < 0) 
                throw new IndexOutOfRangeException();
            else 
                _familiesGold = result;
        }

        /// <summary>
        /// Gets average faith of all families in the village.
        /// </summary>
        public double Faith { get { return _villageFaith; } }

        /// <summary>
        /// Dertermine average faith for all families in the village.
        /// </summary>
        /// <returns></returns>
        public void CalculateAverageVillageFaith()
        {
            double result = 0;
            foreach (Family fam in _family)
            {
                result += fam.FaithAverage();
            }

            if (result < 0 && result > 100)
                throw new IndexOutOfRangeException();
            else
                _villageFaith = result / _family.Count;
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
