using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;

namespace D3Studio.ui
{
    public partial class rawTab : UserControl
    {
        public string file { get; set; }
        public PB.Account.SavedDefinition AccountFile { get; set; }

        public PB.Hero.SavedDefinition HeroFile { get; set; }

        public PB.Console.Profile ProfileFile { get; set; }

        public PB.Console.HeroInfoList IdxFile { get; set; }

        public PB.Items.SavedItem Item { get; set; }

        public lists.prefsType pref { get; set; }

        public lists.prefsTypeXbox prefXbox { get; set; }

        public int type;

        public rawTab()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public void setData(int i)
        {
            this.type = i;
            if (i == 0)
            {
                this.propertyGrid1.SelectedObject = this.AccountFile;
            }
            if (i == 1)
            {
                this.propertyGrid1.SelectedObject = this.ProfileFile;
            }
            if (i == 2)
            {
                this.propertyGrid1.SelectedObject = this.IdxFile;
            }
            if (i == 3)
            {
                this.propertyGrid1.SelectedObject = this.HeroFile;
            }
            if (i == 4)
            {
                this.propertyGrid1.SelectedObject = this.Item;
            }
            if (i == 5)
            {
                this.propertyGrid1.SelectedObject = this.pref;
            }
            if (i == 6)
            {
                this.propertyGrid1.SelectedObject = this.prefXbox;
            }
            if (i == 7)
            {
                this.propertyGrid1.SelectedObject = this.prefXbox;
            }
        }
    }
}
