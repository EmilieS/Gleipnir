namespace GamePages
{
    partial class TabIndex
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
            this.actionsMenu = new System.Windows.Forms.TabControl();
            this.buildingsTab = new System.Windows.Forms.TabPage();
            this.Restaurant = new System.Windows.Forms.Button();
            this.Theater = new System.Windows.Forms.Button();
            this.Brothel = new System.Windows.Forms.Button();
            this.Baths = new System.Windows.Forms.Button();
            this.PartyRoom = new System.Windows.Forms.Button();
            this.Chapel = new System.Windows.Forms.Button();
            this.ApothicaryOffice = new System.Windows.Forms.Button();
            this.Tavern = new System.Windows.Forms.Button();
            this.happinessTab = new System.Windows.Forms.TabPage();
            this.VillagerList = new System.Windows.Forms.TabPage();
            this.godSpellsTab = new System.Windows.Forms.TabPage();
            this.actionsMenu.SuspendLayout();
            this.buildingsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // actionsMenu
            // 
            this.actionsMenu.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.actionsMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.actionsMenu.Controls.Add(this.buildingsTab);
            this.actionsMenu.Controls.Add(this.happinessTab);
            this.actionsMenu.Controls.Add(this.VillagerList);
            this.actionsMenu.Controls.Add(this.godSpellsTab);
            this.actionsMenu.Cursor = System.Windows.Forms.Cursors.Default;
            this.actionsMenu.ItemSize = new System.Drawing.Size(30, 30);
            this.actionsMenu.Location = new System.Drawing.Point(1, 1);
            this.actionsMenu.Name = "actionsMenu";
            this.actionsMenu.SelectedIndex = 0;
            this.actionsMenu.Size = new System.Drawing.Size(216, 566);
            this.actionsMenu.TabIndex = 3;
            this.actionsMenu.TabStop = false;
            // 
            // buildingsTab
            // 
            this.buildingsTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buildingsTab.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.buildingsTab.Controls.Add(this.Restaurant);
            this.buildingsTab.Controls.Add(this.Theater);
            this.buildingsTab.Controls.Add(this.Brothel);
            this.buildingsTab.Controls.Add(this.Baths);
            this.buildingsTab.Controls.Add(this.PartyRoom);
            this.buildingsTab.Controls.Add(this.Chapel);
            this.buildingsTab.Controls.Add(this.ApothicaryOffice);
            this.buildingsTab.Controls.Add(this.Tavern);
            this.buildingsTab.Location = new System.Drawing.Point(4, 4);
            this.buildingsTab.Name = "buildingsTab";
            this.buildingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.buildingsTab.Size = new System.Drawing.Size(208, 528);
            this.buildingsTab.TabIndex = 0;
            this.buildingsTab.UseVisualStyleBackColor = true;
            // 
            // Restaurant
            // 
            this.Restaurant.Location = new System.Drawing.Point(36, 429);
            this.Restaurant.Name = "Restaurant";
            this.Restaurant.Size = new System.Drawing.Size(75, 23);
            this.Restaurant.TabIndex = 7;
            this.Restaurant.Text = "Restaurant";
            this.Restaurant.UseVisualStyleBackColor = true;
            this.Restaurant.Click += new System.EventHandler(this.Restaurant_Click);
            // 
            // Theater
            // 
            this.Theater.Location = new System.Drawing.Point(45, 382);
            this.Theater.Name = "Theater";
            this.Theater.Size = new System.Drawing.Size(75, 23);
            this.Theater.TabIndex = 6;
            this.Theater.Text = "Théatre";
            this.Theater.UseVisualStyleBackColor = true;
            this.Theater.Click += new System.EventHandler(this.Theater_Click);
            // 
            // Brothel
            // 
            this.Brothel.Location = new System.Drawing.Point(36, 323);
            this.Brothel.Name = "Brothel";
            this.Brothel.Size = new System.Drawing.Size(93, 23);
            this.Brothel.TabIndex = 5;
            this.Brothel.Text = "Maison Close";
            this.Brothel.UseVisualStyleBackColor = true;
            this.Brothel.Click += new System.EventHandler(this.Brothel_Click);
            // 
            // Baths
            // 
            this.Baths.Location = new System.Drawing.Point(26, 266);
            this.Baths.Name = "Baths";
            this.Baths.Size = new System.Drawing.Size(68, 24);
            this.Baths.TabIndex = 4;
            this.Baths.Text = "Bains";
            this.Baths.UseVisualStyleBackColor = true;
            this.Baths.Click += new System.EventHandler(this.Baths_Click);
            // 
            // PartyRoom
            // 
            this.PartyRoom.Location = new System.Drawing.Point(36, 202);
            this.PartyRoom.Name = "PartyRoom";
            this.PartyRoom.Size = new System.Drawing.Size(93, 23);
            this.PartyRoom.TabIndex = 3;
            this.PartyRoom.Text = "Salle des Fêtes";
            this.PartyRoom.UseVisualStyleBackColor = true;
            this.PartyRoom.Click += new System.EventHandler(this.PartyRoom_Click);
            // 
            // Chapel
            // 
            this.Chapel.Location = new System.Drawing.Point(26, 133);
            this.Chapel.Name = "Chapel";
            this.Chapel.Size = new System.Drawing.Size(75, 23);
            this.Chapel.TabIndex = 2;
            this.Chapel.Text = "Chapelle";
            this.Chapel.UseVisualStyleBackColor = true;
            this.Chapel.Click += new System.EventHandler(this.Chapel_Click);
            // 
            // ApothicaryOffice
            // 
            this.ApothicaryOffice.Location = new System.Drawing.Point(19, 76);
            this.ApothicaryOffice.Name = "ApothicaryOffice";
            this.ApothicaryOffice.Size = new System.Drawing.Size(75, 23);
            this.ApothicaryOffice.TabIndex = 1;
            this.ApothicaryOffice.Text = "Pharmacie";
            this.ApothicaryOffice.UseVisualStyleBackColor = true;
            this.ApothicaryOffice.Click += new System.EventHandler(this.ApothicaryOffice_Click);
            // 
            // Tavern
            // 
            this.Tavern.Location = new System.Drawing.Point(16, 22);
            this.Tavern.Name = "Tavern";
            this.Tavern.Size = new System.Drawing.Size(75, 23);
            this.Tavern.TabIndex = 0;
            this.Tavern.Text = "Taverne";
            this.Tavern.UseVisualStyleBackColor = true;
            this.Tavern.Click += new System.EventHandler(this.Tavern_Click);
            // 
            // happinessTab
            // 
            this.happinessTab.ImageKey = "(aucun)";
            this.happinessTab.Location = new System.Drawing.Point(4, 4);
            this.happinessTab.Name = "happinessTab";
            this.happinessTab.Padding = new System.Windows.Forms.Padding(3);
            this.happinessTab.Size = new System.Drawing.Size(208, 528);
            this.happinessTab.TabIndex = 1;
            this.happinessTab.UseVisualStyleBackColor = true;
            // 
            // VillagerList
            // 
            this.VillagerList.AutoScroll = true;
            this.VillagerList.Location = new System.Drawing.Point(4, 4);
            this.VillagerList.Name = "VillagerList";
            this.VillagerList.Padding = new System.Windows.Forms.Padding(3);
            this.VillagerList.Size = new System.Drawing.Size(208, 528);
            this.VillagerList.TabIndex = 2;
            this.VillagerList.UseVisualStyleBackColor = true;
            // 
            // godSpellsTab
            // 
            this.godSpellsTab.Location = new System.Drawing.Point(4, 4);
            this.godSpellsTab.Name = "godSpellsTab";
            this.godSpellsTab.Padding = new System.Windows.Forms.Padding(3);
            this.godSpellsTab.Size = new System.Drawing.Size(208, 528);
            this.godSpellsTab.TabIndex = 3;
            this.godSpellsTab.UseVisualStyleBackColor = true;
            // 
            // TabIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.actionsMenu);
            this.Location = new System.Drawing.Point(0, 40);
            this.Name = "TabIndex";
            this.Size = new System.Drawing.Size(216, 570);
            this.actionsMenu.ResumeLayout(false);
            this.buildingsTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl actionsMenu;
        private System.Windows.Forms.TabPage buildingsTab;
        private System.Windows.Forms.TabPage happinessTab;
        private System.Windows.Forms.TabPage VillagerList;
        private System.Windows.Forms.TabPage godSpellsTab;
        private System.Windows.Forms.Button Tavern;
        private System.Windows.Forms.Button ApothicaryOffice;
        private System.Windows.Forms.Button Chapel;
        private System.Windows.Forms.Button PartyRoom;
        private System.Windows.Forms.Button Baths;
        private System.Windows.Forms.Button Brothel;
        private System.Windows.Forms.Button Theater;
        private System.Windows.Forms.Button Restaurant;

    }
}
