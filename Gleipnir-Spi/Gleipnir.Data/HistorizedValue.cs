using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gleipnir.Data
{
    internal class HistorizedValue<T>
    {
        readonly FIFOBuffer<T> _histo;
        T _current;
        bool _hasChangedDuringLastStep;

        public HistorizedValue( int capacity )
        {
            _histo = new FIFOBuffer<T>( capacity );
        }

        public FIFOBuffer<T> Historic { get { return _histo; } }

        public T Current
        {
            get { return _current; }
            set { _current = value; }
        }

        public bool HasChanged
        {
            get { return _hasChangedDuringLastStep; }
        }

        internal bool Conclude()
        {
            if( _histo.Count != 0 )
            {
                _hasChangedDuringLastStep = Comparer<T>.Default.Compare( _histo.Last, _current ) != 0;
            }
            _histo.Push( _current );
            return _hasChangedDuringLastStep;
        }

    }
}
