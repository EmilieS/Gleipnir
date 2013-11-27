namespace GamePages
{
    partial class traceBox
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
            this.traceBoxViewer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // traceBoxViewer
            // 
            this.traceBoxViewer.Location = new System.Drawing.Point(12, 12);
            this.traceBoxViewer.Multiline = true;
            this.traceBoxViewer.Name = "traceBoxViewer";
            this.traceBoxViewer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.traceBoxViewer.Size = new System.Drawing.Size(477, 330);
            this.traceBoxViewer.TabIndex = 0;
            // 
            // traceBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 354);
            this.Controls.Add(this.traceBoxViewer);
            this.Name = "traceBox";
            this.Text = "Trace";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox traceBoxViewer;


    }
}