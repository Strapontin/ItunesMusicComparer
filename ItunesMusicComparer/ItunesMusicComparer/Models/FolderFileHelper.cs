using ItunesMusicComparer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public void AddFilePathToFLP(string fileName, string fullPath, FlowLayoutPanel flp)
        {
            if (!FileAlreadySelected(fullPath, flp))
            {
                var file = new FileListItem(fileName, fullPath);
                file.RequestDeleteItem += Item_RequestDeleteItem;
                file.Name = fileName;

                flp.Controls.Add(file);
            }
        }

        /// <summary>
        /// Retourne true si le chemin est déjà sélectionné
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        private bool FileAlreadySelected(string fullPath, FlowLayoutPanel flp)
        {
            for (int i = 0; i < flp.Controls.Count; i++)
            {
                if ((flp.Controls[i] as FileListItem).FullPath == fullPath)
                    return true;
            }

            return false;
        }
    }
}
