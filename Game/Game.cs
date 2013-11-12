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
            Villager VillagerAH = new Villager(this);
            VillagerAH.Gender = Genders.MALE;
            Villager VillagerAF = new Villager(this);
            VillagerAF.Gender = Genders.FEMALE;
            Villager VillagerBH = new Villager(this);
            VillagerBH.Gender = Genders.MALE;
            Villager VillagerBF = new Villager(this);
            VillagerBF.Gender = Genders.FEMALE;
            Villager VillagerCH = new Villager(this);
            VillagerCH.Gender = Genders.MALE;
            Villager VillagerCF = new Villager(this);
            VillagerCF.Gender = Genders.FEMALE;
            Villager VillagerDH = new Villager(this);
            VillagerDH.Gender = Genders.MALE;
            Villager VillagerDF = new Villager(this);
            VillagerDF.Gender = Genders.FEMALE;
            Villager VillagerEH = new Villager(this);
            VillagerEH.Gender = Genders.MALE;
            Villager VillagerEF = new Villager(this);
            VillagerEF.Gender = Genders.FEMALE;

            _villages = new List<Village>();
             CreateVillage("default");

             Family FamilyA = new Family(VillagerAF, VillagerAH, _villages[0]);
             Family FamilyB = new Family(VillagerBF, VillagerBH, _villages[0]);
             Family FamilyC = new Family(VillagerCF, VillagerCH, _villages[0]);
             Family FamilyD = new Family(VillagerDF, VillagerDH, _villages[0]);
             Family FamilyE = new Family(VillagerEF, VillagerEH, _villages[0]);



           _singleMen = new List<Villager>();

            TotalPop = 10;
            TotalGold = 0;
            Offerings = 0;
        }

        readonly List<GameItem> _items;
        readonly List<Village> _villages;
        public List<Villager> _singleMen; 
        public double TotalGold {get; set;} //changera //warning, static!
        public int TotalPop {get; set;}  //changera //warning, static!
        public int Offerings { get; set; } //changera //warning, static!

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



        private void CloseStep() //a changer.
        {
            for (int k = 0; k < _villages.Count; k++)
            {
                for (int i = 0; i < _villages[k].FamiliesList.Count; i++)
                {
                    for (int j = 0; j < _villages[k].FamiliesList[i].FamilyMembers.Count; j++)
                    {
                        _villages[k].FamiliesList[i].FamilyMembers[j].CloseStep();
                    }
                    _villages[k].FamiliesList[i].CloseStep();
                }
            }
            //TODO : Villagers, Villages.
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

    }
}
