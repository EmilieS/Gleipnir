﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    public abstract class UpgradesModel : GameItem
    {
        string _name;
        int _costPrice;
        HistorizedValue<bool,UpgradesModel> _isActivated;
        public bool IsPossible = false;
        Village _owner;

        internal UpgradesModel(Game g, Village v)
            : base(g)
        {
            _isActivated = new HistorizedValue<bool, UpgradesModel>(this, "IsActivated", 5);
            _owner = v;
            IsActivated = false;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int CostPrice
        {
            get { return _costPrice; }
            set { _costPrice = value; }
        }

        public bool IsActivated
        {
            get { return _isActivated.Current; }
            internal set { _isActivated.Current = value; }
        }
        public void Buy()
        {
            VerififyPrerequisites();
            if (IsPossible)
            {
                
                _owner.Game.AddOrTakeFromOfferings(-CostPrice);
                AffectUpgrade();
                IsActivated = true;
            }
            else
            {
                IsActivated = false;
            }
        }
        internal virtual void VerififyPrerequisites() { }
        internal virtual void AffectUpgrade() { }

        internal override void OnDestroy()
        {

        }
        internal override void CloseStep(List<IEvent> eventList)
        {
            if (_isActivated.Conclude())
                eventList.Add(new EventProperty<UpgradesModel>(this, "Upgrade"));
        }
    }
}
