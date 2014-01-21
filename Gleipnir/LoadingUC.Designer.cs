namespace GamePages
{
    partial class LoadingUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingUC));
            this.loading_text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loading_text
            // 
            this.loading_text.BackColor = System.Drawing.Color.Transparent;
            this.loading_text.CausesValidation = false;
            this.loading_text.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            resources.ApplyResources(this.loading_text, "loading_text");
            this.loading_text.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.loading_text.Image = global::GamePages.Properties.Resources.Sablier2;
            this.loading_text.Name = "loading_text";
            this.loading_text.UseCompatibleTextRendering = true;
            // 
            // LoadingUC
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::GamePages.Properties.Resources.Loading_Text;
            this.Controls.Add(this.loading_text);
            this.Name = "LoadingUC";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label loading_text;



    }
}
