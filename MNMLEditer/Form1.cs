using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGI;
using D3Studio.ide;
using D3Studio.lists;
using D3Studio.lists.types;
using D3Studio.ui;
using Newtonsoft.Json;

namespace D3Studio
{
    public partial class MainFrame : Form
    {
        public MainFrame()
        {
            if(File.Exists(Application.StartupPath + "\\bin\\CheckVersioning.cgf"))
            {
                CheckUpdate cb = new CheckUpdate(true, this);
                cb.ShowDialog();
                cb.Dispose();
            }
            InitializeComponent();
            this.SuspendLayout();
            this.toolTipText.Text = "...";
            this.toolTipBubble.Visible = false;
            this.GBIDList.AddRange(gbidList.gbids(Application.StartupPath + "\\GBID_List.txt"));
            this.AffixList.AddRange(affixList.affixs(Application.StartupPath + "\\Affix_List.txt"));
            this.SNOList.AddRange(snoList.snos(Application.StartupPath + "\\db\\ENsno_item.txt"));
            this.SkillList.AddRange(skillList.skills(Application.StartupPath + "\\db\\ENSkills.txt"));
            AddMain();
            AddLocker();
            AddIDE();
            AddHelp();
            if (this.UF)
                this.WindowState = FormWindowState.Minimized;
            if(!File.Exists(Application.StartupPath + "\\bin\\locker.pb"))
                createBlankLocker();
            this.ResumeLayout();
        }

        

        public bool UF = false;

        private void AddHelp()
        {
            main m = new main();
            m.frame = this;
            byte[] dsp = new byte[]{84,111,110,105,99,66,111,120};
            if (Encoding.ASCII.GetString((new byte[] { 84, 111, 110, 105, 99, 66, 111, 120 })) != m.iSuspendable.Text)
                this.Close();
            TabPage tp = new TabPage("Help");
            tp.Controls.Add(m);
            this.tabControl.Controls.Add(tp);
        }

        private void AddMain()
        {
            frontPage m = new frontPage();
            m.parent = this;
            TabPage tp = new TabPage("Home");
            tp.Controls.Add(m);
            tp.AutoScroll = true;
            tp.BackColor = Color.Black;
            this.tabControl.Controls.Add(tp);
        }

        private void createBlankLocker()
        {
            PB.Items.ItemList locker = new PB.Items.ItemList();
            locker.items = new List<PB.Items.SavedItem>();
            if (!File.Exists(Application.StartupPath + "\\bin\\locker.pb"))
            {
                File.Create(Application.StartupPath + "\\bin\\locker.pb").Close();
            }
            FileStream fileStream = new FileStream(Application.StartupPath + "\\locker.pb", FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite);
            using (Stream stream1 = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize<PB.Items.ItemList>(stream1, locker);
                stream1.Position = 0L;
                Stream stream2 = TonicBox.Data.XorMagic.Saveencryptstream(stream1);
                stream2.Position = 0L;
                stream2.CopyTo(fileStream);
            }
            fileStream.Close();
        }

        public string SelectedPath { get; set; }

        private PB.Account.SavedDefinition AccountFile { get; set; }

        private PB.Console.Profile ProfileFile { get; set; }

        private PB.Items.ItemList Locker { get; set; }

        private PB.Console.HeroInfoList IdxFile { get; set; }

        private int FileType;

        private List<sno> SNOList = new List<sno>();

        private List<gbid> GBIDList = new List<gbid>();

        private List<affix> AffixList = new List<affix>();

        private List<skill> SkillList = new List<skill>();

        private ErrorLog Log = new ErrorLog(Application.StartupPath + "\\bin\\ErrorLog.txt");

        private string path { get; set; }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void switchTab(string name)
        {
            foreach(TabPage tp in tabControl.TabPages)
            {
                if (tp.Text == name)
                    tabControl.SelectedTab = tp;
            }
        }

        public void openSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[] fp = new byte[28];
            byte[] cu = new byte[28];
            progressBar1.BackColor = Color.Black;
            progressBar1.Value = 0;
            OpenFileDialog openFileName = new OpenFileDialog();
            openFileName.Filter = ("Account File|*.dat");
            Array.Copy((new CheckUpdate()).iDisposed, cu, 28);
            int num = string.IsNullOrEmpty(SelectedPath) ? 0 : (SelectedPath != "" ? 1 : 0);
            Array.Copy((new frontPage()).iDisposer, fp, 28);
            //openFileName.InitialDirectory = num == 0 ? Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) : SelectedPath;
            openFileName.Title = "Open save";
            openFileName.DefaultExt = "dat";
            DialogResult result = openFileName.ShowDialog();
            if (result != DialogResult.OK)
                return;
            if (!fp.SequenceEqual(cu))
                Close();
            else if (Path.GetFileName(openFileName.FileName).ToLower() != "account.dat")
            {
                showToolTip("Something went wrong...");
                Log.AddLog("Form1:open", "Wrong file selected...");
                return;
            }
            progressBar1.Value += 10;
            this.tabControl.Visible = false;
            this.tabControl.SuspendLayout();
            this.tabControl.Controls.Clear();
            AddMain();
            this.path = Path.GetDirectoryName(openFileName.FileName);
            progressBar1.Value += 10;
            try
            {
                AddAccount();
                progressBar1.Value += 10;
                AddProfile();
                AddPrefs();
                progressBar1.Value += 10;
                if (File.Exists(this.path + "\\HEROES.IDX"))
                {
                    AddIdx();
                    progressBar1.Value += 10;
                    heroes heroesTab = new heroes();
                    heroesTab.parent = this;
                    heroesTab.path = this.path;
                    heroesTab.GBIDList = this.GBIDList;
                    heroesTab.AffixList = this.AffixList;
                    heroesTab.IdxFile = this.IdxFile;
                    heroesTab.SNOList = this.SNOList;
                    heroesTab.populate(1);
                    TabPage htp = new TabPage("Heroes");
                    htp.Controls.Add(heroesTab);
                    this.tabControl.Controls.Add(htp);
                    //progressBar1.Value += 40;
                }
                else
                {
                    progressBar1.Value += 10;
                    heroes heroesTab = new heroes();
                    heroesTab.parent = this;
                    heroesTab.path = this.path;
                    heroesTab.GBIDList = this.GBIDList;
                    heroesTab.AffixList = this.AffixList;
                    heroesTab.SNOList = this.SNOList;
                    heroesTab.SkillList = this.SkillList;
                    heroesTab.populate(0);
                    TabPage htp = new TabPage("Heroes");
                    htp.Controls.Add(heroesTab);
                    this.tabControl.Controls.Add(htp);
                    //progressBar1.Value += 40;
                }
                AddLocker();
                AddIDE();
                AddHelp();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                showToolTip("Something went wrong...");
                Log.AddLog("MainForm:open", ex.Message);
                this.tabControl.Visible = true;
                return;
            }
            this.saveToolStripMenuItem.Enabled = true;
            this.tabControl.Visible = true;
            this.saveAllToolStripMenuItem.Visible = true;
            progressBar1.Value += (100 - progressBar1.Value -29);
            showToolTip("Successfully loaded save!");
            this.tabControl.ResumeLayout();
            this.tabControl.Visible = true;
        }

        private void AddAccount()
        {
            Stream source = TonicBox.Data.XorMagic.Savedecryptfile(this.path + "\\account.dat");
            this.AccountFile = ProtoBuf.Serializer.Deserialize<PB.Account.SavedDefinition>(source);
            source.Close();
            accountBase accountTab = new accountBase();
            accountTab.AccountFile = this.AccountFile;
            accountTab.GBIDList = this.GBIDList;
            accountTab.AffixList = this.AffixList;
            accountTab.SNOList = this.SNOList;
            accountTab.file = this.path + "\\account.dat";
            accountTab.AddTabs();
            TabPage tp = new TabPage("Account");
            tp.Controls.Add(accountTab);
            this.tabControl.Controls.Add(tp);
        }

        private void AddLocker()
        {
            Stream source = TonicBox.Data.XorMagic.Savedecryptfile(Application.StartupPath + "\\bin\\locker.pb");
            this.Locker = ProtoBuf.Serializer.Deserialize<PB.Items.ItemList>(source);
            source.Close();
            D3Studio.ui.hero.inventory invTab = new D3Studio.ui.hero.inventory();
            invTab.parent = this;
            invTab.Locker = this.Locker;
            invTab.GBIDList = this.GBIDList;
            invTab.AffixList = this.AffixList;
            invTab.SNOList = this.SNOList;
            invTab.file = Application.StartupPath + "\\bin\\locker.pb";
            invTab.populate();
            TabPage tp = new TabPage("Locker");
            tp.Controls.Add(invTab);
            this.tabControl.Controls.Add(tp);
        }

        private void AddIDE()
        {
            IDEBase IDETab = new IDEBase();
            IDETab.GBIDList = this.GBIDList;
            IDETab.AffixList = this.AffixList;
            IDETab.parent = this;
            IDETab.AddTabs();
            TabPage tp = new TabPage("Settings");
            tp.AutoScroll = true;
            tp.Controls.Add(IDETab);
            this.tabControl.Controls.Add(tp);
        }

        private void AddProfile()
        {
            Stream source = TonicBox.Data.XorMagic.Savedecryptfile(this.path + "\\profile.dat");
            this.ProfileFile = ProtoBuf.Serializer.Deserialize<PB.Console.Profile>(source);
            source.Close();
            rawTab accountTab = new rawTab();
            accountTab.ProfileFile = this.ProfileFile;
            accountTab.file = this.path + "\\profile.dat";
            accountTab.setData(1);
            TabPage tp = new TabPage("Profile");
            tp.Controls.Add(accountTab);
            this.tabControl.Controls.Add(tp);
        }

        private prefsType pref { get; set; }

        private prefsTypeXbox prefXbox { get; set; }

        private void AddPrefs()
        {
            try
            {
                this.pref = prefs.readPrefs(this.path + "\\prefs.dat");
                rawTab prefsTab = new rawTab();
                prefsTab.pref = this.pref;
                prefsTab.file = this.path + "\\prefs.dat";
                prefsTab.setData(5);
                TabPage tp = new TabPage("Preferences");
                tp.Controls.Add(prefsTab);
                this.tabControl.Controls.Add(tp);
            }
            catch
            {
                try
                {
                    /*this.prefXbox = prefs.readPrefsXbox(this.path + "\\prefs.dat");
                    rawTab prefsTab = new rawTab();
                    prefsTab.prefXbox = this.prefXbox;
                    prefsTab.file = this.path + "\\prefs.dat";
                    prefsTab.setData(6);
                    TabPage tp = new TabPage("Preferences");
                    tp.Controls.Add(prefsTab);
                    this.tabControl.Controls.Add(tp);*/
                }
                catch 
                { 
                    try
                    {
                        /*this.prefXbox = prefs.readPrefsPS(this.path + "\\prefs.dat");
                        rawTab prefsTab = new rawTab();
                        prefsTab.prefXbox = this.prefXbox;
                        prefsTab.file = this.path + "\\prefs.dat";
                        prefsTab.setData(7);
                        TabPage tp = new TabPage("Preferences");
                        tp.Controls.Add(prefsTab);
                        this.tabControl.Controls.Add(tp);*/
                    }
                    catch { }
                }
            }
            return;
        }

        private void AddIdx()
        {
            Stream source = TonicBox.Data.XorMagic.Savedecryptfile(this.path + "\\HEROES.IDX");
            this.IdxFile = ProtoBuf.Serializer.Deserialize<PB.Console.HeroInfoList>(source);
            source.Close();
            rawTab idxTab = new rawTab();
            idxTab.IdxFile = this.IdxFile;
            idxTab.file = this.path + "\\HEROES.IDX";
            idxTab.setData(2);
            TabPage tp = new TabPage("heroes.idx");
            tp.Controls.Add(idxTab);
            this.tabControl.Controls.Add(tp);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var tab in tabControl.Controls)
                {
                    if (tab is TabPage)
                    {
                        TabPage t = (TabPage)tab;
                        foreach (var raw in t.Controls)
                        {
                            if (raw is heroBase)
                            {
                                heroBase rt = (heroBase)raw;
                                FileStream fileStream = new FileStream(rt.file, FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite);
                                using (Stream stream1 = new MemoryStream())
                                {
                                    ProtoBuf.Serializer.Serialize<PB.Hero.SavedDefinition>(stream1, rt.HeroFile);
                                    stream1.Position = 0L;
                                    Stream stream2 = TonicBox.Data.XorMagic.Saveencryptstream(stream1);
                                    stream2.Position = 0L;
                                    stream2.CopyTo(fileStream);
                                }
                                fileStream.Close();
                            }
                            if (raw is heroes)
                            {
                                heroes rt = (heroes)raw;
                                foreach (var SubTab in rt.heroesControl.Controls)
                                {
                                    TabPage st = (TabPage)SubTab;
                                    foreach (var h in st.Controls)
                                    {
                                        if (h is D3Studio.ui.heroBase)
                                        {
                                            D3Studio.ui.heroBase ht = (D3Studio.ui.heroBase)h;
                                            FileStream fileStream = new FileStream(ht.file, FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite);
                                            using (Stream stream1 = new MemoryStream())
                                            {
                                                ProtoBuf.Serializer.Serialize<PB.Hero.SavedDefinition>(stream1, ht.HeroFile);
                                                stream1.Position = 0L;
                                                Stream stream2 = TonicBox.Data.XorMagic.Saveencryptstream(stream1);
                                                stream2.Position = 0L;
                                                stream2.CopyTo(fileStream);
                                            }
                                            fileStream.Close();
                                        }
                                    }
                                }
                            }
                            if (raw is accountBase)
                            {
                                accountBase rt = (accountBase)raw;
                                FileStream fileStream = new FileStream(rt.file, FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite);
                                using (Stream stream1 = new MemoryStream())
                                {
                                    ProtoBuf.Serializer.Serialize<PB.Account.SavedDefinition>(stream1, rt.AccountFile);
                                    stream1.Position = 0L;
                                    Stream stream2 = TonicBox.Data.XorMagic.Saveencryptstream(stream1);
                                    stream2.Position = 0L;
                                    stream2.CopyTo(fileStream);
                                }
                                fileStream.Close();
                            }
                            if (raw is rawTab)
                            {
                                rawTab rt = (rawTab)raw;
                                if (rt.type == 0)
                                {
                                    FileStream fileStream = new FileStream(rt.file, FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite);
                                    using (Stream stream1 = new MemoryStream())
                                    {
                                        ProtoBuf.Serializer.Serialize<PB.Account.SavedDefinition>(stream1, rt.AccountFile);
                                        stream1.Position = 0L;
                                        Stream stream2 = TonicBox.Data.XorMagic.Saveencryptstream(stream1);
                                        stream2.Position = 0L;
                                        stream2.CopyTo(fileStream);
                                    }
                                    fileStream.Close();
                                }
                                else if (rt.type == 1)
                                {
                                    FileStream fileStream = new FileStream(rt.file, FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite);
                                    using (Stream stream1 = new MemoryStream())
                                    {
                                        ProtoBuf.Serializer.Serialize<PB.Console.Profile>(stream1, rt.ProfileFile);
                                        stream1.Position = 0L;
                                        Stream stream2 = TonicBox.Data.XorMagic.Saveencryptstream(stream1);
                                        stream2.Position = 0L;
                                        stream2.CopyTo(fileStream);
                                    }
                                    fileStream.Close();
                                }
                                else if (rt.type == 2)
                                {
                                    FileStream fileStream = new FileStream(rt.file, FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite);
                                    using (Stream stream1 = new MemoryStream())
                                    {
                                        ProtoBuf.Serializer.Serialize<PB.Console.HeroInfoList>(stream1, rt.IdxFile);
                                        stream1.Position = 0L;
                                        Stream stream2 = TonicBox.Data.XorMagic.Saveencryptstream(stream1);
                                        stream2.Position = 0L;
                                        stream2.CopyTo(fileStream);
                                    }
                                    fileStream.Close();
                                }
                                else if (rt.type == 5)
                                {
                                    prefs.writePrefs(rt.file, rt.pref);
                                }
                                else if (rt.type == 6)
                                {
                                    prefs.writePrefsXbox(rt.file, rt.prefXbox);
                                }
                                else if (rt.type == 7)
                                {
                                    prefs.writePrefsPS(rt.file, rt.prefXbox);
                                }
                            }
                        }
                    }
                }
                FileStream fs = new FileStream(Application.StartupPath + "\\bin\\locker.pb", FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite);
                using (Stream stream1 = new MemoryStream())
                {
                    ProtoBuf.Serializer.Serialize<PB.Items.ItemList>(stream1, this.Locker);
                    stream1.Position = 0L;
                    Stream stream2 = TonicBox.Data.XorMagic.Saveencryptstream(stream1);
                    stream2.Position = 0L;
                    stream2.CopyTo(fs);
                }
                fs.Close();
                showToolTip("Successfully saved all files!");
            }
            catch(Exception ex)
            {
                showToolTip("Something went wrong...");
                Log.AddLog("Form1:save", ex.Message);
            }
        }

        public void showToolTip(string text)
        {
            this.toolTipBubble.BringToFront();
            this.toolTipText.Text = text;
            int len = this.toolTipText.Width;
            this.toolTipBubble.Width = len + 20;
            this.toolTipBubble.Visible = true;
            var t = new Timer();
            t.Interval = 1500;
            t.Tick += (s, e) =>
            {
                this.toolTipBubble.Hide();
                t.Stop();
            };
            t.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
        }
    }
}
