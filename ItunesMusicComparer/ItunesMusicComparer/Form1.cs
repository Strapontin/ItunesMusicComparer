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
            var fileContent = string.Empty;
            var filePaths = new List<string>();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePaths = openFileDialog.SafeFileNames.ToList();

                    flpFilesSelected.Controls.Clear();

                    if (filePaths.Any())
                    {
                        foreach (var item in filePaths)
                        {
                            AddFilePathToFLP(item);
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
        /// <param name="path"></param>
        private void AddFilePathToFLP(string path)
        {
            var file = new FileListItem();
            file.RequestDeleteItem += Item_RequestDeleteItem;
            file.Name = path;
            file.LabelName = path;

            flpFilesSelected.Controls.Add(file);
        }
    }
}
