using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Game.Buildings;

namespace Game
{
    public class Game
    {
        // Name Generator variables
        NameGenerator _nameGenerator;
        NameGenerator _firstNameGenerator;

        // GodSpell variables
        readonly List<GodSpell.Epidemic> _currentEpidemicList;

        // Historized values
        readonly HistorizedValue<int, Game> _totalGold;
        readonly HistorizedValue<int, Game> _totalPop;
        readonly HistorizedValue<int, Game> _offerings;

        // GameItems variables
        internal readonly List<GameItem> _items;

        // Games lists
        readonly List<Village> _villages; // TODO: Upgrade Village list
        readonly List<Villager> _singleMen;
        List<string> _currentText;
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
        public Game()
        {
            // Created "windows values"
            _totalGold = new HistorizedValue<int, Game>(this, "_totalGold", 20);
            _totalPop = new HistorizedValue<int, Game>(this, "_totalPop", 20);
            _offerings = new HistorizedValue<int, Game>(this, "_offerings", 20);

            // Created lists
            _items = new List<GameItem>();
            _singleMen = new List<Villager>();
            _villages = new List<Village>();
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
            Village village = CreateVillage("Ragnar");

            // Create Table
            new TablePlace(village);

            // Create default jobs buildings
            Farm farm = new Farm(village, village.Jobs.Farmer);
            village.Jobs.Farmer.Building = farm;
            Forge forge = new Forge(village, village.Jobs.Blacksmith);
            village.Jobs.Blacksmith.Building = forge;
            UnionOfCrafter uoc = new UnionOfCrafter(village, village.Jobs.Construction_Worker);
            village.Jobs.Construction_Worker.Building = uoc;

            // Create 5 families
            Family FamilyA = village.CreateFamilyFromScratch(village.Jobs.Farmer, village.Jobs.Blacksmith);
            Family FamilyB = village.CreateFamilyFromScratch(village.Jobs.Farmer, village.Jobs.Construction_Worker);
            Family FamilyC = village.CreateFamilyFromScratch();
            Family FamilyD = village.CreateFamilyFromScratch();
            Family FamilyE = village.CreateFamilyFromScratch();

            // Set player's offerings
            _offerings.Current = 100;
        }

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
        public IReadOnlyList<Village> Villages { get { return _villages; } }
        /// <summary>
        /// Gets single men list
        /// </summary>
        public IReadOnlyList<Villager> SingleMen { get { return _singleMen; } }
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
            Debug.Assert(epidemic != null, "( EpidemicDestroyed) item is null");
            Debug.Assert(_currentEpidemicList.Contains(epidemic), "( EpidemicmDestroyed) the item was already removed from the gameitemlist");
            if (epidemic.TimeSinceCreation < 15)
                _faithToBeAddedOrRemovedForAllVillagersThisRound += 20;
            _currentEpidemicList.Remove(epidemic);
            Debug.Assert(!_currentEpidemicList.Contains(epidemic), "( EpidemicDestroyed) the item was not removed from the gameitemlist");

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
            Debug.Assert(item != null, "(GameItemDestroyed) item is null");
            Debug.Assert(_items.Contains(item), "(GameItemDestroyed) the item was already removed from the gameitemlist");
            _items.Remove(item);
            Debug.Assert(!_items.Contains(item), "(GameItemDestroyed) the item was not removed from the gameitemlist");
        }

        // Gold Methods
        /// <summary>
        /// Add gold to TotalGold
        /// </summary>
        /// <param name="amount"></param>
        internal void GoldAdded(int amount)
        {
            Debug.Assert(amount >= 0, "(GoldAdded) negative amount");
            _totalGold.Current += amount;
        }
        /// <summary>
        /// Take gold from the totalGold
        /// </summary>
        /// <param name="amount"></param>
        internal void GoldRemoved(int amount)
        {
            Debug.Assert(amount >= 0, "(GoldRemoved) negative amount.");
            _totalGold.Current -= amount;
        }
        /// <summary>
        /// Take gold from total gold when family is destroyed
        /// </summary>
        /// <param name="family"></param>
        internal void FamilyRemoved(Family family)
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
            if (result < 0) { throw new InvalidOperationException(); }
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
            Debug.Assert(man != null, "man is null! (AddSingleMan)");
            Debug.Assert(man.Gender == Genders.MALE, "is a woman! (AddSingleMan)");
            Debug.Assert(man.StatusInFamily == Status.SINGLE, "is not single! (AddSingleMan)");
            _singleMen.Add(man);
        }
        /// <summary>
        /// Remove single man villager from single men list
        /// </summary>
        /// <param name="villager"></param>
        internal void RemoveSingleMan(Villager villager)
        {
            Debug.Assert(villager.StatusInFamily != Status.SINGLE);
            Debug.Assert(_singleMen.Contains(villager));
            _singleMen.Remove(villager);
        }
        /// <summary>
        /// Remove single man villager from single men list
        /// when the villager is dead
        /// </summary>
        /// <param name="dead"></param>
        internal void SingleManDestroyed(Villager dead)
        {
            _singleMen.Remove(dead);
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
            if (String.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");
            var v = new Village(this, name);
            _villages.Add(v);
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
                _eventList.Add(new GameEventProperty(this, "TotalGold"));
            if (_totalPop.Conclude())
                _eventList.Add(new GameEventProperty(this, "TotalPop"));
            if (_offerings.Conclude())
                _eventList.Add(new GameEventProperty(this, "Offerings"));

            double faith = 0;
            double happiness = 0;
            foreach (Village v in Villages)
            {
                v.CalculateAverageVillageHappinessAndFaith();
                happiness += v.VillageHappiness;
                faith += v.VillageFaith;
            }
            _averageHappiness = happiness / Villages.Count;
            _averageFaith = faith / Villages.Count;
            _eventList.Add(new GameEventProperty(this, "AverageFaith"));
            _eventList.Add(new GameEventProperty(this, "AverageHappiness"));
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
