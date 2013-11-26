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
            this.SuspendLayout();
            // 
            // EventTitle
            // 
            this.EventTitle.AutoSize = true;
            this.EventTitle.Location = new System.Drawing.Point(4, 4);
            this.EventTitle.Name = "EventTitle";
            this.EventTitle.Size = new System.Drawing.Size(61, 13);
            this.EventTitle.TabIndex = 0;
            this.EventTitle.Text = "Evenement";
            // 
            // EventContain
            // 
            this.EventContain.AutoSize = true;
            this.EventContain.Location = new System.Drawing.Point(4, 27);
            this.EventContain.Name = "EventContain";
            this.EventContain.Size = new System.Drawing.Size(74, 13);
            this.EventContain.TabIndex = 1;
            this.EventContain.Text = "Blah blah blah";
            // 
            // GameEventUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EventContain);
            this.Controls.Add(this.EventTitle);
            this.Name = "GameEventUC";
            this.Size = new System.Drawing.Size(269, 98);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EventTitle;
        private System.Windows.Forms.Label EventContain;
    }
}
