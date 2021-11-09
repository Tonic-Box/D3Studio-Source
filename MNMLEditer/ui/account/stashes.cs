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

namespace D3Studio.ui.account
{
    public partial class stashes : UserControl
    {
        public PB.Account.SavedDefinition AccountFile { get; set; }

        public List<gbid> GBIDList = new List<gbid>();

        public List<affix> AffixList = new List<affix>();

        public List<sno> SNOList = new List<sno>();

        public stashes()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public void AddTabs()
        {
            AddStash(0, "SoftCore Stash");
            AddStash(1, "HardCore Stash");
            if (TonicBox.Data.Settings.Seasonal)
            {
                AddStash(2, "Seasonal SoftCore Stash");
                AddStash(3, "Seasonal HardCore Stash");
            }
        }

        private void AddStash(int p, string title)
        {
            D3Studio.ui.hero.inventory invTab = new D3Studio.ui.hero.inventory();
            invTab.AccountFile = this.AccountFile;
            invTab.GBIDList = this.GBIDList;
            invTab.AffixList = this.AffixList;
            invTab.SNOList = this.SNOList;
            invTab.partition = p;
            invTab.populate();
            TabPage tp = new TabPage(title);
            tp.Controls.Add(invTab);
            tp.AutoScroll = true;
            this.stashTabs.Controls.Add(tp);
        }
    }
}
