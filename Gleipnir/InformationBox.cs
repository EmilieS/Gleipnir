using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game;

namespace GamePages
{
    public partial class InformationBox : UserControl
    {
        Meeting _meeting;
        GeneralPage _page;
        Family _family;
        public InformationBox(GeneralPage Parent, Family family)
        {
            InitializeComponent();
            _meeting = new Meeting(family);
            _page = Parent;
            _family = family;
        }

        private void GodMeeting_Click(object sender, EventArgs e)
        {
            _meeting.Convocate();
            _page.ActionMenu.ShowVillagerListInFamily(_family);
        }
    }
}
