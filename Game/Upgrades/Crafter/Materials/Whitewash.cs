using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game;

namespace Game
{
    [Serializable]
    public class Whitewash : UpgradesModel
    {
        JobsModel _selected;
        Village _owner;
        internal Whitewash(Game g, Village v, UpgradesList _listOfUpgrades, JobList _jobs)
            : base(g, v)
        {
            CostPrice = 100;
            IsActivated = false;
            _selected = _jobs.Cooker;
            _owner = v;
        }

        internal override void VerififyPrerequisites()
        {
            if (_owner.BuildingsList.UnionOfCrafterList.Count > 0 && _owner.Game.Offerings >= CostPrice && _owner.Upgrades.Pulley.IsActivated)
                IsPossible = true;
            else
                IsPossible = false;
        }
        internal override void AffectUpgrade()
        {
            _selected.Coefficient += 1;
            _selected.HappinessToAdd += 2;
            foreach (var buildingsList in _owner.BuildingsList)
            {
                buildingsList.MaxHp += 200;
                buildingsList.Hp += 200;
            }
        }
    }
}
