using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Game
    {
        public Game()
        {
            _items = new List<GameItem>();
            //TODO intialisation partie

             _villages = new List<Village>(); 
             CreateVillage("default");

             Family FamilyA = _villages[0].CreateFamilyFromScratch();
             Family FamilyB = _villages[0].CreateFamilyFromScratch();
             Family FamilyC = _villages[0].CreateFamilyFromScratch();
             Family FamilyD = _villages[0].CreateFamilyFromScratch();
             Family FamilyE = _villages[0].CreateFamilyFromScratch();



           _singleMen = new List<Villager>();

            TotalPop = 10;
            TotalGold = 0;
            Offerings = 0;
        }

        readonly List<GameItem> _items;
        readonly List<Village> _villages; //a revoir!
        public IReadOnlyList<Village> Villages { get { return _villages; } }
        public List<Villager> _singleMen; 
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
            foreach (GameItem item in _items)
            {
                item.CloseStep();
            }
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
