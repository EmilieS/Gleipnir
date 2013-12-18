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
        //List<JobsModel> _jobs;// needs to be cleansed
        public JobList Jobs;
        int _familiesGold;
        double _villageFaith;
        double _villageHappiness;
        int _offeringsPoints;
        internal readonly HistorizedValue<int, Village> _villagePop;
        public Buildings.BuildingsList Buildings;
        internal List<Buildings.House> EmptyHouseList;

        public double VillageFaith { get { return _villageFaith; } }
        public double VillageHappiness { get { return _villageHappiness; } }
        readonly string _name;
        FamilyInVillageList _familiesList;
        public IReadOnlyList<Family> FamiliesList { get { return _familiesList; } }

        // public Village(List<Family> families)
        internal Village(Game thisGame, string name)
            : base(thisGame)
        {
            Buildings = new Buildings.BuildingsList(this);
            EmptyHouseList = new List<Buildings.House>();
            _villagePop = new HistorizedValue<int, Village>(this, "_villagePop", 20);
            Debug.Assert(!String.IsNullOrWhiteSpace(name));
            Debug.Assert(thisGame != null, "thisGame is null!");
            _name = name;
            _familiesList = new FamilyInVillageList(this);
            //_jobs = CreateJobs();
            Jobs = new JobList(this);
            _offeringsPoints = 1;
        }

        internal void VillagerAdded()
        {
            _villagePop.Current++;
        }

        public Family CreateFamily(Villager mother, Villager father)
        {
            if (mother.Gender != Genders.FEMALE || father.Gender != Genders.MALE) { throw new InvalidOperationException("gender issue! (CreateFamily)"); }
            if (mother.ParentFamily != null && father.ParentFamily != null)
            {
                if (mother.ParentFamily == father.ParentFamily) { throw new InvalidOperationException("same family!"); }
            }
            var name = Game.NameList.NextName;
            var newFamily = new Family(Game, mother, father, name);
            _familiesList.Add(newFamily);
            Buildings.House house;
            if (EmptyHouseList.Count == 0)
            {
                house = new Buildings.House(this, Jobs.Construction_worker.Workers.Count > 0);
            }
            else
            {
                house = EmptyHouseList[0];
                EmptyHouseList.Remove(house);
            }
            house.Family = newFamily;
            newFamily.House = house;
            return newFamily;
        }
        public Family CreateFamilyFromScratch()
        {
            //Debug.Assert(_thisGame != null, "_thisGame est null!");
            Debug.Assert(Game != null, "Game est null!");
            Villager VillagerAM = new Villager(Game, Genders.MALE, Game.FirstNameList.NextName);
            Villager VillagerAF = new Villager(Game, Genders.FEMALE, Game.FirstNameList.NextName);
            var name = Game.NameList.NextName;
            var newFamily = new Family(Game, VillagerAF, VillagerAM, name);
            _familiesList.Add(newFamily);
            Buildings.House house = new Buildings.House(this);
            house.Family = newFamily;
            newFamily.House = house;
            return newFamily;
        }
        public Family CreateFamilyFromScratch(JobsModel mothersJob, JobsModel fathersJob)
        {
            //Debug.Assert(_thisGame != null, "_thisGame est null!");
            Debug.Assert(Game != null, "Game est null!");
            Villager VillagerAM = new Villager(Game, Genders.MALE, Game.FirstNameList.NextName);
            Villager VillagerAF = new Villager(Game, Genders.FEMALE, Game.FirstNameList.NextName);
            var name = Game.NameList.NextName;
            var newFamily = new Family(Game, VillagerAF, VillagerAM, name);
            _familiesList.Add(newFamily);
            VillagerAF.Job.RemovePerson(VillagerAF);
            VillagerAM.Job.RemovePerson(VillagerAM);
            mothersJob.AddPerson(VillagerAF);
            fathersJob.AddPerson(VillagerAM);
            return newFamily;
        }
        internal void AddEmptyHouse(Buildings.House house)
        {
            Debug.Assert(!EmptyHouseList.Contains(house));
            EmptyHouseList.Add(house);
        }
        internal void RemoveEmptyHouse(Buildings.House house)
        {
            Debug.Assert(EmptyHouseList.Contains(house));
            EmptyHouseList.Remove(house);
        }

        /// <summary>
        /// Gets the total gold for the village.
        /// Addition of all families' gold
        /// </summary>
        public int Gold { get { return _familiesGold; } }

        /// <summary>
        /// Addition of all gold of all families
        /// </summary>
        /// <returns></returns>
        public void CalculateVillageGold()
        {
            int result = 0;
            foreach (Family fam in _familiesList)
            {
                result += fam.GoldStash;
            }

            if (result < 0) throw new IndexOutOfRangeException();
            else _familiesGold = result;
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
            /*foreach (Family fam in _familiesList)
            {
                result += fam.FaithAverage();
            }*/

            int nb = _familiesList.Count;
            int nbf = nb;
            for (int i = 0; i < nb; i++)//had to because some families only get deleted nextstep.
            {
                if (_familiesList[i].FamilyMembers.Count != 0)
                {
                    result += _familiesList[i].FaithAverage();
                }
                else
                {
                    nbf--;
                }
            }
            result = result / nbf;

            if (result < 0 || result > 100)
                throw new IndexOutOfRangeException();

            _villageFaith = result;
            return result;
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
            int nb = _familiesList.Count;
            int nbf = nb;
            for (int i = 0; i < nb; i++)//had to because some families only get deleted nextstep.
            {
                if (_familiesList[i].FamilyMembers.Count != 0)
                {
                    result += _familiesList[i].HappinessAverage();
                }
                else
                {
                    nbf--;
                }
            }
            /*foreach (Family fam in _familiesList)
            {
                result += fam.HappinessAverage();
            }*/
            _villageHappiness = result / nbf;
            return _villageHappiness;
        }

        public void CalculateAverageVillageHappinessAndFaith()//trying to make thing faster.
        {
            double totalH = 0;
            double totalF = 0;
            int nbf = _familiesList.Count;
            //int nb = nbf;
           /* for (int i = 0; i < nb; i++)//had to because some families only get deleted nextstep.
            {
                if (_familiesList[i].FamilyMembers.Count != 0)
                {
                    _familiesList[i].CalculateHappinessAndFaithAverage();
                    //totalH += _familiesList[i].HappinessAverage();
                    //totalF += _familiesList[i].FaithAverage();
                    totalH += _familiesList[i].HappinessAverageValue;
                    totalF += _familiesList[i].FaithAverageValue;

                }
                else
                {
                    nbf--;
                }
            }*/
            foreach (Family fam in _familiesList)
            {
                fam.CalculateHappinessAndFaithAverage();
                totalH += fam.HappinessAverageValue;
                totalF += fam.FaithAverageValue;
            }
            _villageHappiness = totalH / nbf;
            _villageFaith = totalF / nbf;
        }

        /// <summary>
        /// tax per villager per tick.
        /// /// </summary>
        public int OfferingsPointsPerTick { get { return _offeringsPoints; } }


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
        }

        /// <summary>
        /// Take gold from families and add offerings points
        /// </summary>
        /// <param name="amount"></param>
        public void TransformGoldToOfferingsPoints(int amount)
        {
            if (amount >= 1 && amount <= 100)
            {
                int offerings = 0;
                foreach (Family fam in _familiesList)
                {
                    fam.takeFromGoldStash(amount);
                    offerings += amount;
                }
                Game.AddOrTakeFromOfferings(offerings);
            }
            else throw new ArgumentOutOfRangeException();
        }

        //public List<JobsModel> JobsList { get { return _jobs; } }

        /*private List<JobsModel> CreateJobs()
        {
            Debug.Assert(Game != null, "Game doesn't exist!");
            List<JobsModel> jobList = new List<JobsModel>();
            var apothecary = new Apothecary(Game, "Apoticaire");
            var blacksmith = new Blacksmith(Game, "Forgeron");
            var construction_worker = new Construction_Worker(Game, "Ouvrier");
            var cooker = new Cooker(Game, "Cuisinier");
            var farmer = new Farmer(Game, "Fermier");
            var militia = new Militia(Game, "Milice");
            var miller = new Miller(Game, "Meunier");
            var tailor = new Tailor(Game, "Tailleur");
            jobList.Add(apothecary);
            jobList.Add(blacksmith);
            jobList.Add(construction_worker);
            jobList.Add(cooker);
            jobList.Add(farmer);
            jobList.Add(militia);
            jobList.Add(miller);
            jobList.Add(tailor);
            return jobList;
        }
*/

        internal void EmptyFamiliesCleaner(List<IEvent> eventList)
        {
            int nbf = FamiliesList.Count;
            int i = 0;
            Family tmpFamily;
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
        internal void FamilyDestroyed(Family family)
        {
            Debug.Assert(family != null);
            _familiesList.Remove(family);
        }

        //TODO: !!! use new list & all jobs destroyed.
        /*      internal void DestroyJobs(JobsModel jobName)
              {
                  Debug.Assert(jobName != null);
                  _jobs.Remove(jobName);
              }*/

        internal void VillagerRemoved(Villager villager)
        {
            _villagePop.Current--;
        }

        #region called by ImpactHappiness
        internal void JobHappiness(Villager villager)
        {
            foreach (JobsModel job in Jobs.HappinessJobList)
            {
                job.AddHappiness(villager);
            }
        }
        #endregion

        internal override void OnDestroy()
        {
            Jobs.Destroy();
            Jobs = null;
            Debug.Assert(_familiesList.Count == 0, "there is still a family in this village!");
        }
        override internal void CloseStep(List<IEvent> eventList)
        {
            //TODO :  put current values in value history.
            if (_familiesList.Conclude()) { eventList.Add(new EventProperty<Village>(this, "FamiliesList")); }

            //JobList is invariant.
            //TODO : events!
        }
    }
}
