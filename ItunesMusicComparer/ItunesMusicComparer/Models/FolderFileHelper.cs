using ItunesMusicComparer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ItunesMusicComparer.Models
{
    class FolderFileHelper
    {
        /// <summary>
        /// Lorsque l'on supprime un élément de la liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Item_RequestDeleteItem(object sender, ItemDeletedEventArgs e)
        {
            e.Flp.Controls.Remove(e.Flp.Controls.Find((sender as FileListItem).Name, true).First());
        }


        /// <summary>
        /// Ajoute une ligne dans la liste des fichiers sélectionnés
        /// </summary>
        /// <param name="fileName"></param>
        public void AddFilePathOrFolderToFLP(string fileName, string fullPath, FlowLayoutPanel flp)
        {
            if (!FileOrFolderAlreadySelected(fullPath, flp))
            {
                var file = new FileListItem(fileName, fullPath, flp);
                file.RequestDeleteItem += Item_RequestDeleteItem;
                file.Name = fileName;

                flp.Controls.Add(file);
            }
        }


        /// <summary>
        /// Ajoute une musique dans la liste des fichiers sélectionnés
        /// </summary>
        /// <param name="fileName"></param>
        public void AddMusicPathOrFolderToFLP(string songName, string songAuthor, FlowLayoutPanel flp)
        {
            var file = new FileListItem(songAuthor + " - " + songName, string.Empty, flp);
            file.RequestDeleteItem += Item_RequestDeleteItem;
            file.Name = songAuthor + " " + songName;

            flp.Controls.Add(file);
        }


        /// <summary>
        /// Retourne true si le chemin est déjà sélectionné
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        private bool FileOrFolderAlreadySelected(string fullPath, FlowLayoutPanel flp)
        {
            for (int i = 0; i < flp.Controls.Count; i++)
            {
                if ((flp.Controls[i] as FileListItem).FullPath == fullPath)
                    return true;
            }

            return false;
        }


        /// <summary>
        /// Lit les playlists et renvoie une liste des titre/auteur des musiques
        /// </summary>
        /// <returns></returns>
        internal List<MusicCharacteristic> ReadPlaylists(FlowLayoutPanel flp)
        {
            string path;
            List<string> playlistValue = new List<string>();
            List<MusicCharacteristic> mc = new List<MusicCharacteristic>();

            for (int i = 0; i < flp.Controls.Count; i++)
            {
                path = (flp.Controls[i] as FileListItem).FullPath;
                playlistValue.AddRange(File.ReadAllLines(path));
            }

            // On enlève les titres des fichiers
            playlistValue.RemoveAll(pv => pv.Contains("Nombre de mouvements"));

            playlistValue.ForEach(pv =>
            {
                mc.Add(new MusicCharacteristic()
                {
                    Title = pv.Split('\t')[0],
                    Author = pv.Split('\t')[1]
                });
            });

            return mc;
        }


        /// <summary>
        /// Lit les noms des fichiers de musique et renvoie une liste des titres/auteurs
        /// </summary>
        /// <param name="flp"></param>
        /// <returns></returns>
        internal List<MusicCharacteristic> ReadMusics(FlowLayoutPanel flp)
        {
            string path;
            List<string> files = new List<string>();
            List<MusicCharacteristic> mc = new List<MusicCharacteristic>();
            List<string> fileWithoutPath;

            string author;
            string title;

            for (int i = 0; i < flp.Controls.Count; i++)
            {
                path = (flp.Controls[i] as FileListItem).FullPath;
                files.AddRange(Directory.GetFiles(path, "*.mp3"));
            }

            files.ForEach(f =>
            {
                fileWithoutPath = Path.GetFileNameWithoutExtension(f).Split('-').ToList();

                if (fileWithoutPath.Count() == 1)
                {
                    author = fileWithoutPath.First().Trim();
                    title = fileWithoutPath.First().Trim();
                }
                else
                {
                    author = string.Join("-", fileWithoutPath.Take(fileWithoutPath.Count() - 1)).Trim();
                    title = fileWithoutPath.Last().Trim();
                }

                mc.Add(new MusicCharacteristic()
                {
                    Author = author,
                    Title = title
                });
            });

            return mc;
        }
    }
}
