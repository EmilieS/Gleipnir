﻿namespace GamePages
{
    partial class EventFluxUC
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
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.gameEventUC1 = new GamePages.GameEventUC();
            this.SuspendLayout();
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(211, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 200);
            this.vScrollBar1.TabIndex = 0;
            // 
            // gameEventUC1
            // 
            this.gameEventUC1.Location = new System.Drawing.Point(0, 0);
            this.gameEventUC1.Name = "gameEventUC1";
            this.gameEventUC1.Size = new System.Drawing.Size(208, 95);
            this.gameEventUC1.TabIndex = 1;
            // 
            // EventFluxUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gameEventUC1);
            this.Controls.Add(this.vScrollBar1);
            this.Location = new System.Drawing.Point(730, 50);
            this.Name = "EventFluxUC";
            this.Size = new System.Drawing.Size(228, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar vScrollBar1;
        private GameEventUC gameEventUC1;
    }
}
