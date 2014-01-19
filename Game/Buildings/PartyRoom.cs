using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Buildings
{
    [Serializable]
    public class PartyRoom : BuildingsModel
    {
        public PartyRoom(Village v)
            : base(v)
        {
            Name = "Salle des Fêtes";
            Hp = MaxHp = 50;
            this.CostPrice = 250;
        }

        override internal void AddToList()
        {
            Village.Buildings.Add(this);
        }
        internal override void OnOnDestroy()
        {
            Village.Buildings.Remove(this);
        }
    }
}
