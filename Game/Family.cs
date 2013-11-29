using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            : base(game)
        {
            _goldStash = new HistorizedValue<int, Family>(this, "_goldstash", 20);
            if (mother.ParentFamily != null && father.ParentFamily != null)
            {
                _goldStash.Current = mother.ParentFamily.takeFromGoldStash(mother.ParentFamily.GoldStash / 10); //10%
                _goldStash.Current += father.ParentFamily.takeFromGoldStash(father.ParentFamily.GoldStash / 10); //10%
                removeFromFamily(mother, mother.ParentFamily);
                removeFromFamily(father, father.ParentFamily);
            }
            else { _goldStash.Current = 20; }
            game.GoldAdded(_goldStash.Current);
            if (mother.StatusInFamily == Status.SINGLE && father.StatusInFamily == Status.SINGLE)
            {
                mother.Engage(father);
            }

            var firstNamesPath = File.ReadAllLines(@"Extra\nameList.txt");
            _firstNameGenerator = new NameGenerator(firstNamesPath, 1, 1);

            _name = name;
            _mother = mother;
            _father = father;
            _mother.StatusInFamily = Status.MARRIED;
            _father.StatusInFamily = Status.MARRIED;

            _familyMembers = new FamilyMemberList(this);
            _familyMembers.Add(_mother);
            _familyMembers.Add(_father);
            _mother.ParentFamily = this;
            _father.ParentFamily = this;

        }

        Village _ownerVillage;
        readonly HistorizedValue<int, Family> _goldStash;
        Villager _mother;
        Villager _father;
        FamilyMemberList _familyMembers;
        readonly string _name;
        NameGenerator _firstNameGenerator;

        public string Name { get { return _name; } }
        public int GoldStash { get { return _goldStash.Current; } }
        public double LastGoldStash { get {
            if (_goldStash.Historic.Count > 0)
                return _goldStash.Historic.Last;
            else 
                return _goldStash.Current;
        } }//for tests, should be eliminated
        public Villager Mother { get { return _mother; } }
        public Villager Father { get { return _father; } }
        public IFamilyMemberList FamilyMembers { get { return _familyMembers; } }
        public NameGenerator FirstNameList { get { return _firstNameGenerator; } }

        public Village OwnerVillage
        {
            get { return _ownerVillage; }
            internal set { _ownerVillage = value; }
        }
        static private void removeFromFamily(Villager villager, Family parentFamily)
        {
            parentFamily.FamilyMembers.Remove(villager);
        }
        public Villager newFamilyMember()
        {
            if (_mother == null || _father == null)
            {
                throw new InvalidOperationException("Missing parent");
            }
            var name = this.FirstNameList.NextName;
            Villager kid = new Villager(_ownerVillage.Game, this, name);
            _familyMembers.Add(kid);
            return kid;
        }
        /// <summary>
        /// takes from the gold stash the amount asked, if not the maximum it can. Returns true amount.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int takeFromGoldStash(int amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException();
            if (amount <= _goldStash.Current)
            {
                _goldStash.Current -= amount;
                Game.GoldRemoved(amount);
                return amount;
            }
            else if (amount > _goldStash.Current && _goldStash.Current > 0)
            {
                int goldLeft = _goldStash.Current;
                Debug.Assert(goldLeft >= 0, "(takeFromGoldStash) negative _goldStash.Current.");
                _goldStash.Current = 0;
                Game.GoldRemoved(goldLeft);
                return goldLeft;
            }
            else
            {
                _goldStash.Current = 0;
                return 0;
            }
        }
        public void addTOGoldStash(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            _goldStash.Current += amount;
            Game.GoldAdded(amount);
        }
        /*internal void PayOfferings()//done in villager.(requires to know if villager is a heretic or not)
        {
           int payed=takeFromGoldStash(_ownerVillage.OfferingsPointsPerTick);


        }*/
        public double FaithAverage()
        {
            double faith = 0;
            int nbFamilyMembers = _familyMembers.Count;
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
        //====================WORLD=TICK=STUFF=============================
        #region called by ImpactHappiness
        internal void FamilyMemberIsSick()
        {
            for (int i = 0; i < FamilyMembers.Count; i++)
            {
                FamilyMembers[i].AddOrRemoveHappiness(-0.1); //Everybody, even the sick person(who already has a minus).
            }
        }
        private void IsPoorOrRich_HappinessImpact()
        {
            if (_familyMembers.Count != 0)
            {
                if (_goldStash.Current < 16 || _goldStash.Current / FamilyMembers.Count < (Game.TotalGold / Game.TotalPop) / 2)
                {
                    for (int i = 0; i < FamilyMembers.Count; i++)
                    {
                        FamilyMembers[i].AddOrRemoveHappiness(-0.1);
                    }
                }
                else if (_goldStash.Current / FamilyMembers.Count > (Game.TotalGold / Game.TotalPop) * 3)
                {
                    for (int i = 0; i < FamilyMembers.Count; i++)
                    {
                        FamilyMembers[i].AddOrRemoveHappiness(0.1);
                    }
                }
            }
        }
        #endregion
        #region called by Evolution

        #endregion
        #region called by DieOrIsAlive
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
        internal void FamilyMemberDestroyed(Villager dead)
        {
            Debug.Assert(dead != null);
            Debug.Assert(dead.IsDead());
            Debug.Assert(_familyMembers.Contains(dead));
            if (_mother != null) { if (dead == _mother) { _mother = null; } }
            if (_father != null) { if (dead == _father) { _father = null; } }
            _familyMembers.Remove(dead);
        }
        
        internal override void OnDestroy()
        {
            Debug.Assert(_familyMembers.Count == 0, "there is still someone in this family!");
            Debug.Assert(_ownerVillage != null, "(OnDestroy) ownerVillage == null !!!!!!");
            _mother = null;
            _father = null;
            Debug.Assert(_ownerVillage.FamiliesList.Contains(this));
            _ownerVillage.FamilyDestroyed(this);
            Debug.Assert(_ownerVillage == null);
            Game.FamilyRemoved(this);
        }
        #endregion 
        #region worldtickcalls
        override internal void ImpactHappiness() 
        {
            IsPoorOrRich_HappinessImpact();        
        }
        override internal void Evolution()
        {
            //RegularBirths done in villager.

        }
        
        override internal void DieOrIsAlive(List<IEvent> eventList)
        {
            if (FamilyMembers.Count == 0) { eventList.Add(new FamilyEndEvent(this)); OnDestroy(); }
        }
        
        override internal void CloseStep(List<IEvent> eventList)
        {
            if (_goldStash.Conclude()) { eventList.Add(new EventProperty<Family>(this, "LastGoldStash")); }
            if (_familyMembers.Conclude()) { eventList.Add(new EventProperty<Family>(this, "FamilyMembers")); }
        }
        #endregion
        //=================================================================
    }
}
