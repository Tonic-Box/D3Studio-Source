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
    public partial class floodCattegory : Form
    {
        public List<gbid> GBIDList = new List<gbid>();

        public inventory parent = new inventory();

        public floodCattegory()
        {
            InitializeComponent();
        }

        public void populate()
        {
            List<string> temp = new List<string>();
            foreach(gbid item in this.GBIDList)
            {
                if(!temp.Contains(item.Category))
                {
                    temp.Add(item.Category);
                }
            }
            temp.Sort();
            foreach(string c in temp)
            {
                this.categories.Items.Add(c);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.parent.floodItems(this.categories.Items[this.categories.SelectedIndex].ToString());
            this.Close();
        }
    }
}
