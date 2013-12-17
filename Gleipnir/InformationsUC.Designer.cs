namespace GamePages
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformationsUC));
            this.offeringsPoints = new System.Windows.Forms.Label();
            this.happinessVillage = new System.Windows.Forms.Label();
            this.faithVillage = new System.Windows.Forms.Label();
            this.population = new System.Windows.Forms.Label();
            this.goldVillage = new System.Windows.Forms.Label();
            this.menuButton = new System.Windows.Forms.Button();
            this.Village = new System.Windows.Forms.Label();
            this.villageName = new System.Windows.Forms.Label();
            this.StepByStep = new System.Windows.Forms.Button();
            this.TaxAmount = new System.Windows.Forms.TrackBar();
            this.villageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TaxAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.villageBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // offeringsPoints
            // 
            this.offeringsPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.offeringsPoints.AutoSize = true;
            this.offeringsPoints.Location = new System.Drawing.Point(546, 8);
            this.offeringsPoints.Name = "offeringsPoints";
            this.offeringsPoints.Size = new System.Drawing.Size(88, 13);
            this.offeringsPoints.TabIndex = 19;
            this.offeringsPoints.Text = "Points d\'Offrande";
            // 
            // happinessVillage
            // 
            this.happinessVillage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.happinessVillage.AutoSize = true;
            this.happinessVillage.Location = new System.Drawing.Point(479, 8);
            this.happinessVillage.Name = "happinessVillage";
            this.happinessVillage.Size = new System.Drawing.Size(47, 13);
            this.happinessVillage.TabIndex = 18;
            this.happinessVillage.Text = "Bonheur";
            // 
            // faithVillage
            // 
            this.faithVillage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.faithVillage.AutoSize = true;
            this.faithVillage.Location = new System.Drawing.Point(433, 8);
            this.faithVillage.Name = "faithVillage";
            this.faithVillage.Size = new System.Drawing.Size(21, 13);
            this.faithVillage.TabIndex = 17;
            this.faithVillage.Text = "Foi";
            // 
            // population
            // 
            this.population.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.population.AutoSize = true;
            this.population.Location = new System.Drawing.Point(350, 8);
            this.population.Name = "population";
            this.population.Size = new System.Drawing.Size(57, 13);
            this.population.TabIndex = 16;
            this.population.Text = "Population";
            // 
            // goldVillage
            // 
            this.goldVillage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.goldVillage.AutoSize = true;
            this.goldVillage.Location = new System.Drawing.Point(288, 7);
            this.goldVillage.Name = "goldVillage";
            this.goldVillage.Size = new System.Drawing.Size(18, 13);
            this.goldVillage.TabIndex = 15;
            this.goldVillage.Text = "Or";
            // 
            // menuButton
            // 
            this.menuButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuButton.BackgroundImage")));
            this.menuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuButton.Location = new System.Drawing.Point(1034, 3);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(103, 27);
            this.menuButton.TabIndex = 14;
            this.menuButton.Text = "Menu";
            this.menuButton.UseVisualStyleBackColor = true;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // Village
            // 
            this.Village.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Village.AutoSize = true;
            this.Village.BackColor = System.Drawing.Color.Transparent;
            this.Village.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Village.Location = new System.Drawing.Point(9, 7);
            this.Village.Name = "Village";
            this.Village.Size = new System.Drawing.Size(69, 21);
            this.Village.TabIndex = 13;
            this.Village.Text = "Village :";
            this.Village.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // villageName
            // 
            this.villageName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.villageName.AutoSize = true;
            this.villageName.BackColor = System.Drawing.Color.Transparent;
            this.villageName.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.villageName.Location = new System.Drawing.Point(84, 8);
            this.villageName.Name = "villageName";
            this.villageName.Size = new System.Drawing.Size(60, 22);
            this.villageName.TabIndex = 12;
            this.villageName.Text = "Ragnar";
            this.villageName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StepByStep
            // 
            this.StepByStep.Location = new System.Drawing.Point(648, 3);
            this.StepByStep.Name = "StepByStep";
            this.StepByStep.Size = new System.Drawing.Size(110, 21);
            this.StepByStep.TabIndex = 21;
            this.StepByStep.Text = "Step by Step";
            this.StepByStep.UseVisualStyleBackColor = true;
            this.StepByStep.Visible = false;
            this.StepByStep.Click += new System.EventHandler(this.StepByStep_Click);
            // 
            // TaxAmount
            // 
            this.TaxAmount.AccessibleName = "Collection d\'offrandes";
            this.TaxAmount.LargeChange = 20;
            this.TaxAmount.Location = new System.Drawing.Point(764, 0);
            this.TaxAmount.Maximum = 100;
            this.TaxAmount.Minimum = 1;
            this.TaxAmount.Name = "TaxAmount";
            this.TaxAmount.Size = new System.Drawing.Size(250, 45);
            this.TaxAmount.SmallChange = 5;
            this.TaxAmount.TabIndex = 22;
            this.TaxAmount.Tag = "Collection d\'offrandes";
            this.TaxAmount.TickFrequency = 5;
            this.TaxAmount.Value = 1;
            this.TaxAmount.ValueChanged += new System.EventHandler(this.TaxAmount_ValueChanged);
            // 
            // villageBindingSource
            // 
            this.villageBindingSource.DataSource = typeof(Game.Village);
            // 
            // InformationsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TaxAmount);
            this.Controls.Add(this.StepByStep);
            this.Controls.Add(this.offeringsPoints);
            this.Controls.Add(this.happinessVillage);
            this.Controls.Add(this.faithVillage);
            this.Controls.Add(this.population);
            this.Controls.Add(this.goldVillage);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.Village);
            this.Controls.Add(this.villageName);
            this.Name = "InformationsUC";
            this.Size = new System.Drawing.Size(1140, 35);
            ((System.ComponentModel.ISupportInitialize)(this.TaxAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.villageBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label offeringsPoints;
        internal System.Windows.Forms.Label happinessVillage;
        internal System.Windows.Forms.Label faithVillage;
        internal System.Windows.Forms.Label population;
        internal System.Windows.Forms.Label goldVillage;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.Label Village;
        internal System.Windows.Forms.Label villageName;
        internal System.Windows.Forms.Button StepByStep;
        private System.Windows.Forms.TrackBar TaxAmount;
        private System.Windows.Forms.BindingSource villageBindingSource;
    }
}
