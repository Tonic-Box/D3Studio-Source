using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using D3Studio.lists.types;

namespace D3Studio.ide
{
    public partial class IDEBase : UserControl
    {
        public List<sno> SNOList = new List<sno>();

        public List<gbid> GBIDList = new List<gbid>();

        public List<affix> AffixList = new List<affix>();

        public D3Studio.MainFrame parent;

        public IDEBase()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public void AddTabs()
        {
            AddGBIDTab();
            AddAffixTab();
        }

        public void AddGBIDTab()
        {
            IDEGBID GBIDTab = new IDEGBID();
            GBIDTab.GBIDList = this.GBIDList;
            GBIDTab.mParent = this;
            GBIDTab.populate();
            TabPage tp = new TabPage("GBID List");
            tp.AutoScroll = true;
            tp.Controls.Add(GBIDTab);
            this.IDETabControl.Controls.Add(tp);
        }

        public void AddAffixTab()
        {
            IDEAffix AffixTab = new IDEAffix();
            AffixTab.AffixList = this.AffixList;
            AffixTab.mParent = this;
            AffixTab.populate();
            TabPage tp = new TabPage("Affix List");
            tp.Controls.Add(AffixTab);
            this.IDETabControl.Controls.Add(tp);
        }
    }
}
