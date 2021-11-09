using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using D3Studio.lists.types;
using D3Studio.lists;

namespace D3Studio.ui.hero
{
    public partial class skills : UserControl
    {
        public string file { get; set; }

        public PB.Hero.SavedDefinition HeroFile { get; set; }

        public PB.Console.HeroInfoList IdxFile { get; set; }

        public List<gbid> GBIDList = new List<gbid>();

        public List<skill> SkillList = new List<skill>();

        public bool isIDX { get; set; }

        private bool loaded = false;

        private bool loading = false;

        public skills()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.TVList.Visible = false;
            this.searchBox.Visible = false;
            TVList.TreeViewNodeSorter = new NodeSorter();
        }

        public void populate()
        {
            this.loaded = false;
            this.hideArrows();
            if (HeroFile.saved_data == null)
                HeroFile.saved_data = new PB.Hero.SavedData();
            if (HeroFile.saved_data.active_skills == null)
                HeroFile.saved_data.active_skills = new List<PB.Hero.SkillWithRune>();
            if (HeroFile.saved_data.active_skills.Count() < 6)
            {
                while (HeroFile.saved_data.active_skills.Count() < 6)
                {
                    HeroFile.saved_data.active_skills.Add(new PB.Hero.SkillWithRune());
                }
            }
            if (HeroFile.saved_data.sno_traits == null)
                HeroFile.saved_data.sno_traits = new List<int>();
            if (HeroFile.saved_data.sno_traits.Count() < 4)
            {
                while (HeroFile.saved_data.sno_traits.Count() < 4)
                {
                    HeroFile.saved_data.sno_traits.Add(-1);
                }
            }
            if (HeroFile.digest.gbid_class == 1337532130)
            {
                this.className.Text = "[Class: Barbarian]";
                this.skill1.DataSource = this.BarbarianSkills();
                this.skill2.DataSource = this.BarbarianSkills();
                this.skill3.DataSource = this.BarbarianSkills();
                this.skill4.DataSource = this.BarbarianSkills();
                this.skill5.DataSource = this.BarbarianSkills();
                this.skill6.DataSource = this.BarbarianSkills();
                this.passive1.DataSource = this.BarbarianPassives();
                this.passive2.DataSource = this.BarbarianPassives();
                this.passive3.DataSource = this.BarbarianPassives();
                this.passive4.DataSource = this.BarbarianPassives();
            }
            else if (HeroFile.digest.gbid_class == -930376119)
            {
                this.className.Text = "[Class: Demon Hunter]";
                this.skill1.DataSource = this.DemonHunterSkills();
                this.skill2.DataSource = this.DemonHunterSkills();
                this.skill3.DataSource = this.DemonHunterSkills();
                this.skill4.DataSource = this.DemonHunterSkills();
                this.skill5.DataSource = this.DemonHunterSkills();
                this.skill6.DataSource = this.DemonHunterSkills();
                this.passive1.DataSource = this.DemonHunterPassives();
                this.passive2.DataSource = this.DemonHunterPassives();
                this.passive3.DataSource = this.DemonHunterPassives();
                this.passive4.DataSource = this.DemonHunterPassives();
            }
            else if (HeroFile.digest.gbid_class == 4041749)
            {
                this.className.Text = "[Class: Monk]";
                this.skill1.DataSource = this.MonkSkills();
                this.skill2.DataSource = this.MonkSkills();
                this.skill3.DataSource = this.MonkSkills();
                this.skill4.DataSource = this.MonkSkills();
                this.skill5.DataSource = this.MonkSkills();
                this.skill6.DataSource = this.MonkSkills();
                this.passive1.DataSource = this.MonkPassives();
                this.passive2.DataSource = this.MonkPassives();
                this.passive3.DataSource = this.MonkPassives();
                this.passive4.DataSource = this.MonkPassives();
            }
            else if (HeroFile.digest.gbid_class == 54772266)
            {
                this.className.Text = "[Class: Witch Doctor]";
                this.skill1.DataSource = this.WitchDoctorSkills();
                this.skill2.DataSource = this.WitchDoctorSkills();
                this.skill3.DataSource = this.WitchDoctorSkills();
                this.skill4.DataSource = this.WitchDoctorSkills();
                this.skill5.DataSource = this.WitchDoctorSkills();
                this.skill6.DataSource = this.WitchDoctorSkills();
                this.passive1.DataSource = this.WitchDoctorPassives();
                this.passive2.DataSource = this.WitchDoctorPassives();
                this.passive3.DataSource = this.WitchDoctorPassives();
                this.passive4.DataSource = this.WitchDoctorPassives();
            }
            else if (HeroFile.digest.gbid_class == 491159985)
            {
                this.className.Text = "[Class: Wizard]";
                this.skill1.DataSource = this.WizardSkills();
                this.skill2.DataSource = this.WizardSkills();
                this.skill3.DataSource = this.WizardSkills();
                this.skill4.DataSource = this.WizardSkills();
                this.skill5.DataSource = this.WizardSkills();
                this.skill6.DataSource = this.WizardSkills();
                this.passive1.DataSource = this.WizardPassives();
                this.passive2.DataSource = this.WizardPassives();
                this.passive3.DataSource = this.WizardPassives();
                this.passive4.DataSource = this.WizardPassives();
            }
            else if (HeroFile.digest.gbid_class == -1104684007)
            {
                this.className.Text = "[Class: Crusader]";
                this.skill1.DataSource = this.CrusaderSkills();
                this.skill2.DataSource = this.CrusaderSkills();
                this.skill3.DataSource = this.CrusaderSkills();
                this.skill4.DataSource = this.CrusaderSkills();
                this.skill5.DataSource = this.CrusaderSkills();
                this.skill6.DataSource = this.CrusaderSkills();
                this.passive1.DataSource = this.CrusaderPassives();
                this.passive2.DataSource = this.CrusaderPassives();
                this.passive3.DataSource = this.CrusaderPassives();
                this.passive4.DataSource = this.CrusaderPassives();
            }
            else if (HeroFile.digest.gbid_class == -1924295443)
            {
                this.className.Text = "[Class: Necromancer]";
                this.skill1.DataSource = this.NecromancerSkills();
                this.skill2.DataSource = this.NecromancerSkills();
                this.skill3.DataSource = this.NecromancerSkills();
                this.skill4.DataSource = this.NecromancerSkills();
                this.skill5.DataSource = this.NecromancerSkills();
                this.skill6.DataSource = this.NecromancerSkills();
                this.passive1.DataSource = this.NecromancerPassives();
                this.passive2.DataSource = this.NecromancerPassives();
                this.passive3.DataSource = this.NecromancerPassives();
                this.passive4.DataSource = this.NecromancerPassives();
            }
            this.skill1.DisplayMember = "Text";
            this.skill1.ValueMember = "Value";
            this.skill2.DisplayMember = "Text";
            this.skill2.ValueMember = "Value";
            this.skill3.DisplayMember = "Text";
            this.skill3.ValueMember = "Value";
            this.skill4.DisplayMember = "Text";
            this.skill4.ValueMember = "Value";
            this.skill5.DisplayMember = "Text";
            this.skill5.ValueMember = "Value";
            this.skill6.DisplayMember = "Text";
            this.skill6.ValueMember = "Value";
            this.passive1.DisplayMember = "Text";
            this.passive1.ValueMember = "Value";
            this.passive2.DisplayMember = "Text";
            this.passive2.ValueMember = "Value";
            this.passive3.DisplayMember = "Text";
            this.passive3.ValueMember = "Value";
            this.passive4.DisplayMember = "Text";
            this.passive4.ValueMember = "Value";
            this.skill1.SelectedValue = HeroFile.saved_data.active_skills[0].sno_skill.ToString();
            this.skill2.SelectedValue = HeroFile.saved_data.active_skills[1].sno_skill.ToString();
            this.skill3.SelectedValue = HeroFile.saved_data.active_skills[2].sno_skill.ToString();
            this.skill4.SelectedValue = HeroFile.saved_data.active_skills[3].sno_skill.ToString();
            this.skill5.SelectedValue = HeroFile.saved_data.active_skills[4].sno_skill.ToString();
            this.skill6.SelectedValue = HeroFile.saved_data.active_skills[5].sno_skill.ToString();
            this.passive1.SelectedValue = HeroFile.saved_data.sno_traits[0].ToString();
            this.passive2.SelectedValue = HeroFile.saved_data.sno_traits[1].ToString();
            this.passive3.SelectedValue = HeroFile.saved_data.sno_traits[2].ToString();
            this.passive4.SelectedValue = HeroFile.saved_data.sno_traits[3].ToString();
            if (this.HeroFile.saved_data.cube_powers == null)
                this.HeroFile.saved_data.cube_powers = new List<int>();
            if(this.HeroFile.saved_data.cube_powers.Count() < 3)
            {
                while (this.HeroFile.saved_data.cube_powers.Count() < 3)
                    this.HeroFile.saved_data.cube_powers.Add(-1);
            }
            this.cubeJewlry.Text = helper.DefaultFindGBID(this.HeroFile.saved_data.cube_powers[2].ToString(), 0, this.GBIDList).Name;
            this.cubeArmor.Text = helper.DefaultFindGBID(this.HeroFile.saved_data.cube_powers[1].ToString(), 0, this.GBIDList).Name;
            this.cubeWeapon.Text = helper.DefaultFindGBID(this.HeroFile.saved_data.cube_powers[0].ToString(), 0, this.GBIDList).Name;
            this.HeroFile.saved_data.skill_kit_version = 27;
            this.HeroFile.saved_data.skill_slot_ever_assigned = new byte[]
            {
                63
            };
            this.cubeJewlry.Tag = new Dictionary<string,int>{
                { "index", 2 },
                { "gbid", this.HeroFile.saved_data.cube_powers[2] }
            };
            this.cubeArmor.Tag = new Dictionary<string, int>{
                { "index", 1 },
                { "gbid", this.HeroFile.saved_data.cube_powers[1] }
            };
            this.cubeWeapon.Tag = new Dictionary<string, int>{
                { "index", 0 },
                { "gbid", this.HeroFile.saved_data.cube_powers[0] }
            };
            this.loaded = true;
        }

        private void searchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            this.loading = true;
            this.TVList.Nodes.Clear();
            if(this.searchBox.Text == "")
            {
                foreach (gbid id in this.GBIDList)
                {
                    TreeNode node = new TreeNode();
                    node.Text = id.Name;
                    node.Tag = id.GBID.ToString();
                    bool pass = false;
                    foreach (TreeNode x in this.TVList.Nodes)
                    {
                        if (x.Text.ToLower() == id.Category.ToLower())
                        {
                            x.Nodes.Add(node);
                            pass = true;
                        }
                    }
                    if (!pass)
                    {
                        this.TVList.Nodes.Add(id.Category);
                        foreach (TreeNode x in this.TVList.Nodes)
                        {
                            if (x.Text.ToLower() == id.Category.ToLower())
                            {
                                x.Nodes.Add(node);
                                pass = true;
                            }
                        }
                    }
                }
                this.TVList.Sort();
                this.loading = false;
                return;
            }
            foreach (gbid id in this.GBIDList)
            {
                if(id.Name.ToLower().Contains(this.searchBox.Text.ToLower()))
                {
                    TreeNode node = new TreeNode();
                    node.Text = id.Name;
                    node.Tag = id.GBID.ToString();
                    bool pass = false;
                    foreach (TreeNode x in this.TVList.Nodes)
                    {
                        if (x.Text.ToLower() == id.Category.ToLower())
                        {
                            x.Nodes.Add(node);
                            pass = true;
                        }
                    }
                    if (!pass)
                    {
                        this.TVList.Nodes.Add(id.Category);
                        foreach (TreeNode x in this.TVList.Nodes)
                        {
                            if (x.Text.ToLower() == id.Category.ToLower())
                            {
                                x.Nodes.Add(node);
                                pass = true;
                            }
                        }
                    }
                }
            }
            this.TVList.Sort();
            this.TVList.ExpandAll();
            this.TVList.Visible = false;
            this.TVList.Sort();
            this.TVList.CollapseAll();
            if (this.searchBox.Text != "")
                this.TVList.ExpandAll();
            this.TVList.Visible = true;
            this.searchBox.Focus();
            this.loading = false;
        }

        private void skills_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.loaded)
                return;
            ComboBox cb = (ComboBox)sender;
            this.HeroFile.saved_data.active_skills[Convert.ToInt32(cb.Tag)].sno_skill = Convert.ToInt32(cb.SelectedValue);
            AddSkillInfo(Convert.ToInt32(cb.SelectedValue), true);
        }

        private void passives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.loaded)
                return;
            ComboBox cb = (ComboBox)sender;
            this.HeroFile.saved_data.sno_traits[Convert.ToInt32(cb.Tag)] = Convert.ToInt32(cb.SelectedValue);
            AddSkillInfo(Convert.ToInt32(cb.SelectedValue), false);
        }

        private void TVList_DoubleClick(object sender, EventArgs e)
        {
            if (this.TVList.SelectedNode.Tag == null)
                return;
            Dictionary<string, int> tag = (Dictionary<string, int>)this.TVList.Tag;
            this.HeroFile.saved_data.cube_powers[tag["index"]] = Convert.ToInt32(TVList.SelectedNode.Tag);
            gbid selected = helper.DefaultFindGBID(this.HeroFile.saved_data.cube_powers[tag["index"]].ToString(), 0, this.GBIDList);
            this.AddInfo(selected);
            if (tag["index"] == 0)
            {
                this.cubeWeapon.Text = helper.DefaultFindGBID(this.HeroFile.saved_data.cube_powers[0].ToString(), 0, this.GBIDList).Name;
                this.cubeWeapon.Tag = new Dictionary<string, int> {
                    { "index", 0 },
                    { "gbid", this.HeroFile.saved_data.cube_powers[0] }
                };
            }
            else if (tag["index"] == 1)
            {
                this.cubeArmor.Text = helper.DefaultFindGBID(this.HeroFile.saved_data.cube_powers[1].ToString(), 0, this.GBIDList).Name;
                this.cubeArmor.Tag = new Dictionary<string, int> {
                    { "index", 1 },
                    { "gbid", this.HeroFile.saved_data.cube_powers[1] }
                };
            }
            else if (tag["index"] == 2)
            {
                this.cubeJewlry.Text = helper.DefaultFindGBID(this.HeroFile.saved_data.cube_powers[2].ToString(), 0, this.GBIDList).Name;
                this.cubeJewlry.Tag = new Dictionary<string, int> {
                    { "index", 2 },
                    { "gbid", this.HeroFile.saved_data.cube_powers[2] }
                };
            }
        }

        private void AddSkillInfo(int? s, bool type)
        {
            if (s == 0 || s == -1)
            {
                this.infoBox.name = "None";
                this.infoBox.description = "~...";
                this.infoBox.populate();
                return;
            }
            string str = "";
            if (type)
                str = "Skill: ";
            else
                str = "Passive: ";
            skill sk = this.SkillList.First(x => x.SNO == s);
            if (sk != null)
            {
                this.infoBox.name = str + sk.Name;
                this.infoBox.description = sk.Details;
            }
            else
            {
                this.infoBox.name = str + sk.ToString();
                this.infoBox.description = "~Item not found...";
            }
            this.infoBox.populate();
        }

        private void AddInfo(gbid item)
        {
            if (helper.FindGBID(item.GBID.ToString(), 0, this.GBIDList) != null)
            {
                this.infoBox.name = item.Name;
                this.infoBox.description = item.Details;
            }
            else
            {
                this.infoBox.name = item.GBID.ToString();
                this.infoBox.description = "~Item not found...";
            }
            this.infoBox.populate();
        }

        private void cube_click(object sender, EventArgs e)
        {
            //hideArrows();
            this.button1.Visible = false;
            TextBox tb = (TextBox)sender;
            this.searchBox.Text = "Search...";
            this.searchBox.ForeColor = Color.DimGray;
            this.TVList.Tag = tb.Tag;
            Dictionary<string, int> tag = (Dictionary<string, int>)tb.Tag;
            gbid selected = helper.DefaultFindGBID(tag["gbid"].ToString(), 0, this.GBIDList);
            this.AddInfo(selected);
            if (tag["index"] == 0)
            {
                if (this.weaponArrow.Visible)
                {
                    this.weaponArrow.Visible = false;
                    this.TVList.Visible = false;
                    this.searchBox.Visible = false;
                    return;
                }
                hideArrows();
                this.weaponArrow.Visible = true;
            }
            else if (tag["index"] == 1)
            {
                if (this.armorArrow.Visible)
                {
                    this.armorArrow.Visible = false;
                    this.TVList.Visible = false;
                    this.searchBox.Visible = false;
                    return;
                }
                hideArrows();
                this.armorArrow.Visible = true;
            }
            else if (tag["index"] == 2)
            {
                if (this.jewlryArrow.Visible)
                {
                    this.jewlryArrow.Visible = false;
                    this.TVList.Visible = false;
                    this.searchBox.Visible = false;
                    return;
                }
                hideArrows();
                this.jewlryArrow.Visible = true;
            }
            this.button1.Visible = true;
            this.TVList.Visible = true;
            this.searchBox.Visible = true;
            this.loadTV(tag);
        }

        public void populateTV()
        {
            this.loading = true;
            this.TVList.Nodes.Clear();
            foreach (gbid id in this.GBIDList)
            {
                TreeNode node = new TreeNode();
                node.Text = id.Name;
                node.Tag = id.GBID.ToString();
                bool pass = false;
                foreach (TreeNode x in this.TVList.Nodes)
                {
                    if (x.Text.ToLower() == id.Category.ToLower())
                    {
                        x.Nodes.Add(node);
                        pass = true;
                    }
                }
                if (!pass)
                {
                    this.TVList.Nodes.Add(id.Category);
                    foreach (TreeNode x in this.TVList.Nodes)
                    {
                        if (x.Text.ToLower() == id.Category.ToLower())
                        {
                            x.Nodes.Add(node);
                            pass = true;
                        }
                    }
                }
            }
            this.TVList.Sort();
        }

        private void loadTV(Dictionary<string, int> tag)
        {
            try
            {
                this.TVList.CollapseAll();
                this.TVList.Tag = tag;
                var result = this.TVList.Descendants().Where(x => (x.Tag as string) == tag["gbid"].ToString()).FirstOrDefault();
                if (result != null)
                {
                    this.TVList.Focus();
                    this.TVList.SelectedNode = result;
                }
            }
            catch { }
            this.loading = false;
        }

            public void hideArrows()
        {
            this.jewlryArrow.Visible = false;
            this.weaponArrow.Visible = false;
            this.armorArrow.Visible = false;
        }

        private Array BarbarianSkills()
        {
            return new[]
            {
                new { Text = "None", Value = "-1" },
                new { Text = "None", Value = "0" },
                new { Text = "Ancient Spear", Value = "377453" },
                new { Text = "Avalanche", Value = "353447" },
                new { Text = "Bash", Value = "79242" },
                new { Text = "Battle Rage", Value = "79076" },
                new { Text = "Call Of The Ancients", Value = "80049" },
                new { Text = "Cleave", Value = "80263" },
                new { Text = "Earthquake", Value = "98878" },
                new { Text = "Frenzy", Value = "78548" },
                new { Text = "FuriousCharge", Value = "97435" },
                new { Text = "Ground Stomp", Value = "79446" },
                new { Text = "Hammer Of The Ancients", Value = "80028" },
                new { Text = "Ignore Pain", Value = "79528" },
                new { Text = "Leap", Value = "93409" },
                new { Text = "Overpower", Value = "159169" },
                new { Text = "Rend", Value = "70472" },
                new { Text = "Revenge", Value = "109342" },
                new { Text = "Seismic Slam", Value = "86989" },
                new { Text = "Sprint", Value = "78551" },
                new { Text = "Threatening Shout", Value = "79077" },
                new { Text = "War Cry", Value = "375483" },
                new { Text = "Weapon Throw", Value = "377452" },
                new { Text = "Whirlwind", Value = "96296" },
                new { Text = "Wrath Of The Berserker", Value = "79607" }
            };
        }

        private Array CrusaderSkills()
        {
            return new[]
            {
                new { Text = "None", Value = "-1" },
                new { Text = "None", Value = "0" },
                new { Text = "Akarats Champion", Value = "269032" },
                new { Text = "BlessedHammer", Value = "266766" },
                new { Text = "BlessedShield", Value = "266951" },
                new { Text = "Bombardment", Value = "284876" },
                new { Text = "Condemn", Value = "266627" },
                new { Text = "Consecration", Value = "273941" },
                new { Text = "Crushing Resolve", Value = "267818" },
                new { Text = "Falling Sword", Value = "239137" },
                new { Text = "Fist Of The Heavens", Value = "239218" },
                new { Text = "Heavens Fury", Value = "316014" },
                new { Text = "Iron Skin", Value = "291804" },
                new { Text = "Judgment", Value = "267600" },
                new { Text = "Justice", Value = "325216" },
                new { Text = "Laws Of Hope", Value = "342279" },
                new { Text = "Laws Of Justice", Value = "342280" },
                new { Text = "Laws Of Valor", Value = "342281" },
                new { Text = "Phalanx", Value = "330729" },
                new { Text = "Provoke", Value = "290545" },
                new { Text = "Punish", Value = "285903" },
                new { Text = "Shield Bash", Value = "353492" },
                new { Text = "Shield Glare", Value = "268530" },
                new { Text = "Slash", Value = "289243" },
                new { Text = "Smite", Value = "286510" },
                new { Text = "Steed Charge", Value = "243853" },
                new { Text = "Sweep Attack", Value = "239042" }
            };
        }

        private Array DemonHunterSkills()
        {
            return new[]
            {
                new { Text = "None", Value = "-1" },
                new { Text = "None", Value = "0" },
                new { Text = "Bolas", Value = "77552" },
                new { Text = "Caltrops", Value = "129216" },
                new { Text = "Chakram", Value = "129213" },
                new { Text = "Cluster Arrow", Value = "129214" },
                new { Text = "Companion", Value = "365311" },
                new { Text = "Elemental Arrow", Value = "131325" },
                new { Text = "Entangling Shot", Value = "361936" },
                new { Text = "Evasive Fire", Value = "377450" },
                new { Text = "Fan Of Knives", Value = "77546" },
                new { Text = "Grenades", Value = "86610" },
                new { Text = "Hungering Arrow", Value = "129215" },
                new { Text = "Impale", Value = "131366" },
                new { Text = "Marked For Death", Value = "130738" },
                new { Text = "Multishot", Value = "77649" },
                new { Text = "Preparation", Value = "129212" },
                new { Text = "Rain Of Vengeance", Value = "130831" },
                new { Text = "Rapid Fire", Value = "131192" },
                new { Text = "Sentry", Value = "129217" },
                new { Text = "Shadow Power", Value = "130830" },
                new { Text = "Smoke Screen", Value = "130695" },
                new { Text = "Spike Trap", Value = "75301" },
                new { Text = "Strafe", Value = "134030" },
                new { Text = "Vault", Value = "111215" },
                new { Text = "Vengeance", Value = "302846" }
            };
        }

        private Array MonkSkills()
        {
            return new[]
            {
                new { Text = "None", Value = "-1" },
                new { Text = "None", Value = "0" },
                new { Text = "Blinding Flash", Value = "136954" },
                new { Text = "Breath Of Heaven", Value = "69130" },
                new { Text = "Crippling Wave", Value = "96311" },
                new { Text = "Cyclone Strike", Value = "223473" },
                new { Text = "Dashing Strike", Value = "312736" },
                new { Text = "Deadly Reach", Value = "96019" },
                new { Text = "Epiphany", Value = "312307" },
                new { Text = "Exploding Palm", Value = "97328" },
                new { Text = "Fists Of Thunder", Value = "95940" },
                new { Text = "Inner Sanctuary", Value = "317076" },
                new { Text = "Lashing Tail Kick", Value = "111676" },
                new { Text = "Mantra Of Conviction", Value = "375088" },
                new { Text = "Mantra Of Healing", Value = "373143" },
                new { Text = "Mantra Of Retribution", Value = "375082" },
                new { Text = "Mantra Of Salvation", Value = "375049" },
                new { Text = "Mystic Ally", Value = "362102" },
                new { Text = "Serenity", Value = "96215" },
                new { Text = "Seven Sided Strike", Value = "96694" },
                new { Text = "Sweeping Wind", Value = "96090" },
                new { Text = "Tempest Rush", Value = "121442" },
                new { Text = "Wave Of Light", Value = "96033" },
                new { Text = "Way Of The Hundred Fists", Value = "97110" }
            };
        }

        private Array NecromancerSkills()
        {
            return new[]
            {
                new { Text = "None", Value = "-1" },
                new { Text = "None", Value = "0" },
                new { Text = "Army Of The Dead", Value = "460358" },
                new { Text = "Blood Rush", Value = "454090" },
                new { Text = "Bone Armor", Value = "466857" },
                new { Text = "Bone Spear", Value = "451490" },
                new { Text = "Bone Spikes", Value = "462147" },
                new { Text = "Bone Spirit", Value = "464896" },
                new { Text = "Command Golem", Value = "451537" },
                new { Text = "Command Skeletons", Value = "453801" },
                new { Text = "Corpse Explosion", Value = "454174" },
                new { Text = "Corpse Lance", Value = "461650" },
                new { Text = "Death Nova", Value = "462243" },
                new { Text = "Decrepify", Value = "451491" },
                new { Text = "Devour", Value = "460757" },
                new { Text = "Frailty", Value = "460870" },
                new { Text = "Grim Scythe", Value = "462198" },
                new { Text = "Land Of The Dead", Value = "465839" },
                new { Text = "Leech", Value = "462255" },
                new { Text = "Revive", Value = "462239" },
                new { Text = "Simulacrum", Value = "465350" },
                new { Text = "Siphon Blood", Value = "453563" },
                new { Text = "Skeletal Mage", Value = "462089" }
            };
        }

        private Array WitchDoctorSkills()
        {
            return new[]
            {
                new { Text = "None", Value = "-1" },
                new { Text = "None", Value = "0" },
                new { Text = "Acid Cloud", Value = "70455" },
                new { Text = "Big Bad Voodoo", Value = "117402" },
                new { Text = "Corpse Spider", Value = "69866" },
                new { Text = "Fetish Army", Value = "72785" },
                new { Text = "Firebats", Value = "105963" },
                new { Text = "Firebomb", Value = "67567" },
                new { Text = "Gargantuan", Value = "30624" },
                new { Text = "Grasp Of The Dead", Value = "69182" },
                new { Text = "Haunt", Value = "83602" },
                new { Text = "Hex", Value = "30631" },
                new { Text = "Horrify", Value = "67668" },
                new { Text = "Locust Swarm", Value = "69867" },
                new { Text = "Mass Confusion", Value = "67600" },
                new { Text = "Piranhas", Value = "347265" },
                new { Text = "Plague Of Toads", Value = "106465" },
                new { Text = "Poison Dart", Value = "103181" },
                new { Text = "Sacrifice", Value = "102572" },
                new { Text = "Soul Harvest", Value = "67616" },
                new { Text = "Spirit Barrage", Value = "108506" },
                new { Text = "Spirit Walk", Value = "106237" },
                new { Text = "Summon Zombie Dog", Value = "102573" },
                new { Text = "Wall Of Death", Value = "134837" },
                new { Text = "Zombie Charger", Value = "74003" }
            };
        }

        private Array WizardSkills()
        {
            return new[]
            {
                new { Text = "None", Value = "-1" },
                new { Text = "None", Value = "0" },
                new { Text = "Arcane Orb", Value = "30668" },
                new { Text = "Arcane Torrent", Value = "134456" },
                new { Text = "Archon", Value = "134872" },
                new { Text = "Archon Arcane Blast", Value = "167355" },
                new { Text = "Archon Arcane Blast Cold", Value = "392883" },
                new { Text = "Archon Arcane Blast Fire", Value = "392884" },
                new { Text = "Archon Arcane Blast Lightning", Value = "392885" },
                new { Text = "Archon Arcane Strike", Value = "135166" },
                new { Text = "Archon Arcane Strike Cold", Value = "392886" },
                new { Text = "Archon Arcane Strike Fire", Value = "392887" },
                new { Text = "Archon Arcane Strike Lightning", Value = "392888" },
                new { Text = "Archon Cancel", Value = "166616" },
                new { Text = "Archon Disintegration Wave", Value = "135238" },
                new { Text = "Archon Disintegration Wave Cold", Value = "392889" },
                new { Text = "Archon Disintegration Wave Fire", Value = "392890" },
                new { Text = "Archon Disintegration Wave Lightning", Value = "392891" },
                new { Text = "Archon Slow Time", Value = "135663" },
                new { Text = "Archon Teleport", Value = "167648" },
                new { Text = "Black Hole", Value = "243141" },
                new { Text = "Blizzard", Value = "30680" },
                new { Text = "Diamond Skin", Value = "75599" },
                new { Text = "Disintegrate", Value = "91549" },
                new { Text = "Electrocute", Value = "1765" },
                new { Text = "Energy Armor", Value = "86991" },
                new { Text = "Energy Twister", Value = "77113" },
                new { Text = "Explosive Blast", Value = "87525" },
                new { Text = "Familiar", Value = "99120" },
                new { Text = "Frost Nova", Value = "30718" },
                new { Text = "Hydra", Value = "30725" },
                new { Text = "Ice Armor", Value = "73223" },
                new { Text = "Magic Missile", Value = "30744" },
                new { Text = "Magic Weapon", Value = "76108" },
                new { Text = "Meteor", Value = "69190" },
                new { Text = "Mirror Image", Value = "98027" },
                new { Text = "Ray Of Frost", Value = "93395" },
                new { Text = "Shock Pulse", Value = "30783" },
                new { Text = "Slow Time", Value = "1769" },
                new { Text = "Spectral Blade", Value = "71548" },
                new { Text = "Storm Armor", Value = "74499" },
                new { Text = "Teleport", Value = "168344" },
                new { Text = "Wave Of Force", Value = "30796" }
            };
        }

        private Array BarbarianPassives()
        {
            return new[]
            {
                new { Text = "None", Value = "-1" },
                new { Text = "None", Value = "0" },
                new { Text = "Animosity", Value = "205228" },
                new { Text = "Berserker Rage", Value = "205187" },
                new { Text = "Bloodthirst", Value = "205217" },
                new { Text = "Boon Of Bul Kathos", Value = "204603" },
                new { Text = "Brawler", Value = "205133" },
                new { Text = "Earthen Might", Value = "361661" },
                new { Text = "Inspiring Presence", Value = "205546" },
                new { Text = "Juggernaut", Value = "205707" },
                new { Text = "Nerves Of Steel", Value = "217819" },
                new { Text = "No Escape", Value = "204725" },
                new { Text = "Pound Of Flesh", Value = "205205" },
                new { Text = "Rampage", Value = "296572" },
                new { Text = "Relentless", Value = "205398" },
                new { Text = "Ruthless", Value = "205175" },
                new { Text = "Superstition", Value = "205491" },
                new { Text = "Sword And Board", Value = "340877" },
                new { Text = "Tough As Nails", Value = "205848" },
                new { Text = "Unforgiving", Value = "205300" },
                new { Text = "Weapons Master", Value = "206147" }
            };
        }

        private Array CrusaderPassives()
        {
            return new[]
            {
                new { Text = "None", Value = "-1" },
                new { Text = "None", Value = "0" },
                new { Text = "Blunt", Value = "348773" },
                new { Text = "Divine Fortress", Value = "356176" },
                new { Text = "Fanaticism", Value = "357269" },
                new { Text = "Fervor", Value = "357218" },
                new { Text = "Finery", Value = "311629" },
                new { Text = "Heavenly Strength", Value = "286177" },
                new { Text = "Hold Your Ground", Value = "302500" },
                new { Text = "Holy Cause", Value = "310804" },
                new { Text = "Indestructible", Value = "309830" },
                new { Text = "Insurmountable", Value = "310640" },
                new { Text = "Iron Maiden", Value = "310783" },
                new { Text = "Long Arm Of TheLaw", Value = "310678" },
                new { Text = "Lord Commander", Value = "348741" },
                new { Text = "Renewal", Value = "356173" },
                new { Text = "Righteousness", Value = "356147" },
                new { Text = "Towering Shield", Value = "356052" },
                new { Text = "Vigilant", Value = "310626" },
                new { Text = "Wrathful", Value = "310775" }
            };
        }

        private Array DemonHunterPassives()
        {
            return new[]
            {
                new { Text = "None", Value = "-1" },
                new { Text = "None", Value = "0" },
                new { Text = "Ambush", Value = "352920" },
                new { Text = "Archery", Value = "209734" },
                new { Text = "Awareness", Value = "324770" },
                new { Text = "Ballistics", Value = "155723" },
                new { Text = "Brooding", Value = "210801" },
                new { Text = "Companion Passive Effect", Value = "365312" },
                new { Text = "Cull The Weak", Value = "155721" },
                new { Text = "Custom Engineering", Value = "208610" },
                new { Text = "Grenadier", Value = "208779" },
                new { Text = "Hot Pursuit", Value = "155725" },
                new { Text = "Leech", Value = "439525" },
                new { Text = "Night Stalker", Value = "218350" },
                new { Text = "Numbing Traps", Value = "218398" },
                new { Text = "Perfectionist", Value = "155722" },
                new { Text = "Preparation Passive Effect", Value = "324845" },
                new { Text = "Sharpshooter", Value = "155715" },
                new { Text = "Single Out", Value = "338859" },
                new { Text = "Steady Aim", Value = "164363" },
                new { Text = "Tactical Advantage", Value = "218385" },
                new { Text = "Thrill Of The Hunt", Value = "211225" },
                new { Text = "Vengeance Passive Effect", Value = "155714" }
            };
        }

        private Array MonkPassives()
        {
            return new[]
            {
                new { Text = "None", Value = "-1" },
                new { Text = "None", Value = "0" },
                new { Text = "Alacrity", Value = "156492" },
                new { Text = "Beacon Of Ytar", Value = "209104" },
                new { Text = "Chant Of Resonance", Value = "156467" },
                new { Text = "Combination Strike", Value = "218415" },
                new { Text = "Determination", Value = "402633" },
                new { Text = "Exalted Soul", Value = "209027" },
                new { Text = "Fleet Footed", Value = "209029" },
                new { Text = "Harmony", Value = "404168" },
                new { Text = "Mantra Of ConvictionV2", Value = "375089" },
                new { Text = "Mantra Of Evasion V2", Value = "375050" },
                new { Text = "Mantra Of Healing V2", Value = "373154" },
                new { Text = "Mantra Of Retribution V2", Value = "375083" },
                new { Text = "Momentum", Value = "341559" },
                new { Text = "Mythic Rhythm", Value = "315271" },
                new { Text = "Near Death Experience", Value = "156484" },
                new { Text = "Relentless Assault", Value = "404245" },
                new { Text = "Resolve", Value = "211581" },
                new { Text = "Seize The Initiative", Value = "209628" },
                new { Text = "Sixth Sense", Value = "209622" },
                new { Text = "The Guardians Path", Value = "209812" },
                new { Text = "Transcendence", Value = "209250" },
                new { Text = "Unity", Value = "368899" }
            };
        }

        private Array NecromancerPassives()
        {
            return new[]
            {
                new { Text = "None", Value = "-1" },
                new { Text = "None", Value = "0" },
                new { Text = "Aberrant Animator", Value = "472949" },
                new { Text = "Blood For Blood", Value = "465821" },
                new { Text = "Blood Is Power", Value = "465037" },
                new { Text = "Bone Prison", Value = "472965" },
                new { Text = "Commander Of The Risen Dead", Value = "472962" },
                new { Text = "Dark Reaping", Value = "470812" },
                new { Text = "Decrepify Passive Effect", Value = "471738" },
                new { Text = "Draw Life", Value = "465264" },
                new { Text = "Eternal Torment", Value = "472795" },
                new { Text = "Extended Servitude", Value = "464994" },
                new { Text = "Final Service", Value = "465952" },
                new { Text = "Frailty Passive Effect", Value = "471845" },
                new { Text = "Fueled By Death", Value = "465917" },
                new { Text = "Grisly Tribute", Value = "473019" },
                new { Text = "Leech Passive Effect", Value = "471869" },
                new { Text = "Life From Death", Value = "465703" },
                new { Text = "Overwhelming Essence", Value = "470764" },
                new { Text = "Rathmas Shield", Value = "472910" },
                new { Text = "Rigor Mortis", Value = "466415" },
                new { Text = "Serration", Value = "472905" },
                new { Text = "Spreading Malediction", Value = "472220" },
                new { Text = "Stand Alone", Value = "470725" },
                new { Text = "Swift Harvesting", Value = "470805" }
            };
        }

        private Array WitchDoctorPassives()
        {
            return new[]
            {
                new { Text = "None", Value = "-1" },
                new { Text = "None", Value = "0" },
                new { Text = "Bad Medicine", Value = "217826" },
                new { Text = "Blood Ritual", Value = "208568" },
                new { Text = "Circle Of Life", Value = "208571" },
                new { Text = "Confidence Ritual", Value = "442741" },
                new { Text = "Creeping Death", Value = "340908" },
                new { Text = "Fetish Sycophants", Value = "218588" },
                new { Text = "Fierce Loyalty", Value = "208639" },
                new { Text = "Grave Injustice", Value = "218191" },
                new { Text = "Gruesome Feast", Value = "208594" },
                new { Text = "Jungle Fortitude", Value = "217968" },
                new { Text = "Midnight Feast", Value = "340909" },
                new { Text = "Pierce The Veil", Value = "208628" },
                new { Text = "Rush Of Essence", Value = "208565" },
                new { Text = "Spiritual Attunement", Value = "208569" },
                new { Text = "Spirit Vessel", Value = "218501" },
                new { Text = "Swampland Attunement", Value = "340910" },
                new { Text = "Trait Zombie Dog Spawner", Value = "109560" },
                new { Text = "Tribal Rites", Value = "208601" },
                new { Text = "Vision Quest", Value = "209041" },
                new { Text = "Zombie Handler", Value = "208563" }
            };
        }

        private Array WizardPassives()
        {
            return new[]
            {
                new { Text = "None", Value = "-1" },
                new { Text = "None", Value = "0" },
                new { Text = "Arcane Dynamo", Value = "208823" },
                new { Text = "Astral Presence", Value = "208472" },
                new { Text = "Audacity", Value = "341540" },
                new { Text = "Blur", Value = "208468" },
                new { Text = "Cold Blooded", Value = "226301" },
                new { Text = "Con flagration", Value = "218044" },
                new { Text = "Dominance", Value = "341344" },
                new { Text = "Elemental Exposure", Value = "342326" },
                new { Text = "Evocation", Value = "208473" },
                new { Text = "Galvanizing Ward", Value = "208541" },
                new { Text = "Glass Cannon", Value = "208471" },
                new { Text = "Illusionist", Value = "208547" },
                new { Text = "Paralysis", Value = "226348" },
                new { Text = "Power Hungry", Value = "208478" },
                new { Text = "Prodigy", Value = "208493" },
                new { Text = "Temporal Flux", Value = "208477" },
                new { Text = "Unstable Anomaly", Value = "208474" },
                new { Text = "Unwavering Will", Value = "298038" }
            };
        }

        private void RemoveText(object sender, EventArgs e)
        {
            if (this.searchBox.Text == "Search...")
            {
                this.searchBox.Text = "";
                this.searchBox.ForeColor = Color.Black;
            }
        }

        private void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.searchBox.Text))
            {
                this.searchBox.Text = "Search...";
                this.searchBox.ForeColor = Color.DimGray;
            }
        }

        private void TVList_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.TVList.SelectedNode.Tag == null)
                    return;
                Dictionary<string, int> tag = (Dictionary<string, int>)this.TVList.Tag;
                gbid selected = helper.DefaultFindGBID(this.TVList.SelectedNode.Tag.ToString(), 0, this.GBIDList);
                this.AddInfo(selected);
            }
            catch { }
        }

        private void TVList_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.TVList.SelectedNode.Tag == null)
                    return;
                Dictionary<string, int> tag = (Dictionary<string, int>)this.TVList.Tag;
                gbid selected = helper.DefaultFindGBID(this.TVList.SelectedNode.Tag.ToString(), 0, this.GBIDList);
                this.AddInfo(selected);
            }
            catch { }
        }

        private void TVList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (loading || this.TVList.SelectedNode.Tag == null)
                return;
            Dictionary<string, int> tag = (Dictionary<string, int>)this.TVList.Tag;
            gbid selected = helper.DefaultFindGBID(this.TVList.SelectedNode.Tag.ToString(), 0, this.GBIDList);
            this.AddInfo(selected);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripItem menuItem = sender as ToolStripItem;
                if (menuItem != null)
                {
                    ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                    if (owner != null)
                    {
                        TextBox tb = (TextBox)owner.SourceControl;
                        Dictionary<string, int> tag = (Dictionary<string, int>)tb.Tag;
                        string name = tb.Name.ToLower();
                        string str = "";
                        if (name.Contains("cube"))
                        {
                            str = "GBID:" + Base64Encode(this.HeroFile.saved_data.cube_powers[tag["index"]].ToString());
                        }
                        else
                            return;
                        Clipboard.SetText(str);
                    }
                }
            }
            catch
            {
            }
        }

        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripItem menuItem = sender as ToolStripItem;
                if (menuItem != null)
                {
                    ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                    if (owner != null)
                    {
                        TextBox tb = (TextBox)owner.SourceControl;
                        Dictionary<string, int> tag = (Dictionary<string, int>)tb.Tag;

                        string name = tb.Name.ToLower();
                        string[] str = Clipboard.GetText().Split(':');

                        if (name.Contains("cube") && str[0] == "GBID")
                        {
                            this.HeroFile.saved_data.cube_powers[tag["index"]] = Convert.ToInt32(Base64Decode(str[1]));
                            tb.Text = helper.DefaultFindGBID(this.HeroFile.saved_data.cube_powers[2].ToString(), 0, this.GBIDList).Name;
                        }
                        else
                            return;
                    }
                }
            }
            catch
            {
            }
        }

        private void editGBIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
            TextBox tb = (TextBox)owner.SourceControl;
            Dictionary<string, int> tag = (Dictionary<string, int>)tb.Tag;
            gbid temp = helper.DefaultFindGBID(tag["gbid"].ToString(), 0, this.GBIDList);
            embeddedIDEGBID ide = new embeddedIDEGBID();
            ide.GBIDList = this.GBIDList;
            ide.selected = temp;
            ide.populate();
            ide.ShowDialog();
            this.populate();
        }

        private void TVList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            TVList_DoubleClick(sender, new EventArgs());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.searchBox.Text = "";
            searchBox_KeyUp(this.searchBox, new KeyEventArgs(Keys.Enter));
        }
    }
}
