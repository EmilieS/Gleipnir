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
        GeneralPage _page;
        Family _family;
        int positionX;
        int positionY;

        public InformationBox(GeneralPage page)
        {
            InitializeComponent();
            _page = page;
            GodMeeting.Visible = false;
            positionX = 125;
            positionY = 10;
        }

        // Meeting Button Event
        private void GodMeeting_Click(object sender, EventArgs e)
        {
            if (_page.TheGame.Villages[0].MeetingStart(_family))
            {
                GodMeeting.Visible = false;
                GodMeeting.Enabled = false;
            }
            //_page.ActionMenu.ShowVillagerListInFamily(_family);
        }

        // Hide or Show elements in InfoBox
        internal void SetFamilyHouseInfo(Family family)
        {
            if (family != null)
            {
                // Background
                this.BackgroundImage = GamePages.Properties.Resources.InformationBox_house_background;

                // BuildingImage
                buildingIcon.Visible = true;
                buildingIcon.BackgroundImage = GamePages.Properties.Resources.Building_House;

                // InfoBox Texts
                Title.Visible = true;
                Title.Location = new Point(positionX, positionY);
                Title.Text = "Famille";
                objectName.Visible = true;
                ElementName.Visible = true;
                ElementName.Text = family.Name;
                goldIcon.Visible = true;
                Gold.Visible = true;
                Gold.Text = _page.TransformHighNumberToKnumbers(family.GoldStash);
                faithIcon.Visible = true;
                Faith.Visible = true;
                if (family.FaithAverageValue.ToString().Count<char>() > 5)
                {
                    string txt = family.FaithAverageValue.ToString();
                    string tmp = "";
                    for (int i = 0; i < 5; i++)
                        tmp += txt[i];
                    Faith.Text = tmp;
                }
                else
                    Faith.Text = family.FaithAverageValue.ToString();
                membersIcon.Visible = true;
                NbMembers.Visible = true;
                NbMembers.Text = family.FamilyMembers.Count.ToString();
                happinessIcon.Visible = true;
                Happiness.Visible = true;
                if (family.HappinessAverageValue.ToString().Count<char>() > 5)
                {
                    string txt = family.HappinessAverageValue.ToString();
                    string tmp = "";
                    for (int i = 0; i < 5; i++)
                        tmp += txt[i];
                    Happiness.Text = tmp;
                }
                else
                    Happiness.Text = family.HappinessAverageValue.ToString();
                buildingHealthIcon.Visible = true;
                buildingLife.Visible = true;
                buildingLife.Text = family.House.Hp.ToString();

                // Action Tab infos
                _page.ActionMenu.ShowVillagerListInFamily(family);

                // Meetings Details
                _family = family;
                if (_page.TheGame.Villages[0].Meeting != null)
                {
                    GodMeeting.Visible = false;
                    GodMeeting.Enabled = false;
                }
                else
                {
                    GodMeeting.Visible = true;
                    GodMeeting.Enabled = true;
                }
            }
            else
            {
                SetNothingSelected();
                Title.Visible = true;
                Title.Text = "Failed Open Family";
            }
        }
        internal void SetEmptyHouseInfo(House house)
        {
            // Background
            this.BackgroundImage = GamePages.Properties.Resources.InformationBox_others_background;

            // BuildingImage
            buildingIcon.Visible = true;
            buildingIcon.BackgroundImage = GamePages.Properties.Resources.Building_House;

            // InfoBox Texts
            objectName.Visible = false;
            Title.Visible = true;
            Title.Location = new Point(positionX - 20, positionY);
            Title.Text = "Maison Vide";
            ElementName.Visible = false;
            goldIcon.Visible = false;
            Gold.Visible = false;
            faithIcon.Visible = false;
            Faith.Visible = false;
            happinessIcon.Visible = false;
            Happiness.Visible = false;
            membersIcon.Visible = false;
            NbMembers.Visible = false;
            buildingHealthIcon.Visible = true;
            buildingLife.Visible = true;
            buildingLife.Text = house.Hp.ToString();

            // Action Tab infos
            _page.ActionMenu.DestroyVillagerList();

            // Meeting Info
            GodMeeting.Visible = false;
            GodMeeting.Enabled = false;
        }
        internal void SetJobInfo(JobsModel job, Image buildingImage)
        {
            if (job != null)
            {
                // Background
                this.BackgroundImage = GamePages.Properties.Resources.InformationBox_job_background;

                // BuildingImage
                buildingIcon.Visible = true;
                buildingIcon.BackgroundImage = buildingImage;

                // InfoBox Texts
                objectName.Visible = true;
                Title.Visible = true;
                Title.Location = new Point(positionX, positionY);
                Title.Text = job.Building.Name;
                ElementName.Visible = true;
                ElementName.Text = job.Name;
                goldIcon.Visible = false;
                Gold.Visible = false;
                faithIcon.Visible = false;
                Faith.Visible = false;
                happinessIcon.Visible = false;
                Happiness.Visible = false;
                membersIcon.Visible = true;
                NbMembers.Visible = true;
                NbMembers.Text = job.Workers.Count.ToString();
                buildingHealthIcon.Visible = true;
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
            // Background
            this.BackgroundImage = GamePages.Properties.Resources.InformationBox_table_background;

            // BuildingImage
            buildingIcon.Visible = true;
            buildingIcon.BackgroundImage = GamePages.Properties.Resources.Building_Table;

            // InfoBox Texts
            objectName.Visible = false;
            Title.Visible = true;
            Title.Location = new Point(positionX - 20, positionY);
            Title.Text = table.Name;
            ElementName.Visible = false;
            goldIcon.Visible = false;
            Gold.Visible = false;
            faithIcon.Visible = false;
            Faith.Visible = false;
            happinessIcon.Visible = false;
            Happiness.Visible = false;
            membersIcon.Visible = false;
            NbMembers.Visible = false;
            buildingHealthIcon.Visible = true;
            buildingLife.Visible = true;
            buildingLife.Text = table.Hp.ToString();

            // Action Tab infos
            // TODO: Change list for families convocated//table nom famille convoquée
            _page.ActionMenu.DestroyVillagerList();

            // Meeting Info
            GodMeeting.Visible = false;
            GodMeeting.Enabled = false;
        }
        internal void SetOtherBuildingsInfo(BuildingsModel building, Image buildingImage)
        {
            // Background
            this.BackgroundImage = GamePages.Properties.Resources.InformationBox_others_background;

            // BuildingImage
            buildingIcon.Visible = true;
            buildingIcon.BackgroundImage = buildingImage;

            // InfoBox Texts
            Title.Visible = true;
            Title.Location = new Point(positionX, positionY);
            Title.Text = building.Name;
            objectName.Visible = false;
            ElementName.Visible = false;
            goldIcon.Visible = false;
            Gold.Visible = false;
            faithIcon.Visible = false;
            Faith.Visible = false;
            happinessIcon.Visible = false;
            Happiness.Visible = false;
            membersIcon.Visible = false;
            NbMembers.Visible = false;
            buildingHealthIcon.Visible = true;
            buildingLife.Visible = true;
            buildingLife.Text = building.Hp.ToString();

            // Action Tab infos
            _page.ActionMenu.DestroyVillagerList();

            // Meetings Details
            GodMeeting.Visible = false;
            GodMeeting.Enabled = false;
        }
        internal void SetDestroyedBuilding(BuildingsModel building)
        {
            // Background
            this.BackgroundImage = GamePages.Properties.Resources.InformationBox_destroyed_background;

            // BuildingImage
            buildingIcon.Visible = true;
            buildingIcon.BackgroundImage = GamePages.Properties.Resources.Building_Destroyed;

            // InfoBox Texts
            Title.Visible = true;
            Title.Location = new Point(positionX - 35, positionY);
            Title.Text = "Bâtiment détruit";
            objectName.Visible = true;
            ElementName.Visible = true;
            ElementName.Text = building.Name;
            goldIcon.Visible = false;
            Gold.Visible = false;
            faithIcon.Visible = false;
            Faith.Visible = false;
            happinessIcon.Visible = false;
            Happiness.Visible = false;
            membersIcon.Visible = false;
            NbMembers.Visible = false;
            buildingHealthIcon.Visible = false;
            buildingLife.Visible = false;

            // Action Tab infos
            _page.ActionMenu.DestroyVillagerList();

            //Meeting button
            GodMeeting.Visible = false;
            GodMeeting.Enabled = false;
        }
        internal void SetNothingSelected()
        {
            // Background
            this.BackgroundImage = GamePages.Properties.Resources.InformationBox_background;

            // BuildingImage
            buildingIcon.Visible = false;

            // InfoBox Texts
            objectName.Visible = false;
            Title.Visible = false;
            ElementName.Visible = false;
            goldIcon.Visible = false;
            Gold.Visible = false;
            faithIcon.Visible = false;
            Faith.Visible = false;
            happinessIcon.Visible = false;
            Happiness.Visible = false;
            membersIcon.Visible = false;
            NbMembers.Visible = false;
            buildingHealthIcon.Visible = false;
            buildingLife.Visible = false;

            // Action Tab infos
            _page.ActionMenu.DestroyVillagerList();

            // Meeting Info
            GodMeeting.Visible = false;
            GodMeeting.Enabled = false;
        }
    }
}
