using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Game
{
    public class Village : GameItem
    {

        List<Jobs> _jobs;
        double _familiesGold;
        double _villageFaith;
        double _villageHappiness;
        int _offeringsPoints;

        readonly string _name;
        FamilyInVillageList _familiesList;
        public FamilyInVillageList FamiliesList { get { return _familiesList; } }

        internal Village(Game thisGame, string name)
            : base(thisGame)
        {
            Debug.Assert(!String.IsNullOrWhiteSpace(name));
            _name = name;
            _familiesList=new FamilyInVillageList(this);

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
        public Village(List<Family> families, Game thisGame)//a éliminer.
            : base(thisGame)
        {
            _familiesList = new FamilyInVillageList(this);
            for (int i=0; i<families.Count; i++)
            {
            _familiesList.Add(families[i]);
            }
        }

        Game _thisGame;
        public Game ThisGame { get { return _thisGame; } }


        public void AddFamily(Family family)
        {
            _familiesList.Add(family);
        }
        public void RemoveFamily(Family family)
        {
            _familiesList.Remove(family);
        }

        public Family CreateFamily(Villager mother, Villager father)
        {
            var newFamily= new Family(_thisGame, mother, father, "default");
            FamiliesList.Add(newFamily);
            return newFamily;
        }
        //TODO : CreateFamilyFromScratch
        public Family CreateFamilyFromScratch()
        {
            Villager VillagerAM = new Villager(_thisGame, Genders.MALE);
            Villager VillagerAF = new Villager(_thisGame, Genders.FEMALE);
            var newFamily = new Family(_thisGame, VillagerAF, VillagerAM, "default");
            FamiliesList.Add(newFamily);
            return newFamily;
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
            foreach (Family fam in _familiesList)
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
            foreach (Family fam in _familiesList)
            {
                result += fam.FaithAverage();
            }

            if (result < 0 && result > 100)
                throw new IndexOutOfRangeException();
            else
                _villageFaith = result / _familiesList.Count;
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
            foreach (Family fam in _familiesList)
            {
                result += fam.HappinessAverage();
            }
            return result = result / _familiesList.Count;
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
                foreach (Family fam in _familiesList  )
                {
                    fam.takeFromGoldStash(playerChoice);
                }
            }
        }
        internal override void OnDestroy()
        {
            Debug.Assert(_familiesList.Count == 0, "there is still a family in this village!");
        }
        override internal void CloseStep()
        {
            //TODO :  put current values in value history.
            foreach(Family family in _familiesList)
            {
                if (family.FamilyMembers.Count == 0)
                {
                    _familiesList.Remove(family);
                }
            }  
            //jobs
            //TODO : events!
        }
    }
}
