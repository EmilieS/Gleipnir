namespace GamePages
{
    partial class InformationBox
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
            this.ElementName = new System.Windows.Forms.Label();
            this.Gold = new System.Windows.Forms.Label();
            this.Faith = new System.Windows.Forms.Label();
            this.NbMembers = new System.Windows.Forms.Label();
            this.GodMeeting = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.buildingLife = new System.Windows.Forms.Label();
            this.Happiness = new System.Windows.Forms.Label();
            this.buildingHealthIcon = new System.Windows.Forms.PictureBox();
            this.faithIcon = new System.Windows.Forms.PictureBox();
            this.goldIcon = new System.Windows.Forms.PictureBox();
            this.happinessIcon = new System.Windows.Forms.PictureBox();
            this.buildingIcon = new System.Windows.Forms.PictureBox();
            this.familyMembers = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.buildingHealthIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.faithIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goldIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.happinessIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buildingIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.familyMembers)).BeginInit();
            this.SuspendLayout();
            // 
            // ElementName
            // 
            this.ElementName.AutoSize = true;
            this.ElementName.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElementName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ElementName.Location = new System.Drawing.Point(95, 43);
            this.ElementName.Name = "ElementName";
            this.ElementName.Size = new System.Drawing.Size(78, 15);
            this.ElementName.TabIndex = 1;
            this.ElementName.Text = "FamilyName";
            // 
            // Gold
            // 
            this.Gold.AutoSize = true;
            this.Gold.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gold.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Gold.Location = new System.Drawing.Point(35, 74);
            this.Gold.Name = "Gold";
            this.Gold.Size = new System.Drawing.Size(34, 15);
            this.Gold.TabIndex = 3;
            this.Gold.Text = "Gold";
            // 
            // Faith
            // 
            this.Faith.AutoSize = true;
            this.Faith.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Faith.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Faith.Location = new System.Drawing.Point(35, 105);
            this.Faith.Name = "Faith";
            this.Faith.Size = new System.Drawing.Size(35, 15);
            this.Faith.TabIndex = 5;
            this.Faith.Text = "Faith";
            // 
            // NbMembers
            // 
            this.NbMembers.AutoSize = true;
            this.NbMembers.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NbMembers.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.NbMembers.Location = new System.Drawing.Point(120, 74);
            this.NbMembers.Name = "NbMembers";
            this.NbMembers.Size = new System.Drawing.Size(81, 15);
            this.NbMembers.TabIndex = 7;
            this.NbMembers.Text = "NbMembers";
            // 
            // GodMeeting
            // 
            this.GodMeeting.BackgroundImage = global::GamePages.Properties.Resources.button_homepage;
            this.GodMeeting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GodMeeting.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.GodMeeting.Location = new System.Drawing.Point(177, 71);
            this.GodMeeting.Name = "GodMeeting";
            this.GodMeeting.Size = new System.Drawing.Size(86, 47);
            this.GodMeeting.TabIndex = 8;
            this.GodMeeting.Text = "Convocation";
            this.GodMeeting.UseVisualStyleBackColor = true;
            this.GodMeeting.Click += new System.EventHandler(this.GodMeeting_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.Maroon;
            this.Title.Location = new System.Drawing.Point(125, 10);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(65, 21);
            this.Title.TabIndex = 9;
            this.Title.Text = "Maison";
            // 
            // buildingLife
            // 
            this.buildingLife.AutoSize = true;
            this.buildingLife.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildingLife.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buildingLife.Location = new System.Drawing.Point(213, 128);
            this.buildingLife.Name = "buildingLife";
            this.buildingLife.Size = new System.Drawing.Size(67, 15);
            this.buildingLife.TabIndex = 11;
            this.buildingLife.Text = "BuidingHP";
            // 
            // Happiness
            // 
            this.Happiness.AutoSize = true;
            this.Happiness.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Happiness.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Happiness.Location = new System.Drawing.Point(120, 105);
            this.Happiness.Name = "Happiness";
            this.Happiness.Size = new System.Drawing.Size(68, 15);
            this.Happiness.TabIndex = 12;
            this.Happiness.Text = "Happiness";
            // 
            // buildingHealthIcon
            // 
            this.buildingHealthIcon.BackgroundImage = global::GamePages.Properties.Resources.HealthPoints;
            this.buildingHealthIcon.Location = new System.Drawing.Point(189, 126);
            this.buildingHealthIcon.Name = "buildingHealthIcon";
            this.buildingHealthIcon.Size = new System.Drawing.Size(20, 20);
            this.buildingHealthIcon.TabIndex = 13;
            this.buildingHealthIcon.TabStop = false;
            // 
            // faithIcon
            // 
            this.faithIcon.BackgroundImage = global::GamePages.Properties.Resources.Faith;
            this.faithIcon.Location = new System.Drawing.Point(12, 102);
            this.faithIcon.Name = "faithIcon";
            this.faithIcon.Size = new System.Drawing.Size(20, 20);
            this.faithIcon.TabIndex = 14;
            this.faithIcon.TabStop = false;
            // 
            // goldIcon
            // 
            this.goldIcon.BackgroundImage = global::GamePages.Properties.Resources.Gold;
            this.goldIcon.Location = new System.Drawing.Point(11, 71);
            this.goldIcon.Name = "goldIcon";
            this.goldIcon.Size = new System.Drawing.Size(20, 20);
            this.goldIcon.TabIndex = 15;
            this.goldIcon.TabStop = false;
            // 
            // happinessIcon
            // 
            this.happinessIcon.BackgroundImage = global::GamePages.Properties.Resources.Happiness;
            this.happinessIcon.Location = new System.Drawing.Point(96, 102);
            this.happinessIcon.Name = "happinessIcon";
            this.happinessIcon.Size = new System.Drawing.Size(20, 20);
            this.happinessIcon.TabIndex = 16;
            this.happinessIcon.TabStop = false;
            // 
            // buildingIcon
            // 
            this.buildingIcon.BackgroundImage = global::GamePages.Properties.Resources.Index_Buildings;
            this.buildingIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buildingIcon.Location = new System.Drawing.Point(12, 10);
            this.buildingIcon.Name = "buildingIcon";
            this.buildingIcon.Size = new System.Drawing.Size(50, 50);
            this.buildingIcon.TabIndex = 17;
            this.buildingIcon.TabStop = false;
            // 
            // familyMembers
            // 
            this.familyMembers.BackgroundImage = global::GamePages.Properties.Resources.HumanMembers;
            this.familyMembers.Location = new System.Drawing.Point(96, 71);
            this.familyMembers.Name = "familyMembers";
            this.familyMembers.Size = new System.Drawing.Size(20, 20);
            this.familyMembers.TabIndex = 18;
            this.familyMembers.TabStop = false;
            // 
            // InformationBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::GamePages.Properties.Resources.InformationBox_house_background;
            this.Controls.Add(this.familyMembers);
            this.Controls.Add(this.buildingIcon);
            this.Controls.Add(this.happinessIcon);
            this.Controls.Add(this.goldIcon);
            this.Controls.Add(this.faithIcon);
            this.Controls.Add(this.buildingHealthIcon);
            this.Controls.Add(this.GodMeeting);
            this.Controls.Add(this.Happiness);
            this.Controls.Add(this.buildingLife);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.NbMembers);
            this.Controls.Add(this.Faith);
            this.Controls.Add(this.Gold);
            this.Controls.Add(this.ElementName);
            this.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(870, 450);
            this.Name = "InformationBox";
            this.Size = new System.Drawing.Size(270, 150);
            ((System.ComponentModel.ISupportInitialize)(this.buildingHealthIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.faithIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goldIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.happinessIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buildingIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.familyMembers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ElementName;
        private System.Windows.Forms.Label Gold;
        private System.Windows.Forms.Label Faith;
        private System.Windows.Forms.Label NbMembers;
        private System.Windows.Forms.Button GodMeeting;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label buildingLife;
        private System.Windows.Forms.Label Happiness;
        private System.Windows.Forms.PictureBox buildingHealthIcon;
        private System.Windows.Forms.PictureBox faithIcon;
        private System.Windows.Forms.PictureBox goldIcon;
        private System.Windows.Forms.PictureBox happinessIcon;
        private System.Windows.Forms.PictureBox buildingIcon;
        private System.Windows.Forms.PictureBox familyMembers;
    }
}
