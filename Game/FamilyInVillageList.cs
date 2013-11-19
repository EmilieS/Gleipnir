using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class FamilyInVillageList : IReadOnlyList<Family>
    {

        public FamilyInVillageList(Village owner)
        {
            _families = new List<Family>();
            _owner = owner;
        }
       private readonly List<Family> _families;
       internal readonly Village _owner;

       public void Add(Family family)
       {
           if (family == null) throw new ArgumentNullException("family");
           if (family.OwnerVillage != null)
           {
               if (family.OwnerVillage == this._owner) throw new InvalidOperationException("This family already belongs to this Village.");
               throw new InvalidOperationException("This family already belongs to a village."); 
           }
           family.OwnerVillage = _owner;
           _families.Add(family);
       }

       public void Remove(Family family)
       {
           if (!_families.Remove(family))
           {
               throw new InvalidOperationException("Villager must belong to this family.");
           }
           family.OwnerVillage = null;
           _families.Remove(family);
       }



       public Family this[int index]
       {
           get { return _families[index]; }
       }

       public int Count
       {
           get { return _families.Count; }
       }

       public IEnumerator<Family> GetEnumerator()
       {
           return _families.GetEnumerator();
       }
       
       System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
       {
           return GetEnumerator();
       }


    }
}
