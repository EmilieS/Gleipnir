using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    [Serializable]
    public class House : BuildingsModel
    {
        Family _family;

        public House(Village v, bool IsAProperHouse = true)
            : base(v)
        {
            Name = "Maison";
            if (IsAProperHouse == true)
            {
                Hp = 100;
                MaxHp = 100;
            }
            else
            {
                Hp = 5;
                MaxHp = 15;
            }
            this.CostPrice = 70;
        }

        public Family Family
        {
            get { return _family; }
            set { _family = value; }
        }

        override internal void AddToList()
        {
            _village.BuildingsList.Add(this);
        }
        internal override void OnOnDestroy()
        {
            Village.RemoveEmptyHouse(this);
            Village.BuildingsList.Remove(this);
        }
        internal override void JustCollapsed()
        {
            if (Hp == 0 && Family != null)
            {
                foreach (Villager v in Family.FamilyMembers)
                {
                    v.Kill();
                }
                Family = null;
            }
            //Debug.Assert(Village.EmptyHouseList.Contains(this), "JustCollapsed - emptyHouseList");
            //if (Hp == 0 && Family == null)
            //{
            //    Village.RemoveEmptyHouse(this);
            //}
        }

        internal void FamilyDestroyed()
        {
            Family = null;
            if (Hp > 0)
            {
                Village.AddEmptyHouse(this);
            }
        }
    }
}
