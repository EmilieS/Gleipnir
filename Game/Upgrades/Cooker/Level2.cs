﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    [Serializable]
    public class Level2  : UpgradesModel
    {
        JobsModel _selected;
        Village _owner;

        internal Level2(Game g, Village v, UpgradesList _listOfUpgrades,JobList _jobs)
            :base(g,v)
        {
            CostPrice = 400;
            IsActivated = false;
            _selected = _jobs.Cooker;
            _owner = v;
        }
        internal override void VerififyPrerequisites()
        {
            if (_owner.BuildingsList.RestaurantList.Count > 0 && _owner.Game.Offerings >= CostPrice)
            {
                IsPossible = true;
            }
            else
            {
                IsPossible = false;
            }
        }

        internal override void AffectUpgrade()
        {
            _selected.Coefficient += 7;
            _selected.HappinessToAdd += 4;
        }
     
    }
}
