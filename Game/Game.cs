using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Game.Buildings;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Game
{
    [Serializable]
    public class Game/* : ISerializable*/
    {
        // Name Generator variables
        NameGenerator _nameGenerator;
        NameGenerator _firstNameGenerator;

        // GodSpell variables
        internal readonly List<GodSpell.Epidemic> _currentEpidemicList;

        // Historized values
        readonly HistorizedValue<int, Game> _totalGold;
        readonly HistorizedValue<int, Game> _totalPop;
        readonly HistorizedValue<int, Game> _offerings;

        // GameItems variables
        internal readonly List<GameItem> _items;

        // Games lists
        readonly List<Village> _villagesList; // TODO: Upgrade Village list
        readonly List<Villager> _singleMenList;
        List<IEvent> _eventList;

        // Average variables
        double _averageHappiness;
        double _averageFaith;

        // Others
        double _faithToBeAddedOrRemovedForAllVillagersThisRound;
        readonly internal double[] _regularBirthDates;
        readonly internal double _ageTickTime;
        public Random Rand;

        // NEW GAME
        public Game(double timeStep = 0)
        {

            // Created "windows values"
            _totalGold = new HistorizedValue<int, Game>(this, @"_totalGold", 20);
            _totalPop = new HistorizedValue<int, Game>(this, @"_totalPop", 20);
            _offerings = new HistorizedValue<int, Game>(this, @"_offerings", 20);

            // Created lists
            _items = new List<GameItem>();
            _singleMenList = new List<Villager>();
            _villagesList = new List<Village>();
            _eventList = new List<IEvent>();

            // FamilyNames Generator
            var namesPath = File.ReadAllLines(@"Extra\nameList.txt");
            _nameGenerator = new NameGenerator(namesPath, 1, 1);
            var firstNamesPath = File.ReadAllLines(@"Extra\firstNameList.txt");
            _firstNameGenerator = new NameGenerator(namesPath, 1, 1);

            // GodSpell Initialization
            _currentEpidemicList = new List<GodSpell.Epidemic>();

            // BirthDates Initialisation
            _regularBirthDates = new double[5];
            #region To Be CHANGED
            //_ageTickTime = 0.0834;//time(years) between each tick.
            _ageTickTime = 1;
            Rand = new Random();//to be moved elsewhere.

            int j = 216; // j = 18
            for (int i = 0; i < 5; i++) // Must be kept orderly
            {
                _regularBirthDates[i] = j;
                j = j + 4 * 12; // j = j + 4
            }
            #endregion

            // Create Village
            Village village = CreateVillage(@"Ragnar");

            // Create Table
            new TablePlace(village);

            // Create default jobs buildings
            Farm farm = new Farm(village, village.JobsList.Farmer);
            village.JobsList.Farmer.Building = farm;
            Forge forge = new Forge(village, village.JobsList.Blacksmith);
            village.JobsList.Blacksmith.Building = forge;
            UnionOfCrafter uoc = new UnionOfCrafter(village, village.JobsList.Construction_Worker);
            village.JobsList.Construction_Worker.Building = uoc;

            // Create 5 families
            Family FamilyA = village.CreateFamilyFromScratch(village.JobsList.Farmer, village.JobsList.Blacksmith);
            Family FamilyB = village.CreateFamilyFromScratch(village.JobsList.Farmer, village.JobsList.Construction_Worker);
            Family FamilyC = village.CreateFamilyFromScratch();
            Family FamilyD = village.CreateFamilyFromScratch();
            Family FamilyE = village.CreateFamilyFromScratch();

            // Set player's offerings
            _offerings.Current = 100;
        }

        /*public Game(SerializationInfo info, StreamingContext ctxt)
        {
            this.make = (string)info.GetValue("Make", typeof(string));
            this.model = (string)info.GetValue("Model",typeof(string));
            this.year = (string)info.GetValue("Year", typeof(int));
            this.owner = (Owner)info.GetValue("Owner", typeof(Owner));
        
            _nameGenerator = (NameGenerator)info.GetValue("_nameGenerator", typeof(NameGenerator));
            _firstNameGenerator= (NameGenerator)info.GetValue("_firstnameGenerator", typeof(NameGenerator));

            _currentEpidemicList=(List<GodSpell.Epidemic>) info.GetValue("_currentEpidemicList", typeof(List<GodSpell.Epidemic>));

            _offerings=(HistorizedValue<int, Game>) info.GetValue("_offerings", typeof(HistorizedValue<int, Game>));
            _totalGold=(HistorizedValue<int, Game>) info.GetValue("_totalGold", typeof(HistorizedValue<int, Game>));
            _totalPop=(HistorizedValue<int, Game>) info.GetValue("_totalPop", typeof(HistorizedValue<int, Game>));
                              
            _items=(List<GameItem>) info.GetValue("_items", typeof(List<GameItem>));
            _villages=(List<Village>) info.GetValue("_villages", typeof(List<Village>));
            _singleMen=(List<Villager>) info.GetValue("_singleMen", typeof(List<Villager>));

            _currentText = (List<string>)info.GetValue("_currentText", typeof(List<string>));
            _eventList = (List<IEvent>)info.GetValue("_eventList", typeof(List<IEvent>));

            // Average variables
            double _averageHappiness;
            double _averageFaith;
        }*/

        /*public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("_nameGenerator", _nameGenerator);
            info.AddValue("_firstNameGenerator", _firstNameGenerator);

            info.AddValue("_currentEpidemicList", _currentEpidemicList);

            info.AddValue("_offerings", _offerings);
            info.AddValue("_totalGold", _totalGold);
            info.AddValue("_totalPop", _totalPop);

            info.AddValue("_items", _items);
            info.AddValue("_villages", _villages);
            info.AddValue("_singleMen", _singleMen);

            info.AddValue("_currentText", _currentText);
            info.AddValue("_eventList", _eventList);
        }*/


        // NameGenerator Properties
        /// <summary>
        /// Gets the family names list
        /// </summary>
        public NameGenerator NameList { get { return _nameGenerator; } }
        /// <summary>
        /// Gets the first names list
        /// </summary>
        public NameGenerator FirstNameList { get { return _firstNameGenerator; } }

        // Calculated Properties
        /// <summary>
        /// Gets village total gold
        /// </summary>
        public int TotalGold { get { return _totalGold.Current; } }
        /// <summary>
        /// Gets last village total gold
        /// </summary>
        public int LastTotalGold { get { return _totalGold.Historic.Last; } } // For tests, should get eliminated
        /// <summary>
        /// Get village total population
        /// </summary>
        public int TotalPop { get { return _totalPop.Current; } }
        /// <summary>
        /// Gets player's offerings points
        /// </summary>
        public int Offerings { get { return _offerings.Current; } }
        /// <summary>
        /// Gets average village happinness
        /// </summary>
        public double AverageHappiness { get { return _averageHappiness; } }
        /// <summary>
        /// Gets average village faith
        /// </summary>
        public double AverageFaith { get { return _averageFaith; } }
        /// <summary>
        /// Gets amount of faith to be add/remove for all villagers
        /// </summary>
        internal double FaithToBeAddedOrRemovedForAllVillagersThisRound { get { return _faithToBeAddedOrRemovedForAllVillagersThisRound; } }

        // Lists
        /// <summary>
        /// Gets villages list
        /// </summary>
        public IReadOnlyList<Village> Villages { get { return _villagesList; } }
        /// <summary>
        /// Gets single men list
        /// </summary>
        public IReadOnlyList<Villager> SingleMen { get { return _singleMenList; } }
        /// <summary>
        /// Gets events list
        /// </summary>
        public IReadOnlyList<IEvent> EventList { get { return _eventList; } }

        // GodSpells Methods
        /// <summary>
        /// Add created epidemic to epidemic list
        /// </summary>
        /// <param name="epidemic"></param>
        internal void EpidemicCreated(GodSpell.Epidemic epidemic)
        {
            _currentEpidemicList.Add(epidemic);
        }
        /// <summary>
        /// Remove created epidemic from the list and destroy it
        /// </summary>
        /// <param name="epidemic"></param>
        internal void EpidemicDestroyed(GodSpell.Epidemic epidemic)
        {
            Debug.Assert(epidemic != null, @"(game, EpidemicDestroyed) Item is null");
            Debug.Assert(_currentEpidemicList.Contains(epidemic), @"(game, EpidemicmDestroyed) Item not in gameitemlist");
            if (epidemic.TimeSinceCreation < 15)
                _faithToBeAddedOrRemovedForAllVillagersThisRound += 20;
            _currentEpidemicList.Remove(epidemic);
            Debug.Assert(!_currentEpidemicList.Contains(epidemic), @"(game, EpidemicDestroyed) Item still in gameitemlist");

        }

        // GameItems Methods
        /// <summary>
        /// Add GameItem to GameItem list
        /// </summary>
        /// <param name="item"></param>
        internal void GameItemCreated(GameItem item)
        {
            _items.Add(item);
        }
        /// <summary>
        /// Remove a GameItem from the GameItem list
        /// </summary>
        /// <param name="item"></param>
        internal void GameItemDestroyed(GameItem item)
        {
            Debug.Assert(item != null, @"(game, GameItemDestroyed) Item is null");
            Debug.Assert(_items.Contains(item), @"(game, GameItemDestroyed) Item not in gameitemlist");
            _items.Remove(item);
            Debug.Assert(!_items.Contains(item), @"(game, GameItemDestroyed) Item still in gameitemlist");
        }

        // Gold Methods
        /// <summary>
        /// Add gold to TotalGold
        /// </summary>
        /// <param name="amount"></param>
        internal void GoldAdded(int amount)
        {
            Debug.Assert(amount >= 0, @"(game, GoldAdded) Negative amount");
            _totalGold.Current += amount;
        }
        /// <summary>
        /// Take gold from the totalGold
        /// </summary>
        /// <param name="amount"></param>
        internal void GoldRemoved(int amount)
        {
            Debug.Assert(amount >= 0, "(game, GoldRemoved) Negative amount.");
            _totalGold.Current -= amount;
        }
        /// <summary>
        /// Take gold from total gold when family is destroyed
        /// </summary>
        /// <param name="family"></param>
        internal void TakeGoldWhenFamilyRemoved(Family family)
        {
            _totalGold.Current -= family.GoldStash;
        }

        // Offerings Methods
        /// <summary>
        /// Add or Take offerings point from the player's offerings points
        /// </summary>
        /// <param name="amount"></param>
        public void AddOrTakeFromOfferings(int amount)
        {
            int result = _offerings.Current + amount;
            if (result < 0)
                throw new InvalidOperationException(@"(game, AddOrTakeFromOfferings) Negative Offerings");
            else _offerings.Current = result;
        }

        // Population Methods
        /// <summary>
        /// Add 1 to total population when willager is added
        /// </summary>
        internal void VillagerAdded()
        {
            _totalPop.Current++;
        }
        /// <summary>
        /// Take 1 from the total population
        /// </summary>
        /// <param name="villager"></param>
        internal void VillagerRemoved(Villager villager)
        {
            _totalPop.Current--;
        }
        /// <summary>
        /// Add single man villager to single men list
        /// </summary>
        /// <param name="man"></param>
        internal void AddSingleMan(Villager man)
        {
            Debug.Assert(man != null, @"(game, AddSingleMan) Man is null");
            Debug.Assert(man.Gender == Genders.MALE, @"(game, AddSingleMan) Is a woman");
            Debug.Assert(man.StatusInFamily == Status.SINGLE, @"(game, AddSingleMan) Is not single");
            _singleMenList.Add(man);
        }
        /// <summary>
        /// Remove single man villager from single men list
        /// </summary>
        /// <param name="villager"></param>
        internal void RemoveSingleMan(Villager villager)
        {
            Debug.Assert(villager.StatusInFamily != Status.SINGLE, @"(game, RemoveSingleMen) Man not single");
            Debug.Assert(_singleMenList.Contains(villager), @"(game, RemoveSingleMen) Man not in singleMenList");
            _singleMenList.Remove(villager);
        }
        /// <summary>
        /// Remove single man villager from single men list
        /// when the villager is dead
        /// </summary>
        /// <param name="dead"></param>
        internal void SingleManDestroyed(Villager dead)
        {
            _singleMenList.Remove(dead);
        }

        // Happiness Methods
        /// <summary>
        /// Add or Take happiness in function of the Item
        /// </summary>
        private void ImpactHappiness()
        {
            foreach (GameItem item in _items)
                item.ImpactHappiness();
        }

        // Faith Methods
        /// <summary>
        /// Take faith to villagers during epidemic
        /// </summary>
        void EpidemicFaithImpact()
        {
            foreach (GodSpell.Epidemic e in _currentEpidemicList)
                if (e.TimeSinceCreation == 15)
                    _faithToBeAddedOrRemovedForAllVillagersThisRound += -15;
        }
        /// <summary>
        /// Take faith to villagers after earthquake
        /// </summary>
        /// <param name="amount"></param>
        internal void DamagedBuildingsNotRepairedOrRepairedFaithImpact(double amount)
        {
            _faithToBeAddedOrRemovedForAllVillagersThisRound += amount;
        }

        // Village Methods
        /// <summary>
        /// Create new village "Name"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Village CreateVillage(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(@"(game, CreateVillage) Invalid name");
            var v = new Village(this, name);
            _villagesList.Add(v);
            return v;
        }

        // Events Methods
        static public void BigEvent()
        {
            //TODO: BigEvent
        }

        // Time Methods
        /// <summary>
        /// Do 1 "cycle" of the game
        /// </summary>
        public void NextStep() // Public for testing
        {
            ImpactHappiness();
            // Has to be after ImpactHappiness(); !!
            _faithToBeAddedOrRemovedForAllVillagersThisRound = 0;
            // Has to be before DieOrIsAlive
            EpidemicFaithImpact();
            Evolution();
            Creation();
            DieOrIsAlive();
            CloseStep();
        }
        /// <summary>
        /// Evolute Items
        /// </summary>
        private void Evolution()
        {
            foreach (GameItem item in _items)
                item.Evolution();
        }
        /// <summary>
        /// Create new Items
        /// </summary>
        private void Creation()
        {
            _eventList.RemoveRange(0, _eventList.Count);
            int i = 0;
            //int tmpCount = _items.Count;
            //GameItem tmpItem;
            while (i < _items.Count)
            {
                Debug.Assert(_items[i] != null);
                Debug.Assert(_items[i].Game != null);
                _items[i].Creation(_eventList);//must do family version (marriage)

                i++;
            }
            //tmpItem = null;
        }
        /// <summary>
        /// Check if Items are dead or not
        /// </summary>
        private void DieOrIsAlive()
        {
            int i = 0;
            int tmpCount = _items.Count;

            GameItem tmpItem;
            while (i < tmpCount)
            {
                Debug.Assert(_items[i] != null);
                Debug.Assert(_items[i].Game != null);
                tmpItem = _items[i];
                tmpItem.DieOrIsAlive(_eventList);

                if (tmpItem.IsDestroyed)
                    tmpCount--;
                else
                    i++;
            }
            tmpItem = null;

            foreach (Village v in Villages)
                v.EmptyFamiliesCleaner(_eventList);
        }
        /// <summary>
        /// Update "windows values" and End the "cycle"
        /// </summary>
        private void CloseStep()
        {
            foreach (GameItem item in _items)
                item.CloseStep(_eventList);
            if (_totalGold.Conclude())
                _eventList.Add(new GameEventProperty(this, @"TotalGold"));
            if (_totalPop.Conclude())
                _eventList.Add(new GameEventProperty(this, @"TotalPop"));
            if (_offerings.Conclude())
                _eventList.Add(new GameEventProperty(this, @"Offerings"));

            double faith = 0;
            double happiness = 0;
            foreach (Village v in Villages)
            {
                v.CalculateAverageVillageHappinessAndFaith();
                happiness += v.Happiness;
                faith += v.Faith;
            }
            _averageHappiness = happiness / Villages.Count;
            _averageFaith = faith / Villages.Count;
            _eventList.Add(new GameEventProperty(this, @"AverageFaith"));
            _eventList.Add(new GameEventProperty(this, @"AverageHappiness"));
        }

        //variables à avoir: les coefficients des métiers
        //liste familles?
        //TODO : le 'main' de la dll sera ici
        /*
        -regarder si _lifexpectancy<age => morts.
        -actualiser le bonheur 
        -actualiser la foi...
        -ajouter l'or
        -retirer l'or => offrandes

        -faire liste de marriage
        */
    }
}
