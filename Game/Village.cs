using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Game
{
    [Serializable]
    public class Village : GameItem
    {
        public UpgradesList _upgrades;
        internal readonly HistorizedValue<int, Village> _offeringsPointsPerTick;
        internal readonly HistorizedValue<int, Village> _villagePop;
        internal List<Buildings.House> EmptyHouseList;
        public Buildings.BuildingsList BuildingsList;
        public JobList JobsList;
        readonly string _name;
        int _familiesGold;
        double _villageFaith;
        double _villageHappiness;
        FamilyInVillageList _familiesList;

        internal Village(Game game, string name)
            : base(game)
        {
            Debug.Assert(!String.IsNullOrWhiteSpace(name));
            Debug.Assert(game != null, @"(village, Village) Game is null");

            // Initilize village's lists
            BuildingsList = new Buildings.BuildingsList(this);
            EmptyHouseList = new List<Buildings.House>();
            JobsList = new JobList(this);
            _familiesList = new FamilyInVillageList(this);

            // Initialize historized values
            _upgrades = new UpgradesList(this);
            _offeringsPointsPerTick = new HistorizedValue<int, Village>(this, @"_offeringsPointsPerTick", 20);
            _villagePop = new HistorizedValue<int, Village>(this, @"_villagePop", 20);

            // Set values
            _name = name;
            _offeringsPointsPerTick.Current = 1;
        }

        /// <summary>
        /// Gets village's families list
        /// </summary>
        public IReadOnlyList<Family> FamiliesList { get { return _familiesList; } }
        /// <summary>
        /// Gets the total gold for the village
        /// Addition of all families' gold
        /// </summary>
        public int Gold { get { return _familiesGold; } }
        /// <summary>
        /// Gets average faith of all families in the village.
        /// </summary>
        public double Faith { get { return _villageFaith; } }
        /// <summary>
        /// Gets the happiness of all the village
        /// </summary>
        public double Happiness { get { return _villageHappiness; } }
        /// <summary>
        /// Gets tax per villager per tick
        /// </summary>
        public int OfferingsPointsPerTick { get { return _offeringsPointsPerTick.Current; } }

        /// <summary>
        /// Add new villager in village
        /// </summary>
        internal void VillagerAdded()
        {
            _villagePop.Current++;
        }
        /// <summary>
        /// Remove villager from village
        /// </summary>
        /// <param name="villager"></param>
        internal void VillagerRemoved(Villager villager)
        {
            _villagePop.Current--;
        }

        /// <summary>
        /// Create family with mother and father
        /// </summary>
        /// <param name="mother"></param>
        /// <param name="father"></param>
        /// <returns></returns>
        public Family CreateFamily(Villager mother, Villager father)
        {
            if (mother.Gender != Genders.FEMALE || father.Gender != Genders.MALE)
                throw new InvalidOperationException(@"(village, CreateFamily) Gender issue");
            if (mother.ParentFamily != null && father.ParentFamily != null)
                if (mother.ParentFamily == father.ParentFamily)
                    throw new InvalidOperationException(@"(village, CreateFamily) Same family");

            // Create family
            var name = Game.NameList.NextName;
            var newFamily = new Family(Game, mother, father, name);

            // No house yet for this family
            Buildings.House house = null;

            // Add family to families list
            _familiesList.Add(newFamily);

            // Try add empty house to family
            if (EmptyHouseList.Count > 0)
            {
                int i = 0;
                while (i < EmptyHouseList.Count && house == null)
                {
                    if (EmptyHouseList[i].Hp > 0)
                    {
                        house = EmptyHouseList[0];
                        RemoveEmptyHouse(house);
                    }
                    i++;
                }
            }
            else // (house == null)
                house = new Buildings.House(this, JobsList.Construction_Worker.Workers.Count > 0);

            // Add house to family and family into house
            house.Family = newFamily;
            newFamily.House = house;

            return newFamily;
        }
        /// <summary>
        /// Create family without mother and father
        /// </summary>
        /// <returns></returns>
        public Family CreateFamilyFromScratch()
        {
            Debug.Assert(Game != null, @"(village, CreateFamilyFromScratch) Game is null");

            // Create family
            var name = Game.NameList.NextName;
            Villager VillagerAM = new Villager(Game, Genders.MALE, Game.FirstNameList.NextName);
            Villager VillagerAF = new Villager(Game, Genders.FEMALE, Game.FirstNameList.NextName);
            var newFamily = new Family(Game, VillagerAF, VillagerAM, name);

            // Add family into families list
            _familiesList.Add(newFamily);

            // Create new house
            Buildings.House house = new Buildings.House(this);

            // Add family into house and house in family
            house.Family = newFamily;
            newFamily.House = house;

            return newFamily;
        }
        /// <summary>
        /// Create family with no mother and no father but with jobs
        /// </summary>
        /// <param name="mothersJob"></param>
        /// <param name="fathersJob"></param>
        /// <returns></returns>
        public Family CreateFamilyFromScratch(JobsModel mothersJob, JobsModel fathersJob)
        {
            Debug.Assert(Game != null, @"(village, CreateFamilyFromScratch2) Game is null");

            // Create family
            var name = Game.NameList.NextName;
            Villager VillagerAM = new Villager(Game, Genders.MALE, Game.FirstNameList.NextName);
            Villager VillagerAF = new Villager(Game, Genders.FEMALE, Game.FirstNameList.NextName);
            var newFamily = new Family(Game, VillagerAF, VillagerAM, name);

            // Add family into families house
            _familiesList.Add(newFamily);

            // Remove villager into job worker list
            if (VillagerAF.Job != null)
                VillagerAF.Job.RemovePerson(VillagerAF);
            if (VillagerAM.Job != null)
                VillagerAM.Job.RemovePerson(VillagerAM);

            // Add villager into job worker list
            mothersJob.AddPerson(VillagerAF);
            fathersJob.AddPerson(VillagerAM);

            // Create new house
            Buildings.House house = new Buildings.House(this);

            // Add family into house and house in family
            house.Family = newFamily;
            newFamily.House = house;

            return newFamily;
        }

        /// <summary>
        /// Add new empty house in empty houses list
        /// </summary>
        /// <param name="house"></param>
        public void AddEmptyHouse(Buildings.House house)
        {
            // Debug.Assert(!EmptyHouseList.Contains(house), @"(village, AddEmptyHouse) This house is in EmptyHouseList");
            if (!EmptyHouseList.Contains(house))
                EmptyHouseList.Add(house);
        }
        /// <summary>
        /// Remove empty house for empty houses list
        /// </summary>
        /// <param name="house"></param>
        internal void RemoveEmptyHouse(Buildings.House house)
        {
            Debug.Assert(EmptyHouseList.Contains(house), @"(village, RemoveEmptyHouse) EmptyHouseList not have this house");
            EmptyHouseList.Remove(house);
        }

        public UpgradesList Upgrades { get { return _upgrades; } }
        /// <summary>
        /// Addition of all gold of all families
        /// </summary>
        /// <returns></returns>
        public void CalculateVillageGold()
        {
            int result = 0;

            foreach (Family fam in _familiesList)
                result += fam.GoldStash;

            if (result < 0)
                throw new IndexOutOfRangeException(@"(village, CalculateVillageGold) Negative gold!");
            else
                _familiesGold = result;
        }
        /// <summary>
        /// Dertermine average faith for all families in the village.
        /// </summary>
        /// <returns></returns>
        public double CalculateAverageVillageFaith()
        {
            double result = 0;
            int nb = _familiesList.Count;
            int nbf = nb;

            for (int i = 0; i < nb; i++) // Had to because some families only get deleted nextstep.
            {
                if (_familiesList[i].FamilyMembers.Count != 0)
                    result += _familiesList[i].FaithAverage();
                else
                    nbf--;
            }
            result = result / nbf;

            if (result < 0 || result > 100)
                throw new IndexOutOfRangeException(@"(village, CalculateVillageFaith) Negative or more than 100");

            _villageFaith = result;

            return result;
        }
        /// <summary>
        /// Dertermine the happiness of the village.
        /// </summary>
        /// <returns></returns>
        public double CalculateAverageVillageHappiness()
        {
            double result = 0;
            int nb = _familiesList.Count;
            int nbf = nb;

            for (int i = 0; i < nb; i++) // Had to because some families only get deleted nextstep.
            {
                if (_familiesList[i].FamilyMembers.Count != 0)
                    result += _familiesList[i].HappinessAverage();
                else
                    nbf--;
            }
            _villageHappiness = result / nbf;

            return _villageHappiness;
        }
        /// <summary>
        /// Calculate village's average faith and happiness
        /// </summary>
        public void CalculateAverageVillageHappinessAndFaith() // Trying to do faster
        {
            double totalH = 0;
            double totalF = 0;
            int nbf = _familiesList.Count;

            foreach (Family fam in _familiesList)
            {
                fam.CalculateHappinessAndFaithAverage();
                totalH += fam.HappinessAverageValue;
                totalF += fam.FaithAverageValue;
            }
            _villageHappiness = totalH / nbf;
            _villageFaith = totalF / nbf;
        }
        SamhainFest _samhainFest;
        SamhainFest SamhainFest { get; set; }

        public bool FestStart()
        {
            if (_samhainFest == null)
            {
                _samhainFest = new SamhainFest(this);
                return true;
            }
            return false;
        }
        internal void FestEnded()
        {
            if (_samhainFest == null) { throw new InvalidOperationException(); }
            _samhainFest = null;
        }



        /// <summary>
        /// Modify number offering points generated
        /// </summary>
        /// <returns></returns>
        public void SetOfferingsPoints(int playerChoice)
        {
            if (playerChoice <= 0)
                _offeringsPointsPerTick.Current = 1;
            else if (playerChoice >= 100)
                _offeringsPointsPerTick.Current = 100;
            else
                _offeringsPointsPerTick.Current = playerChoice;
        }
        /// <summary>
        /// Take gold from families and add offerings points
        /// </summary>
        /// <param name="amount"></param>
        public void TransformGoldToOfferingsPoints(int amount)// WTF NOT USED a part from village test.
        {
            if (amount >= 1 && amount <= 100)
            {
                int offerings = 0;
                foreach (Family fam in _familiesList)
                    offerings += fam.TakeFromGoldStash(amount);

                Game.AddOrTakeFromOfferings(offerings);
            }
            else
                throw new ArgumentOutOfRangeException(@"(village, TransformGoldToOfferingsPoints) Take 0 or more than 100");
        }

        /// <summary>
        /// Remove and delete empty families
        /// </summary>
        /// <param name="eventList"></param>
        internal void EmptyFamiliesCleaner(List<IEvent> eventList)
        {
            int nbf = FamiliesList.Count;
            Family tmpFamily;

            int i = 0;
            while (i < nbf)
            {
                tmpFamily = FamiliesList[i];
                FamiliesList[i].DieOrIsAlive(eventList);
                if (tmpFamily.IsDestroyed)
                    nbf--;
                else
                    i++;
            }
            tmpFamily = null;
        }
        /// <summary>
        /// Remove destroyed family from families list
        /// </summary>
        /// <param name="family"></param>
        internal void FamilyDestroyed(Family family)
        {
            Debug.Assert(family != null, @"(village, FamilyDestroyed) Family don't exist");
            _familiesList.Remove(family);
        }

        //TODO: !!! use new list & all jobs destroyed.
        /*internal void DestroyJobs(JobsModel jobName)
        {
            Debug.Assert(jobName != null);
            _jobs.Remove(jobName);
        }*/

        // called by ImpactHappiness
        /// <summary>
        /// Add happiness from job to villagers
        /// </summary>
        /// <param name="villager"></param>
        internal void JobHappiness(Villager villager)
        {
            foreach (JobsModel job in JobsList.HappinessJobList)
                job.AddHappiness(villager);
        }

        /// <summary>
        /// Destroy village
        /// </summary>
        internal override void OnDestroy()
        {
            JobsList.Destroy();
            JobsList = null;
            Debug.Assert(_familiesList.Count == 0, @"(village, OnDestroy) Still family in village");
        }
        /// <summary>
        /// End step with events
        /// </summary>
        /// <param name="eventList"></param>
        override internal void CloseStep(List<IEvent> eventList)
        {
            //TODO :  put current values in value history.
            if (_familiesList.Conclude())
                eventList.Add(new VillageEventProperty(this, @"FamiliesList"));
            if (_offeringsPointsPerTick.Conclude())
                eventList.Add(new VillageEventProperty(this, @"OfferingsPointsPerTick"));
            //JobList is invariant.
            //TODO : events!
        }
    }
}
