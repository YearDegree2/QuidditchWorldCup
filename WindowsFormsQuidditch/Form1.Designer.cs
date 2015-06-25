namespace WindowsFormsQuidditch
{
    partial class Form1
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonMatch = new System.Windows.Forms.Button();
            this.listBoxMatch = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonMatch
            // 
            this.buttonMatch.Location = new System.Drawing.Point(180, 38);
            this.buttonMatch.Name = "buttonMatch";
            this.buttonMatch.Size = new System.Drawing.Size(146, 23);
            this.buttonMatch.TabIndex = 0;
            this.buttonMatch.Text = "Display matchs";
            this.buttonMatch.UseVisualStyleBackColor = true;
            this.buttonMatch.Click += new System.EventHandler(this.buttonMatch_Click);
            // 
            // listBoxMatch
            // 
            this.listBoxMatch.FormattingEnabled = true;
            this.listBoxMatch.Location = new System.Drawing.Point(28, 86);
            this.listBoxMatch.Name = "listBoxMatch";
            this.listBoxMatch.Size = new System.Drawing.Size(463, 290);
            this.listBoxMatch.TabIndex = 1;
            this.listBoxMatch.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 450);
            this.Controls.Add(this.listBoxMatch);
            this.Controls.Add(this.buttonMatch);
            this.Name = "Form1";
            this.Text = "Home";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonMatch;
        private System.Windows.Forms.ListBox listBoxMatch;
    }
}

