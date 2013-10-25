using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }
            _mother = mother;
            _father = father;
            _mother.StatusInFamily = Status.MARRIED;
            _father.StatusInFamily = Status.MARRIED;
            _familyMembers=new List<Villager>();
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
        public readonly List<Villager> _familyMembers;

        public int GoldStash { get { return _goldStash; } }
        public Villager Mother { get { return _mother; } }
        public Villager Father { get { return _father; } }

        public Villager newFamilyMember()
        {
            if (_mother == null || _father == null)
            {
                throw new InvalidOperationException();
            }
                Villager kid = new Villager(this);
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
        public float FaithAverage()
        {
            float faith=0;
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
        public float HapinessAverage()
        {
            float happiness = 0;
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
        

    }
}
