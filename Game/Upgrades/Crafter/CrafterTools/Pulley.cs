﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    [Serializable]
    public class Pulley : UpgradesModel
    {
       JobsModel _selected;
        Village _owner;
        internal Pulley(Game g, Village v, UpgradesList _listOfUpgrades, JobList _jobs)
            : base(g, v)
        {
            CostPrice = 200;
            IsActivated = false;
            _selected = _jobs.Construction_Worker;
            _owner = v;
        }
        internal override void VerififyPrerequisites()
        {
            if (_owner.BuildingsList.UnionOfCrafterList.Count > 0 && _owner.Game.Offerings >= CostPrice)
                IsPossible = true;
            else
                IsPossible = false;
        }
        internal override void AffectUpgrade()
        {
            _selected.Coefficient += 5;
            _selected.HappinessToAdd += 4;
        }
    }
}
