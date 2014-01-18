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
        Village _owner;
        internal Level1(Game g, Village v, UpgradesList _listOfUpgrades, JobList _jobs)
            : base(g, v)
        {
            CostPrice = 200;
            IsActivated = false;
            _selected = _jobs.Cooker;
            _owner = v;
        }
        internal override void  VerififyPrerequisites()
        {
            if (_owner.Buildings.RestaurantList.Count > 0 && _owner.Game.Offerings >= CostPrice)
                IsPossible = true ;
            else
               IsPossible = false;
        }
        
        internal override void AffectUpgrade()
        {
            _selected.Coefficient += 5;
            _selected.HappinessToAdd += 2;
        }

    }
}
