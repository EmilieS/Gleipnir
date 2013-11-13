using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class FIFOBuffer<T>
    {
        readonly List<T> _items;
        int _maxCapacity;

        public FIFOBuffer( int maxCapacity )
        {
            if( maxCapacity <= 0 ) throw new ArgumentException();
            _items = new List<T>();
            _maxCapacity = maxCapacity;
        }

        public int Capacity
        {
            get { return _maxCapacity; }
            set
            {
                Debug.Assert( _items != null && _items.Count <= _maxCapacity, "Invariant." );        
                if( value <= 0 ) throw new ArgumentException();
                if( value != _maxCapacity )
                {
                    _maxCapacity = value;
                    int excess = _items.Count - value;
                    if( excess > 0 ) _items.RemoveRange( value, excess );
                }
                Debug.Assert( _items != null && _items.Count <= _maxCapacity, "Invariant." );        
            }
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public T this[int idx]
        {
            get { return _items[idx]; }
        }

        public IEnumerable<T> Items
        {
            get { return _items; }
        }

        public T Last
        {
            get 
            {
                if( _items.Count == 0 ) throw new InvalidOperationException();
                return _items[0]; 
            }
        }



        public void Push( T v )
        {
            Debug.Assert( _items != null && _items.Count <= _maxCapacity, "Invariant." );        
            _items.Insert( 0, v );
            if( _items.Count > _maxCapacity )
            {
                _items.RemoveAt( _maxCapacity );
            }
            Debug.Assert( _items != null && _items.Count <= _maxCapacity, "Invariant." );        
        }
    }
}
