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
        int positionX;
        int positionY;
        public EventFluxUC()
        {
            InitializeComponent();
            i = 0;
            positionX = 0;
            positionY = 0;
        }
        public void CreateNewEventAndShow(string message, string title)
        {
            if (eventTab[9] == null && i < 9)
            {
                eventTab[i] = new GameEventUC();
                this.Controls.Add(eventTab[i]);
                eventTab[i].Show();
                eventTab[i].EventTitle.Text = message;
                eventTab[i].EventContain.Text = title;
                eventTab[i].Location = new System.Drawing.Point(positionX, positionY);
                positionY += 100;
                i++;

            }
            else
            {
                ReguleTab();
                eventTab[9] = new GameEventUC();
                this.Controls.Add(eventTab[9]);
                eventTab[9].Show();
                eventTab[9].EventTitle.Text = title;
                eventTab[9].EventContain.Text = message;
            }
        }
        internal void ReguleTab()
        {
            int j;
            eventTab[0].Hide();
            this.Controls.Remove(eventTab[0]);
            eventTab[0] = null;
            for (j = 0; j < 9; j++)
            {
                eventTab[j] = eventTab[j + 1];
                positionY += 100;
            }
            eventTab[9] = null;
        }
    }
}
