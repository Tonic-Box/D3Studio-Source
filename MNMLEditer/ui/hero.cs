using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using D3Studio.ui;
using D3Studio.lists.types;
using D3Studio.ui.hero;
using System.IO;
using DGI;

namespace D3Studio.ui
{
    public partial class heroBase : UserControl
    {
        public string file { get; set; }

        public PB.Hero.SavedDefinition HeroFile { get; set; }

        public PB.Console.HeroInfoList IdxFile { get; set; }

        public List<gbid> GBIDList = new List<gbid>();

        public List<affix> AffixList = new List<affix>();

        public List<sno> SNOList = new List<sno>();

        public skills SkillsTab = new skills();

        public List<skill> SkillList = new List<skill>();

        public ErrorLog Log = new ErrorLog(Application.StartupPath + "\\bin\\ErrorLog.txt");

        public heroes parent { get; set; }

        public bool isIDX { get; set; }

        public heroBase()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public void AddTabs()
        {
            this.SuspendLayout();
            try { AddGeneral(); } catch(Exception ex) 
            {
                Log.AddLog("hero:general", ex.InnerException.Message);
                if (TonicBox.Data.Settings.AdvancedErrorThrowing)
                    MessageBox.Show(ex.ToString()); 
            }
            try { AddVisuals(); } catch (Exception ex) 
            {
                Log.AddLog("hero:visuals", ex.InnerException.Message);
                if (TonicBox.Data.Settings.AdvancedErrorThrowing)
                    MessageBox.Show(ex.ToString()); 
            }
            try { AddInventory(); } catch (Exception ex) 
            {
                Log.AddLog("hero:inventory", ex.InnerException.Message);
                if (TonicBox.Data.Settings.AdvancedErrorThrowing)
                    MessageBox.Show(ex.ToString()); 
            }
            try { AddSkills(); } catch (Exception ex) 
            {
                Log.AddLog("hero:skills", ex.InnerException.Message);
                if (TonicBox.Data.Settings.AdvancedErrorThrowing)
                    MessageBox.Show(ex.ToString()); 
            }
            try { AddRaw(); } catch (Exception ex) 
            {
                Log.AddLog("hero:raw", ex.InnerException.Message);
                if (TonicBox.Data.Settings.AdvancedErrorThrowing)
                    MessageBox.Show(ex.ToString()); 
            }
            this.ResumeLayout();
            /*using (StreamWriter newTask = new StreamWriter(Application.StartupPath + "\\keys.txt", false))
            {
                foreach (PB.AttributeSerializer.SavedAttribute attr in HeroFile.saved_attributes.attributes)
                {
                    newTask.WriteLine(attr.key.ToString() + " : " + attr.value.ToString());
                }
            }*/
        }

        private void AddVisuals()
        {
            visuals visualsTab = new visuals();
            visualsTab.SuspendLayout();
            visualsTab.HeroFile = this.HeroFile;
            visualsTab.GBIDList = this.GBIDList;
            visualsTab.parent = this;
            visualsTab.file = this.file;
            if (this.IdxFile != null)
                visualsTab.IdxFile = this.IdxFile;
            visualsTab.populate();
            TabPage tp = new TabPage("Visuals");
            tp.Controls.Add(visualsTab);
            tp.AutoScroll = true;
            this.heroTabControl.Controls.Add(tp);
            visualsTab.ResumeLayout();
        }

        private void AddSkills()
        {
            skills skillsTab = new skills();
            skillsTab.SuspendLayout();
            skillsTab.HeroFile = this.HeroFile;
            skillsTab.GBIDList = this.GBIDList;
            skillsTab.SkillList = this.SkillList;
            skillsTab.isIDX = this.isIDX;
            skillsTab.file = this.file;
            skillsTab.populate();
            skillsTab.populateTV();
            TabPage tp = new TabPage("Skills, Passives, & Powers");
            tp.Controls.Add(skillsTab);
            tp.AutoScroll = true;
            this.heroTabControl.Controls.Add(tp);
            skillsTab.ResumeLayout();
        }

        private void AddInventory()
        {
            inventory invTab = new inventory();
            invTab.SuspendLayout();
            invTab.HeroFile = this.HeroFile;
            invTab.GBIDList = this.GBIDList;
            invTab.AffixList = this.AffixList;
            invTab.SNOList = this.SNOList;
            invTab.isIDX = this.isIDX;
            invTab.file = this.file;
            invTab.hParent = this;
            invTab.populate();
            TabPage tp = new TabPage("Inventory");
            tp.Controls.Add(invTab);
            tp.AutoScroll = true;
            this.heroTabControl.Controls.Add(tp);
            invTab.ResumeLayout();
        }

        private void AddGeneral()
        {
            general genTab = new general();
            genTab.SuspendLayout();
            genTab.HeroFile = this.HeroFile;
            genTab.file = System.IO.Path.GetFileName(this.file);
            if (this.IdxFile != null)
                genTab.IdxFile = this.IdxFile;
            genTab.populate();
            TabPage tp = new TabPage("General");
            tp.Controls.Add(genTab);
            tp.AutoScroll = true;
            this.heroTabControl.Controls.Add(tp);
            genTab.ResumeLayout();
        }

        private void AddRaw()
        {
            rawTab heroTab = new rawTab();
            heroTab.SuspendLayout();
            heroTab.HeroFile = this.HeroFile;
            heroTab.file = this.file;
            heroTab.setData(3);
            TabPage tp = new TabPage("Raw");
            tp.Controls.Add(heroTab);
            this.heroTabControl.Controls.Add(tp);
            heroTab.ResumeLayout();
        }
    }
}
