using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    public class Tavern : BuildingsModel
    {
        public Tavern(Village v)
            : base(v)
        {
            CostPrice = 100;
            Name = "Taverne";
            Hp = MaxHp = 50;
            this.CostPrice = 250;
        }

        public double SetFaith
        {
            get { return 4; }
        }
        public double SetHappiness
        {
            get { return 6; }
        }
        /*public void SetEnterPrice()
        {
            prop.EnterPrice = 2;
        }*/

        override internal void AddToList()
        {
            Village.BuildingsList.Add(this);
        }
        internal override void OnOnDestroy()
        {
            Village.BuildingsList.Remove(this);
        }
    }
}
