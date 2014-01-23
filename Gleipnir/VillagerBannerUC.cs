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
    public partial class VillagerBannerUC : UserControl
    {
        public VillagerBannerUC(Villager v)
        {
            InitializeComponent();

            this.SuspendLayout();
            // Gender Pic
            if (v.Gender == Genders.FEMALE)
                VillagerFace.BackgroundImage = GamePages.Properties.Resources.Gender_Female;
            else
                VillagerFace.BackgroundImage = GamePages.Properties.Resources.Gender_Male;

            // Sick Pic
            Sick_status_pic.BackgroundImage = GamePages.Properties.Resources.ButtonIcon_epidemic;
            if ((v.Health & Healths.SICK) != 0)
                Sick_status_pic.Visible = true;
            else
                Sick_status_pic.Visible = false;

            // Name
            VillagerName.Text = v.FirstName + " " + v.Name;

            // Job
            if (v.Job != null)
                Job_label.Text = "Métier : " + v.Job.Name;
            else
                Job_label.Text = "Aucun métier";
            this.ResumeLayout();
        }
    }
}
