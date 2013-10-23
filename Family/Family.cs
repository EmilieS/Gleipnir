using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family
{
    class Family
    {
        //TODO initial constructor.
        public Family(Villager mother, Villager father)
        {
            _goldStash = mother.ParentFamily.takeFromGoldStash(mother.ParentFamily.GoldStash / 10); //10%
            _goldStash += father.ParentFamily.takeFromGoldStash(father.ParentFamily.GoldStash / 10); //10%
            _mother = mother;
            _father = father;
            _mother.StatusInFamily = Status.MARRIED;
            _father.StatusInFamily = Status.MARRIED;
            _familyMembers=new List<Villager>();
            _familyMembers.Add(_mother);
            _familyMembers.Add(_father);
            _mother.ParentFamily = this;
            _father.ParentFamily = this;
        }
        int _goldStash;
        Villager _mother;
        Villager _father;
        readonly List<Villager> _familyMembers;

        public int GoldStash { get { return _goldStash; } }
        public Villager Mother { get { return _mother; } }
        public Villager Father { get { return _father; } }

        public void newFamilyMember()
        {
            _familyMembers.Add(new Villager(this));
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


    }
}
