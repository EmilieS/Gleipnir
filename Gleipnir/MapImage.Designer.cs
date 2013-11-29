namespace GamePages
{
    partial class MapImage
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
            this.mapPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mapPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // mapPicture
            // 
            this.mapPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapPicture.BackgroundImage = global::GamePages.Properties.Resources.carte;
            this.mapPicture.Location = new System.Drawing.Point(0, 0);
            this.mapPicture.Name = "mapPicture";
            this.mapPicture.Size = new System.Drawing.Size(640, 400);
            this.mapPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mapPicture.TabIndex = 0;
            this.mapPicture.TabStop = false;
            // 
            // MapImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.mapPicture);
            this.Location = new System.Drawing.Point(200, 40);
            this.Name = "MapImage";
            this.Size = new System.Drawing.Size(640, 400);
            ((System.ComponentModel.ISupportInitialize)(this.mapPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mapPicture;
    }
}
