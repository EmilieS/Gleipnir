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
            Villager VillagerAH =new Villager();
            VillagerAH.Gender = Genders.MALE;
            Villager VillagerAF = new Villager();
            VillagerAF.Gender = Genders.FEMALE;
            Villager VillagerBH = new Villager();
            VillagerBH.Gender = Genders.MALE;
            Villager VillagerBF = new Villager();
            VillagerBF.Gender = Genders.FEMALE;
            Villager VillagerCH= new Villager();
            VillagerCH.Gender = Genders.MALE;
            Villager VillagerCF = new Villager();
            VillagerCF.Gender = Genders.FEMALE;

            Family FamilyA = new Family(VillagerAF, VillagerAH);
            Family FamilyB = new Family(VillagerBF, VillagerBH);
            Family FamilyC = new Family(VillagerCF, VillagerCH);

           _families=new List<Family>();

           _singleMen = new List<Villager>();

            _families.Add(FamilyA);
            _families.Add(FamilyB);
            _families.Add(FamilyC);
        }

        List<Family> _families;

        static public List<Villager> _singleMen; //changera plus tard. //TODO : warning, static!
        static public double TotalGold{get; set;} //changera //warning, static!
        static public int TotalPop{get; set;}  //changera //warning, static!

        static public void BigEvent()
        {
            //TODO
        }

        static public void AddOrRemoveFromTotalGold(double amount)
        {
            TotalGold += amount; //curious to find out if TotalGold can be negative.
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
