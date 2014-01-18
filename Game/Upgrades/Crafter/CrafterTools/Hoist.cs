using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class Hoist : UpgradesModel
    {
        JobsModel _selected;
        Village _owner;
        internal Hoist(Game g, Village v, UpgradesList _listOfUpgrades, JobList _jobs)
            : base(g, v)
        {
            CostPrice = 5000;
            IsActivated = false;
            _selected = _jobs.Cooker;
            _owner = v;
        }
        internal override void VerififyPrerequisites()
        {
            if (_owner.Buildings.UnionOfCrafterList.Count > 0 && _owner.Game.Offerings >= CostPrice && _owner.Upgrades.Pulley.IsActivated)
                IsPossible = true;
            else
                IsPossible = false;
        }
        internal override void AffectUpgrade()
        {
            _selected.Coefficient += 1;
            _selected.HappinessToAdd += 2;
        }
    }
}
