using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using D3Studio.lists.types;
using DGI;

namespace D3Studio
{
    public partial class heroes : UserControl
    {
        public string path { get; set; }

        public List<gbid> GBIDList = new List<gbid>();

        public List<affix> AffixList = new List<affix>();

        public List<sno> SNOList = new List<sno>();

        public List<skill> SkillList = new List<skill>();

        public TreeNode[] GBIDNodes;

        public MainFrame parent;

        public PB.Console.HeroInfoList IdxFile { get; set; }

        public ErrorLog Log = new ErrorLog(Application.StartupPath + "\\bin\\ErrorLog.txt");

        public heroes()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public void populate(int type)
        {
            this.SuspendLayout();
            populateGBIDs();
            forceUpdate fu = new forceUpdate();
            if (type == 0)
            {
                DirectoryInfo di = new DirectoryInfo(this.path + "\\heroes\\");
                int count = di.GetFiles("*.dat", SearchOption.AllDirectories).Length;
                int increment = (int)(40 / count);
                foreach (var hero in Directory.EnumerateFiles(this.path + "\\heroes\\", "*.dat"))
                {
                    try
                    {
                        AddHero(hero, false);
                        this.parent.progressBar1.Value += increment;
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("There was an error loading \"" + hero + "\"");
                        Log.AddLog("heroes", ex.Message);
                        this.parent.progressBar1.Value += increment;
                    }
                    fu.ShowDialog();
                }
            }
            else if (type == 1)
            {
                DirectoryInfo di = new DirectoryInfo(this.path);
                int count = di.GetFiles("*.hro", SearchOption.AllDirectories).Length;
                int increment = (int)(40 / count);
                foreach (var hero in Directory.EnumerateFiles(this.path, "*.hro"))
                {
                    
                    try
                    {
                        AddHero(hero, true);
                        this.parent.progressBar1.Value += increment;
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("There was an error loading \"" + hero + "\"");
                        Log.AddLog("heroes", ex.Message);
                        this.parent.progressBar1.Value += increment;
                    }
                    fu.ShowDialog();
                }
            }
            fu.Dispose();
            this.ResumeLayout();
        }

        private void AddHero(string p, bool idx)
        {
            Stream source = TonicBox.Data.XorMagic.Savedecryptfile(p);
            D3Studio.ui.heroBase heroTab = new D3Studio.ui.heroBase();
            heroTab.HeroFile = ProtoBuf.Serializer.Deserialize<PB.Hero.SavedDefinition>(source);
            source.Close();
            heroTab.file = p;
            heroTab.AffixList = this.AffixList;
            heroTab.GBIDList = this.GBIDList;
            heroTab.SNOList = this.SNOList;
            heroTab.parent = this;
            heroTab.SkillList = this.SkillList;
            heroTab.isIDX = idx;
            if (this.IdxFile != null)
                heroTab.IdxFile = this.IdxFile;
            heroTab.AddTabs();
            string str = "";
            if (heroTab.HeroFile.digest.season_created == TonicBox.Data.Settings.CurrentSeason)
                str = "[S] ";
            TabPage tp = new TabPage(str + heroTab.HeroFile.digest.hero_name);
            tp.Controls.Add(heroTab);
            this.heroesControl.Controls.Add(tp);
        }

        public void populateGBIDs()
        {
            List<TreeNode> o = new List<TreeNode>();
            foreach (gbid id in this.GBIDList)
            {
                TreeNode node = new TreeNode();
                node.Text = id.Name;
                node.Name = id.Category;
                node.Tag = id.GBID.ToString();
                bool pass = false;
                foreach (TreeNode x in o)
                {
                    if (x.Text.ToLower() == id.Category.ToLower())
                    {
                        x.Nodes.Add(node);
                        pass = true;
                        break;
                    }
                }
                if (!pass)
                {
                    TreeNode category = new TreeNode();
                    category.Text = id.Category;
                    category.Name = id.Category;
                    category.Nodes.Add(node);
                    o.Add(category);
                }
            }
            this.GBIDNodes = o.ToArray();
        }
    }
}
