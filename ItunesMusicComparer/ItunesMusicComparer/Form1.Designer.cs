﻿namespace ItunesMusicComparer
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
            this.btnChoosePlaylistFile = new System.Windows.Forms.Button();
            this.flpFilesSelected = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // btnChoosePlaylistFile
            // 
            this.btnChoosePlaylistFile.Location = new System.Drawing.Point(34, 24);
            this.btnChoosePlaylistFile.Name = "btnChoosePlaylistFile";
            this.btnChoosePlaylistFile.Size = new System.Drawing.Size(280, 66);
            this.btnChoosePlaylistFile.TabIndex = 0;
            this.btnChoosePlaylistFile.Text = "Choisir les fichiers de playlist";
            this.btnChoosePlaylistFile.UseVisualStyleBackColor = true;
            this.btnChoosePlaylistFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // flpFilesSelected
            // 
            this.flpFilesSelected.AutoScroll = true;
            this.flpFilesSelected.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpFilesSelected.Location = new System.Drawing.Point(34, 112);
            this.flpFilesSelected.Name = "flpFilesSelected";
            this.flpFilesSelected.Size = new System.Drawing.Size(280, 200);
            this.flpFilesSelected.TabIndex = 1;
            this.flpFilesSelected.WrapContents = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 464);
            this.Controls.Add(this.flpFilesSelected);
            this.Controls.Add(this.btnChoosePlaylistFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChoosePlaylistFile;
        private System.Windows.Forms.FlowLayoutPanel flpFilesSelected;
    }
}

