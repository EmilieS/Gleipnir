namespace GamePages
{
    partial class InGameMenu
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
            this.GoBack = new System.Windows.Forms.Button();
            this.InGameSettings = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.InGameQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GoBack
            // 
            this.GoBack.BackgroundImage = global::GamePages.Properties.Resources.button_homepage1;
            this.GoBack.Location = new System.Drawing.Point(3, 3);
            this.GoBack.Name = "GoBack";
            this.GoBack.Size = new System.Drawing.Size(152, 36);
            this.GoBack.TabIndex = 0;
            this.GoBack.Text = "Menu Principal";
            this.GoBack.UseVisualStyleBackColor = true;
            this.GoBack.Click += new System.EventHandler(this.GoBack_Click);
            // 
            // InGameSettings
            // 
            this.InGameSettings.BackgroundImage = global::GamePages.Properties.Resources.button_homepage;
            this.InGameSettings.Location = new System.Drawing.Point(3, 45);
            this.InGameSettings.Name = "InGameSettings";
            this.InGameSettings.Size = new System.Drawing.Size(152, 36);
            this.InGameSettings.TabIndex = 1;
            this.InGameSettings.Text = "Paramètres";
            this.InGameSettings.UseVisualStyleBackColor = true;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(3, 87);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(152, 36);
            this.Save.TabIndex = 2;
            this.Save.Text = "Sauver";
            this.Save.UseVisualStyleBackColor = true;
            // 
            // InGameQuit
            // 
            this.InGameQuit.Location = new System.Drawing.Point(3, 129);
            this.InGameQuit.Name = "InGameQuit";
            this.InGameQuit.Size = new System.Drawing.Size(152, 36);
            this.InGameQuit.TabIndex = 3;
            this.InGameQuit.Text = "Quitter";
            this.InGameQuit.UseVisualStyleBackColor = true;
            // 
            // InGameMenu
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.InGameQuit);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.InGameSettings);
            this.Controls.Add(this.GoBack);
            this.Location = new System.Drawing.Point(996, 60);
            this.Name = "InGameMenu";
            this.Size = new System.Drawing.Size(158, 168);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GoBack;
        private System.Windows.Forms.Button InGameSettings;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button InGameQuit;
    }
}
