using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public FileListItem()
        {
            InitializeComponent();
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
            RequestDeleteItem?.Invoke(this, e);
        }

        public event EventHandler RequestDeleteItem;
    }
}
