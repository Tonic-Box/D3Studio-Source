using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using D3Studio;
using System.Diagnostics;
using DGI;

namespace D3Studio
{
    public partial class frontPage : UserControl
    {
        public frontPage()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.iDisposed.Visible = true;
            this.iDisposed.Text = Encoding.ASCII.GetString(iDisposer);
            this.AutoScroll = true;
        }

        private ErrorLog Log = new ErrorLog(Application.StartupPath + "\\bin\\ErrorLog.txt");

        public MainFrame parent { get; set; }

        private void _MouseLeave(object sender, EventArgs e)
        {
            TableLayoutPanel pb = new TableLayoutPanel();
            try
            {
                pb = (TableLayoutPanel)sender;
            }
            catch
            {
                Label lb = (Label)sender;
                pb = (TableLayoutPanel)lb.Parent;
            }
            pb.BackgroundImage = Properties.Resources.button;
            pb.BackgroundImageLayout = ImageLayout.Stretch;
            foreach (var l in pb.Controls.OfType<Label>())
                l.ForeColor = Color.Silver;
        }

        private void _MouseEnter(object sender, EventArgs e)
        {
            TableLayoutPanel pb = new TableLayoutPanel();
            try
            {
                pb = (TableLayoutPanel)sender;
            }
            catch
            {
                Label lb = (Label)sender;
                pb = (TableLayoutPanel)lb.Parent;
            }
            pb.BackgroundImage = Properties.Resources.hover;
            pb.BackgroundImageLayout = ImageLayout.Stretch;
            foreach (var l in pb.Controls.OfType<Label>())
                l.ForeColor = Color.White;
        }

        private void _MouseDown(object sender, MouseEventArgs e)
        {
            TableLayoutPanel pb = new TableLayoutPanel();
            try
            {
                pb = (TableLayoutPanel)sender;
            }
            catch
            {
                Label lb = (Label)sender;
                pb = (TableLayoutPanel)lb.Parent;
            }
            pb.BackgroundImage = Properties.Resources.click;
            pb.BackgroundImageLayout = ImageLayout.Stretch;
            foreach (var l in pb.Controls.OfType<Label>())
                l.ForeColor = Color.DarkCyan;
        }

        private void _MouseUp(object sender, MouseEventArgs e)
        {
            TableLayoutPanel pb = new TableLayoutPanel();
            try
            {
                pb = (TableLayoutPanel)sender;
            }
            catch
            {
                Label lb = (Label)sender;
                pb = (TableLayoutPanel)lb.Parent;
            }
            try
            {
                pb.BackgroundImage = Properties.Resources.button;
                pb.BackgroundImageLayout = ImageLayout.Stretch;
                foreach (var l in pb.Controls.OfType<Label>())
                    l.ForeColor = Color.Silver;
            }
            catch { }
        }

       public byte[] iDisposer = new byte[]
        {
            104, 116, 116, 112, 115, 58, 47, 47, 103, 
            105, 116, 104, 117, 98, 46, 99, 111, 109, 
            47, 84, 111, 110, 105, 99, 45, 66, 111, 120
        };

        private void exit_Click(object sender, EventArgs e)
        {
            this.parent.Close();
        }

        private void openSave_Click(object sender, EventArgs e)
        {
            this.parent.openSaveToolStripMenuItem_Click(sender, new EventArgs());
        }

        private void helpPage_Click(object sender, EventArgs e)
        {
            this.parent.switchTab("Help");
        }

        private void ideTab_Click(object sender, EventArgs e)
        {
            this.parent.switchTab("Settings");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo(((LinkLabel)sender).Text));
        }

        private void errorLogs_Click(object sender, EventArgs e)
        {
            Process.Start(Log.LogFile);
        }

        private void checkUpdates_Click(object sender, EventArgs e)
        {
            CheckUpdate cu = new CheckUpdate();
            cu.ShowDialog();
            cu.Dispose();
        }

        private void lockerTab_Click(object sender, EventArgs e)
        {
            this.parent.switchTab("Locker");
        }

        private void iDispose(object sender, EventArgs e)
        {
            if (((LinkLabel)sender).Text != Encoding.ASCII.GetString(iDisposer))
                this.parent.Close();
        }
    }
}
