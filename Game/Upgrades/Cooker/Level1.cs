using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Level1 : UpgradesModel
    {
        JobsModel _selected;
        internal Level1(Game g, UpgradesList _listOfUpgrades, JobList _jobs)
            : base(g)
        {
            CostPrice = 200;
            IsActivated = false;
            _selected = _jobs.Cooker;
        }
        internal override void AffectUpgrade()
        {
            _selected.Coefficient += 10;
        }
    }
}
