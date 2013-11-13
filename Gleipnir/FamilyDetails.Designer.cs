namespace GamePages
{
    partial class FamilyDetails
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
            this.familyName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.viewFamilyList = new System.Windows.Forms.Button();
            this.familyMemberCount = new System.Windows.Forms.Label();
            this.familyGold = new System.Windows.Forms.Label();
            this.familyHappiness = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.familyFaith = new System.Windows.Forms.Label();
            this.familyConvocation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // familyName
            // 
            this.familyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.familyName.AutoSize = true;
            this.familyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.familyName.Location = new System.Drawing.Point(38, 9);
            this.familyName.Name = "familyName";
            this.familyName.Size = new System.Drawing.Size(140, 25);
            this.familyName.TabIndex = 1;
            this.familyName.Text = "Nom de famille";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "État";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Or :";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Bonheur :";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Liste des membres :";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Nombre total :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Membres";
            // 
            // viewFamilyList
            // 
            this.viewFamilyList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.viewFamilyList.Location = new System.Drawing.Point(142, 193);
            this.viewFamilyList.Name = "viewFamilyList";
            this.viewFamilyList.Size = new System.Drawing.Size(45, 23);
            this.viewFamilyList.TabIndex = 14;
            this.viewFamilyList.Text = "Voir";
            this.viewFamilyList.UseVisualStyleBackColor = true;
            // 
            // familyMemberCount
            // 
            this.familyMemberCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.familyMemberCount.AutoSize = true;
            this.familyMemberCount.Location = new System.Drawing.Point(118, 177);
            this.familyMemberCount.Name = "familyMemberCount";
            this.familyMemberCount.Size = new System.Drawing.Size(70, 13);
            this.familyMemberCount.TabIndex = 15;
            this.familyMemberCount.Text = "Nb_Membres";
            // 
            // familyGold
            // 
            this.familyGold.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.familyGold.AutoSize = true;
            this.familyGold.Location = new System.Drawing.Point(150, 80);
            this.familyGold.Name = "familyGold";
            this.familyGold.Size = new System.Drawing.Size(38, 13);
            this.familyGold.TabIndex = 17;
            this.familyGold.Text = "Nb_Or";
            // 
            // familyHappiness
            // 
            this.familyHappiness.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.familyHappiness.AutoSize = true;
            this.familyHappiness.Location = new System.Drawing.Point(120, 100);
            this.familyHappiness.Name = "familyHappiness";
            this.familyHappiness.Size = new System.Drawing.Size(67, 13);
            this.familyHappiness.TabIndex = 16;
            this.familyHappiness.Text = "Nb_Bonheur";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Foi :";
            // 
            // familyFaith
            // 
            this.familyFaith.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.familyFaith.AutoSize = true;
            this.familyFaith.Location = new System.Drawing.Point(146, 122);
            this.familyFaith.Name = "familyFaith";
            this.familyFaith.Size = new System.Drawing.Size(41, 13);
            this.familyFaith.TabIndex = 19;
            this.familyFaith.Text = "Nb_Foi";
            // 
            // familyConvocation
            // 
            this.familyConvocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.familyConvocation.Location = new System.Drawing.Point(19, 224);
            this.familyConvocation.Name = "familyConvocation";
            this.familyConvocation.Size = new System.Drawing.Size(169, 23);
            this.familyConvocation.TabIndex = 20;
            this.familyConvocation.Text = "Convoquer";
            this.familyConvocation.UseVisualStyleBackColor = true;
            // 
            // FamilyDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.familyConvocation);
            this.Controls.Add(this.familyFaith);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.familyGold);
            this.Controls.Add(this.familyHappiness);
            this.Controls.Add(this.familyMemberCount);
            this.Controls.Add(this.viewFamilyList);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.familyName);
            this.Name = "FamilyDetails";
            this.Size = new System.Drawing.Size(215, 260);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label familyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button viewFamilyList;
        private System.Windows.Forms.Label familyMemberCount;
        private System.Windows.Forms.Label familyGold;
        private System.Windows.Forms.Label familyHappiness;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label familyFaith;
        private System.Windows.Forms.Button familyConvocation;
    }
}
