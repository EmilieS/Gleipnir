using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gleipnir.Data
{
    public class Game
    {
        readonly List<GameItem> _items;
        readonly List<Village> _villages;

        public Game()
        {
            _items = new List<GameItem>();
            _villages = new List<Village>();
        }

        public Village CreateVillage( string name )
        {
            if( String.IsNullOrWhiteSpace( name ) ) throw new ArgumentNullException( "name" );
            var v = new Village( this, name );
            _villages.Add( v );
            return v;
        }

        internal void GameItemCreated( GameItem item )
        {
            _items.Add( item );
        }
        
        internal void GameItemDestroyed( GameItem item )
        {
            _items.Remove( item );
        }

    }
}
