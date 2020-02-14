using ItunesMusicComparer.Classes;
using ItunesMusicComparer.Models;
using ItunesMusicComparer.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ItunesMusicComparer
{
    public partial class Form1 : Form
    {
        FolderFileHelper ffh;

        public Form1()
        {
            InitializeComponent();

            ffh = new FolderFileHelper();
        }

        /// <summary>
        /// Lors du clique sur le bouton pour sélectionner des fichiers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChoosePlaylistFile(object sender, EventArgs e)
        {
            //var fileContent = string.Empty;
            var filesData = new List<FileData>();
            FileData fileData;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                // Lorsque l'on a sélectionné les fichiers
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Récupère les noms des fichiers
                    for (int i = 0; i < openFileDialog.SafeFileNames.Length; i++)
                    {
                        fileData = new FileData(openFileDialog.SafeFileNames[i], openFileDialog.FileNames[i]);
                        filesData.Add(fileData);
                    }


                    if (filesData.Any())
                    {
                        // Ajoute les noms des fichiers dans la liste
                        foreach (var item in filesData)
                        {
                            ffh.AddFilePathOrFolderToFLP(item.FileName, item.FullPath, flpFilesSelected);
                        }
                    }

                    ////Read the contents of the file into a stream
                    //var fileStream = openFileDialog.OpenFile();

                    //using (StreamReader reader = new StreamReader(fileStream))
                    //{
                    //    fileContent = reader.ReadToEnd();
                    //}
                }
            }

            //MessageBox.Show(fileContent, "File Content at path: " + filePaths, MessageBoxButtons.OK);
        }

        /// <summary>
        /// Lorsque l'on clique sur le bouton pour choisir un dossier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseFolders(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                // Si on a bien sélectionné un fichier
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    // On ajoute le chemin entier dans le FLP
                    ffh.AddFilePathOrFolderToFLP(folderBrowserDialog.SelectedPath, folderBrowserDialog.SelectedPath, flpFolderSelection);
                }
            }
        }

        /// <summary>
        /// Quand on clique sur le bouton pour recherche les musiques manquantes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindDifferences(object sender, EventArgs e)
        {
            // On lit les playlists et les musiques qu'on est censés trouver
            var allWantedMusicsFromPlaylists = ffh.ReadPlaylists(flpFilesSelected);


            // On lit les musiques présentes dans les dossiers sélectionnés
            var allMusicsFromFolders = ffh.ReadMusics(flpFolderSelection);


            // On cherche toutes les musiques présentes dans une variable et pas dans l'autre pour l'afficher dans l'autre fenêtre
            List<MusicCharacteristic> musicsMissingFromPlaylists = new List<MusicCharacteristic>();
            List<MusicCharacteristic> musicsMissingFromFolders = new List<MusicCharacteristic>();

            var form = new FormShowFilesMissing();


            foreach (var mfp in allWantedMusicsFromPlaylists)
            {
                if (!allMusicsFromFolders.Any(fromFolder => fromFolder.Author == mfp.Author && fromFolder.Title == mfp.Title))
                {
                    musicsMissingFromFolders.Add(mfp);
                }
            }

            form.ClearMusicMissingFromPlaylist();

            foreach (var mff in allMusicsFromFolders)
            {
                if (!allWantedMusicsFromPlaylists.Any(fromPlaylist => fromPlaylist.Author == mff.Author && fromPlaylist.Title == mff.Title))
                {
                    form.AddMusicMissingFromPlaylist(mff);
                    //musicsMissingFromPlaylists.Add(mff);
                }
            }


            form.Show();
        }
    }
}
