﻿namespace GamePages
{
    partial class InformationsUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformationsUC));
            this.changeGoldOfferings = new System.Windows.Forms.Button();
            this.offeringsPoints = new System.Windows.Forms.Label();
            this.happinessVillage = new System.Windows.Forms.Label();
            this.faithVillage = new System.Windows.Forms.Label();
            this.population = new System.Windows.Forms.Label();
            this.goldVillage = new System.Windows.Forms.Label();
            this.menuButton = new System.Windows.Forms.Button();
            this.Village = new System.Windows.Forms.Label();
            this.villageName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // changeGoldOfferings
            // 
            this.changeGoldOfferings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("changeGoldOfferings.BackgroundImage")));
            this.changeGoldOfferings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeGoldOfferings.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.changeGoldOfferings.Location = new System.Drawing.Point(764, 2);
            this.changeGoldOfferings.Name = "changeGoldOfferings";
            this.changeGoldOfferings.Size = new System.Drawing.Size(94, 23);
            this.changeGoldOfferings.TabIndex = 20;
            this.changeGoldOfferings.Text = "Echange Or/PO";
            this.changeGoldOfferings.UseVisualStyleBackColor = true;
            // 
            // offeringsPoints
            // 
            this.offeringsPoints.AutoSize = true;
            this.offeringsPoints.Location = new System.Drawing.Point(567, 8);
            this.offeringsPoints.Name = "offeringsPoints";
            this.offeringsPoints.Size = new System.Drawing.Size(88, 13);
            this.offeringsPoints.TabIndex = 19;
            this.offeringsPoints.Text = "Points d\'Offrande";
            // 
            // happinessVillage
            // 
            this.happinessVillage.AutoSize = true;
            this.happinessVillage.Location = new System.Drawing.Point(500, 8);
            this.happinessVillage.Name = "happinessVillage";
            this.happinessVillage.Size = new System.Drawing.Size(47, 13);
            this.happinessVillage.TabIndex = 18;
            this.happinessVillage.Text = "Bonheur";
            // 
            // faithVillage
            // 
            this.faithVillage.AutoSize = true;
            this.faithVillage.Location = new System.Drawing.Point(454, 8);
            this.faithVillage.Name = "faithVillage";
            this.faithVillage.Size = new System.Drawing.Size(21, 13);
            this.faithVillage.TabIndex = 17;
            this.faithVillage.Text = "Foi";
            // 
            // population
            // 
            this.population.AutoSize = true;
            this.population.Location = new System.Drawing.Point(371, 8);
            this.population.Name = "population";
            this.population.Size = new System.Drawing.Size(57, 13);
            this.population.TabIndex = 16;
            this.population.Text = "Population";
            // 
            // goldVillage
            // 
            this.goldVillage.AutoSize = true;
            this.goldVillage.Location = new System.Drawing.Point(309, 7);
            this.goldVillage.Name = "goldVillage";
            this.goldVillage.Size = new System.Drawing.Size(18, 13);
            this.goldVillage.TabIndex = 15;
            this.goldVillage.Text = "Or";
            // 
            // menuButton
            // 
            this.menuButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuButton.BackgroundImage")));
            this.menuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuButton.Location = new System.Drawing.Point(864, 2);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(103, 22);
            this.menuButton.TabIndex = 14;
            this.menuButton.Text = "Menu";
            this.menuButton.UseVisualStyleBackColor = true;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // Village
            // 
            this.Village.AutoSize = true;
            this.Village.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Village.Location = new System.Drawing.Point(3, 7);
            this.Village.Name = "Village";
            this.Village.Size = new System.Drawing.Size(44, 13);
            this.Village.TabIndex = 13;
            this.Village.Text = "Village :";
            this.Village.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // villageName
            // 
            this.villageName.AutoSize = true;
            this.villageName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.villageName.Location = new System.Drawing.Point(44, 7);
            this.villageName.Name = "villageName";
            this.villageName.Size = new System.Drawing.Size(42, 13);
            this.villageName.TabIndex = 12;
            this.villageName.Text = "Ragnar";
            this.villageName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InformationsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.changeGoldOfferings);
            this.Controls.Add(this.offeringsPoints);
            this.Controls.Add(this.happinessVillage);
            this.Controls.Add(this.faithVillage);
            this.Controls.Add(this.population);
            this.Controls.Add(this.goldVillage);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.Village);
            this.Controls.Add(this.villageName);
            this.Name = "InformationsUC";
            this.Size = new System.Drawing.Size(970, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button changeGoldOfferings;
        private System.Windows.Forms.Label offeringsPoints;
        private System.Windows.Forms.Label happinessVillage;
        private System.Windows.Forms.Label faithVillage;
        private System.Windows.Forms.Label population;
        private System.Windows.Forms.Label goldVillage;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.Label Village;
        private System.Windows.Forms.Label villageName;
    }
}