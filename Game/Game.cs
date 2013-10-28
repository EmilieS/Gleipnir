using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Game
    {
        Game()
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

            Family FamilyA = new Family(VillagerAH, VillagerAF);
            Family FamilyB = new Family(VillagerBH, VillagerBF);
            Family FamilyC = new Family(VillagerCH, VillagerCF);

           _families=new List<Family>();

            _families.Add(FamilyA);
            _families.Add(FamilyB);
            _families.Add(FamilyC);
        }

        List<Family> _families;


        void Engagement() //WILL CHANGE
        {
            int familyNB = _families.Count;
            int familyMemberNB;
            List<Villager> singleWomen= new List<Villager>();
            List<Villager> singleMen = new List<Villager>();
            for (int i = 0; i < familyNB; i++)
            {

                familyMemberNB = _families[i].FamilyMembers.Count;
                for (int j = 0; j < familyMemberNB; j++)
                {
                    if (_families[i].FamilyMembers[j].StatusInFamily == Status.SINGLE)
                    {
                        if (_families[i].FamilyMembers[j].Gender == Genders.MALE)
                        {
                            singleWomen.Add(_families[i].FamilyMembers[j]);
                        }
                        else
                        {
                            singleMen.Add(_families[i].FamilyMembers[j]);
                        }
                    }
               }
                for ( i = 0; i < singleWomen.Count; i++)
                {

                    int j2= 0;
                    while(j2<singleMen.Count)
                    {
                        if (singleWomen[i].ParentFamily != singleMen[j2].ParentFamily)
                        {
                            Villager.Engage(singleWomen[i],singleMen[j2]);
                        }
                        j2++;
                    }
                }
            }
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
