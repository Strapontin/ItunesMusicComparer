using ItunesMusicComparer.Classes;
using ItunesMusicComparer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItunesMusicComparer.Views
{
    public partial class FormShowFilesMissing : Form
    {
        FolderFileHelper ffh;


        public FormShowFilesMissing()
        {
            InitializeComponent();

            ffh = new FolderFileHelper();
        }

        /// <summary>
        /// Ajoute une musiques dans le flowLayoutPanel
        /// </summary>
        /// <param name="musicCharacteristic"></param>
        public void AddMusicMissingFromPlaylist(MusicCharacteristic mc)
        {
            // On ajoute la musique dans le flp
            ffh.AddMusicPathOrFolderToFLP(mc.Title, mc.Author, flpMusicMissingFromPlaylists);
        }


        public void ClearMusicMissingFromPlaylist()
        {
            flpMusicMissingFromPlaylists.Controls.Clear();
        }
    }
}
