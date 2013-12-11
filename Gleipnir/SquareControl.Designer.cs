using System.Drawing;
using System.Windows.Forms;
namespace GamePages
{
    partial class SquareControl
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
            this.SuspendLayout();
            // 
            // SquareControl
            // 
            this.Name = "SquareControl";
            this.Size = new System.Drawing.Size(20, 20);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Grid_paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
