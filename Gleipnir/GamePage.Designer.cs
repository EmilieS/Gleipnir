namespace GamePages
{
    partial class GamePage
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dialogTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dialogTextBox
            // 
            this.dialogTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dialogTextBox.Location = new System.Drawing.Point(218, 568);
            this.dialogTextBox.Multiline = true;
            this.dialogTextBox.Name = "dialogTextBox";
            this.dialogTextBox.ReadOnly = true;
            this.dialogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dialogTextBox.Size = new System.Drawing.Size(558, 150);
            this.dialogTextBox.TabIndex = 5;
            this.dialogTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GamePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.dialogTextBox);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Name = "GamePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dialogTextBox;
    }
}

