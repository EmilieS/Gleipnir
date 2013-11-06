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
            this.happinessTab = new System.Windows.Forms.TabPage();
            this.faithTab = new System.Windows.Forms.TabPage();
            this.godSpellsTab = new System.Windows.Forms.TabPage();
            this.actionsMenu.SuspendLayout();
            this.SuspendLayout();
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
            this.actionsMenu.Location = new System.Drawing.Point(1, 1);
            this.actionsMenu.Name = "actionsMenu";
            this.actionsMenu.SelectedIndex = 0;
            this.actionsMenu.Size = new System.Drawing.Size(216, 767);
            this.actionsMenu.TabIndex = 3;
            this.actionsMenu.TabStop = false;
            // 
            // buildingsTab
            // 
            this.buildingsTab.Location = new System.Drawing.Point(4, 4);
            this.buildingsTab.Name = "buildingsTab";
            this.buildingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.buildingsTab.Size = new System.Drawing.Size(208, 741);
            this.buildingsTab.TabIndex = 0;
            this.buildingsTab.Text = "Constructions";
            this.buildingsTab.UseVisualStyleBackColor = true;
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
            // GamePageUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.actionsMenu);
            this.Name = "GamePageUC";
            this.Size = new System.Drawing.Size(216, 768);
            this.actionsMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl actionsMenu;
        private System.Windows.Forms.TabPage buildingsTab;
        private System.Windows.Forms.TabPage happinessTab;
        private System.Windows.Forms.TabPage faithTab;
        private System.Windows.Forms.TabPage godSpellsTab;

    }
}
