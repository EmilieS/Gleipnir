namespace GamePages
{
    partial class HomepageUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomepageUC));
            this.exit = new System.Windows.Forms.Button();
            this.loadGame = new System.Windows.Forms.Button();
            this.settings = new System.Windows.Forms.Button();
            this.newGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // exit
            // 
            this.exit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exit.BackColor = System.Drawing.Color.Transparent;
            this.exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exit.BackgroundImage")));
            this.exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exit.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.exit.Location = new System.Drawing.Point(3, 182);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(214, 50);
            this.exit.TabIndex = 7;
            this.exit.Text = "Quitter";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // loadGame
            // 
            this.loadGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.loadGame.BackColor = System.Drawing.Color.Transparent;
            this.loadGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loadGame.BackgroundImage")));
            this.loadGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loadGame.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadGame.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.loadGame.Location = new System.Drawing.Point(3, 62);
            this.loadGame.Name = "loadGame";
            this.loadGame.Size = new System.Drawing.Size(214, 54);
            this.loadGame.TabIndex = 6;
            this.loadGame.Text = "Charger";
            this.loadGame.UseVisualStyleBackColor = false;
            this.loadGame.Click += new System.EventHandler(this.loadGame_Click);
            // 
            // settings
            // 
            this.settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.settings.BackColor = System.Drawing.Color.Transparent;
            this.settings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("settings.BackgroundImage")));
            this.settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.settings.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.settings.Location = new System.Drawing.Point(3, 122);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(214, 54);
            this.settings.TabIndex = 5;
            this.settings.Text = "Paramètres";
            this.settings.UseVisualStyleBackColor = false;
            // 
            // newGame
            // 
            this.newGame.AccessibleName = "";
            this.newGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newGame.BackColor = System.Drawing.Color.Transparent;
            this.newGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("newGame.BackgroundImage")));
            this.newGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.newGame.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGame.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.newGame.Location = new System.Drawing.Point(3, 2);
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(214, 54);
            this.newGame.TabIndex = 4;
            this.newGame.Text = "Créer une partie";
            this.newGame.UseVisualStyleBackColor = false;
            this.newGame.Click += new System.EventHandler(this.new_game);
            // 
            // HomepageUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GamePages.Properties.Resources.GeneralPage_background;
            this.Controls.Add(this.exit);
            this.Controls.Add(this.loadGame);
            this.Controls.Add(this.settings);
            this.Controls.Add(this.newGame);
            this.Location = new System.Drawing.Point(470, 250);
            this.Name = "HomepageUC";
            this.Size = new System.Drawing.Size(219, 232);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button loadGame;
        private System.Windows.Forms.Button settings;
        private System.Windows.Forms.Button newGame;
    }
}
