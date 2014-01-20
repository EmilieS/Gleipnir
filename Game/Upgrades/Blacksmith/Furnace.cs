using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    [Serializable]
    public class Furnace : UpgradesModel
    {
        JobsModel _selected;
        Village _owner;
        JobList _jobsList;
        public Furnace(Game g, Village v, UpgradesList _listOfUpgrades, JobList _jobs)
            :base(g,v)
        {
            CostPrice = 1000;
            IsActivated = false;
            _selected = _jobs.Blacksmith;
            _owner = v;
            _jobsList = _jobs;
        }
        internal override void VerififyPrerequisites()
        {
            if (_owner.BuildingsList.ForgeList.Count > 0 && _owner.Game.Offerings >= CostPrice)
                IsPossible = true;
            else
                IsPossible = false;
        }

        internal override void AffectUpgrade()
        {
            _selected.Coefficient += 7;
            _jobsList.Farmer.Coefficient += 1;
        }

    }
}
