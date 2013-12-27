using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    public class House: BuildingsModel
    {
        Family _family;
        int _x;
        int _y;

        public House(Village v, bool IsAProperHouse=true)
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
        }

        public Family Family { get; set; }

        override internal void AddToList()
        {
            _village.Buildings.Add(this);
        }
        internal override void OnOnDestroy()
        {
            Village.Buildings.Remove(this);
        }

        internal override void JustCollapsed()
        {
            if (Hp == 0 && _family != null)
            {
                
                foreach (Villager v in _family.FamilyMembers)
                {
                    v.Kill();
                }
                _family = null;
            }
            if (Hp == 0 && Family == null)
            {
                Village.RemoveEmptyHouse(this);
            }
        }

        internal void FamilyDestroyed()
        {
            Family = null;
            if (Hp > 0)
            {
                Village.AddEmptyHouse(this);
            }
        }

        public void SetCoordinates(int x, int y)
        {
            if (x == null || y == null)
                throw new ArgumentNullException("X or Y doesn't exist");
            if ((x < 0 || x > 20) || (y < 0 || y > 32))
                throw new IndexOutOfRangeException("Must be in tab");
            this.HorizontalPos = x;
            this.VerticalPos = y;
        }
    }
}
