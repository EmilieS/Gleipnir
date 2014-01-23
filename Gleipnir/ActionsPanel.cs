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
    public partial class ActionsPanel : UserControl
    {
        GeneralPage _page;
        JobsModel _job;
        Villager _villager;
        int _action;
        bool _isOpen;

        public ActionsPanel(GeneralPage p)
        {
            InitializeComponent();

            this.SuspendLayout();
            _page = p;

            // Disable elements
            LockElements();
            this.ResumeLayout();
        }

        public bool IsOpen { get { return _isOpen; } set { _isOpen = value; } }

        private void ListOfVillagers_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ListOfVillagers.SelectedValue != null)
            {
                _villager = (Villager)ListOfVillagers.SelectedValue;
                SetVillagerInfos(_villager);
            }
            else
            {
                HideVillagerInfos();
                _villager = null;
            }
        }
        private void ActionOnVillager_SelectedValueChanged(object sender, EventArgs e)
        {
            _action = ActionOnVillager.SelectedIndex;
        }
        private void ListOfJobs_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ListOfJobs.SelectedValue != null)
                _job = (JobsModel)ListOfJobs.SelectedValue;
            else
                _job = null;

        }

        public bool OpenPanel(Family f)
        {
            if (f == null)
                return false;
            else
            {
                this.BringToFront();
                this.Show();
                _isOpen = true;
                SetLists(f);
                UnlockElements();
                _page.InformationsBox.ActionsButton.Enabled = false;
                return true;
            }
        }
        private void SetLists(Family f)
        {
            // ListOfVillagers
            BindingList<Villager> villagersList = new BindingList<Villager>();
            foreach (Villager v in f.FamilyMembers)
                villagersList.Add(v);
            ListOfVillagers.ValueMember = null;
            ListOfVillagers.DisplayMember = "FirstName";
            ListOfVillagers.DataSource = villagersList;

            // ListOfJobs
            BindingList<JobsModel> jobsList = new BindingList<JobsModel>();
            foreach (JobsModel j in _page.TheGame.Villages[0].JobsList)
                if (j.Building != null)
                    jobsList.Add(j);
            ListOfJobs.ValueMember = null;
            ListOfJobs.DisplayMember = "Name";
            ListOfJobs.DataSource = jobsList;
        }
        private void SetVillagerInfos(Villager v)
        {
            this.SuspendLayout();
            // Set genderIcon
            GenderIcon.Visible = true;
            if (v.Gender == Genders.FEMALE)
                GenderIcon.BackgroundImage = GamePages.Properties.Resources.Gender_Female;
            else
                GenderIcon.BackgroundImage = GamePages.Properties.Resources.Gender_Male;

            // Set villager Name
            VillagerSelected.Visible = true;
            VillagerSelected.Text = v.FirstName + " " + v.Name;

            // Set villager Job
            VillagerJob.Visible = true;
            if (v.Job != null)
                VillagerJob.Text = v.Job.Name;
            else
                VillagerJob.Text = "Aucun métier";

            // Set sickIcon
            SickIcon.Visible = true;
            if (v.Health == Healths.SICK)
                SickIcon.BackgroundImage = GamePages.Properties.Resources.ButtonIcon_epidemic;
            else
                SickIcon.BackgroundImage = GamePages.Properties.Resources.Building_HealthPoints;

            // Set villager State
            VillagerState.Visible = true;
            VillagerState.Text = v.Health.ToString();

            // Set villager Happiness
            VillagerHappinessIcon.Visible = true;
            VillagerHappiness.Visible = true;
            VillagerHappiness.Text = v.Happiness.ToString();

            // Set villager Faith
            VillagerFaithIcon.Visible = true;
            VillagerFaith.Visible = true;
            VillagerFaith.Text = v.Faith.ToString();
            this.ResumeLayout();
        }
        private void HideVillagerInfos()
        {
            this.SuspendLayout();
            GenderIcon.Visible = false;
            VillagerSelected.Visible = false;
            VillagerJob.Visible = false;
            SickIcon.Visible = false;
            VillagerState.Visible = false;
            VillagerHappinessIcon.Visible = false;
            VillagerHappiness.Visible = false;
            VillagerFaithIcon.Visible = false;
            VillagerFaith.Visible = false;
            this.ResumeLayout();
        }
        private void LockElements()
        {
            ListOfJobs.Enabled = false;
            ListOfVillagers.Enabled = false;
            ActionOnVillager.Enabled = false;
            SetMission.Enabled = false;
            HideVillagerInfos();
        }
        private void UnlockElements()
        {
            ListOfJobs.Enabled = true;
            ListOfVillagers.Enabled = true;
            ActionOnVillager.Enabled = true;
            SetMission.Enabled = true;
        }

        private void SetMission_Click(object sender, EventArgs e)
        {
            if (_villager != null && _action > -1 && _job != null)
            {
                switch(_action)
                {
                    case 0: // New Job
                        {
                            if (_villager.Job != null)
                            {
                                var lastJob = _villager.Job.Name;
                                _villager.AddToJob(_job);
                                MessageBox.Show(_villager.FirstName + " n'est plus " + lastJob + ".\nIl est maintenant " + _job.Name + ".");
                            }
                            else
                            {
                                _villager.AddToJob(_job);
                                MessageBox.Show(_villager.FirstName + " est maintenant " + _job.Name + ".");
                            }
                            break;
                        }
                    default:
                        {
                            MessageBox.Show(@"Veuillez selectionner une action");
                            break;
                        }
                }
            }
        }
        private void ActionPanelQuit_Click(object sender, EventArgs e)
        {
            this.SendToBack();
            this.Hide();
            _isOpen = false;
            _page.InformationsBox.UnlockOpenActionMenuButton();
        }
    }
}
