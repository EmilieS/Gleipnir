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

        int positionX;
        int positionY;

        public EventFluxUC()
        {
            InitializeComponent();
            _eventList = new FIFOList(10);
            positionX = 3;
            positionY = 0;
        }

        public void CreateNewEventAndShow(string message, string title)
        {
            this.SuspendLayout();
            positionY = 3;
            GameEventUC newMessage = new GameEventUC();
            newMessage.EventTitle.Text = title;
            newMessage.EventContain.Text = "";
            newMessage.EventContain2.Text = "";

            // Cut message if too long
            if (message.Count<char>() > 38)
            {
                for (int i = 0; i < 38; i++)
                    newMessage.EventContain.Text += message[i];
                for (int i = 38; i < message.Count<char>(); i++)
                    newMessage.EventContain2.Text += message[i];
            }
            else
                newMessage.EventContain.Text = message;

            if (_eventList.Count == 10)
                this.Controls.Remove(_eventList[9]);
            _eventList.Push(newMessage);
            this.Controls.Add(_eventList[0]);
            _eventList[0].Show();

            for (int i = 0; i < _eventList.Count; i++)
            {
                _eventList[i].Location = new System.Drawing.Point(positionX + 3, positionY);
                positionY += 68;
            }
            this.ResumeLayout();
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
