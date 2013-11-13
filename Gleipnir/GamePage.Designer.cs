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
            this.groupInfoBox = new System.Windows.Forms.GroupBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.mapBackground = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.SuspendLayout();
            // 
            this.eventFlux.Location = new System.Drawing.Point(796, 37);
            this.eventFlux.Size = new System.Drawing.Size(200, 415);
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
            // 
            this.groupInfoBox.Location = new System.Drawing.Point(782, 458);
            this.groupInfoBox.Name = "groupInfoBox";
            this.groupInfoBox.Size = new System.Drawing.Size(214, 260);
            this.groupInfoBox.TabIndex = 13;
            this.groupInfoBox.TabStop = false;
            this.groupInfoBox.Text = "Informations";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.mapBackground});
            this.shapeContainer1.Size = new System.Drawing.Size(1008, 730);
            this.shapeContainer1.TabIndex = 14;
            this.shapeContainer1.TabStop = false;
            // 
            // mapBackground
            // 
            this.mapBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapBackground.BackgroundImage = global::GamePages.Properties.Resources.Ebauche_Carte_du_Monde;
            this.mapBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mapBackground.Location = new System.Drawing.Point(218, 37);
            this.mapBackground.Name = "mapBackground";
            this.mapBackground.Size = new System.Drawing.Size(555, 525);
            // 
            // GamePage
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.groupInfoBox);
            this.Controls.Add(this.dialogTextBox);
            this.Controls.Add(this.shapeContainer1);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Name = "GamePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dialogTextBox;
        private System.Windows.Forms.GroupBox groupInfoBox;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape mapBackground;
    }
}

