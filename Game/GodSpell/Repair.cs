using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GodSpell
{
    static class Repair
    {
        static void RepairAll(Village v)
        {
            foreach (Buildings.BuildingsModel b in v.BuildingsList)
            {
                b.Repair(b.MaxHp);

            }
        }
    }
}
