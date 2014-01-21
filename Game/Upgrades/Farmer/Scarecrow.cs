using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    [Serializable]
    public class Scarecrow : UpgradesModel
    {
        JobsModel _selected;
        Village _owner;
        public Scarecrow(Game g, Village v, UpgradesList _listOfUpgrades, JobList _jobs)
            : base(g, v)
        {
            CostPrice = 500;
            IsActivated = false;
            _selected = _jobs.Farmer;
            _owner = v;
        }
        internal override void VerififyPrerequisites()
        {
            if (_owner.BuildingsList.FarmList.Count > 0 && _owner.Game.Offerings >= CostPrice)
                IsPossible = true;
            else
                IsPossible = false;
        }

        internal override void AffectUpgrade()
        {
            _selected.Coefficient += 1;
        }
    }
}
