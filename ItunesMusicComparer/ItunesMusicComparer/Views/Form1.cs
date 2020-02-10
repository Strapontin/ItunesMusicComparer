using ItunesMusicComparer.Classes;
using ItunesMusicComparer.Models;
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




                    //var files = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.*", SearchOption.AllDirectories).ToList();


                    //// On enlève le nom des dossiers pour n'avoir que le nom des fichiers
                    //files.ForEach(file =>
                    //{
                    //    file = Path.GetFileNameWithoutExtension(file);
                    //});



                    //flpFolderSelection.Controls.AddRange(files);
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
            var allWantedMusicsFromPlaylists = ffh.ReadPlaylists();


            // On lit les musiques présentes dans les dossiers sélectionnés
            //var allMusicsFromFolders = ffh.ReadMusics();
        }
    }
}
