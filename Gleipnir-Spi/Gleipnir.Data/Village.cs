using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gleipnir.Data
{
    public class Village : GameItem
    {
        readonly string _name;
        readonly List<Villager> _villagers;

        internal Village( Game g, string name )
            : base( g )
        {
            Debug.Assert( !String.IsNullOrWhiteSpace( name ) );
            _name = name;
            _villagers = new List<Villager>();
        }

        public string Name { get { return _name; } }

        public Villager CreateVillager( string name )
        {
            if( String.IsNullOrWhiteSpace( name ) ) throw new ArgumentNullException( "name" );
            var v = new Villager( this, name );
            _villagers.Add( v );
            return v;
        }
    }
}
