using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class Level4 : UpgradesModel
    {
        public Level4(Game g, UpgradesList _listOfUpgrades)
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
