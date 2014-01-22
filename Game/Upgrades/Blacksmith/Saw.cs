using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    [Serializable]
    public class Saw : UpgradesModel
    {
        JobsModel _selected;
        Village _owner;
        internal Saw(Game g, Village v, UpgradesList _listOfUpgrades, JobList _jobs)
            : base(g, v)
        {
            CostPrice = 600;
            IsActivated = false;
            _selected = _jobs.Blacksmith;
            _owner = v;
        }
        internal override void  VerififyPrerequisites()
        {
            if (_owner.BuildingsList.ForgeList.Count > 0 && _owner.Game.Offerings >= CostPrice)
                IsPossible = true ;
            else
               IsPossible = false;
        }
        
        internal override void AffectUpgrade()
        {
            _selected.Coefficient += 5;
        }
    }
}
