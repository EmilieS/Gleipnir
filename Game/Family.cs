using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Game
{
    public class Family : GameItem
    {
        //TODO initial constructor.
        internal Family(Game game, Villager mother, Villager father, string name)
            : base (game)
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
                _goldStash.Current = mother.ParentFamily.takeFromGoldStash(mother.ParentFamily.GoldStash / 10); //10%
                _goldStash.Current += father.ParentFamily.takeFromGoldStash(father.ParentFamily.GoldStash / 10); //10%
                removeFromFamily(mother, mother.ParentFamily);
                removeFromFamily(father, father.ParentFamily);
            }
            else { _goldStash.Current = 15; }
            _name = name;
            _mother = mother;
            _father = father;
            _mother.StatusInFamily = Status.MARRIED;
            _father.StatusInFamily = Status.MARRIED;

            _familyMembers=new FamilyMemberList(this);
            _familyMembers.Add(_mother);
            _familyMembers.Add(_father);
            _mother.ParentFamily = this;
            _father.ParentFamily = this;
        }

        public Family(Village village) //a eliminer
            : base(village.ThisGame) 
        { _ownerVillage = village; }

        public Family(Villager mother, Villager father, Village village)//a eliminer
            : base(village.ThisGame)
        {
            _mother = mother;
            _father = father;
            _mother.StatusInFamily = Status.MARRIED;
            _father.StatusInFamily = Status.MARRIED;

            _familyMembers = new FamilyMemberList(this);
            _familyMembers.Add(_mother);
            _familyMembers.Add(_father);
            _mother.ParentFamily = this;
            _father.ParentFamily = this;
            village.FamiliesList.Add(this);
        }



        Village _ownerVillage;
        HistorizedValue<double> _goldStash;
        Villager _mother;
        Villager _father;
        FamilyMemberList _familyMembers;
        readonly string _name;

        public string Name { get { return _name; } }
        public double GoldStash { get { return _goldStash.Current; } }
        public Villager Mother { get { return _mother; } }
        public Villager Father { get { return _father; } }
        public IFamilyMemberList FamilyMembers { get { return _familyMembers; } }

        public Village OwnerVillage
        {
            get { return _ownerVillage; }
            set { _ownerVillage = value; } //riqueraque
        }

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
                Villager kid = new Villager( _ownerVillage.Game, this, "default");
                _familyMembers.Add(kid);
                if (kid.Gender == Genders.FEMALE)
                {
                    Engage(kid, _ownerVillage.ThisGame._singleMen);
                }

                return kid;           
        }



        /// <summary>
        /// takes from the gold stash the amount asked, if not the maximum it can. Returns true amount.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public double takeFromGoldStash(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (amount<=_goldStash.Current)
            {
                _goldStash.Current -= amount;
                return amount;
            }
            double goldLeft=_goldStash.Current;
            _goldStash.Current=0;
            return goldLeft;
        }



        public void addTOGoldStash(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            _goldStash.Current += amount;
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
            if (_goldStash.Historic.Last / FamilyMembers.Count < (OwnerVillage.ThisGame.TotalGold / OwnerVillage.ThisGame.TotalPop) / 2)
            {
                for (int i=0; i<FamilyMembers.Count; i++)
                {
                    FamilyMembers[i].AddOrRemoveHappiness(-0.1);
                }
            }
            else if (_goldStash.Historic.Last / FamilyMembers.Count > (OwnerVillage.ThisGame.TotalGold / OwnerVillage.ThisGame.TotalPop) * 4)
            {
                for (int i = 0; i < FamilyMembers.Count; i++)
                {
                    FamilyMembers[i].AddOrRemoveHappiness(0.1);
                }

            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        #endregion
        internal override void OnDestroy()
        {
            Debug.Assert(_familyMembers.Count==0, "there is still someone in this family!");

            _mother = null;
            _father = null;
            _ownerVillage = null;

        }
        override internal void CloseStep() 
        {


            //TODO :  put current values in value history.
            _goldStash.Conclude();
            //TODO : check everything it is linked to.
            if (_mother.IsDead()) { _mother = null; }
            if (_father.IsDead()) { _father = null; }


            for (int i = 0; i < _familyMembers.Count; i++)
            {
                if (_familyMembers[i].IsDead()) { _familyMembers.Remove(_familyMembers[i]); }
            }

            //TODO : events!
        }
    }
}
