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
            this.Job_label = new System.Windows.Forms.Label();
            this.Sick_status_pic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.VillagerFace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sick_status_pic)).BeginInit();
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
            // Job_label
            // 
            this.Job_label.AutoSize = true;
            this.Job_label.ForeColor = System.Drawing.Color.Navy;
            this.Job_label.Location = new System.Drawing.Point(53, 26);
            this.Job_label.Name = "Job_label";
            this.Job_label.Size = new System.Drawing.Size(36, 13);
            this.Job_label.TabIndex = 2;
            this.Job_label.Text = "Métier";
            // 
            // Sick_status_pic
            // 
            this.Sick_status_pic.BackgroundImage = global::GamePages.Properties.Resources.ButtonIcon_epidemic;
            this.Sick_status_pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Sick_status_pic.InitialImage = null;
            this.Sick_status_pic.Location = new System.Drawing.Point(148, 16);
            this.Sick_status_pic.Name = "Sick_status_pic";
            this.Sick_status_pic.Size = new System.Drawing.Size(20, 20);
            this.Sick_status_pic.TabIndex = 3;
            this.Sick_status_pic.TabStop = false;
            this.Sick_status_pic.Visible = false;
            // 
            // VillagerBannerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::GamePages.Properties.Resources.GameEventUC_backgroung;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.Sick_status_pic);
            this.Controls.Add(this.Job_label);
            this.Controls.Add(this.VillagerFace);
            this.Controls.Add(this.VillagerName);
            this.DoubleBuffered = true;
            this.Name = "VillagerBannerUC";
            this.Size = new System.Drawing.Size(178, 50);
            ((System.ComponentModel.ISupportInitialize)(this.VillagerFace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sick_status_pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label VillagerName;
        internal System.Windows.Forms.PictureBox VillagerFace;
        internal System.Windows.Forms.Label Job_label;
        internal System.Windows.Forms.PictureBox Sick_status_pic;
    }
}
