using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using D3Studio.ui.account;
using D3Studio.lists.types;

namespace D3Studio.ui
{
    

    public partial class accountBase : UserControl
    {
        public string file { get; set; }
        public PB.Account.SavedDefinition AccountFile { get; set; }

        public List<gbid> GBIDList = new List<gbid>();

        public List<affix> AffixList = new List<affix>();

        public List<sno> SNOList = new List<sno>();

        public accountBase()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public void AddTabs()
        {
            AddGeneral();
            AddStash();
            //AddRollover();
            AddRaw();
        }

        private void AddGeneral()
        {
            general accountTab = new general();
            accountTab.AccountFile = this.AccountFile;
            accountTab.populate();
            TabPage tp = new TabPage("General");
            tp.Controls.Add(accountTab);
            this.generalTabControl.Controls.Add(tp);
        }

        private void AddStash()
        {
            D3Studio.ui.account.stashes invTab = new D3Studio.ui.account.stashes();
            invTab.AccountFile = this.AccountFile;
            invTab.GBIDList = this.GBIDList;
            invTab.AffixList = this.AffixList;
            invTab.SNOList = this.SNOList;
            invTab.AddTabs();
            TabPage tp = new TabPage("Stashes");
            tp.Controls.Add(invTab);
            tp.AutoScroll = true;
            this.generalTabControl.Controls.Add(tp);
        }

        private void AddRollover()
        {
            D3Studio.ui.account.rolloverItems invTab = new D3Studio.ui.account.rolloverItems();
            invTab.AccountFile = this.AccountFile;
            invTab.GBIDList = this.GBIDList;
            invTab.AffixList = this.AffixList;
            invTab.SNOList = this.SNOList;
            invTab.populate();
            TabPage tp = new TabPage("Seasonal Rollover Stashes");
            tp.Controls.Add(invTab);
            tp.AutoScroll = true;
            this.generalTabControl.Controls.Add(tp);
        }

        private void AddRaw()
        {
            D3Studio.ui.rawTab accountTab = new D3Studio.ui.rawTab();
            accountTab.AccountFile = this.AccountFile;
            accountTab.file = this.file;
            accountTab.setData(0);
            TabPage tp = new TabPage("Raw");
            tp.Controls.Add(accountTab);
            this.generalTabControl.Controls.Add(tp);
        }
    }
}
