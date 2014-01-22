using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    [Serializable]
    public class Scaffolding : UpgradesModel
    {

        JobsModel _selected;
        Village _owner;
        internal Scaffolding(Game g, Village v, UpgradesList _listOfUpgrades, JobList _jobs)
            : base(g, v)
        {
            CostPrice = 15000;
            IsActivated = false;
            _selected = _jobs.Construction_Worker;
            _owner = v;
        }
        internal override void VerififyPrerequisites()
        {
            if (_owner.BuildingsList.UnionOfCrafterList.Count > 0 && _owner.Game.Offerings >= CostPrice && _owner.Upgrades.Pulley.IsActivated && _owner.Upgrades.Hoist.IsActivated)
                IsPossible = true;
            else
                IsPossible = false;
        }
        internal override void AffectUpgrade()
        {
            _selected.Coefficient += 10;
            _selected.HappinessToAdd += 6;
        }
    }
}
