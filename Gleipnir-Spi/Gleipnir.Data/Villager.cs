using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gleipnir.Data
{
    public class Villager : GameItem
    {
        readonly string _name;
        readonly Village _village;

        readonly HistorizedValue<int> _happiness;
        readonly HistorizedValue<int> _faith;

        internal Villager( Village v, string name )
            : base( v.Game )
        {
            Debug.Assert( !String.IsNullOrWhiteSpace( name ) );
            _name = name;
            _village = v;
        }

        public string Name { get { return _name; } }

    }
}
