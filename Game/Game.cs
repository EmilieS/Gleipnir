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
            _items = new List<GameItem>();
            //TODO intialisation partie
            _singleMen = new List<Villager>();
            _villages = new List<Village>();
            CreateVillage("default");

             Family FamilyA = _villages[0].CreateFamilyFromScratch();
             Family FamilyB = _villages[0].CreateFamilyFromScratch();
             Family FamilyC = _villages[0].CreateFamilyFromScratch();
             Family FamilyD = _villages[0].CreateFamilyFromScratch();
             Family FamilyE = _villages[0].CreateFamilyFromScratch();





            TotalPop = 10;
            TotalGold = 0;
            Offerings = 0;
        }

        readonly List<GameItem> _items;
        readonly List<Village> _villages; //a revoir!
        readonly List<Villager> _singleMen;
        public IReadOnlyList<Village> Villages { get { return _villages; } }
        public IReadOnlyList<Villager> SingleMen { get { return _singleMen; } }
        public double TotalGold {get; set;} //will change
        public int TotalPop {get; set;}  //will change
        public int Offerings { get; set; } //will change

        internal void GameItemCreated(GameItem item)
        {
            _items.Add(item);
        }

        internal void GameItemDestroyed(GameItem item)
        {
            _items.Remove(item);
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

        public void AddOrRemoveFromTotalGold(double amount)
        {
            TotalGold += amount; //curious to find out if TotalGold can be negative.
        }
        List<string> _currentText; 
        public void NextStep() //public for testing (again)
        {
            CloseStep();
            
        }

        public void CloseStep() //public for debug
        {
            
            /*foreach (GameItem item in _items)
            {
                item.CloseStep();
            }*/
            int i=0;
            int tmpCount = _items.Count;

            GameItem tmpItem;
            while (i < tmpCount)
            {
                Debug.Assert(_items[i] != null);
                Debug.Assert(_items[i].Game != null);
                tmpItem =_items[i];
                tmpItem.CloseStep();

                if (tmpItem.IsDestroyed)
                    tmpCount--;
                else
                    i++;
            }
            tmpItem = null;
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
    }
}
