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

        public InformationBox(GeneralPage page)
        {
            InitializeComponent();
            _page = page;
            GodMeeting.Visible = false;
        }

        // Meeting Button Event
        private void GodMeeting_Click(object sender, EventArgs e)
        {
            _meeting.Convocate();
            _page.ActionMenu.ShowVillagerListInFamily(_family);
        }

        // Hide or Show elements in InfoBox
        internal void SetFamilyHouseInfo(Family family)
        {
            // InfoBox Texts
            Title.Visible = true;
            Title.Text = "Famille";
            NameView.Visible = true;
            NameView.Text = "Nom :";
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
            buildingHP.Visible = true;
            buildingLife.Visible = true;
            buildingLife.Text = family.House.Hp.ToString();

            // Action Tab infos
            _page.ActionMenu.ShowVillagerListInFamily(family);

            // Meetings Details
            _meeting = new Meeting(family);
            _family = family;
            GodMeeting.Visible = true;
            GodMeeting.Enabled = true;
        }
        internal void SetEmptyHouseInfo(House house)
        {
            // InfoBox Texts
            Title.Visible = true;
            Title.Text = "Maison Vide";
            NameView.Visible = false;
            ElementName.Visible = false;
            GoldView.Visible = false;
            Gold.Visible = false;
            FaithView.Visible = false;
            Faith.Visible = false;
            MemberView.Visible = false;
            NbMembers.Visible = false;
            buildingHP.Visible = true;
            buildingLife.Visible = true;
            buildingLife.Text = house.Hp.ToString();

            // Action Tab infos
            _page.ActionMenu.DestroyVillagerList();

            // Meeting Info
            GodMeeting.Visible = false;
            GodMeeting.Enabled = false;
        }
        internal void SetJobInfo(JobsModel job)
        {
            if (job != null)
            {
                // InfoBox Texts
                Title.Visible = true;
                Title.Text = job.Building.Name;
                NameView.Visible = true;
                NameView.Text = "Métier :";
                ElementName.Visible = true;
                ElementName.Text = job.Name;
                GoldView.Visible = false;
                Gold.Visible = false;
                FaithView.Visible = false;
                Faith.Visible = false;
                MemberView.Visible = true;
                NbMembers.Visible = true;
                NbMembers.Text = job.Workers.Count.ToString();
                buildingHP.Visible = true;
                buildingLife.Visible = true;
                buildingLife.Text = job.Building.Hp.ToString();

                // Action Tab infos
                _page.ActionMenu.ShowWorkersInJob(job);

                // Meetings Details
                GodMeeting.Visible = false;
                GodMeeting.Enabled = false;
            }
            else
            {
                SetNothingSelected();
                Title.Visible = true;
                Title.Text = "Open Job Failed";
            }
        }
        internal void SetTableInfo(TablePlace table)
        {
            // InfoBox Texts
            Title.Visible = true;
            Title.Text = table.Name;
            NameView.Visible = false;
            ElementName.Visible = false;
            GoldView.Visible = false;
            Gold.Visible = false;
            FaithView.Visible = false;
            Faith.Visible = false;
            MemberView.Visible = false;
            NbMembers.Visible = false;
            buildingHP.Visible = true;
            buildingLife.Visible = true;
            buildingLife.Text = table.Hp.ToString();

            // Action Tab infos
            // TODO: Change list for families convocated
            _page.ActionMenu.DestroyVillagerList();

            // Meeting Info
            GodMeeting.Visible = false;
            GodMeeting.Enabled = false;
        }
        internal void SetDestroyedBuilding(BuildingsModel building)
        {
            // InfoBox Texts
            Title.Visible = true;
            Title.Text = "Bâtiment détruit";
            NameView.Visible = false;
            ElementName.Visible = true;
            ElementName.Text = building.Name;
            GoldView.Visible = false;
            Gold.Visible = false;
            FaithView.Visible = false;
            Faith.Visible = false;
            MemberView.Visible = false;
            NbMembers.Visible = false;
            buildingHP.Visible = false;
            buildingLife.Visible = false;

            // Action Tab infos
            _page.ActionMenu.DestroyVillagerList();

            //Meeting button
            GodMeeting.Visible = false;
            GodMeeting.Enabled = false;
        }
        internal void SetNothingSelected()
        {
            // InfoBox Texts
            Title.Visible = false;
            NameView.Visible = false;
            ElementName.Visible = false;
            GoldView.Visible = false;
            Gold.Visible = false;
            FaithView.Visible = false;
            Faith.Visible = false;
            MemberView.Visible = false;
            NbMembers.Visible = false;
            buildingHP.Visible = false;
            buildingLife.Visible = false;

            // Action Tab infos
            _page.ActionMenu.DestroyVillagerList();

            // Meeting Info
            GodMeeting.Visible = false;
            GodMeeting.Enabled = false;
        }
    }
}
