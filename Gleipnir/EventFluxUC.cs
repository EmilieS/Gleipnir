using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamePages
{
    public partial class EventFluxUC : UserControl
    {
        GameEventUC[] eventTab = new GameEventUC[10];
        int i;

        public EventFluxUC()
        {
            InitializeComponent();
            i = 0;
        }
        public void CreateNewEventAndShow(string message, string title)
        {
            GameEventUC GameEvent = new GameEventUC();
            if (eventTab[9] == null && i < 9)
            {
                eventTab[i] = GameEvent;
                this.Controls.Add(eventTab[i]);
                eventTab[i].Show();
                eventTab[i].EventTitle.Text = title;
                eventTab[i].EventContain.Text = message;
                i++;
            }
            else
            {
                ReguleTab();
                eventTab[i] = GameEvent;
                this.Controls.Add(eventTab[i]);
                eventTab[i].Show();
            }
        }
        internal void ReguleTab()
        {
            int j;
            eventTab[0].Hide();
            this.Controls.Remove(eventTab[0]);
            eventTab[0] = null;
            for (j = 0; j < 10; j++)
            {
                eventTab[j] = eventTab[j + 1];
            }
        }
    }
}
