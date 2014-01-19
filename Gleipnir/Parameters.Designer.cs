namespace GamePages
{
    partial class Parameters
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.timerTitle = new System.Windows.Forms.Label();
            this.timerTrackBar = new System.Windows.Forms.TrackBar();
            this.timerValue = new System.Windows.Forms.Label();
            this.noTimerButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.timerTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // timerTitle
            // 
            this.timerTitle.AutoSize = true;
            this.timerTitle.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerTitle.Location = new System.Drawing.Point(16, 11);
            this.timerTitle.Name = "timerTitle";
            this.timerTitle.Size = new System.Drawing.Size(300, 21);
            this.timerTitle.TabIndex = 0;
            this.timerTitle.Text = "Réglage vitesse du passage du temps";
            // 
            // timerTrackBar
            // 
            this.timerTrackBar.AutoSize = false;
            this.timerTrackBar.BackColor = System.Drawing.Color.Peru;
            this.timerTrackBar.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.timerTrackBar.Location = new System.Drawing.Point(29, 35);
            this.timerTrackBar.Maximum = 10000;
            this.timerTrackBar.Minimum = 500;
            this.timerTrackBar.Name = "timerTrackBar";
            this.timerTrackBar.Size = new System.Drawing.Size(150, 35);
            this.timerTrackBar.TabIndex = 1;
            this.timerTrackBar.Value = 500;
            this.timerTrackBar.ValueChanged += new System.EventHandler(this.timerTrackBar_ValueChanged);
            // 
            // timerValue
            // 
            this.timerValue.AutoSize = true;
            this.timerValue.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerValue.Location = new System.Drawing.Point(185, 44);
            this.timerValue.Name = "timerValue";
            this.timerValue.Size = new System.Drawing.Size(50, 19);
            this.timerValue.TabIndex = 2;
            this.timerValue.Text = "label2";
            // 
            // noTimerButton
            // 
            this.noTimerButton.BackgroundImage = global::GamePages.Properties.Resources.button_homepage;
            this.noTimerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.noTimerButton.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noTimerButton.ForeColor = System.Drawing.Color.Navy;
            this.noTimerButton.Location = new System.Drawing.Point(39, 76);
            this.noTimerButton.Name = "noTimerButton";
            this.noTimerButton.Size = new System.Drawing.Size(268, 29);
            this.noTimerButton.TabIndex = 3;
            this.noTimerButton.Text = "Ne pas avoir un écoulement du temps";
            this.noTimerButton.UseVisualStyleBackColor = true;
            this.noTimerButton.Click += new System.EventHandler(this.noTimerButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.BackgroundImage = global::GamePages.Properties.Resources.button_homepage;
            this.quitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.quitButton.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.ForeColor = System.Drawing.Color.Navy;
            this.quitButton.Location = new System.Drawing.Point(254, 156);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(78, 25);
            this.quitButton.TabIndex = 4;
            this.quitButton.Text = "Quitter";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // Parameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::GamePages.Properties.Resources.ScenarioBox_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.noTimerButton);
            this.Controls.Add(this.timerValue);
            this.Controls.Add(this.timerTrackBar);
            this.Controls.Add(this.timerTitle);
            this.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(440, 260);
            this.Name = "Parameters";
            this.Size = new System.Drawing.Size(335, 187);
            ((System.ComponentModel.ISupportInitialize)(this.timerTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timerTitle;
        private System.Windows.Forms.TrackBar timerTrackBar;
        private System.Windows.Forms.Label timerValue;
        private System.Windows.Forms.Button noTimerButton;
        private System.Windows.Forms.Button quitButton;
    }
}
