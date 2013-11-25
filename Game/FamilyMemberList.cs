using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class FamilyMemberList : IFamilyMemberList
    {
        public FamilyMemberList(Family owner)
        {
            _members = new List<Villager>();
            _owner = owner;
        }
       private readonly List<Villager> _members;
       internal readonly Family _owner;
       internal bool FamilyMemberListChanged { get; set; }

       public void Add(Villager villager)
       {
           if (villager == null) throw new ArgumentNullException("villager");
           if (villager.ParentFamily != null)
           {
               if (villager.ParentFamily==this._owner) throw new InvalidOperationException("This villager already belongs to this Family.");
               throw new InvalidOperationException("This villager already belongs to a Family."); 
           }
           villager.ParentFamily = _owner;
           _members.Add(villager);
           FamilyMemberListChanged = true;
       }

       public void Remove(Villager villager)
       {
           if (!_members.Remove(villager))
           {
               throw new InvalidOperationException("Villager must belong to this family.");
           }
           villager.ParentFamily = null;
           _members.Remove(villager);
           FamilyMemberListChanged = true;
       }
       internal bool Conclude()
       {
           bool changed=FamilyMemberListChanged;
           FamilyMemberListChanged = false;
           return changed;
       }

       public Villager this[int index]
       {
           get { return _members[index]; }
       }

       public int Count
       {
           get { return _members.Count; }
       }

       public IEnumerator<Villager> GetEnumerator()
       {
           return _members.GetEnumerator();
       }

       System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
       {
           return GetEnumerator();
       }
    }
}
