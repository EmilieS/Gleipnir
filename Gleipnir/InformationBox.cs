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
            positionX = 125;
            positionY = 10;

            BackgroundImageLayout = ImageLayout.Stretch;
        }

        // Meeting Button Event
        private void GodMeeting_Click(object sender, EventArgs e)
        {
            if (_page.TheGame.Villages[0].MeetingStart(_family))
                GodMeeting.Enabled = false;
            else
                GodMeeting.Enabled = true;
        }
        private void StopMeeting_Click(object sender, EventArgs e)
        {
            if (_page.TheGame.Villages[0].EndMeeting())
            {
                StopMeeting.Enabled = false;
                ActionsButton.Enabled = false;
            }
            else
                StopMeeting.Enabled = true;
        }
        private void ActionsButton_Click(object sender, EventArgs e)
        {
            if (!_page.MeetingActionsPanel.IsOpen && _page.TheGame.Villages[0].Meeting != null)
            {
                if (_page.MeetingActionsPanel.OpenPanel(_page.TheGame.Villages[0].Meeting.ActualConvocated))
                {
                    _page.LockEverything();
                    ActionsButton.Enabled = false;
                }
            }
        }

        // Hide or Show elements in InfoBox
        internal void SetFamilyHouseInfo(Family family)
        {
            if (family != null)
            {
                this.SuspendLayout();
                _family = family;

                // Background
                this.BackgroundImage = GamePages.Properties.Resources.InformationBox_house_background;

                // BuildingImage
                buildingIcon.BackgroundImage = GamePages.Properties.Resources.Building_House;
                buildingIcon.Visible = true;

                #region InfoBox infos
                // Title
                Title.Location = new Point(positionX, positionY);
                Title.Text = "Famille";
                Title.Visible = true;

                // ObjectName
                objectName.Visible = true;
                ElementName.Text = family.Name;
                ElementName.Visible = true;

                // Gold
                goldIcon.Visible = true;
                Gold.Text = _page.TransformHighNumberToKnumbers(family.GoldStash);
                Gold.Visible = true;

                // Faith
                faithIcon.Visible = true;
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
                Faith.Visible = true;

                // Members
                membersIcon.Visible = true;
                NbMembers.Text = family.FamilyMembers.Count.ToString();
                NbMembers.Visible = true;

                // Happiness
                happinessIcon.Visible = true;
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
                Happiness.Visible = true;

                // Building Life
                buildingHealthIcon.Visible = true;
                buildingLife.Text = family.House.Hp.ToString();
                buildingLife.Visible = true;

                this.ResumeLayout();
                #endregion

                // Action Tab infos
                _page.ActionMenu.Visible = false;
                _page.ActionMenu.SuspendLayout();
                _page.ActionMenu.ShowVillagerListInFamily(family);
                _page.ActionMenu.ResumeLayout();
                _page.ActionMenu.Visible = true;

                // Meetings Details
                GodMeeting.Visible = true;
                if (_page.TheGame.Villages[0].Meeting != null)
                    GodMeeting.Enabled = false;
                else
                    GodMeeting.Enabled = true;
                StopMeeting.Visible = false;
                StopMeeting.Enabled = false;
                ActionsButton.Visible = false;
                ActionsButton.Enabled = false;
            }
            else
                SetError();
        }
        internal void SetEmptyHouseInfo(House house)
        {
            if (house != null)
            {
                this.SuspendLayout();

                // Background
                this.BackgroundImage = GamePages.Properties.Resources.InformationBox_others_background;

                // BuildingImage
                buildingIcon.BackgroundImage = GamePages.Properties.Resources.Building_House;
                buildingIcon.Visible = true;

                #region InfoBox infos
                // Title
                Title.Location = new Point(positionX - 20, positionY);
                Title.Text = "Maison Vide";
                Title.Visible = true;

                // Hidden infos
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

                // Building
                buildingHealthIcon.Visible = true;
                buildingLife.Text = house.Hp.ToString();
                buildingLife.Visible = true;

                this.ResumeLayout();
                #endregion

                // Action Tab infos
                _page.ActionMenu.Visible = false;
                _page.ActionMenu.SuspendLayout();
                _page.ActionMenu.DestroyVillagerList();
                _page.ActionMenu.ResumeLayout();
                _page.ActionMenu.Visible = true;

                // Meeting Info
                GodMeeting.Visible = false;
                GodMeeting.Enabled = false;
                StopMeeting.Visible = false;
                StopMeeting.Enabled = false;
                ActionsButton.Visible = false;
                ActionsButton.Enabled = false;
            }
            else
                SetError();
        }
        internal void SetJobInfo(JobsModel job, Image buildingImage)
        {
            if (job != null)
            {
                this.SuspendLayout();
                // Background
                this.BackgroundImage = GamePages.Properties.Resources.InformationBox_job_background;

                // BuildingImage
                buildingIcon.BackgroundImage = buildingImage;
                buildingIcon.Visible = true;

                #region InfoBox Infos
                // Title
                Title.Location = new Point(positionX, positionY);
                Title.Text = job.Building.Name;
                Title.Visible = true;

                // Object
                ElementName.Visible = true;
                ElementName.Text = job.Name;
                objectName.Visible = true;

                // Hidden Infos
                goldIcon.Visible = false;
                Gold.Visible = false;
                faithIcon.Visible = false;
                Faith.Visible = false;
                happinessIcon.Visible = false;
                Happiness.Visible = false;

                // Members
                membersIcon.Visible = true;
                NbMembers.Text = job.Workers.Count.ToString();
                NbMembers.Visible = true;

                // Building
                buildingHealthIcon.Visible = true;
                buildingLife.Visible = true;
                buildingLife.Text = job.Building.Hp.ToString();

                this.ResumeLayout();
                #endregion

                // Action Tab infos
                _page.ActionMenu.Visible = false;
                _page.ActionMenu.SuspendLayout();
                _page.ActionMenu.ShowWorkersInJob(job);
                _page.ActionMenu.ResumeLayout();
                _page.ActionMenu.Visible = true;

                // Meetings Details
                GodMeeting.Visible = false;
                GodMeeting.Enabled = false;
                StopMeeting.Visible = false;
                StopMeeting.Enabled = false;
                ActionsButton.Visible = false;
                ActionsButton.Enabled = false;
            }
            else
                SetError();
        }
        internal void SetTableInfo(TablePlace table)
        {
            if (table != null)
            {
                this.SuspendLayout();

                // Background
                this.BackgroundImage = GamePages.Properties.Resources.InformationBox_table_background;

                // BuildingImage
                buildingIcon.BackgroundImage = GamePages.Properties.Resources.Building_Table;
                buildingIcon.Visible = true;

                #region InfoBox Infos
                // Title
                Title.Location = new Point(positionX - 20, positionY);
                Title.Text = table.Name;
                Title.Visible = true;

                // Hidden Infos
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

                // Building
                buildingHealthIcon.Visible = true;
                buildingLife.Text = table.Hp.ToString();
                buildingLife.Visible = true;

                this.ResumeLayout();
                #endregion

                // Action Tab infos
                if (_page.TheGame.Villages[0].Meeting != null && _page.TheGame.Villages[0].Meeting.ActualConvocated != null)
                    _page.ActionMenu.ShowConvocatedVillagers(_page.TheGame.Villages[0].Meeting.ActualConvocated);
                else
                    _page.ActionMenu.DestroyVillagerList();

                // Meeting Info
                GodMeeting.Visible = false;
                GodMeeting.Enabled = false;
                StopMeeting.Visible = true;
                ActionsButton.Visible = true;
                if (_page.TheGame.Villages[0].Meeting != null && _page.TheGame.Villages[0].Meeting.ActualConvocated != null)
                {
                    StopMeeting.Enabled = true;
                    ActionsButton.Enabled = true;
                }
                else
                {
                    StopMeeting.Enabled = false;
                    ActionsButton.Enabled = false;
                }
            }
            else
                SetError();
        }
        internal void SetOtherBuildingsInfo(BuildingsModel building, Image buildingImage)
        {
            if (building != null)
            {
                this.SuspendLayout();

                // Background
                this.BackgroundImage = GamePages.Properties.Resources.InformationBox_others_background;

                // BuildingImage
                buildingIcon.BackgroundImage = buildingImage;
                buildingIcon.Visible = true;

                #region InfoBox Infos
                // Title
                if (building.Name.Count<char>() > 8)
                    Title.Location = new Point(positionX - 15, positionY);
                else
                    Title.Location = new Point(positionX, positionY);
                Title.Text = building.Name;
                Title.Visible = true;

                // Hidden Infos
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

                // Building
                buildingHealthIcon.Visible = true;
                buildingLife.Visible = true;
                buildingLife.Text = building.Hp.ToString();

                this.ResumeLayout();
                #endregion

                // Action Tab infos
                _page.ActionMenu.Visible = false;
                _page.ActionMenu.SuspendLayout();
                _page.ActionMenu.DestroyVillagerList();
                _page.ActionMenu.ResumeLayout();
                _page.ActionMenu.Visible = true;

                // Meetings Details
                GodMeeting.Visible = false;
                GodMeeting.Enabled = false;
                StopMeeting.Visible = false;
                StopMeeting.Enabled = false;
                ActionsButton.Visible = false;
                ActionsButton.Enabled = false;
            }
            else
                SetError();
        }
        internal void SetDestroyedBuilding(BuildingsModel building)
        {
            if (building != null)
            {
                this.SuspendLayout();

                // Background
                this.BackgroundImage = GamePages.Properties.Resources.InformationBox_destroyed_background;

                // BuildingImage
                buildingIcon.BackgroundImage = GamePages.Properties.Resources.Building_Destroyed;
                buildingIcon.Visible = true;

                #region InfoBox Infos
                // Title
                Title.Location = new Point(positionX - 35, positionY);
                Title.Text = "Bâtiment détruit";
                Title.Visible = true;

                // Object
                objectName.Visible = true;
                ElementName.Text = building.Name;
                ElementName.Visible = true;

                // Hidden Infos
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

                this.ResumeLayout();
                #endregion

                // Action Tab infos
                _page.ActionMenu.Visible = false;
                _page.ActionMenu.SuspendLayout();
                _page.ActionMenu.DestroyVillagerList();
                _page.ActionMenu.ResumeLayout();
                _page.ActionMenu.Visible = true;

                //Meeting button
                GodMeeting.Visible = false;
                GodMeeting.Enabled = false;
                StopMeeting.Visible = false;
                StopMeeting.Enabled = false;
                ActionsButton.Visible = false;
                ActionsButton.Enabled = false;
            }
            else
                SetError();
        }
        internal void SetNothingSelected()
        {
            this.SuspendLayout();

            // Background
            this.BackgroundImage = GamePages.Properties.Resources.InformationBox_background;

            // BuildingImage
            buildingIcon.Visible = false;

            #region InfoBox Infos
            // Hidden Infos
            Title.Visible = false;
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
            buildingHealthIcon.Visible = false;
            buildingLife.Visible = false;

            this.ResumeLayout();
            #endregion

            // Action Tab infos
            _page.ActionMenu.Visible = false;
            _page.ActionMenu.SuspendLayout();
            _page.ActionMenu.DestroyVillagerList();
            _page.ActionMenu.ResumeLayout();
            _page.ActionMenu.Visible = true;

            // Meeting Info
            GodMeeting.Visible = false;
            GodMeeting.Enabled = false;
            StopMeeting.Visible = false;
            StopMeeting.Enabled = false;
            ActionsButton.Visible = false;
            ActionsButton.Enabled = false;
        }
        internal void SetError()
        {
            this.SuspendLayout();

            // Background
            BackgroundImage = GamePages.Properties.Resources.InformationBox_destroyed_background;

            // BuildingImage
            buildingIcon.BackgroundImage = GamePages.Properties.Resources.Error;
            buildingIcon.Visible = true;

            #region InfoBox Infos
            // Title
            Title.Location = new Point(positionX, positionY);
            Title.Text = @"ERREUR";
            Title.Visible = true;

            // Object
            ElementName.Text = @"Failed open building object";
            ElementName.Visible = true;

            // Hidden Infos
            objectName.Visible = false;
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

            this.ResumeLayout();
            #endregion

            // Action Tab infos
            _page.ActionMenu.Visible = false;
            _page.ActionMenu.SuspendLayout();
            _page.ActionMenu.DestroyVillagerList();
            _page.ActionMenu.ResumeLayout();
            _page.ActionMenu.Visible = true;

            //Meeting button
            GodMeeting.Visible = false;
            GodMeeting.Enabled = false;
            StopMeeting.Visible = false;
            StopMeeting.Enabled = false;
            ActionsButton.Visible = false;
            ActionsButton.Enabled = false;
        }

        internal void UnlockOpenActionMenuButton()
        {
            if (!_page.MeetingActionsPanel.IsOpen)
            {
                ActionsButton.Enabled = true;
                _page.UnLockEverything();
            }
        }
    }
}
