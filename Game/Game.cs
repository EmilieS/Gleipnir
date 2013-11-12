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

            Village = new Village(this);
            Family FamilyA = new Family(VillagerAF, VillagerAH, Village);
            Family FamilyB = new Family(VillagerBF, VillagerBH, Village);
            Family FamilyC = new Family(VillagerCF, VillagerCH, Village);
            Family FamilyD = new Family(VillagerDF, VillagerDH, Village);
            Family FamilyE = new Family(VillagerEF, VillagerEH, Village);

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

        public Village Village { get; set; }
        public List<Villager> _singleMen; 
        public double TotalGold {get; set;} //changera //warning, static!
        public int TotalPop {get; set;}  //changera //warning, static!
        public int Offerings { get; set; } //changera //warning, static!

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

        private void CloseStep()
        {
            for (int i = 0; i < Village.FamiliesList.Count; i++)
            {
                for (int j=0; j<Village.FamiliesList[i].FamilyMembers.Count; j++)
                {
                    Village.FamiliesList[i].FamilyMembers[j].CloseStep();
                }
                Village.FamiliesList[i].CloseStep();
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
