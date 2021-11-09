using D3Studio.lists.types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D3Studio.ui.hero
{
    public partial class embeddedIDEGBID : Form
    {
        public inventory parent;
        public gbid selected;
        public List<gbid> GBIDList = new List<gbid>();
        public embeddedIDEGBID()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        
        public void populate()
        {
            ide.embeded = true;
            ide.selected = this.selected;
            ide.parent = this;
            ide.GBIDList = this.GBIDList;
            ide.resize();
            ide.populate();
            ide.AutoScroll = false;
        }
    }
}
