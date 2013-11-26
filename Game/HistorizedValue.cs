using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Game
{
    class HistorizedValue<T, TOwner>
    {
        readonly FIFOBuffer<T> _histo;
        T _current;
        readonly string _name;
        readonly TOwner _owner;

        bool _hasChangedDuringLastStep;

        public HistorizedValue(TOwner owner, string name, int capacity)
        {
            Debug.Assert(! string.IsNullOrWhiteSpace(name));
            _histo = new FIFOBuffer<T>(capacity);
            _owner = owner;
            _name = name;
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
            if (_histo.Count != 0)
            {
                _hasChangedDuringLastStep = Comparer<T>.Default.Compare(_histo.Last, _current) != 0;
            }
            else { _hasChangedDuringLastStep = true; }
            _histo.Push(_current);
            return _hasChangedDuringLastStep;
        }
    }
}
