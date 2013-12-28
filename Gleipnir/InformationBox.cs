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
using Game.Buildings;

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

        public void SetFamilyHouseInfo(Family family)
        {
            // InfoBox Texts
            Title.Text = "Famille";
            NameView.Visible = true;
            ElementName.Visible = true;
            ElementName.Text = family.Name;
            GoldView.Visible = true;
            Gold.Visible = true;
            Gold.Text = family.GoldStash.ToString();
            FaithView.Visible = true;
            Faith.Visible = true;
            Faith.Text = family.FaithAverageValue.ToString();
            MemberView.Visible = true;
            NbMembers.Visible = true;
            NbMembers.Text = family.FamilyMembers.Count.ToString();
            buildingLife.Text = family.House.Hp.ToString();

            // Action Tab infos
            _page.ActionMenu.ShowVillagerListInFamily(family);

            // Meetings Details
            _meeting = new Meeting(family);
            _family = family;
            GodMeeting.Visible = true;
        }

        internal void SetEmptyHouseInfo(House house)
        {
            // InfoBox Texts
            Title.Text = "Maison Vide";
            NameView.Visible = false;
            ElementName.Visible = false;
            GoldView.Visible = false;
            Gold.Visible = false;
            FaithView.Visible = false;
            Faith.Visible = false;
            MemberView.Visible = false;
            NbMembers.Visible = false;
            buildingLife.Text = house.Hp.ToString();

            // Meeting Info
            GodMeeting.Visible = false;
        }
    }
}
