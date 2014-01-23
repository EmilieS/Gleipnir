using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    [Serializable]
    public class Irrigation : UpgradesModel
    {
        JobsModel _selected;
        Village _owner;
        public Irrigation(Game g, Village v, UpgradesList _listOfUpgrades, JobList _jobs)
            : base(g, v)
        {
            CostPrice = 5000;
            IsActivated = false;
            _selected = _jobs.Farmer;
            _owner = v;
        }
        internal override void VerififyPrerequisites()
        {
            if (_owner.BuildingsList.FarmList.Count > 0 && _owner.Game.Offerings >= CostPrice && _owner.Upgrades.Fertilizer.IsActivated)
                IsPossible = true;
            else
                IsPossible = false;
        }

        internal override void AffectUpgrade()
        {
            _selected.Coefficient += 6;
            _selected.HappinessToAdd += 5;
        }
    }
}
