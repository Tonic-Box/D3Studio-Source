using Newtonsoft.Json;
using D3Studio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D3Studio
{
    public partial class CheckUpdate : Form
    {
        public CheckUpdate(bool isu = false, MainFrame frame = null, bool iLoader = false)
        {
            this.isStartUp = isu;
            this.isLoader = iLoader;
            this.frm = frame;
            InitializeComponent();
            this.CenterToScreen();
            if (this.isStartUp)
            {
                this.ControlBox = false;
                this.FormBorderStyle = FormBorderStyle.None;
                StartAsyncTimedWork(10000);
            }
            else if (this.isLoader)
            {
                this.ControlBox = false;
                this.FormBorderStyle = FormBorderStyle.None;
            }
            else
                StartAsyncTimedWork(25000);
        }

        public bool isLoader;

        public bool isStartUp;

        public MainFrame frm;

        private void checkVersioning()
        {
            string url = "https://api.github.com/repos/Tonic-Box/D3Studio/releases/latest";
            string version = TonicBox.Data.Settings.Version;
            if (File.Exists(Application.StartupPath + "\\bin\\CheckVersioning.cgf"))
            {
                if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    dynamic releases;
                    try
                    {
                        releases = JsonConvert.DeserializeObject<dynamic>(new TimedWebClient { Timeout = 6000 }.DownloadString(url));
                    }
                    catch
                    {
                        return;
                    }
                    if (releases["message"] == "Not Found")
                    {
                        MessageBox.Show("GitHub Project page seems to be having issues...");
                        this.Close();
                        return;
                    }
                    if (releases["tag_name"].ToString() != version)
                    {
                        Process.Start(new ProcessStartInfo(releases["html_url"].ToString()));
                        if (this.frm != null)
                            this.frm.UF = true;
                        this.Close();
                        return;
                    }
                }
            }
            if(!this.isStartUp)
            this.Close();
        }

        private void CheckUpdate_Shown(object sender, EventArgs e)
        {
            if(!this.isLoader)
                checkVersioning();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (((LinkLabel)sender).Text != Encoding.ASCII.GetString(iDisposed))
                this.frm.Close();
            Process.Start(new ProcessStartInfo(((LinkLabel)sender).Text));
            if(!this.isLoader)
                this.Close();
        }

        public byte[] iDisposed = new byte[]
        {
            104, 116, 116, 112, 115, 58, 47, 47, 103, 105,
            116, 104, 117, 98, 46, 99, 111, 109, 47, 84,
            111, 110, 105, 99, 45, 66, 111, 120, 47, 68,
            51, 83, 116, 117, 100, 105, 111, 47, 114, 101,
            108, 101, 97, 115, 101, 115
        };

        private System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        private void StartAsyncTimedWork(int delay)
        {
            myTimer.Interval = delay;
            myTimer.Tick += new EventHandler(myTimer_Tick);
            myTimer.Start();
        }

        private void iDispose(object sender, EventArgs e)
        {
            if (((LinkLabel)sender).Text != Encoding.ASCII.GetString(iDisposed))
                this.frm.Close();
        }

        private void myTimer_Tick(object sender, EventArgs e)
        {
            if (iDisposer.Text != Encoding.ASCII.GetString(iDisposed))
                this.frm.Close();
            if (this.InvokeRequired)
            {
                /* Not on UI thread, reenter there... */
                this.BeginInvoke(new EventHandler(myTimer_Tick), sender, e);
            }
            else
            {
                lock (myTimer)
                {
                    /* only work when this is no reentry while we are already working */
                    if (this.myTimer.Enabled)
                    {
                        this.myTimer.Stop();
                        if(this.isLoader)
                        {
                            this.Close();
                        }
                        else
                            this.Close();
                        this.myTimer.Start(); /* optionally restart for periodic work */
                    }
                }
            }
        }
    }

    public class TimedWebClient : WebClient
    {
        // Timeout in milliseconds, default = 600,000 msec
        public int Timeout { get; set; }

        public TimedWebClient()
        {
            this.Timeout = 600000;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var objWebRequest = (HttpWebRequest)base.GetWebRequest(address);
            objWebRequest.Timeout = this.Timeout;
            objWebRequest.UserAgent = "D3StudioVersioning/1.0";
            return objWebRequest;
        }
    }
}
