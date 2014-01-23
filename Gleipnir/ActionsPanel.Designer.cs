namespace GamePages
{
    partial class ActionsPanel
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.VillagerSelected = new System.Windows.Forms.Label();
            this.ListOfVillagers = new System.Windows.Forms.ComboBox();
            this.ActionsPanelTitle = new System.Windows.Forms.Label();
            this.ActionOnVillager = new System.Windows.Forms.ComboBox();
            this.VillagerJob = new System.Windows.Forms.Label();
            this.GenderIcon = new System.Windows.Forms.PictureBox();
            this.Actions = new System.Windows.Forms.Label();
            this.VillagerInformations = new System.Windows.Forms.Label();
            this.SelectedVillager = new System.Windows.Forms.Label();
            this.SickIcon = new System.Windows.Forms.PictureBox();
            this.VillagerState = new System.Windows.Forms.Label();
            this.VillagerHappinessIcon = new System.Windows.Forms.PictureBox();
            this.VillagerFaithIcon = new System.Windows.Forms.PictureBox();
            this.SetMission = new System.Windows.Forms.Button();
            this.VillagerHappiness = new System.Windows.Forms.Label();
            this.VillagerFaith = new System.Windows.Forms.Label();
            this.ListOfJobs = new System.Windows.Forms.ComboBox();
            this.ActionPanelQuit = new System.Windows.Forms.Button();
            this.SelectedJob = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GenderIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SickIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VillagerHappinessIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VillagerFaithIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // VillagerSelected
            // 
            this.VillagerSelected.AutoSize = true;
            this.VillagerSelected.BackColor = System.Drawing.Color.Transparent;
            this.VillagerSelected.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VillagerSelected.Location = new System.Drawing.Point(288, 72);
            this.VillagerSelected.Name = "VillagerSelected";
            this.VillagerSelected.Size = new System.Drawing.Size(99, 15);
            this.VillagerSelected.TabIndex = 0;
            this.VillagerSelected.Text = "villagerSelected";
            // 
            // ListOfVillagers
            // 
            this.ListOfVillagers.BackColor = System.Drawing.Color.Peru;
            this.ListOfVillagers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ListOfVillagers.FormattingEnabled = true;
            this.ListOfVillagers.Location = new System.Drawing.Point(18, 116);
            this.ListOfVillagers.Name = "ListOfVillagers";
            this.ListOfVillagers.Size = new System.Drawing.Size(110, 21);
            this.ListOfVillagers.TabIndex = 1;
            this.ListOfVillagers.SelectedValueChanged += new System.EventHandler(this.ListOfVillagers_SelectedValueChanged);
            // 
            // ActionsPanelTitle
            // 
            this.ActionsPanelTitle.AutoSize = true;
            this.ActionsPanelTitle.BackColor = System.Drawing.Color.Transparent;
            this.ActionsPanelTitle.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActionsPanelTitle.ForeColor = System.Drawing.Color.Maroon;
            this.ActionsPanelTitle.Location = new System.Drawing.Point(61, 9);
            this.ActionsPanelTitle.Name = "ActionsPanelTitle";
            this.ActionsPanelTitle.Size = new System.Drawing.Size(280, 21);
            this.ActionsPanelTitle.TabIndex = 2;
            this.ActionsPanelTitle.Text = "Panneau d\'Action sur un Villageois";
            // 
            // ActionOnVillager
            // 
            this.ActionOnVillager.BackColor = System.Drawing.Color.Peru;
            this.ActionOnVillager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ActionOnVillager.FormattingEnabled = true;
            this.ActionOnVillager.Items.AddRange(new object[] {
            "Nouveau Métier"});
            this.ActionOnVillager.Location = new System.Drawing.Point(49, 64);
            this.ActionOnVillager.Name = "ActionOnVillager";
            this.ActionOnVillager.Size = new System.Drawing.Size(133, 21);
            this.ActionOnVillager.TabIndex = 3;
            this.ActionOnVillager.SelectedValueChanged += new System.EventHandler(this.ActionOnVillager_SelectedValueChanged);
            // 
            // VillagerJob
            // 
            this.VillagerJob.AutoSize = true;
            this.VillagerJob.BackColor = System.Drawing.Color.Transparent;
            this.VillagerJob.Location = new System.Drawing.Point(288, 98);
            this.VillagerJob.Name = "VillagerJob";
            this.VillagerJob.Size = new System.Drawing.Size(62, 13);
            this.VillagerJob.TabIndex = 4;
            this.VillagerJob.Text = "villagerJob";
            // 
            // GenderIcon
            // 
            this.GenderIcon.BackColor = System.Drawing.Color.Transparent;
            this.GenderIcon.BackgroundImage = global::GamePages.Properties.Resources.Gender_Male;
            this.GenderIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GenderIcon.Location = new System.Drawing.Point(242, 71);
            this.GenderIcon.Name = "GenderIcon";
            this.GenderIcon.Size = new System.Drawing.Size(40, 40);
            this.GenderIcon.TabIndex = 5;
            this.GenderIcon.TabStop = false;
            // 
            // Actions
            // 
            this.Actions.AutoSize = true;
            this.Actions.BackColor = System.Drawing.Color.Transparent;
            this.Actions.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Actions.ForeColor = System.Drawing.Color.Navy;
            this.Actions.Location = new System.Drawing.Point(53, 42);
            this.Actions.Name = "Actions";
            this.Actions.Size = new System.Drawing.Size(129, 19);
            this.Actions.TabIndex = 6;
            this.Actions.Text = "Mission à Attribuer";
            // 
            // VillagerInformations
            // 
            this.VillagerInformations.AutoSize = true;
            this.VillagerInformations.BackColor = System.Drawing.Color.Transparent;
            this.VillagerInformations.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VillagerInformations.ForeColor = System.Drawing.Color.Navy;
            this.VillagerInformations.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.VillagerInformations.Location = new System.Drawing.Point(265, 43);
            this.VillagerInformations.Name = "VillagerInformations";
            this.VillagerInformations.Size = new System.Drawing.Size(87, 19);
            this.VillagerInformations.TabIndex = 7;
            this.VillagerInformations.Text = "Informations";
            // 
            // SelectedVillager
            // 
            this.SelectedVillager.AutoSize = true;
            this.SelectedVillager.BackColor = System.Drawing.Color.Transparent;
            this.SelectedVillager.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedVillager.ForeColor = System.Drawing.Color.Navy;
            this.SelectedVillager.Location = new System.Drawing.Point(38, 95);
            this.SelectedVillager.Name = "SelectedVillager";
            this.SelectedVillager.Size = new System.Drawing.Size(67, 19);
            this.SelectedVillager.TabIndex = 8;
            this.SelectedVillager.Text = "Villageois";
            // 
            // SickIcon
            // 
            this.SickIcon.BackColor = System.Drawing.Color.Transparent;
            this.SickIcon.BackgroundImage = global::GamePages.Properties.Resources.ButtonIcon_epidemic;
            this.SickIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SickIcon.Location = new System.Drawing.Point(253, 115);
            this.SickIcon.Name = "SickIcon";
            this.SickIcon.Size = new System.Drawing.Size(20, 20);
            this.SickIcon.TabIndex = 9;
            this.SickIcon.TabStop = false;
            // 
            // VillagerState
            // 
            this.VillagerState.AutoSize = true;
            this.VillagerState.BackColor = System.Drawing.Color.Transparent;
            this.VillagerState.Location = new System.Drawing.Point(288, 118);
            this.VillagerState.Name = "VillagerState";
            this.VillagerState.Size = new System.Drawing.Size(70, 13);
            this.VillagerState.TabIndex = 10;
            this.VillagerState.Text = "villagerState";
            // 
            // VillagerHappinessIcon
            // 
            this.VillagerHappinessIcon.BackColor = System.Drawing.Color.Transparent;
            this.VillagerHappinessIcon.BackgroundImage = global::GamePages.Properties.Resources.Stats_Happiness;
            this.VillagerHappinessIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VillagerHappinessIcon.Location = new System.Drawing.Point(253, 139);
            this.VillagerHappinessIcon.Name = "VillagerHappinessIcon";
            this.VillagerHappinessIcon.Size = new System.Drawing.Size(20, 20);
            this.VillagerHappinessIcon.TabIndex = 11;
            this.VillagerHappinessIcon.TabStop = false;
            // 
            // VillagerFaithIcon
            // 
            this.VillagerFaithIcon.BackColor = System.Drawing.Color.Transparent;
            this.VillagerFaithIcon.BackgroundImage = global::GamePages.Properties.Resources.Stats_Faith;
            this.VillagerFaithIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VillagerFaithIcon.Location = new System.Drawing.Point(253, 163);
            this.VillagerFaithIcon.Name = "VillagerFaithIcon";
            this.VillagerFaithIcon.Size = new System.Drawing.Size(20, 20);
            this.VillagerFaithIcon.TabIndex = 12;
            this.VillagerFaithIcon.TabStop = false;
            // 
            // SetMission
            // 
            this.SetMission.BackColor = System.Drawing.Color.Transparent;
            this.SetMission.BackgroundImage = global::GamePages.Properties.Resources.button_homepage;
            this.SetMission.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SetMission.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetMission.Location = new System.Drawing.Point(37, 145);
            this.SetMission.Name = "SetMission";
            this.SetMission.Size = new System.Drawing.Size(166, 37);
            this.SetMission.TabIndex = 13;
            this.SetMission.Text = "Attribuer la mission";
            this.SetMission.UseVisualStyleBackColor = false;
            this.SetMission.Click += new System.EventHandler(this.SetMission_Click);
            // 
            // VillagerHappiness
            // 
            this.VillagerHappiness.AutoSize = true;
            this.VillagerHappiness.BackColor = System.Drawing.Color.Transparent;
            this.VillagerHappiness.Location = new System.Drawing.Point(288, 142);
            this.VillagerHappiness.Name = "VillagerHappiness";
            this.VillagerHappiness.Size = new System.Drawing.Size(97, 13);
            this.VillagerHappiness.TabIndex = 14;
            this.VillagerHappiness.Text = "villagerHappiness";
            // 
            // VillagerFaith
            // 
            this.VillagerFaith.AutoSize = true;
            this.VillagerFaith.BackColor = System.Drawing.Color.Transparent;
            this.VillagerFaith.Location = new System.Drawing.Point(288, 166);
            this.VillagerFaith.Name = "VillagerFaith";
            this.VillagerFaith.Size = new System.Drawing.Size(70, 13);
            this.VillagerFaith.TabIndex = 15;
            this.VillagerFaith.Text = "villagerState";
            // 
            // ListOfJobs
            // 
            this.ListOfJobs.BackColor = System.Drawing.Color.Peru;
            this.ListOfJobs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ListOfJobs.FormattingEnabled = true;
            this.ListOfJobs.Location = new System.Drawing.Point(132, 116);
            this.ListOfJobs.Name = "ListOfJobs";
            this.ListOfJobs.Size = new System.Drawing.Size(113, 21);
            this.ListOfJobs.TabIndex = 16;
            this.ListOfJobs.SelectedValueChanged += new System.EventHandler(this.ListOfJobs_SelectedValueChanged);
            // 
            // ActionPanelQuit
            // 
            this.ActionPanelQuit.BackColor = System.Drawing.Color.Transparent;
            this.ActionPanelQuit.BackgroundImage = global::GamePages.Properties.Resources.button_homepage;
            this.ActionPanelQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ActionPanelQuit.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActionPanelQuit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ActionPanelQuit.Location = new System.Drawing.Point(350, 179);
            this.ActionPanelQuit.Name = "ActionPanelQuit";
            this.ActionPanelQuit.Size = new System.Drawing.Size(62, 27);
            this.ActionPanelQuit.TabIndex = 17;
            this.ActionPanelQuit.Text = "Fermer";
            this.ActionPanelQuit.UseVisualStyleBackColor = false;
            this.ActionPanelQuit.Click += new System.EventHandler(this.ActionPanelQuit_Click);
            // 
            // SelectedJob
            // 
            this.SelectedJob.AutoSize = true;
            this.SelectedJob.BackColor = System.Drawing.Color.Transparent;
            this.SelectedJob.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedJob.ForeColor = System.Drawing.Color.Navy;
            this.SelectedJob.Location = new System.Drawing.Point(159, 95);
            this.SelectedJob.Name = "SelectedJob";
            this.SelectedJob.Size = new System.Drawing.Size(51, 19);
            this.SelectedJob.TabIndex = 18;
            this.SelectedJob.Text = "Métier";
            // 
            // ActionsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::GamePages.Properties.Resources.InformationBox_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.SelectedJob);
            this.Controls.Add(this.ActionPanelQuit);
            this.Controls.Add(this.ListOfJobs);
            this.Controls.Add(this.VillagerFaith);
            this.Controls.Add(this.VillagerHappiness);
            this.Controls.Add(this.SetMission);
            this.Controls.Add(this.VillagerFaithIcon);
            this.Controls.Add(this.VillagerHappinessIcon);
            this.Controls.Add(this.VillagerState);
            this.Controls.Add(this.SickIcon);
            this.Controls.Add(this.SelectedVillager);
            this.Controls.Add(this.VillagerInformations);
            this.Controls.Add(this.Actions);
            this.Controls.Add(this.GenderIcon);
            this.Controls.Add(this.VillagerJob);
            this.Controls.Add(this.ActionOnVillager);
            this.Controls.Add(this.ActionsPanelTitle);
            this.Controls.Add(this.ListOfVillagers);
            this.Controls.Add(this.VillagerSelected);
            this.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(350, 200);
            this.Name = "ActionsPanel";
            this.Size = new System.Drawing.Size(412, 209);
            ((System.ComponentModel.ISupportInitialize)(this.GenderIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SickIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VillagerHappinessIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VillagerFaithIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label VillagerSelected;
        private System.Windows.Forms.ComboBox ListOfVillagers;
        private System.Windows.Forms.Label ActionsPanelTitle;
        private System.Windows.Forms.ComboBox ActionOnVillager;
        private System.Windows.Forms.Label VillagerJob;
        private System.Windows.Forms.PictureBox GenderIcon;
        private System.Windows.Forms.Label Actions;
        private System.Windows.Forms.Label VillagerInformations;
        private System.Windows.Forms.Label SelectedVillager;
        private System.Windows.Forms.PictureBox SickIcon;
        private System.Windows.Forms.Label VillagerState;
        private System.Windows.Forms.PictureBox VillagerHappinessIcon;
        private System.Windows.Forms.PictureBox VillagerFaithIcon;
        private System.Windows.Forms.Button SetMission;
        private System.Windows.Forms.Label VillagerHappiness;
        private System.Windows.Forms.Label VillagerFaith;
        private System.Windows.Forms.ComboBox ListOfJobs;
        private System.Windows.Forms.Button ActionPanelQuit;
        private System.Windows.Forms.Label SelectedJob;
    }
}
