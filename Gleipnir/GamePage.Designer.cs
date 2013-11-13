namespace GamePages
{
    partial class GamePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.villageName = new System.Windows.Forms.Label();
            this.Village = new System.Windows.Forms.Label();
            this.godSpellsTab = new System.Windows.Forms.TabPage();
            this.faithTab = new System.Windows.Forms.TabPage();
            this.happinessTab = new System.Windows.Forms.TabPage();
            this.buildingsTab = new System.Windows.Forms.TabPage();
            this.actionsMenu = new System.Windows.Forms.TabControl();
            this.eventFlux = new System.Windows.Forms.FlowLayoutPanel();
            this.menuButton = new System.Windows.Forms.Button();
            this.dialogTextBox = new System.Windows.Forms.TextBox();
            this.goldVillage = new System.Windows.Forms.Label();
            this.population = new System.Windows.Forms.Label();
            this.faithVillage = new System.Windows.Forms.Label();
            this.happinessVillage = new System.Windows.Forms.Label();
            this.offeringsPoints = new System.Windows.Forms.Label();
            this.changeGoldOfferings = new System.Windows.Forms.Button();
            this.groupInfoBox = new System.Windows.Forms.GroupBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.mapBackground = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.actionsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // villageName
            // 
            this.villageName.AutoSize = true;
            this.villageName.BackColor = System.Drawing.SystemColors.ControlDark;
            this.villageName.Location = new System.Drawing.Point(101, 9);
            this.villageName.Name = "villageName";
            this.villageName.Size = new System.Drawing.Size(42, 13);
            this.villageName.TabIndex = 0;
            this.villageName.Text = "Ragnar";
            this.villageName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Village
            // 
            this.Village.AutoSize = true;
            this.Village.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Village.Location = new System.Drawing.Point(60, 9);
            this.Village.Name = "Village";
            this.Village.Size = new System.Drawing.Size(44, 13);
            this.Village.TabIndex = 1;
            this.Village.Text = "Village :";
            this.Village.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // godSpellsTab
            // 
            this.godSpellsTab.Location = new System.Drawing.Point(4, 4);
            this.godSpellsTab.Name = "godSpellsTab";
            this.godSpellsTab.Padding = new System.Windows.Forms.Padding(3);
            this.godSpellsTab.Size = new System.Drawing.Size(192, 655);
            this.godSpellsTab.TabIndex = 3;
            this.godSpellsTab.Text = "Sorts Divins";
            this.godSpellsTab.UseVisualStyleBackColor = true;
            // 
            // faithTab
            // 
            this.faithTab.Location = new System.Drawing.Point(4, 4);
            this.faithTab.Name = "faithTab";
            this.faithTab.Padding = new System.Windows.Forms.Padding(3);
            this.faithTab.Size = new System.Drawing.Size(192, 655);
            this.faithTab.TabIndex = 2;
            this.faithTab.Text = "Foi";
            this.faithTab.UseVisualStyleBackColor = true;
            // 
            // happinessTab
            // 
            this.happinessTab.Location = new System.Drawing.Point(4, 4);
            this.happinessTab.Name = "happinessTab";
            this.happinessTab.Padding = new System.Windows.Forms.Padding(3);
            this.happinessTab.Size = new System.Drawing.Size(192, 655);
            this.happinessTab.TabIndex = 1;
            this.happinessTab.Text = "Bonheur";
            this.happinessTab.UseVisualStyleBackColor = true;
            // 
            // buildingsTab
            // 
            this.buildingsTab.Location = new System.Drawing.Point(4, 4);
            this.buildingsTab.Name = "buildingsTab";
            this.buildingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.buildingsTab.Size = new System.Drawing.Size(192, 655);
            this.buildingsTab.TabIndex = 0;
            this.buildingsTab.Text = "Constructions";
            this.buildingsTab.UseVisualStyleBackColor = true;
            // 
            // actionsMenu
            // 
            this.actionsMenu.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.actionsMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.actionsMenu.Controls.Add(this.buildingsTab);
            this.actionsMenu.Controls.Add(this.happinessTab);
            this.actionsMenu.Controls.Add(this.faithTab);
            this.actionsMenu.Controls.Add(this.godSpellsTab);
            this.actionsMenu.Location = new System.Drawing.Point(12, 37);
            this.actionsMenu.Name = "actionsMenu";
            this.actionsMenu.SelectedIndex = 0;
            this.actionsMenu.Size = new System.Drawing.Size(200, 681);
            this.actionsMenu.TabIndex = 2;
            this.actionsMenu.TabStop = false;
            // 
            // eventFlux
            // 
            this.eventFlux.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.eventFlux.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.eventFlux.Location = new System.Drawing.Point(782, 37);
            this.eventFlux.Name = "eventFlux";
            this.eventFlux.Size = new System.Drawing.Size(214, 415);
            this.eventFlux.TabIndex = 3;
            // 
            // menuButton
            // 
            this.menuButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuButton.Location = new System.Drawing.Point(893, 9);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(103, 22);
            this.menuButton.TabIndex = 4;
            this.menuButton.Text = "Menu";
            this.menuButton.UseVisualStyleBackColor = true;
            // 
            // dialogTextBox
            // 
            this.dialogTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dialogTextBox.Location = new System.Drawing.Point(218, 568);
            this.dialogTextBox.Multiline = true;
            this.dialogTextBox.Name = "dialogTextBox";
            this.dialogTextBox.ReadOnly = true;
            this.dialogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dialogTextBox.Size = new System.Drawing.Size(558, 150);
            this.dialogTextBox.TabIndex = 5;
            this.dialogTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // goldVillage
            // 
            this.goldVillage.AutoSize = true;
            this.goldVillage.Location = new System.Drawing.Point(291, 14);
            this.goldVillage.Name = "goldVillage";
            this.goldVillage.Size = new System.Drawing.Size(18, 13);
            this.goldVillage.TabIndex = 6;
            this.goldVillage.Text = "Or";
            // 
            // population
            // 
            this.population.AutoSize = true;
            this.population.Location = new System.Drawing.Point(353, 14);
            this.population.Name = "population";
            this.population.Size = new System.Drawing.Size(57, 13);
            this.population.TabIndex = 7;
            this.population.Text = "Population";
            // 
            // faithVillage
            // 
            this.faithVillage.AutoSize = true;
            this.faithVillage.Location = new System.Drawing.Point(450, 14);
            this.faithVillage.Name = "faithVillage";
            this.faithVillage.Size = new System.Drawing.Size(21, 13);
            this.faithVillage.TabIndex = 8;
            this.faithVillage.Text = "Foi";
            // 
            // happinessVillage
            // 
            this.happinessVillage.AutoSize = true;
            this.happinessVillage.Location = new System.Drawing.Point(513, 14);
            this.happinessVillage.Name = "happinessVillage";
            this.happinessVillage.Size = new System.Drawing.Size(47, 13);
            this.happinessVillage.TabIndex = 9;
            this.happinessVillage.Text = "Bonheur";
            // 
            // offeringsPoints
            // 
            this.offeringsPoints.AutoSize = true;
            this.offeringsPoints.Location = new System.Drawing.Point(605, 14);
            this.offeringsPoints.Name = "offeringsPoints";
            this.offeringsPoints.Size = new System.Drawing.Size(88, 13);
            this.offeringsPoints.TabIndex = 10;
            this.offeringsPoints.Text = "Points d\'Offrande";
            // 
            // changeGoldOfferings
            // 
            this.changeGoldOfferings.Location = new System.Drawing.Point(793, 9);
            this.changeGoldOfferings.Name = "changeGoldOfferings";
            this.changeGoldOfferings.Size = new System.Drawing.Size(94, 23);
            this.changeGoldOfferings.TabIndex = 11;
            this.changeGoldOfferings.Text = "Echange Or/PO";
            this.changeGoldOfferings.UseVisualStyleBackColor = true;
            // 
            // groupInfoBox
            // 
            this.groupInfoBox.Location = new System.Drawing.Point(782, 458);
            this.groupInfoBox.Name = "groupInfoBox";
            this.groupInfoBox.Size = new System.Drawing.Size(214, 260);
            this.groupInfoBox.TabIndex = 13;
            this.groupInfoBox.TabStop = false;
            this.groupInfoBox.Text = "Informations";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.mapBackground});
            this.shapeContainer1.Size = new System.Drawing.Size(1008, 730);
            this.shapeContainer1.TabIndex = 14;
            this.shapeContainer1.TabStop = false;
            // 
            // mapBackground
            // 
            this.mapBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapBackground.BackgroundImage = global::GamePages.Properties.Resources.Ebauche_Carte_du_Monde;
            this.mapBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mapBackground.Location = new System.Drawing.Point(218, 37);
            this.mapBackground.Name = "mapBackground";
            this.mapBackground.Size = new System.Drawing.Size(555, 525);
            // 
            // GamePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.groupInfoBox);
            this.Controls.Add(this.changeGoldOfferings);
            this.Controls.Add(this.offeringsPoints);
            this.Controls.Add(this.happinessVillage);
            this.Controls.Add(this.faithVillage);
            this.Controls.Add(this.population);
            this.Controls.Add(this.goldVillage);
            this.Controls.Add(this.dialogTextBox);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.eventFlux);
            this.Controls.Add(this.actionsMenu);
            this.Controls.Add(this.Village);
            this.Controls.Add(this.villageName);
            this.Controls.Add(this.shapeContainer1);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Name = "GamePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.actionsMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label villageName;
        private System.Windows.Forms.Label Village;
        private System.Windows.Forms.TabPage godSpellsTab;
        private System.Windows.Forms.TabPage faithTab;
        private System.Windows.Forms.TabPage happinessTab;
        private System.Windows.Forms.TabPage buildingsTab;
        private System.Windows.Forms.TabControl actionsMenu;
        private System.Windows.Forms.FlowLayoutPanel eventFlux;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.TextBox dialogTextBox;
        private System.Windows.Forms.Label goldVillage;
        private System.Windows.Forms.Label population;
        private System.Windows.Forms.Label faithVillage;
        private System.Windows.Forms.Label happinessVillage;
        private System.Windows.Forms.Label offeringsPoints;
        private System.Windows.Forms.Button changeGoldOfferings;
        private System.Windows.Forms.GroupBox groupInfoBox;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape mapBackground;
    }
}

