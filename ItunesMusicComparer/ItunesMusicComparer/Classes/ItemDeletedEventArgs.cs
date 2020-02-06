using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItunesMusicComparer.Classes
{
    public class ItemDeletedEventArgs
    {
        public ItemDeletedEventArgs(FlowLayoutPanel flp)
        {
            _flp = flp;
        }
        private FlowLayoutPanel _flp;
        public FlowLayoutPanel Flp
        {
            get { return _flp; }
        }
    }
}
