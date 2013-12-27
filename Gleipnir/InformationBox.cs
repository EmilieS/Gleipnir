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

        public InformationBox(GeneralPage Parent)
        {
            InitializeComponent();
            _page = Parent;
            GodMeeting.Visible = false;
        }

        private void GodMeeting_Click(object sender, EventArgs e)
        {
            _meeting.Convocate();
            _page.ActionMenu.ShowVillagerListInFamily(_family);
        }

        public void SetInfoBoxForFamily(Family family)
        {
            // InfoBox Texts
            Title.Text = "Famille"; 
            ElementName.Text = family.Name;
            Gold.Text = family.GoldStash.ToString();
            Faith.Text = family.FaithAverageValue.ToString();
            NbMembers.Text = family.FamilyMembers.Count.ToString();

            // Action Tab infos
            _page.ActionMenu.ShowVillagerListInFamily(family);

            // Meetings Details
            _meeting = new Meeting(family);
            _family = family;
            GodMeeting.Visible = true;
        }
    }
}
