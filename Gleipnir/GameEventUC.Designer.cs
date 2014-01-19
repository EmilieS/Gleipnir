namespace GamePages
{
    partial class GameEventUC
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
            this.EventTitle = new System.Windows.Forms.Label();
            this.EventContain = new System.Windows.Forms.Label();
            this.EventContain2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EventTitle
            // 
            this.EventTitle.AutoSize = true;
            this.EventTitle.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventTitle.ForeColor = System.Drawing.Color.Maroon;
            this.EventTitle.Location = new System.Drawing.Point(19, 5);
            this.EventTitle.Name = "EventTitle";
            this.EventTitle.Size = new System.Drawing.Size(85, 19);
            this.EventTitle.TabIndex = 0;
            this.EventTitle.Text = "Evenement";
            // 
            // EventContain
            // 
            this.EventContain.AutoSize = true;
            this.EventContain.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventContain.ForeColor = System.Drawing.Color.Navy;
            this.EventContain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EventContain.Location = new System.Drawing.Point(8, 26);
            this.EventContain.Name = "EventContain";
            this.EventContain.Size = new System.Drawing.Size(84, 15);
            this.EventContain.TabIndex = 1;
            this.EventContain.Text = "Blah blah blah";
            // 
            // EventContain2
            // 
            this.EventContain2.AutoSize = true;
            this.EventContain2.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventContain2.ForeColor = System.Drawing.Color.Navy;
            this.EventContain2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EventContain2.Location = new System.Drawing.Point(8, 43);
            this.EventContain2.Name = "EventContain2";
            this.EventContain2.Size = new System.Drawing.Size(84, 15);
            this.EventContain2.TabIndex = 2;
            this.EventContain2.Text = "Blah blah blah";
            // 
            // GameEventUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::GamePages.Properties.Resources.GameEventUC_backgroung;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.EventContain2);
            this.Controls.Add(this.EventTitle);
            this.Controls.Add(this.EventContain);
            this.DoubleBuffered = true;
            this.Name = "GameEventUC";
            this.Size = new System.Drawing.Size(240, 65);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label EventTitle;
        internal System.Windows.Forms.Label EventContain;
        internal System.Windows.Forms.Label EventContain2;
    }
}
