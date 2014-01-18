using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    [Serializable]
    public class Scaffolding
    {
        bool _isBought;

        public bool IsBought
        {
            get { return _isBought; }
            set { _isBought = value; }
        }
    }
}
