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
            this.GoBack.BackColor = System.Drawing.Color.Transparent;
            this.GoBack.BackgroundImage = global::GamePages.Properties.Resources.button_homepage1;
            this.GoBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GoBack.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoBack.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.GoBack.Location = new System.Drawing.Point(3, 3);
            this.GoBack.Name = "GoBack";
            this.GoBack.Size = new System.Drawing.Size(152, 36);
            this.GoBack.TabIndex = 0;
            this.GoBack.Text = "Menu Principal";
            this.GoBack.UseVisualStyleBackColor = false;
            this.GoBack.Click += new System.EventHandler(this.GoBack_Click);
            // 
            // InGameSettings
            // 
            this.InGameSettings.BackColor = System.Drawing.Color.Transparent;
            this.InGameSettings.BackgroundImage = global::GamePages.Properties.Resources.button_homepage;
            this.InGameSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.InGameSettings.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InGameSettings.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.InGameSettings.Location = new System.Drawing.Point(3, 45);
            this.InGameSettings.Name = "InGameSettings";
            this.InGameSettings.Size = new System.Drawing.Size(152, 36);
            this.InGameSettings.TabIndex = 1;
            this.InGameSettings.Text = "Paramètres";
            this.InGameSettings.UseVisualStyleBackColor = false;
            this.InGameSettings.Click += new System.EventHandler(this.InGameSettings_Click);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.Transparent;
            this.Save.BackgroundImage = global::GamePages.Properties.Resources.button_homepage;
            this.Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Save.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Save.Location = new System.Drawing.Point(3, 87);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(152, 36);
            this.Save.TabIndex = 2;
            this.Save.Text = "Sauvegarder";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // InGameQuit
            // 
            this.InGameQuit.BackColor = System.Drawing.Color.Transparent;
            this.InGameQuit.BackgroundImage = global::GamePages.Properties.Resources.button_homepage;
            this.InGameQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.InGameQuit.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InGameQuit.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.InGameQuit.Location = new System.Drawing.Point(3, 129);
            this.InGameQuit.Name = "InGameQuit";
            this.InGameQuit.Size = new System.Drawing.Size(152, 36);
            this.InGameQuit.TabIndex = 3;
            this.InGameQuit.Text = "Retour au Jeu";
            this.InGameQuit.UseVisualStyleBackColor = false;
            this.InGameQuit.Click += new System.EventHandler(this.InGameQuit_Click);
            // 
            // InGameMenu
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::GamePages.Properties.Resources.GeneralPage_background;
            this.Controls.Add(this.InGameQuit);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.InGameSettings);
            this.Controls.Add(this.GoBack);
            this.Location = new System.Drawing.Point(500, 150);
            this.Name = "InGameMenu";
            this.Size = new System.Drawing.Size(158, 168);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GoBack;
        private System.Windows.Forms.Button InGameSettings;
        private System.Windows.Forms.Button Save;
        internal System.Windows.Forms.Button InGameQuit;
    }
}
