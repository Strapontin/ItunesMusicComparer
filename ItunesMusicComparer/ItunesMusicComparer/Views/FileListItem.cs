using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ItunesMusicComparer.Classes;

namespace ItunesMusicComparer
{
    public partial class FileListItem : UserControl
    {
        public string LabelName
        {
            set
            {
                lblTitle.Text = value;
            }
        }

        private string _fullPath;
        public string FullPath
        {
            get => _fullPath;
            set
            {
                _fullPath = value;
            }
        }

        public FileListItem(string name, string fullPath)
        {
            InitializeComponent();

            LabelName = name;
            FullPath = fullPath;
        }

        /// <summary>
        /// Lorsque l'on clique sur le bouton pour suspprimer l'item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, ItemDeletedEventArgs e)
        {
            OnRequestDeleteItem(ItemDeletedEventArgs.Empty);
        }

        /// <summary>
        /// Lorsque l'on essaye de supprimer l'item
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnRequestDeleteItem(ItemDeletedEventArgs e)
        {
            RequestDeleteItem?.Invoke(this, e);
        }

        public event EventHandler<ItemDeletedEventArgs> RequestDeleteItem;
    }
}
