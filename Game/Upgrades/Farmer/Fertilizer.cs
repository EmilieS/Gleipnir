﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    [Serializable]
    public class Fertilizer : UpgradesModel
    {
        JobsModel _selected;
        Village _owner;
        public Fertilizer(Game g, Village v, UpgradesList _listOfUpgrades, JobList _jobs)
            : base(g, v)
        {
            CostPrice = 1000;
            IsActivated = false;
            _selected = _jobs.Farmer;
            _owner = v;
        }
        internal override void VerififyPrerequisites()
        {
            if (_owner.BuildingsList.FarmList.Count > 0 && _owner.Game.Offerings >= CostPrice && _owner.Upgrades.Scarecrow.IsActivated)
                IsPossible = true;
            else
                IsPossible = false;
        }

        internal override void AffectUpgrade()
        {
            _selected.Coefficient += 3;
            _selected.HappinessToAdd += 2;
        }
    }
}
