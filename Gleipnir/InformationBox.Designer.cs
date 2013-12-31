﻿namespace GamePages
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
            this.NameView = new System.Windows.Forms.Label();
            this.ElementName = new System.Windows.Forms.Label();
            this.GoldView = new System.Windows.Forms.Label();
            this.Gold = new System.Windows.Forms.Label();
            this.FaithView = new System.Windows.Forms.Label();
            this.Faith = new System.Windows.Forms.Label();
            this.MemberView = new System.Windows.Forms.Label();
            this.NbMembers = new System.Windows.Forms.Label();
            this.GodMeeting = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.buildingLife = new System.Windows.Forms.Label();
            this.buildingHP = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NameView
            // 
            this.NameView.AutoSize = true;
            this.NameView.BackColor = System.Drawing.Color.Transparent;
            this.NameView.Location = new System.Drawing.Point(94, 37);
            this.NameView.Name = "NameView";
            this.NameView.Size = new System.Drawing.Size(41, 13);
            this.NameView.TabIndex = 0;
            this.NameView.Text = "Nom  : ";
            // 
            // ElementName
            // 
            this.ElementName.AutoSize = true;
            this.ElementName.Location = new System.Drawing.Point(136, 37);
            this.ElementName.Name = "ElementName";
            this.ElementName.Size = new System.Drawing.Size(34, 13);
            this.ElementName.TabIndex = 1;
            this.ElementName.Text = "Value";
            // 
            // GoldView
            // 
            this.GoldView.AutoSize = true;
            this.GoldView.BackColor = System.Drawing.Color.Transparent;
            this.GoldView.Location = new System.Drawing.Point(108, 50);
            this.GoldView.Name = "GoldView";
            this.GoldView.Size = new System.Drawing.Size(24, 13);
            this.GoldView.TabIndex = 2;
            this.GoldView.Text = "Or :";
            // 
            // Gold
            // 
            this.Gold.AutoSize = true;
            this.Gold.Location = new System.Drawing.Point(136, 50);
            this.Gold.Name = "Gold";
            this.Gold.Size = new System.Drawing.Size(34, 13);
            this.Gold.TabIndex = 3;
            this.Gold.Text = "Value";
            // 
            // FaithView
            // 
            this.FaithView.AutoSize = true;
            this.FaithView.BackColor = System.Drawing.Color.Transparent;
            this.FaithView.Location = new System.Drawing.Point(106, 63);
            this.FaithView.Name = "FaithView";
            this.FaithView.Size = new System.Drawing.Size(30, 13);
            this.FaithView.TabIndex = 4;
            this.FaithView.Text = "Foi : ";
            // 
            // Faith
            // 
            this.Faith.AutoSize = true;
            this.Faith.Location = new System.Drawing.Point(136, 63);
            this.Faith.Name = "Faith";
            this.Faith.Size = new System.Drawing.Size(34, 13);
            this.Faith.TabIndex = 5;
            this.Faith.Text = "Value";
            // 
            // MemberView
            // 
            this.MemberView.AutoSize = true;
            this.MemberView.BackColor = System.Drawing.Color.Transparent;
            this.MemberView.Location = new System.Drawing.Point(22, 76);
            this.MemberView.Name = "MemberView";
            this.MemberView.Size = new System.Drawing.Size(111, 13);
            this.MemberView.TabIndex = 6;
            this.MemberView.Text = "Nombre de Membres :";
            // 
            // NbMembers
            // 
            this.NbMembers.AutoSize = true;
            this.NbMembers.Location = new System.Drawing.Point(136, 76);
            this.NbMembers.Name = "NbMembers";
            this.NbMembers.Size = new System.Drawing.Size(34, 13);
            this.NbMembers.TabIndex = 7;
            this.NbMembers.Text = "Value";
            // 
            // GodMeeting
            // 
            this.GodMeeting.Location = new System.Drawing.Point(165, 112);
            this.GodMeeting.Name = "GodMeeting";
            this.GodMeeting.Size = new System.Drawing.Size(75, 23);
            this.GodMeeting.TabIndex = 8;
            this.GodMeeting.Text = "Convocation";
            this.GodMeeting.UseVisualStyleBackColor = true;
            this.GodMeeting.Click += new System.EventHandler(this.GodMeeting_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(64, 13);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(28, 13);
            this.Title.TabIndex = 9;
            this.Title.Text = "Titre";
            // 
            // buildingLife
            // 
            this.buildingLife.AutoSize = true;
            this.buildingLife.Location = new System.Drawing.Point(136, 89);
            this.buildingLife.Name = "buildingLife";
            this.buildingLife.Size = new System.Drawing.Size(34, 13);
            this.buildingLife.TabIndex = 11;
            this.buildingLife.Text = "Value";
            // 
            // buildingHP
            // 
            this.buildingHP.AutoSize = true;
            this.buildingHP.BackColor = System.Drawing.Color.Transparent;
            this.buildingHP.Location = new System.Drawing.Point(46, 89);
            this.buildingHP.Name = "buildingHP";
            this.buildingHP.Size = new System.Drawing.Size(87, 13);
            this.buildingHP.TabIndex = 10;
            this.buildingHP.Text = "Vie du Bâtiment :";
            // 
            // InformationBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.buildingLife);
            this.Controls.Add(this.buildingHP);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.GodMeeting);
            this.Controls.Add(this.NbMembers);
            this.Controls.Add(this.MemberView);
            this.Controls.Add(this.Faith);
            this.Controls.Add(this.FaithView);
            this.Controls.Add(this.Gold);
            this.Controls.Add(this.GoldView);
            this.Controls.Add(this.ElementName);
            this.Controls.Add(this.NameView);
            this.Location = new System.Drawing.Point(870, 450);
            this.Name = "InformationBox";
            this.Size = new System.Drawing.Size(270, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameView;
        private System.Windows.Forms.Label ElementName;
        private System.Windows.Forms.Label GoldView;
        private System.Windows.Forms.Label Gold;
        private System.Windows.Forms.Label FaithView;
        private System.Windows.Forms.Label Faith;
        private System.Windows.Forms.Label MemberView;
        private System.Windows.Forms.Label NbMembers;
        private System.Windows.Forms.Button GodMeeting;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label buildingLife;
        private System.Windows.Forms.Label buildingHP;
    }
}
