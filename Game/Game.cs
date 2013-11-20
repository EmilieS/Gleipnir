using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Game
{
    public class Game
    {
        public Game()
        {
            _totalGold = new HistorizedValue<double, Game>(this, "_totalGold", 20);
            _totalPop = new HistorizedValue<int, Game>(this, "_totalPop", 20);
            _items = new List<GameItem>();
            //TODO intialisation partie
            _singleMen = new List<Villager>();
            _villages = new List<Village>();
            _eventList = new List<IEvent>();
            CreateVillage("default");

             Family FamilyA = _villages[0].CreateFamilyFromScratch();
             Family FamilyB = _villages[0].CreateFamilyFromScratch();
             Family FamilyC = _villages[0].CreateFamilyFromScratch();
             Family FamilyD = _villages[0].CreateFamilyFromScratch();
             Family FamilyE = _villages[0].CreateFamilyFromScratch();

            //TotalPop = 10;
            //TotalGold = 0;
            Offerings = 0;
        }

        readonly List<GameItem> _items;
        readonly List<Village> _villages; //a revoir!
        readonly List<Villager> _singleMen;
        public IReadOnlyList<Village> Villages { get { return _villages; } }
        public IReadOnlyList<Villager> SingleMen { get { return _singleMen; } }
        readonly HistorizedValue<double, Game> _totalGold;
        readonly HistorizedValue<int, Game> _totalPop;
        public double TotalGold { get { return _totalGold.Current; } }
        public double LastTotalGold { get { return _totalGold.Historic.Last; } }//for tests, should get eliminated
        public int TotalPop { get { return _totalPop.Current; } } 
        public int Offerings { get; set; } //will change
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
            _items.Remove(item);
        }
        internal void GoldAdded(double amount)
        {
            Debug.Assert(amount > 0, "(GoldAdded)");
            _totalGold.Current += amount;
        }
        internal void GoldRemoved(double amount)
        {
            Debug.Assert(amount > 0, "(GoldRemoved)");
            _totalGold.Current -= amount;
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
        public void NextStep() //public for testing (again)
        {
            ImpactHappiness();
            Evolution();
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

        private void DieOrIsAlive()
        {
            int i=0;
            int tmpCount = _items.Count;

            GameItem tmpItem;
            while (i < tmpCount)
            {
                Debug.Assert(_items[i] != null);
                Debug.Assert(_items[i].Game != null);
                tmpItem =_items[i];
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
            if(_totalGold.Conclude()){ _eventList.Add(new EventProperty<Game>(this, "TotalGold")); }
            if(_totalPop.Conclude()){ _eventList.Add(new EventProperty<Game>(this, "TotalPop")); }
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
