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
    [Serializable]
    public class Family : GameItem
    {
        readonly HistorizedValue<int, Family> _goldStash;
        FamilyMemberList _familyMembersList;
        NameGenerator _firstNameGenerator;
        Buildings.House _house;
        Villager _mother;
        Villager _father;
        Village _ownerVillage;
        readonly string _name;
        double _faithAverage;
        double _happinessAverage;

        internal Family(Game game, Villager mother, Villager father, string name)
            : base(game)
        {
            // Initialized historized value for gold
            _goldStash = new HistorizedValue<int, Family>(this, @"_goldstash", 20);
            _hungry = new HistorizedValue<bool, Family>(this, @"_hungry", 5);

            if (mother.ParentFamily != null && father.ParentFamily != null)
            {
                _goldStash.Current = mother.ParentFamily.TakeFromGoldStash(mother.ParentFamily.GoldStash / 10); //10%
                _goldStash.Current += father.ParentFamily.TakeFromGoldStash(father.ParentFamily.GoldStash / 10); //10%
                RemoveFromFamily(mother, mother.ParentFamily);
                RemoveFromFamily(father, father.ParentFamily);
            }
            else
                _goldStash.Current = 20;

            game.GoldAdded(_goldStash.Current);

            if (mother.StatusInFamily == Status.SINGLE && father.StatusInFamily == Status.SINGLE)
                mother.Engage(father);

            var firstNamesPath = File.ReadAllLines(@"Extra\nameList.txt");
            _firstNameGenerator = new NameGenerator(firstNamesPath, 1, 1);

            _name = name;
            _mother = mother;
            _father = father;
            _mother.StatusInFamily = Status.MARRIED;
            _father.StatusInFamily = Status.MARRIED;

            _familyMembersList = new FamilyMemberList(this);
            _familyMembersList.Add(_mother);
            _familyMembersList.Add(_father);
            _mother.ParentFamily = this;
            _father.ParentFamily = this;

            //=> marriage pendant convocation ? ils s'enfuyent.
            _mother.ActivityStatus = _mother.ActivityStatus & ~ActivityStatus.CONVOCATED;
            _father.ActivityStatus = _father.ActivityStatus & ~ActivityStatus.CONVOCATED;
        }

        // Properties
        /// <summary>
        /// Gets family's house
        /// </summary>
        public Buildings.House House { get { return _house; } internal set { _house = value; } }
        /// <summary>
        /// Gets family name
        /// </summary>
        public string Name { get { return _name; } }
        /// <summary>
        /// Gets family gold
        /// </summary>
        public int GoldStash { get { return _goldStash.Current; } }
        /// <summary>
        /// Gets last gold value
        /// </summary>
        public double LastGoldStash
        {
            get
            {
                if (_goldStash.Historic.Count > 0)
                    return _goldStash.Historic.Last;
                else
                    return _goldStash.Current;
            }
        } // For tests, should be eliminated
        /// <summary>
        /// Gets family mother
        /// </summary>
        public Villager Mother { get { return _mother; } }
        /// <summary>
        /// Gets family father
        /// </summary>
        public Villager Father { get { return _father; } }
        /// <summary>
        /// Gets family members list
        /// </summary>
        public IFamilyMemberList FamilyMembers { get { return _familyMembersList; } }
        /// <summary>
        /// Gets firstName generator
        /// </summary>
        public NameGenerator FirstNameList { get { return _firstNameGenerator; } }
        /// <summary>
        /// Gets family's village
        /// </summary>
        public Village OwnerVillage
        {
            get { return _ownerVillage; }
            internal set { _ownerVillage = value; }
        }
        /// <summary>
        /// Gets family average faith
        /// </summary>
        public double FaithAverageValue { get { return _faithAverage; } }
        /// <summary>
        /// Gets family average happiness
        /// </summary>
        public double HappinessAverageValue { get { return _happinessAverage; } }

        // Family Member Methods
        /// <summary>
        /// Add new villager in family members list
        /// </summary>
        /// <returns></returns>
        public Villager NewFamilyMember()
        {
            if (_mother == null || _father == null)
                throw new InvalidOperationException(@"(family, NewFamilyMember) Missing parent");
            var name = this.FirstNameList.NextName;
            Villager kid = new Villager(_ownerVillage.Game, this, name);
            _familyMembersList.Add(kid);
            return kid;
        }
        /// <summary>
        /// Remove villager from family's members list
        /// </summary>
        /// <param name="villager"></param>
        /// <param name="parentFamily"></param>
        private void RemoveFromFamily(Villager villager, Family parentFamily)
        {
            parentFamily.FamilyMembers.Remove(villager);
        }

        // Gold Methods
        /// <summary>
        /// Takes gold stash
        /// If not the maximum it can, return 0
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int TakeFromGoldStash(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(@"(family, TakeFromGoldStash) Negative amount");
            if (amount <= _goldStash.Current)
            {
                _goldStash.Current -= amount;
                Game.GoldRemoved(amount);
                return amount;
            }
            else if (amount > _goldStash.Current && _goldStash.Current > 0)
            {
                int goldLeft = _goldStash.Current;
                Debug.Assert(goldLeft >= 0, @"(family, TakeFromGoldStash) Negative goldStash");
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
        /// <summary>
        /// Adds gold in gold stash
        /// </summary>
        /// <param name="amount"></param>
        public void AddToGoldStash(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(@"(family, AddToGoldStash) Negative amount");
            _goldStash.Current += amount;
            Game.GoldAdded(amount);
        }

        /*internal void PayOfferings()//done in villager.(requires to know if villager is a heretic or not)
        {
           int payed=takeFromGoldStash(_ownerVillage.OfferingsPointsPerTick);


        }*/

        // Faith & Happiness Methods
        /// <summary>
        /// Calculates average family's faith
        /// </summary>
        /// <returns></returns>
        public double FaithAverage()
        {
            double faith = 0;
            int nbFamilyMembers = _familyMembersList.Count;

            if (nbFamilyMembers == 0)
                throw new NullReferenceException(@"(family, FaithAverage) Empty family");

            for (int i = 0; i < nbFamilyMembers; i++)
                faith += _familyMembersList[i].Faith;

            return faith / nbFamilyMembers;
        }
        /// <summary>
        /// Calculates family's average happiness
        /// </summary>
        /// <returns></returns>
        public double HappinessAverage()
        {
            double happiness = 0;
            int nbFamilyMembers = _familyMembersList.Count;

            if (nbFamilyMembers == 0)
                throw new NullReferenceException(@"(family, HappinessAverage) Empty family");

            for (int i = 0; i < nbFamilyMembers; i++)
                happiness += _familyMembersList[i].Happiness;

            return happiness / nbFamilyMembers;
        }
        /// <summary>
        /// Calculates family's average faith and happiness
        /// </summary>
        public void CalculateHappinessAndFaithAverage()
        {
            double faith = 0;
            double happiness = 0;
            int nbFamilyMembers = _familyMembersList.Count;

            if (nbFamilyMembers == 0)
                throw new NullReferenceException(@"(family, CalculateHappinessAndFaithAverage) Empty family");

            for (int i = 0; i < nbFamilyMembers; i++)
            {
                faith += _familyMembersList[i].Faith;
                happiness += _familyMembersList[i].Happiness;
            }
            _faithAverage= faith / nbFamilyMembers;
            _happinessAverage= happiness / nbFamilyMembers;
        }

        //====================WORLD=TICK=STUFF=============================
        #region called by ImpactHappiness
        /// <summary>
        /// Takes happiness when family member is sick
        /// </summary>
        internal void FamilyMemberIsSick()
        {
            for (int i = 0; i < FamilyMembers.Count; i++)
                FamilyMembers[i].AddOrRemoveHappiness(-0.1); //Everybody, even the sick person(who already has a minus).
        }
        /// <summary>
        /// Takes faith when family member is heretic
        /// </summary>
        internal void FamilyMemberIsHeretic()
        {
            for (int i = 0; i < FamilyMembers.Count; i++)
                FamilyMembers[i].AddOrRemoveFaith(-0.2); //need to see if the heretic should be included or not.
        }
        /// <summary>
        /// Takes or Adds happiness when family is poor or rich
        /// </summary>
        private void IsPoorOrRich_HappinessImpact()
        {
            if (_familyMembersList.Count != 0)//not needed as long as the families are cleaned
            {
                if (_goldStash.Current < 16 || _goldStash.Current / FamilyMembers.Count < (Game.TotalGold / Game.TotalPop) / 2)
                    for (int i = 0; i < FamilyMembers.Count; i++)
                        FamilyMembers[i].AddOrRemoveHappiness(-0.1);
                else if (_goldStash.Current / FamilyMembers.Count > (Game.TotalGold / Game.TotalPop) * 3)
                    for (int i = 0; i < FamilyMembers.Count; i++)
                        FamilyMembers[i].AddOrRemoveHappiness(0.1);
            }
        }
        #endregion
        #region called by Evolution

        #endregion
        #region called by DieOrIsAlive
        /// <summary>
        /// Removes happiness when family member died
        /// </summary>
        /// <param name="deadVillager"></param>
        internal void FamilyMemberDied(Villager deadVillager)
        {
            for (int i = 0; i < FamilyMembers.Count; i++)
                if (FamilyMembers[i] != deadVillager)
                    FamilyMembers[i].AddOrRemoveHappiness(-5);
        }
        /// <summary>
        /// Remove dead member from familyMemberList
        /// </summary>
        /// <param name="dead"></param>
        internal void FamilyMemberDestroyed(Villager dead)
        {
            Debug.Assert(dead != null, @"(family, FamilyMemberDestroyed) Villager exist");
            Debug.Assert(dead.IsDead(), @"(family, FamilyMemberDestroyed) Villager not dead");
            Debug.Assert(_familyMembersList.Contains(dead), @"(family, FamilyMemberDestroyed) Villager not familyMembersList");
            if (_mother != null)
                if (dead == _mother)
                    _mother = null;
            if (_father != null)
                if (dead == _father)
                    _father = null;
            _familyMembersList.Remove(dead);
        }
        /// <summary>
        /// Destroy family
        /// </summary>
        internal override void OnDestroy()
        {
            Debug.Assert(_familyMembersList.Count == 0, @"(family, OnDestroy) Still member in family");
            Debug.Assert(_ownerVillage != null, @"(family, OnDestroy) Family's village is null");
            
            _mother = null;
            _father = null;
            if (House != null)
            {
                House.FamilyDestroyed();
                House = null;
            }

            Debug.Assert(_ownerVillage.FamiliesList.Contains(this), @"(family, OnDestroy) Family not in village's familiesList");
            _ownerVillage.FamilyDestroyed(this);

            Debug.Assert(_ownerVillage == null, @"(family, OnDestroy) Village isn't null");
            Game.TakeGoldWhenFamilyRemoved(this);
        }
        #endregion 
        #region worldtickcalls
        /// <summary>
        /// Impact happiness with gold
        /// </summary>
        override internal void ImpactHappiness() 
        {
            Debug.Assert(_ownerVillage != null, @"(family, ImpactHappiness) Family's village is null");
            IsPoorOrRich_HappinessImpact();        
        }

        internal HistorizedValue<bool, Family> _hungry;
        override internal void Evolution()
        {
            //RegularBirths done in villager.
            Debug.Assert(_ownerVillage != null, @"(family, Evolution) Family's village is null");
            //TODO : do this better! 
            //TODO event !
            if (OwnerVillage.JobsList.Farmer.Workers.Count * 5 < Game.TotalPop)
            {
                int i = 0;
                bool hasFarmer = false;
                while (!hasFarmer && i < _familyMembersList.Count)
                {
                    if (_familyMembersList[i].Job == OwnerVillage.JobsList.Farmer)
                        hasFarmer = true;
                    i++;
                }
                _hungry.Current = !hasFarmer;
            }
            else
                _hungry.Current = false;
            foreach (Villager v in _familyMembersList)
            {

                if (_hungry.Current == false)
                    v.NotHungry();
                else
                    v.FamineImpact();
            }

        }
        /// <summary>
        /// Check if family is dead or not
        /// </summary>
        /// <param name="eventList"></param>
        override internal void DieOrIsAlive(List<IEvent> eventList)
        {
            Debug.Assert(_ownerVillage != null, @"(family, DieOrIsAlive) Family's village is null");
            if (FamilyMembers.Count == 0)
            {
                OwnerVillage.AddEmptyHouse(House);
                eventList.Add(new FamilyEndEvent(this));
                Destroy();
                Debug.Assert(Game == null, @"(family, DieOrIsAlive) Game is not null");
            }
        }
        /// <summary>
        /// Ends step and send events
        /// </summary>
        /// <param name="eventList"></param>
        override internal void CloseStep(List<IEvent> eventList)
        {
            Debug.Assert(_ownerVillage != null, @"(family, CloseStep) Family's village is null");
            if (_goldStash.Conclude()) { eventList.Add(new EventProperty<Family>(this, @"LastGoldStash")); }
            if (_familyMembersList.Conclude()) { eventList.Add(new EventProperty<Family>(this, @"FamilyMembers")); }
            if (_hungry.Conclude()) { eventList.Add(new HungryFamilyEvent(this)); }
        }
        #endregion
        //=================================================================
    }
}
