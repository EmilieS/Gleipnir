using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class Level3 : UpgradesModel
    {
        public Level3(Game g, UpgradesList _listOfUpgrades)
            : base(g)
        {
            CostPrice = 800;
            IsActivated = false;
        }
        internal override void AffectUpgrade()
        {
        }
    }
}
