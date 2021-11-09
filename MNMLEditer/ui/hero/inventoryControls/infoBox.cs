using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D3Studio.ui.hero.inventoryControls
{
    public partial class infoBox : UserControl
    {
        public string description;

        public Color nameColor = Color.White;

        public string name;
        public infoBox()
        {
            InitializeComponent();
            this.ItemName.Text = "...";
            this.Description.Text = "No Item Selected...";
        }

        public void populate()
        {
            this.formatDescription(this.description);
            this.formatName(this.name);
            this.ItemName.Text = this.name;
            this.ItemName.ForeColor = this.nameColor;
            this.Description.Text = this.description;
            this.Description.MaximumSize = new Size(10000, 0);
            this.Description.AutoSize = true;
        }

        public void formatName(string name)
        {
            if (name.ToLower().Contains("legendary:"))
                this.nameColor = Color.Orange;
            else if (name.ToLower().Contains("set:"))
                this.nameColor = Color.LightGreen;
            else if (name.ToLower().Contains("skill:") || name.ToLower().Contains("passive:"))
                this.nameColor = Color.Aquamarine;
            else
                this.nameColor = Color.White;
        }

        public void formatDescription(string desc)
        {
            this.description = desc.Replace("$", Environment.NewLine).Replace("~", "      * ").Replace("#", Environment.NewLine).Replace("\"", "");
        }
    }
}
