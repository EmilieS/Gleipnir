namespace GamePages
{
    partial class GeneralPage
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralPage));
            this.gleipnir_logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gleipnir_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // gleipnir_logo
            // 
            this.gleipnir_logo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gleipnir_logo.BackColor = System.Drawing.Color.Transparent;
            this.gleipnir_logo.Image = global::GamePages.Properties.Resources.logo_lava_salpha;
            this.gleipnir_logo.Location = new System.Drawing.Point(75, -60);
            this.gleipnir_logo.Name = "gleipnir_logo";
            this.gleipnir_logo.Size = new System.Drawing.Size(1000, 271);
            this.gleipnir_logo.TabIndex = 0;
            this.gleipnir_logo.TabStop = false;
            // 
            // GeneralPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = global::GamePages.Properties.Resources.GeneralPage_background;
            this.ClientSize = new System.Drawing.Size(1140, 612);
            this.Controls.Add(this.gleipnir_logo);
            this.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 550);
            this.Name = "GeneralPage";
            this.Text = "Gleipnir";
            ((System.ComponentModel.ISupportInitialize)(this.gleipnir_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox gleipnir_logo;

    }
}

