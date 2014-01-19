namespace GamePages
{
    partial class VillagerBannerUC
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
            this.VillagerName = new System.Windows.Forms.Label();
            this.VillagerFace = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.VillagerFace)).BeginInit();
            this.SuspendLayout();
            // 
            // VillagerName
            // 
            this.VillagerName.AutoSize = true;
            this.VillagerName.Location = new System.Drawing.Point(68, 23);
            this.VillagerName.Name = "VillagerName";
            this.VillagerName.Size = new System.Drawing.Size(35, 13);
            this.VillagerName.TabIndex = 0;
            this.VillagerName.Text = "Name";
            // 
            // VillagerFace
            // 
            this.VillagerFace.Location = new System.Drawing.Point(3, 14);
            this.VillagerFace.Name = "VillagerFace";
            this.VillagerFace.Size = new System.Drawing.Size(37, 38);
            this.VillagerFace.TabIndex = 1;
            this.VillagerFace.TabStop = false;
            // 
            // VillagerBannerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.VillagerFace);
            this.Controls.Add(this.VillagerName);
            this.Name = "VillagerBannerUC";
            this.Size = new System.Drawing.Size(210, 76);
            ((System.ComponentModel.ISupportInitialize)(this.VillagerFace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label VillagerName;
        private System.Windows.Forms.PictureBox VillagerFace;
    }
}
