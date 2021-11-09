using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using D3Studio;

namespace D3Studio.ui
{
    public partial class main : UserControl
    {
        public main()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public MainFrame frame;

        public MainFrame Continue;

        private void LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo(((LinkLabel)sender).Text));
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("gsec.tonicbox@protonmail.com");
            frame.showToolTip("Email coppied to clipboard!");
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("Tonic_Box");
            frame.showToolTip("Twitter Handle coppied to clipboard!");
        }

        private void main_Load(object sender, EventArgs e)
        {
            if (Encoding.ASCII.GetString((new byte[] { 84, 111, 110, 105, 99, 66, 111, 120 })) != iSuspendable.Text)
                this.Continue.Close();
        }
    }
}
