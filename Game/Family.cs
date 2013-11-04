using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Game
{
    public class Family
    {
        //TODO initial constructor.
        public Family(Villager mother, Villager father)
        {
            if (mother.Gender != Genders.FEMALE || father.Gender != Genders.MALE)
            {
                throw new InvalidOperationException("gender issue!");
            }
            if (mother.ParentFamily != null && father.ParentFamily != null)
            {
                if (mother.ParentFamily == father.ParentFamily)
                {
                    throw new InvalidOperationException("same family!");
                }
                _goldStash = mother.ParentFamily.takeFromGoldStash(mother.ParentFamily.GoldStash / 10); //10%
                _goldStash += father.ParentFamily.takeFromGoldStash(father.ParentFamily.GoldStash / 10); //10%
                removeFromFamily(mother, mother.ParentFamily);
                removeFromFamily(father, father.ParentFamily);
            }
            else
            {
                _goldStash = 0;
            }
            _mother = mother;
            _father = father;
            _mother.StatusInFamily = Status.MARRIED;
            _father.StatusInFamily = Status.MARRIED;

            _familyMembers=new FamilyMemberList(this);
            _familyMembers.Add(_mother);
            _familyMembers.Add(_father);
            _mother.ParentFamily = this;
            _father.ParentFamily = this;
            _mother.PropertyChanged += (sender, e) =>
            {
                _mother = null;
            };
            _father.PropertyChanged += (sender, e) =>
            {
                _father = null;
            };
        }

        public Family() { }


        int _goldStash;
        Villager _mother;
        Villager _father;
        FamilyMemberList _familyMembers; 

        public int GoldStash { get { return _goldStash; } }
        public Villager Mother { get { return _mother; } }
        public Villager Father { get { return _father; } }
        public IFamilyMemberList FamilyMembers { get { return _familyMembers; } }

        static private void removeFromFamily(Villager villager, Family parentFamily)
        {
            parentFamily.FamilyMembers.Remove(villager);
        }
        static private void Engage(Villager woman, List<Villager> MenList)
        {
            int i = 0;
            while (i < MenList.Count)
            {
                if (woman.ParentFamily != MenList[i].ParentFamily)
                {
                    woman.Fiance = MenList[i];
                    MenList[i].Fiance = woman;
                    woman.StatusInFamily = Status.ENGAGED;
                    MenList[i].StatusInFamily = Status.ENGAGED;

                    /*Timer timer = new Timer;
                    timer.Interval=5000;
                    timer.Start*/

                    break;
                }
                i++;
            }
        }

        public Villager newFamilyMember()
        {
            if (_mother == null || _father == null)
            {
                throw new InvalidOperationException("missing parent");
            }
                Villager kid = new Villager(this);
                _familyMembers.Add(kid);
                if (kid.Gender == Genders.FEMALE)
                {
                    Engage(kid, Game._singleMen);
                }
                
                return kid;           
        }



        /// <summary>
        /// takes from the gold stash the amount asked, if not the maximum it can. Returns true amount.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int takeFromGoldStash(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (amount<=_goldStash)
            {
                _goldStash -= amount;
                return amount;
            }
            int goldLeft=_goldStash;
            _goldStash=0;
            return goldLeft;
        }



        public void addTOGoldStash(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            _goldStash += amount;
        }
        public double FaithAverage()
        {
            double faith=0;
            int nbFamilyMembers=_familyMembers.Count;
            if (nbFamilyMembers == 0)
            {
                throw new NullReferenceException();
            }
            for (int i = 0; i < nbFamilyMembers; i++)
            {
                faith += _familyMembers[i].Faith;
            }
            return faith / nbFamilyMembers;
        }
        public double HappinessAverage()
        {
            double happiness = 0;
            int nbFamilyMembers = _familyMembers.Count;
            if (nbFamilyMembers == 0)
            {
                throw new NullReferenceException();
            }
            for (int i = 0; i < nbFamilyMembers; i++)
            {
                happiness += _familyMembers[i].Happiness;
            }
            return happiness / nbFamilyMembers;
        }


        #region happiness evolution
        //-------------------------------------------------------------------------------------------------------------------------------

        internal void FamilyMemberDied(Villager deadVillager)
        {
            for (int i = 0; i < FamilyMembers.Count; i++)
            {
                if (FamilyMembers[i] != deadVillager)
                {
                    FamilyMembers[i].AddOrRemoveHappiness(-5);
                }
            }
        }
        internal void FamilyMemberIsSick()
        {
            for (int i = 0; i < FamilyMembers.Count; i++)
            {
                    FamilyMembers[i].AddOrRemoveHappiness(-0.1); //Everybody, even the sick person(who already has a minus).
            }
        }
        public void IsPoorOrRich_HappinessImpact() //public for tests
        {
            if (_goldStash / FamilyMembers.Count < (Game.TotalGold / Game.TotalPop) / 2)
            {
                for (int i=0; i<FamilyMembers.Count; i++)
                {
                    FamilyMembers[i].AddOrRemoveHappiness(-0.1);
                }
            }
            else if (_goldStash / FamilyMembers.Count > (Game.TotalGold / Game.TotalPop) *4)
            {
                for (int i = 0; i < FamilyMembers.Count; i++)
                {
                    FamilyMembers[i].AddOrRemoveHappiness(0.1);
                }

            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        #endregion


    }
}
