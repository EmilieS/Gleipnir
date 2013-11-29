using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Game
{
    public class Game
    {
        public Game()
        {
            _totalGold = new HistorizedValue<int, Game>(this, "_totalGold", 20);
            _totalPop = new HistorizedValue<int, Game>(this, "_totalPop", 20);
            _offerings = new HistorizedValue<int, Game>(this, "_offerings", 20);
            _items = new List<GameItem>();
            //TODO intialisation partie
            _singleMen = new List<Villager>();
            _villages = new List<Village>();
            _eventList = new List<IEvent>();
            var namesPath = File.ReadAllLines(@"Extra\nameList.txt");
            _nameGenerator = new NameGenerator(namesPath, 1, 1);
            var firstNamesPath = File.ReadAllLines(@"Extra\firstNameList.txt");
            _firstNameGenerator = new NameGenerator(namesPath, 1, 1);
            _regularBirthDates= new double[5];
            //===to be changed
            //_ageTickTime = 0.0834;//time(years) between each tick.
            _ageTickTime = 1;
            Rand = new Random();//to be moved elsewhere.

            /*int j=18;
            for (int i = 0; i < 5; i++)//must be kept orderly
            {
                _regularBirthDates[i] = j;
                j=j + 4;
            }*/
            int j = 216;
            for (int i = 0; i < 5; i++)//must be kept orderly
            {
                _regularBirthDates[i] = j;
                j = j + 4*12;
            }
            //===
            CreateVillage("default");

            Family FamilyA = _villages[0].CreateFamilyFromScratch();
            Family FamilyB = _villages[0].CreateFamilyFromScratch();
            Family FamilyC = _villages[0].CreateFamilyFromScratch();
            Family FamilyD = _villages[0].CreateFamilyFromScratch();
            Family FamilyE = _villages[0].CreateFamilyFromScratch();

            _offerings.Current = 100;
        }

        internal readonly List<GameItem> _items;//internal for tests
        readonly List<Village> _villages; //a revoir!
        readonly List<Villager> _singleMen;
        NameGenerator _nameGenerator;
        NameGenerator _firstNameGenerator;
        readonly HistorizedValue<int, Game> _totalGold;
        readonly HistorizedValue<int, Game> _totalPop;
        readonly HistorizedValue<int, Game> _offerings;

        public NameGenerator NameList { get { return _nameGenerator; } }
        public NameGenerator FirstNameList { get { return _firstNameGenerator; } }
        public IReadOnlyList<Village> Villages { get { return _villages; } }
        public IReadOnlyList<Villager> SingleMen { get { return _singleMen; } }
	public int TotalGold { get { return _totalGold.Current; } }
        public int LastTotalGold { get { return _totalGold.Historic.Last; } }//for tests, should get eliminated

        public int TotalPop { get { return _totalPop.Current; } }
        public int Offerings { get { return _offerings.Current; } }
        readonly internal double[] _regularBirthDates;
        readonly internal double _ageTickTime;
        public Random Rand;

        /*public double TotalGold { get 
        {
            double totalGold = 0;
            foreach( Village village in _villages)
            {
                totalGold += village.Gold;
            }
            return totalGold;
        } } */
        internal void GameItemCreated(GameItem item)
        {
            _items.Add(item);
        }
        internal void GameItemDestroyed(GameItem item)
        {
            Debug.Assert(item != null, "(GameItemDestroyed) item is null");
            Debug.Assert(_items.Contains(item), "(GameItemDestroyed) the item was already removed from the gameitemlist");
            _items.Remove(item);
            Debug.Assert(!_items.Contains(item), "(GameItemDestroyed) the item was not removed from the gameitemlist");

        }
        internal void GoldAdded(int amount)
        {
            Debug.Assert(amount >= 0, "(GoldAdded) negative amount");
            _totalGold.Current += amount;
        }
        internal void GoldRemoved(int amount)
        {
            Debug.Assert(amount >= 0, "(GoldRemoved) negative amount.");
            _totalGold.Current -= amount;
        }
        internal void AddOrTakeFromOfferings(int amount)
        {
            int result = Offerings + amount;
            if (result < 0) _offerings.Current = 0;
            else _offerings.Current += amount;
        }

        internal void VillagerAdded()
        {
            _totalPop.Current++;
        }

        internal void AddSingleMan(Villager man)
        {
            Debug.Assert(man != null, "man is null! (AddSingleMan)");
            Debug.Assert(man.Gender == Genders.MALE, "is a woman! (AddSingleMan)");
            Debug.Assert(man.StatusInFamily == Status.SINGLE, "is not single! (AddSingleMan)");
            _singleMen.Add(man);
        }
        public Village CreateVillage(string name)
        {
            if (String.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");
            var v = new Village(this, name);
            _villages.Add(v);
            return v;
        }
        static public void BigEvent()
        {
            //TODO
        }
/*
        public void AddOrRemoveFromTotalGold(double amount)
        {
            _totalGold.Current += amount; //curious to find out if TotalGold can be negative.
        }
 * */
        List<string> _currentText;
        public void NextStep() //public for testing (again)
        {
            ImpactHappiness();
            Evolution();
            Creation();
            DieOrIsAlive();
            CloseStep();
        }

        List<IEvent> _eventList;
        public IReadOnlyList<IEvent> EventList{get{return _eventList;}}
        private void ImpactHappiness()
        {
            foreach (GameItem item in _items)
            {
                item.ImpactHappiness();
            }
        }
        private void Evolution()
        {
            foreach (GameItem item in _items)
            {
                item.Evolution();
            }
        }
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
        }
        private void CloseStep()
        {
            foreach (GameItem item in _items)
            {
                item.CloseStep(_eventList);
            }
            if(_totalGold.Conclude()){ _eventList.Add(new GameEventProperty(this, "TotalGold")); }
            if(_totalPop.Conclude()){ _eventList.Add(new GameEventProperty(this, "TotalPop")); }
            if(_offerings.Conclude()){ _eventList.Add(new GameEventProperty(this, "Offerings")); }

        }

        //variables à avoir: les coefficients des métiers
        //liste familles?


        //le 'main' de la dll sera ici : TODO
        /*
        -regarder si _lifexpectancy<age => morts.
        -actualiser le bonheur 
        -actualiser la foi...
        -ajouter l'or
        -retirer l'or => offrandes

        -faire liste de marriage
        */
        internal void RemoveSingleMan(Villager villager)
        {
            Debug.Assert(villager.StatusInFamily != Status.SINGLE);
            Debug.Assert(_singleMen.Contains(villager));

            _singleMen.Remove(villager);

        }
        internal void SingleManDestroyed(Villager dead)
        {
            _singleMen.Remove(dead);
        }
        internal void VillagerRemoved(Villager villager)
        {
            _totalPop.Current--;
        }
        internal void FamilyRemoved(Family family)
        {
            _totalGold.Current -= family.GoldStash;
        }
    }
}
