using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface IFamilyMemberList: IReadOnlyList<Villager>
    {
        void Add( Villager villager );
        
        void Remove( Villager villager );

    }
}
