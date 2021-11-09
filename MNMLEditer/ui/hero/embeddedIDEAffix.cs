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

namespace D3Studio.ui.hero.inventoryControls
{
    public partial class embeddedIDEAffix : Form
    {

        public inventory parent;
        public affix selected;
        public List<affix> AffixList = new List<affix>();
        public embeddedIDEAffix()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        public void populate()
        {
            ide.embeded = true;
            ide.selected = this.selected;
            ide.parent = this;
            ide.AffixList = this.AffixList;
            ide.populate();
            ide.resize();
        }
    }
}
