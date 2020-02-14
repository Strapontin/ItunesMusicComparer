namespace ItunesMusicComparer.Views
{
    partial class FormShowFilesMissing
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
            this.flpMusicMissingFromPlaylists = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flpMusicsMissingFromFolders = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpMusicMissingFromPlaylists
            // 
            this.flpMusicMissingFromPlaylists.AutoScroll = true;
            this.flpMusicMissingFromPlaylists.Location = new System.Drawing.Point(12, 31);
            this.flpMusicMissingFromPlaylists.Name = "flpMusicMissingFromPlaylists";
            this.flpMusicMissingFromPlaylists.Size = new System.Drawing.Size(542, 407);
            this.flpMusicMissingFromPlaylists.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Musiques non comprises dans les playlists";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(689, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(287, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Musiques dans les playlists non comprises dans les dossiers";
            // 
            // flpMusicsMissingFromFolders
            // 
            this.flpMusicsMissingFromFolders.AutoScroll = true;
            this.flpMusicsMissingFromFolders.Location = new System.Drawing.Point(560, 31);
            this.flpMusicsMissingFromFolders.Name = "flpMusicsMissingFromFolders";
            this.flpMusicsMissingFromFolders.Size = new System.Drawing.Size(470, 407);
            this.flpMusicsMissingFromFolders.TabIndex = 2;
            // 
            // FormShowFilesMissing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flpMusicsMissingFromFolders);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flpMusicMissingFromPlaylists);
            this.Name = "FormShowFilesMissing";
            this.Text = "FormShowFilesMissing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpMusicMissingFromPlaylists;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flpMusicsMissingFromFolders;
    }
}