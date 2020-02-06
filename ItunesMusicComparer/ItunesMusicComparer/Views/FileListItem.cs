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

        private FlowLayoutPanel _flp;
        public FlowLayoutPanel Flp
        {
            get => _flp;
            set
            {
                _flp = value;
            }
        }

        public FileListItem(string name, string fullPath, FlowLayoutPanel flp)
        {
            InitializeComponent();

            LabelName = name;
            FullPath = fullPath;
            _flp = flp;
        }

        /// <summary>
        /// Lorsque l'on clique sur le bouton pour suspprimer l'item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, EventArgs e)
        {
            OnRequestDeleteItem(EventArgs.Empty);
        }

        /// <summary>
        /// Lorsque l'on essaye de supprimer l'item
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnRequestDeleteItem(EventArgs e)
        {
            ItemDeletedEventArgs ev = new ItemDeletedEventArgs(_flp);

            RequestDeleteItem?.Invoke(this, ev);
        }

        public event EventHandler<ItemDeletedEventArgs> RequestDeleteItem;
    }
}
