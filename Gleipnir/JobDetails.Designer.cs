namespace GamePages
{
    partial class JobDetails
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
            this.jobName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.happinessPerTick = new System.Windows.Forms.Label();
            this.goldPerTick1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.jobWorkerCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.viewWorkersList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // jobName
            // 
            this.jobName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jobName.AutoSize = true;
            this.jobName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobName.Location = new System.Drawing.Point(38, 9);
            this.jobName.Name = "jobName";
            this.jobName.Size = new System.Drawing.Size(138, 25);
            this.jobName.TabIndex = 0;
            this.jobName.Text = "Nom du métier";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Revenus";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Personnel";
            // 
            // happinessPerTick
            // 
            this.happinessPerTick.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.happinessPerTick.AutoSize = true;
            this.happinessPerTick.Location = new System.Drawing.Point(123, 95);
            this.happinessPerTick.Name = "happinessPerTick";
            this.happinessPerTick.Size = new System.Drawing.Size(67, 13);
            this.happinessPerTick.TabIndex = 4;
            this.happinessPerTick.Text = "Nb_Bonheur";
            // 
            // goldPerTick1
            // 
            this.goldPerTick1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.goldPerTick1.AutoSize = true;
            this.goldPerTick1.Location = new System.Drawing.Point(152, 75);
            this.goldPerTick1.Name = "goldPerTick1";
            this.goldPerTick1.Size = new System.Drawing.Size(38, 13);
            this.goldPerTick1.TabIndex = 5;
            this.goldPerTick1.Text = "Nb_Or";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bonheur généré :";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Or généré :";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nombre total :";
            // 
            // jobWorkerCount
            // 
            this.jobWorkerCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.jobWorkerCount.AutoSize = true;
            this.jobWorkerCount.Location = new System.Drawing.Point(115, 172);
            this.jobWorkerCount.Name = "jobWorkerCount";
            this.jobWorkerCount.Size = new System.Drawing.Size(74, 13);
            this.jobWorkerCount.TabIndex = 9;
            this.jobWorkerCount.Text = "Nb_Personnel";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Liste du personnel :";
            // 
            // viewWorkersList
            // 
            this.viewWorkersList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.viewWorkersList.Location = new System.Drawing.Point(140, 188);
            this.viewWorkersList.Name = "viewWorkersList";
            this.viewWorkersList.Size = new System.Drawing.Size(45, 23);
            this.viewWorkersList.TabIndex = 11;
            this.viewWorkersList.Text = "Voir";
            this.viewWorkersList.UseVisualStyleBackColor = true;
            // 
            // JobDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.viewWorkersList);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.jobWorkerCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.goldPerTick1);
            this.Controls.Add(this.happinessPerTick);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.jobName);
            this.Name = "JobDetails";
            this.Size = new System.Drawing.Size(215, 260);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label jobName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label happinessPerTick;
        private System.Windows.Forms.Label goldPerTick1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label jobWorkerCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button viewWorkersList;
    }
}
