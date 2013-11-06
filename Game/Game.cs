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
            //TODO intialisation partie
            Villager VillagerAH = new Villager();
            VillagerAH.Gender = Genders.MALE;
            Villager VillagerAF = new Villager();
            VillagerAF.Gender = Genders.FEMALE;
            Villager VillagerBH = new Villager();
            VillagerBH.Gender = Genders.MALE;
            Villager VillagerBF = new Villager();
            VillagerBF.Gender = Genders.FEMALE;
            Villager VillagerCH = new Villager();
            VillagerCH.Gender = Genders.MALE;
            Villager VillagerCF = new Villager();
            VillagerCF.Gender = Genders.FEMALE;
            Villager VillagerDH = new Villager();
            VillagerDH.Gender = Genders.MALE;
            Villager VillagerDF = new Villager();
            VillagerDF.Gender = Genders.FEMALE;
            Villager VillagerEH = new Villager();
            VillagerEH.Gender = Genders.MALE;
            Villager VillagerEF = new Villager();
            VillagerEF.Gender = Genders.FEMALE;

            Family FamilyA = new Family(VillagerAF, VillagerAH);
            Family FamilyB = new Family(VillagerBF, VillagerBH);
            Family FamilyC = new Family(VillagerCF, VillagerCH);
            Family FamilyD = new Family(VillagerDF, VillagerDH);
            Family FamilyE = new Family(VillagerEF, VillagerEH);

           _families = new List<Family>();

           _singleMen = new List<Villager>();

            _families.Add(FamilyA);
            _families.Add(FamilyB);
            _families.Add(FamilyC);
            _families.Add(FamilyD);
            _families.Add(FamilyE);

            TotalPop = (_families.Count * 2);
            TotalGold = 0;
            Offerings = 0;
        }

        List<Family> _families;

        static public List<Villager> _singleMen; //changera plus tard. //TODO : warning, static!
        static public double TotalGold {get; set;} //changera //warning, static!
        static public int TotalPop {get; set;}  //changera //warning, static!
        static public int Offerings { get; set; } //changera //warning, static!

        static public void BigEvent()
        {
            //TODO
        }

        static public void AddOrRemoveFromTotalGold(double amount)
        {
            TotalGold += amount; //curious to find out if TotalGold can be negative.
        }
        List<string> _currentText; 
        public void NextStep() //public for testing (again)
        {
            CloseStep();
            
        }

        private void CloseStep()
        {
            for (int i = 0; i < _families.Count; i++)
            {
                _families[i].CloseStep();
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
