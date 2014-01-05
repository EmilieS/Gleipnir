using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class Level2 : UpgradesModel
    {
        JobsModel _selected;
        public Level2(Game g, UpgradesList _listOfUpgrades,JobList _jobs)
            : base(g)
        {
            CostPrice = 400;
            IsActivated = false;
            _selected = _jobs.Cooker;
        }
        internal override void AffectUpgrade()
        {
            _selected.Coefficient += 40;
        }
    }
}
