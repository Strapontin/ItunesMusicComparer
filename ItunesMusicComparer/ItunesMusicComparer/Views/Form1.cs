using ItunesMusicComparer.Classes;
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
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lorsque l'on supprime un élément de la liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Item_RequestDeleteItem(object sender, EventArgs e)
        {
            flpFilesSelected.Controls.Remove(flpFilesSelected.Controls.Find((sender as FileListItem).Name, true).First());
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
                            AddFilePathToFLP(item.FileName, item.FullPath);
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
        /// Ajoute une ligne dans la liste des fichiers sélectionnés
        /// </summary>
        /// <param name="fileName"></param>
        private void AddFilePathToFLP(string fileName, string fullPath)
        {
            if (!FileAlreadySelected(fullPath))
            {
                var file = new FileListItem();
                file.RequestDeleteItem += Item_RequestDeleteItem;
                file.Name = fileName;
                file.LabelName = fileName;
                file.FullPath = fullPath;

                flpFilesSelected.Controls.Add(file);
            }
        }

        /// <summary>
        /// Retourne true si le chemin est déjà sélectionné
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        private bool FileAlreadySelected(string fullPath)
        {
            for (int i = 0; i < flpFilesSelected.Controls.Count; i++)
            {
                if ((flpFilesSelected.Controls[i] as FileListItem).FullPath == fullPath)
                    return true;
            }

            return false;
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
                    var files = Directory.GetFiles(folderBrowserDialog.SelectedPath, "*.*", SearchOption.AllDirectories).ToList();


                    // On enlève le nom des dossiers pour n'avoir que le nom des fichiers
                    files.ForEach(file =>
                    {
                        file = Path.GetFileNameWithoutExtension(file);
                    });


                    flpFolderSelection.Controls.AddRange(files);
                }
            }
        }
    }
}
