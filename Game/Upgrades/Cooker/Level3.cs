using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class Level3 : UpgradesModel
    {

        public Level3(Game g, Village v, UpgradesList _listOfUpgrades)
            :base(g,v)
        {
            CostPrice = 800;
            IsActivated = false;
        }
        
    }
}
