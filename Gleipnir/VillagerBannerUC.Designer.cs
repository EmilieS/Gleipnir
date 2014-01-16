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
            this.VillagerName.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VillagerName.ForeColor = System.Drawing.Color.Navy;
            this.VillagerName.Location = new System.Drawing.Point(50, 7);
            this.VillagerName.Name = "VillagerName";
            this.VillagerName.Size = new System.Drawing.Size(42, 15);
            this.VillagerName.TabIndex = 0;
            this.VillagerName.Text = "Name";
            // 
            // VillagerFace
            // 
            this.VillagerFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VillagerFace.Location = new System.Drawing.Point(6, 5);
            this.VillagerFace.Name = "VillagerFace";
            this.VillagerFace.Size = new System.Drawing.Size(40, 40);
            this.VillagerFace.TabIndex = 1;
            this.VillagerFace.TabStop = false;
            // 
            // VillagerBannerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::GamePages.Properties.Resources.GameEventUC_backgroung;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.VillagerFace);
            this.Controls.Add(this.VillagerName);
            this.DoubleBuffered = true;
            this.Name = "VillagerBannerUC";
            this.Size = new System.Drawing.Size(178, 50);
            ((System.ComponentModel.ISupportInitialize)(this.VillagerFace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label VillagerName;
        internal System.Windows.Forms.PictureBox VillagerFace;
    }
}
