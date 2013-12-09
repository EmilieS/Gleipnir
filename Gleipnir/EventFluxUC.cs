﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace GamePages
{
    public partial class EventFluxUC : UserControl
    {
        GameEventUC[] eventTab = new GameEventUC[10];
        FIFOList _eventList;

        int i;
        int positionX;
        int positionY;
        public EventFluxUC()
        {
            InitializeComponent();
            _eventList = new FIFOList(10);
            i = 0;
            positionX = 0;
            positionY = 0;
        }
        public void CreateNewEventAndShow(string message, string title)
        {
            positionY = 0;
            GameEventUC newMessage = new GameEventUC();
            newMessage.EventTitle.Text = title;
            newMessage.EventContain.Text = message;

            if (_eventList.Count == 10)
            {
                //_eventList[9].Hide();
                this.Controls.Remove(_eventList[9]);
            }
            _eventList.Push(newMessage);
            this.Controls.Add(_eventList[0]);
            _eventList[0].Show();

            for (int i = 0; i < _eventList.Count; i++)
            {
                _eventList[i].Location = new System.Drawing.Point(positionX, positionY);
                positionY += 65;
            }
        }
    }

    internal class FIFOList /*: IReadOnlyList<GameEventUC>*/
    {
        readonly List<GameEventUC> _items;
        int _maxCapacity;

        public FIFOList(int maxCapacity)
        {
            if (maxCapacity <= 0) throw new ArgumentException();
            _items = new List<GameEventUC>();
            _maxCapacity = maxCapacity;
        }

        public int Capacity
        {
            get { return _maxCapacity; }
            set
            {
                Debug.Assert(_items != null && _items.Count <= _maxCapacity, "Invariant.");
                if (value <= 0) throw new ArgumentException();
                if (value != _maxCapacity)
                {
                    _maxCapacity = value;
                    int excess = _items.Count - value;
                    if (excess > 0) _items.RemoveRange(value, excess);
                }
                Debug.Assert(_items != null && _items.Count <= _maxCapacity, "Invariant.");
            }
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public GameEventUC this[int idx]
        {
            get { return _items[idx]; }
        }

        public IEnumerable<GameEventUC> Items
        {
            get { return _items; }
        }


        public void Push(GameEventUC v)
        {
            Debug.Assert(_items.Count <= _maxCapacity);
            if (_items.Count == _maxCapacity)
            {
                _items.RemoveAt(_items.Count - 1);
            }
            _items.Insert(0, v);
        }
    }
}
