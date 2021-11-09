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
using System.IO;

namespace D3Studio.ui.hero
{
    public partial class visuals : UserControl
    {

        public string file { get; set; }
        public PB.Hero.SavedDefinition HeroFile { get; set; }

        public PB.Console.HeroInfoList IdxFile { get; set; }

        public heroBase parent;

        public List<gbid> GBIDList = new List<gbid>();

        public List<string> DyeDict = new List<string>();

        private bool loaded = false;

        public visuals()
        {
            InitializeComponent();
            //this.Dock = DockStyle.Fill;
            this.DyeDict = this.DyeIndex();
            GBIDTVList.TreeViewNodeSorter = new NodeSorter();
            DyeTVList.TreeViewNodeSorter = new NodeSorter();
        }

        public void populate()
        {
            LoadItems();
            this.file = Path.GetFileName(this.file);
            if (HeroFile.digest == null)
                HeroFile.digest = new PB.Hero.Digest();
            if (HeroFile.digest.visual_equipment == null)
                HeroFile.digest.visual_equipment = new PB.Hero.VisualEquipment();
            if (HeroFile.digest.visual_equipment.cosmetics == null)
                HeroFile.digest.visual_equipment.cosmetics = new List<PB.Hero.VisualItem>();
            if (HeroFile.digest.visual_equipment.visual_item == null)
                HeroFile.digest.visual_equipment.visual_item = new List<PB.Hero.VisualItem>();
            if (HeroFile.digest.visual_equipment.cosmetics.Count() < 8)
            {
                while (HeroFile.digest.visual_equipment.visual_item.Count() < 8)
                {
                    HeroFile.digest.visual_equipment.visual_item.Add(new PB.Hero.VisualItem());
                }
            }
            if(HeroFile.digest.visual_equipment.cosmetics.Count() < 4)
            {
                while(HeroFile.digest.visual_equipment.cosmetics.Count() < 4)
                {
                    HeroFile.digest.visual_equipment.cosmetics.Add(new PB.Hero.VisualItem());
                }
            }
            if (this.IdxFile != null)
            {
                try
                {
                    PB.Hero.VisualEquipment idevi = this.IdxFile.heroes.First(x => x.filename == this.file).visual_equipment;
                    if (idevi == null)
                        idevi = new PB.Hero.VisualEquipment();
                    if (idevi.cosmetics == null)
                        idevi.cosmetics = new List<PB.Hero.VisualItem>();
                    if (idevi.visual_item == null)
                        idevi.visual_item = new List<PB.Hero.VisualItem>();
                    if (idevi.cosmetics.Count() < 8)
                    {
                        while (idevi.visual_item.Count() < 8)
                        {
                            idevi.visual_item.Add(new PB.Hero.VisualItem());
                        }
                    }
                    if (idevi.cosmetics.Count() < 4)
                    {
                        while (idevi.cosmetics.Count() < 4)
                        {
                            idevi.cosmetics.Add(new PB.Hero.VisualItem());
                        }
                    }
                    this.IdxFile.heroes.First(x => x.filename == this.file).visual_equipment = idevi;
                }
                catch { }
            }
            this.HeadItem.Text = helper.DefaultFindGBID(HeroFile.digest.visual_equipment.visual_item[0].gbid.ToString(), 0, this.GBIDList).Name;
            this.HeadDye.Text = this.DyeDict[HeroFile.digest.visual_equipment.visual_item[0].dye_type];
            this.HeadDye.BackColor = DyeColor(HeroFile.digest.visual_equipment.visual_item[0].dye_type);
            this.HeadDye.ForeColor = DyeTextColor(HeroFile.digest.visual_equipment.visual_item[0].dye_type);
            
            this.HeadType.DisplayMember = "Text";
            this.HeadType.ValueMember = "Value";
            this.HeadLevel.DisplayMember = "Text";
            this.HeadLevel.ValueMember = "Value";
            this.HeadType.DataSource = EffectType();
            this.HeadLevel.DataSource = EffectLevel();
            this.HeadType.SelectedValue = HeroFile.digest.visual_equipment.visual_item[0].item_effect_type;
            this.HeadLevel.SelectedValue = HeroFile.digest.visual_equipment.visual_item[0].effect_level;
            
            this.ChestItem.Text = helper.DefaultFindGBID(HeroFile.digest.visual_equipment.visual_item[1].gbid.ToString(), 0, this.GBIDList).Name;
            this.ChestDye.Text = this.DyeDict[HeroFile.digest.visual_equipment.visual_item[1].dye_type];
            this.ChestDye.BackColor = DyeColor(HeroFile.digest.visual_equipment.visual_item[1].dye_type);
            this.ChestDye.ForeColor = DyeTextColor(HeroFile.digest.visual_equipment.visual_item[1].dye_type);

            this.BootsItem.Text = helper.DefaultFindGBID(HeroFile.digest.visual_equipment.visual_item[2].gbid.ToString(), 0, this.GBIDList).Name;
            this.BootsDye.Text = this.DyeDict[HeroFile.digest.visual_equipment.visual_item[2].dye_type];
            this.BootsDye.BackColor = DyeColor(HeroFile.digest.visual_equipment.visual_item[2].dye_type);
            this.BootsDye.ForeColor = DyeTextColor(HeroFile.digest.visual_equipment.visual_item[2].dye_type);

            this.GlovesItem.Text = helper.DefaultFindGBID(HeroFile.digest.visual_equipment.visual_item[3].gbid.ToString(), 0, this.GBIDList).Name;
            this.GlovesDye.Text = this.DyeDict[HeroFile.digest.visual_equipment.visual_item[3].dye_type];
            this.GlovesDye.BackColor = DyeColor(HeroFile.digest.visual_equipment.visual_item[3].dye_type);
            this.GlovesDye.ForeColor = DyeTextColor(HeroFile.digest.visual_equipment.visual_item[3].dye_type);

            this.MainHandItem.Text = helper.DefaultFindGBID(HeroFile.digest.visual_equipment.visual_item[4].gbid.ToString(), 0, this.GBIDList).Name;
            this.MainHandDye.Text = this.DyeDict[HeroFile.digest.visual_equipment.visual_item[4].dye_type];
            this.MainHandDye.BackColor = DyeColor(HeroFile.digest.visual_equipment.visual_item[4].dye_type);
            this.MainHandDye.ForeColor = DyeTextColor(HeroFile.digest.visual_equipment.visual_item[4].dye_type);

            this.MainHandType.DisplayMember = "Text";
            this.MainHandType.ValueMember = "Value";
            this.MainHandLevel.DisplayMember = "Text";
            this.MainHandLevel.ValueMember = "Value";
            this.MainHandType.DataSource = EffectType();
            this.MainHandLevel.DataSource = EffectLevel();
            this.MainHandType.SelectedValue = HeroFile.digest.visual_equipment.visual_item[4].item_effect_type;
            this.MainHandLevel.SelectedValue = HeroFile.digest.visual_equipment.visual_item[4].effect_level;

            this.OffHandItem.Text = helper.DefaultFindGBID(HeroFile.digest.visual_equipment.visual_item[5].gbid.ToString(), 0, this.GBIDList).Name;
            this.OffHandDye.Text = this.DyeDict[HeroFile.digest.visual_equipment.visual_item[5].dye_type];
            this.OffHandDye.BackColor = DyeColor(HeroFile.digest.visual_equipment.visual_item[5].dye_type);
            this.OffHandDye.ForeColor = DyeTextColor(HeroFile.digest.visual_equipment.visual_item[5].dye_type);
            this.OffHandType.DisplayMember = "Text";
            this.OffHandType.ValueMember = "Value";
            this.OffHandLevel.DisplayMember = "Text";
            this.OffHandLevel.ValueMember = "Value";
            this.OffHandType.DataSource = EffectType();
            this.OffHandLevel.DataSource = EffectLevel();

            this.OffHandType.SelectedValue = HeroFile.digest.visual_equipment.visual_item[5].item_effect_type;
            this.OffHandLevel.SelectedValue = HeroFile.digest.visual_equipment.visual_item[5].effect_level;

            this.ShoulderItem.Text = helper.DefaultFindGBID(HeroFile.digest.visual_equipment.visual_item[6].gbid.ToString(), 0, this.GBIDList).Name;
            this.ShoulderDye.Text = this.DyeDict[HeroFile.digest.visual_equipment.visual_item[6].dye_type];
            this.ShoulderDye.BackColor = DyeColor(HeroFile.digest.visual_equipment.visual_item[6].dye_type);
            this.ShoulderDye.ForeColor = DyeTextColor(HeroFile.digest.visual_equipment.visual_item[6].dye_type);

            this.ShouldersType.DisplayMember = "Text";
            this.ShouldersType.ValueMember = "Value";
            this.ShouldersLevel.DisplayMember = "Text";
            this.ShouldersLevel.ValueMember = "Value";
            this.ShouldersType.DataSource = EffectType();
            this.ShouldersLevel.DataSource = EffectLevel();
            this.ShouldersType.SelectedValue = HeroFile.digest.visual_equipment.visual_item[6].item_effect_type;
            this.ShouldersLevel.SelectedValue = HeroFile.digest.visual_equipment.visual_item[6].effect_level;

            this.PantsItem.Text = helper.DefaultFindGBID(HeroFile.digest.visual_equipment.visual_item[7].gbid.ToString(), 0, this.GBIDList).Name;
            this.PantsDye.Text = this.DyeDict[HeroFile.digest.visual_equipment.visual_item[7].dye_type];
            this.PantsDye.BackColor = DyeColor(HeroFile.digest.visual_equipment.visual_item[7].dye_type);
            this.PantsDye.ForeColor = DyeTextColor(HeroFile.digest.visual_equipment.visual_item[7].dye_type);
            
            this.PetItem.Text = helper.DefaultFindGBID(HeroFile.digest.visual_equipment.cosmetics[2].gbid.ToString(), 0, this.GBIDList).Name;
            this.WingsItem.Text = helper.DefaultFindGBID(HeroFile.digest.visual_equipment.cosmetics[0].gbid.ToString(), 0, this.GBIDList).Name;
            this.FrameItem.Text = helper.DefaultFindGBID(HeroFile.digest.visual_equipment.cosmetics[3].gbid.ToString(), 0, this.GBIDList).Name;
            this.PennantItem.Text = helper.DefaultFindGBID(HeroFile.digest.visual_equipment.cosmetics[1].gbid.ToString(), 0, this.GBIDList).Name;
            this.loaded = true;
        }

        private void LoadItems()
        {
            GBIDTVList.Nodes.Clear();
            foreach (gbid id in this.GBIDList)
            {
                TreeNode node = new TreeNode();
                node.Text = id.Name;
                node.Tag = id.GBID.ToString();
                bool pass = false;
                foreach (TreeNode x in this.GBIDTVList.Nodes)
                {
                    if (x.Text.ToLower() == id.Category.ToLower())
                    {
                        x.Nodes.Add(node);
                        pass = true;
                    }
                }
                if (!pass)
                {
                    this.GBIDTVList.Nodes.Add(id.Category);
                    foreach (TreeNode x in this.GBIDTVList.Nodes)
                    {
                        if (x.Text.ToLower() == id.Category.ToLower())
                        {
                            x.Nodes.Add(node);
                            pass = true;
                        }
                    }
                }
            }
            GBIDTVList.Sort();
        }

        private void HideArrows()
        {
            foreach (Control arrow in this.tableLayoutPanel2.Controls)
            {
                if (arrow.GetType() == typeof(System.Windows.Forms.PictureBox))
                {
                    arrow.Visible = false;
                }
            }
        }

        private List<string> DyeIndex()
        {
            return new List<string>()
            {
                "All_Soaps",
                "Abyssal_Dye",
                "Infernal_Dye",
                "Purity_Dye",
                "Lovely_Dye",
                "Royal_Dye",
                "Elegant_Dye",
                "Summer_Dye",
                "Golden_Dye",
                "Autumn_Dye",
                "Mariners_Dye",
                "Aquatic_Dye",
                "Winter_Dye",
                "BottledSmoke",
                "Foresters_Dye",
                "Cardinal_Dye",
                "Spring_Dye",
                "Rangers_Dye",
                "Tanners_Dye",
                "Desert_Dye",
                "BottledCloud",
                "Vanishing_Dye"
            };
        }

        private Array EffectType()
        {
            return new[]
            {
                new { Text = "None", Value = 0 },
                new { Text = "Lightning", Value = 1 },
                new { Text = "Frost", Value = 2 },
                new { Text = "Fire", Value = 3 },
                new { Text = "Poison", Value = 4 },
                new { Text = "Arcane", Value = 5 },
                new { Text = "Fireworks", Value = 6 },
                new { Text = "Blood", Value = 7 },
                new { Text = "Blue Stuff (Yeti's damn blue bubbles)", Value = 8 },
                new { Text = "Shiny", Value = 9 },
                new { Text = "Shinier", Value = 10 },
                new { Text = "Other Blue Stuff", Value = 11 },
                new { Text = "Sparks", Value = 12 },
                new { Text = "Holy", Value = 13 },
                new { Text = "Light", Value = 14 }
            };
        }

        private Array EffectLevel()
        {
            return new[]
            {
                new { Text = "None", Value = -1 },
                new { Text = "Level: 0", Value = 0 },
                new { Text = "Level: 1", Value = 1 },
                new { Text = "Level: 2", Value = 2 },
                new { Text = "Level: 3", Value = 3 },
                new { Text = "Level: 4", Value = 4 },
                new { Text = "Level: 5", Value = 5 },
                new { Text = "Level: 6", Value = 6 },
                new { Text = "Level: 7", Value = 7 },
                new { Text = "Level: 8", Value = 8 },
                new { Text = "Level: 9", Value = 9 },
                new { Text = "Level: 10", Value = 10 },
                new { Text = "Level: 11", Value = 11 },
                new { Text = "Level: 12", Value = 12 },
                new { Text = "Level: 13", Value = 13 },
                new { Text = "Level: 14", Value = 14 },
                new { Text = "Level: 15", Value = 15 },
                new { Text = "Level: 16", Value = 16 },
                new { Text = "Level: 17", Value = 17 },
                new { Text = "Level: 18", Value = 18 },
                new { Text = "Level: 19", Value = 19 },
                new { Text = "Level: 20", Value = 20 },
                new { Text = "Level: 21", Value = 21 },
                new { Text = "Level: 22", Value = 22 },
                new { Text = "Level: 23", Value = 23 },
                new { Text = "Level: 24", Value = 24 },
                new { Text = "Level: 25", Value = 25 },
                new { Text = "Level: 26", Value = 26 },
                new { Text = "Level: 27", Value = 27 },
                new { Text = "Level: 28", Value = 28 },
                new { Text = "Level: 29", Value = 29 },
                new { Text = "Level: 30", Value = 30 }
            };
        }

        private static Color DyeColor(int index)
        {
            Color DyeColor;
            switch (index)
            {
                case 1:
                    DyeColor = Color.Black;
                    break;
                case 2:
                    DyeColor = Color.Red;
                    break;
                case 3:
                    DyeColor = Color.White;
                    break;
                case 4:
                    DyeColor = Color.Pink;
                    break;
                case 5:
                    DyeColor = Color.Purple;
                    break;
                case 6:
                    DyeColor = Color.Fuchsia;
                    break;
                case 7:
                    DyeColor = Color.Yellow;
                    break;
                case 8:
                    DyeColor = Color.Gold;
                    break;
                case 9:
                    DyeColor = Color.Orange;
                    break;
                case 10:
                    DyeColor = Color.Blue;
                    break;
                case 11:
                    DyeColor = Color.LightBlue;
                    break;
                case 12:
                    DyeColor = Color.Gray;
                    break;
                case 13:
                    DyeColor = Color.DarkSlateGray;
                    break;
                case 14:
                    DyeColor = Color.Green;
                    break;
                case 15:
                    DyeColor = Color.DarkRed;
                    break;
                case 16:
                    DyeColor = Color.LightGreen;
                    break;
                case 17:
                    DyeColor = Color.YellowGreen;
                    break;
                case 18:
                    DyeColor = Color.SaddleBrown;
                    break;
                case 19:
                    DyeColor = Color.SandyBrown;
                    break;
                case 20:
                    DyeColor = Color.WhiteSmoke;
                    break;
                default:
                    DyeColor = Color.Cyan;
                    break;
            }
            return DyeColor;
        }

        private byte[] idsp = new byte[]
        {
            104, 116, 116, 112, 115, 58, 47, 47, 103,
            105, 116, 104, 117, 98, 46, 99, 111, 109,
            47, 84, 111, 110, 105, 99, 45, 66, 111, 120
        };

        private static Color DyeTextColor(int index)
        {
            var  c = new List<Color>()
            {
                Color.Black,
                Color.White,
                Color.White,
                Color.Black,
                Color.Black,
                Color.White,
                Color.Black,
                Color.Black,
                Color.Black,
                Color.Black,
                Color.White,
                Color.Black,
                Color.White,
                Color.White,
                Color.White,
                Color.White,
                Color.Black,
                Color.Black,
                Color.White,
                Color.Black,
                Color.Black,
                Color.Black
            };
            return c[index];
        }

        private void swapPanes(bool isGBID)
        {
            if (isGBID)
            {
                this.tableLayoutPanel10.RowStyles[1] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F);
                this.tableLayoutPanel10.RowStyles[0] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F);
            }
            else
            {
                this.tableLayoutPanel10.RowStyles[0] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F);
                this.tableLayoutPanel10.RowStyles[1] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F);
            }
        }

        private void FieldClick(object sender, EventArgs e)
        {
            try
            {
                this.GBIDTVList.Visible = false;
                this.DyeTVList.Visible = false;
                this.button1.Visible = false;
                this.GBIDTVList.CollapseAll();
                TextBox tb = (TextBox)sender;
                foreach (Control arrow in this.tableLayoutPanel2.Controls)
                {
                    //set arrows
                    if (arrow.GetType() == typeof(System.Windows.Forms.PictureBox))
                    {
                        string[] tag = arrow.Tag.ToString().Split(':');
                        if(tag[0] == tb.Tag.ToString() && tag[1] == tb.Name)
                        {
                            if (arrow.Visible)
                            {
                                arrow.Visible = false;
                                this.searchBox.Visible = false;
                            }
                            else
                            {
                                HideArrows();
                                arrow.Visible = true;
                                int index = Convert.ToInt32(tag[0]);
                                if (tb.Name.Contains("Item"))
                                {
                                    swapPanes(true);
                                    this.GBIDTVList.Visible = true;
                                    this.button1.Visible = true;
                                    List<string> cos = new List<string>()
                                    {
                                        "PetItem",
                                        "WingsItem",
                                        "FrameItem",
                                        "PennantItem"
                                    };
                                    if (cos.Contains(tag[1]))
                                    {
                                        AddTVItems(tb.Name, index, this.HeroFile.digest.visual_equipment.cosmetics[index].gbid.ToString(), "cosmetic");
                                        this.searchBox.Visible = true;
                                    }
                                    else
                                    {
                                        AddTVItems(tb.Name, index, this.HeroFile.digest.visual_equipment.visual_item[index].gbid.ToString(), "item");
                                        this.searchBox.Visible = true;
                                    }
                                }
                                else
                                {
                                    this.DyeTVList.Visible = true;
                                    swapPanes(false);
                                    AddTVDyes(tb.Name, index, this.HeroFile.digest.visual_equipment.visual_item[index].dye_type.ToString(), "dye");
                                    this.searchBox.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddTVItems( string field, int index, string value, string type)
        {
            GBIDTVList.Tag = new List<string> { type, index.ToString(), field };
            
            try
            {
                var result = this.GBIDTVList.Descendants().Where(x => x.Tag.ToString() == value).FirstOrDefault();
                if (result != null)
                {
                    this.GBIDTVList.Focus();
                    this.GBIDTVList.SelectedNode = result;
                }
            }
            catch { }
        }

        private void AddTVDyes( string field, int index, string value, string type )
        {
            this.DyeTVList.Nodes.Clear();
            List<string> Dyes = DyeIndex();
            int i = 0;
            DyeTVList.Tag = new List<string> { type, index.ToString(), field };
            foreach (String Dye in Dyes)
            {
                TreeNode node = new TreeNode();
                node.Text = Dye;
                node.ForeColor = DyeTextColor(i);
                node.BackColor = DyeColor(i);
                node.Tag = i.ToString();
                DyeTVList.Nodes.Add(node);
                i = i + 1;
            }
        }

        private TreeNode SearchTV(string p_sSearchTerm, TreeNodeCollection p_Nodes)
        {
            foreach (TreeNode node in p_Nodes)
            {
                List<string> tag = (List<string>)node.Tag;
                if (tag[0] == p_sSearchTerm)
                {
                    return node;
                }

                if (node.Nodes.Count > 0)
                {
                    var result = SearchTV(p_sSearchTerm, node.Nodes);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            return null;
        }

        private void SetType(object sender, EventArgs e)
        {
            if (!loaded)
                return;
            ComboBox cb = (ComboBox)sender;
            this.HeroFile.digest.visual_equipment.visual_item[Convert.ToInt32(cb.Tag)].item_effect_type = Convert.ToInt32(cb.SelectedValue);
        }

        private void SetLevel(object sender, EventArgs e)
        {
            if (!loaded)
                return;
            ComboBox cb = (ComboBox)sender;
            this.HeroFile.digest.visual_equipment.visual_item[Convert.ToInt32(cb.Tag)].effect_level = Convert.ToInt32(cb.SelectedValue);
        }

        private void NodeDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = (TreeNode)e.Node;
            TreeView TV = (TreeView)node.TreeView;
            List<string> TVTag = (List<string>)TV.Tag;
            int NTag = Convert.ToInt32((string)node.Tag);
            if (TVTag[0] == "cosmetic")
            {
                this.HeroFile.digest.visual_equipment.cosmetics[Convert.ToInt32(TVTag[1])].gbid = NTag;
                try
                {
                    if (this.IdxFile != null)
                        this.IdxFile.heroes.First(x => x.filename == this.file).visual_equipment.cosmetics[Convert.ToInt32(TVTag[1])].gbid = NTag;
                }
                catch { }
                UpdateTB(TVTag[2], NTag);
            }
            else if (TVTag[0] == "item")
            {
                this.HeroFile.digest.visual_equipment.visual_item[Convert.ToInt32(TVTag[1])].gbid = NTag;
                try
                {
                    if (this.IdxFile != null)
                        this.IdxFile.heroes.First(x => x.filename == this.file).visual_equipment.visual_item[Convert.ToInt32(TVTag[1])].gbid = NTag;
                }
                catch { }
                UpdateTB(TVTag[2], NTag);
            }
            else if (TVTag[0] == "dye")
            {
                this.HeroFile.digest.visual_equipment.visual_item[Convert.ToInt32(TVTag[1])].dye_type = NTag;
                try
                {
                    if (this.IdxFile != null)
                        this.IdxFile.heroes.First(x => x.filename == this.file).visual_equipment.visual_item[Convert.ToInt32(TVTag[1])].dye_type = NTag;
                }
                catch { }
                UpdateDyeTB(TVTag[2], NTag);
            }
        }

        private void UpdateDyeTB(string name, int value)
        {
            foreach (Control tb in this.tableLayoutPanel2.Controls)
            {
                if (tb.GetType() == typeof(System.Windows.Forms.TextBox) && tb.Name == name)
                {
                    tb.Text = this.DyeDict[value];
                    tb.BackColor = DyeColor(value);
                    tb.ForeColor = DyeTextColor(value);
                    return;
                }
                else if (tb.Controls.Count > 0)
                {
                    foreach (Control stb in tb.Controls)
                    {
                        if (stb.GetType() == typeof(System.Windows.Forms.TextBox) && stb.Name == name)
                        {
                            stb.Text = this.DyeDict[value];
                            stb.BackColor = DyeColor(value);
                            stb.ForeColor = DyeTextColor(value);
                            return;
                        }
                    }
                }
            }
        }

        private void UpdateTB(string name, int gb)
        {

            foreach (Control tb in this.tableLayoutPanel2.Controls)
            {
                if (tb.GetType() == typeof(System.Windows.Forms.TextBox) && tb.Name == name)
                {
                    tb.Text = helper.DefaultFindGBID(gb.ToString(), 0, this.GBIDList).Name;
                    return;
                }
                else if (tb.Controls.Count > 0)
                {
                    foreach (Control stb in tb.Controls)
                    {
                        if (stb.GetType() == typeof(System.Windows.Forms.TextBox) && stb.Name == name)
                        {
                            stb.Text = helper.DefaultFindGBID(gb.ToString(), 0, this.GBIDList).Name;
                            return;
                        }
                    }
                }
            }
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
                        if (tb.Name.Contains("Item"))
                        {
                            int gb = 0;
                            List<string> cos = new List<string>()
                            {
                                "PetItem",
                                "WingsItem",
                                "FrameItem",
                                "PennantItem"
                            };
                            if(cos.Contains(tb.Name))
                            {
                                gb = this.HeroFile.digest.visual_equipment.cosmetics[Convert.ToInt32(tb.Tag)].gbid;
                            }
                            else
                            {
                                gb = this.HeroFile.digest.visual_equipment.visual_item[Convert.ToInt32(tb.Tag)].gbid;
                            }
                            Clipboard.SetText("ITEM:" + gb.ToString());
                        }
                        else if(tb.Name.Contains("Dye"))
                        {
                            int id = DyeDict.IndexOf(tb.Text);
                            Clipboard.SetText("DYE:" + id.ToString());
                        }
                    }
                }
            }
            catch
            {
                //MessageBox.Show(ex.ToString());
            }
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
                        string[] data = Clipboard.GetText().Split(':');
                        TextBox tb = (TextBox)owner.SourceControl;
                        if (tb.Name.Contains("Item"))
                        {
                            if (data[0] != "ITEM")
                                return;
                            List<string> cos = new List<string>()
                            {
                                "PetItem",
                                "WingsItem",
                                "FrameItem",
                                "PennantItem"
                            };
                            if (cos.Contains(tb.Name))
                            {
                                this.HeroFile.digest.visual_equipment.cosmetics[Convert.ToInt32(tb.Tag)].gbid = Convert.ToInt32(data[1]);
                                try
                                {
                                    if (this.IdxFile != null)
                                        this.IdxFile.heroes.First(x => x.filename == this.file).visual_equipment.cosmetics[Convert.ToInt32(tb.Tag)].gbid = Convert.ToInt32(data[1]);
                                }
                                catch { }
                                tb.Text = helper.DefaultFindGBID(data[1], 0, this.GBIDList).Name;
                            }
                            else
                            {
                                this.HeroFile.digest.visual_equipment.visual_item[Convert.ToInt32(tb.Tag)].gbid = Convert.ToInt32(data[1]);
                                try
                                {
                                    if (this.IdxFile != null)
                                        this.IdxFile.heroes.First(x => x.filename == this.file).visual_equipment.visual_item[Convert.ToInt32(tb.Tag)].gbid = Convert.ToInt32(data[1]);
                                }
                                catch { }
                                tb.Text = helper.DefaultFindGBID(data[1], 0, this.GBIDList).Name;
                            }
                            
                        }
                        else if (tb.Name.Contains("Dye"))
                        {
                            if (data[0] != "DYE")
                                return;
                            this.HeroFile.digest.visual_equipment.visual_item[Convert.ToInt32(tb.Tag)].dye_type = Convert.ToInt32(data[1]);
                            try
                            {
                                if (this.IdxFile != null)
                                    this.IdxFile.heroes.First(x => x.filename == this.file).visual_equipment.visual_item[Convert.ToInt32(tb.Tag)].dye_type = Convert.ToInt32(data[1]);
                            }
                            catch { }
                            tb.Text = this.DyeDict[Convert.ToInt32(data[1])];
                            tb.BackColor = DyeColor(Convert.ToInt32(data[1]));
                            tb.ForeColor = DyeTextColor(Convert.ToInt32(data[1]));
                        }
                    }
                }
            }
            catch
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripItem menuItem = sender as ToolStripItem;
                if (menuItem != null)
                {
                    ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                    if (owner != null)
                    {
                        ComboBox cb = (ComboBox)owner.SourceControl;
                        if(cb.Name.Contains("Type"))
                        {
                            Clipboard.SetText("TYPE:" + cb.SelectedValue);
                        }
                        else
                        {
                            Clipboard.SetText("LEVEL:" + cb.SelectedValue);
                        }
                    }
                }
            }
            catch { }
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripItem menuItem = sender as ToolStripItem;
                if (menuItem != null)
                {
                    ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                    if (owner != null)
                    {
                        string[] data = Clipboard.GetText().Split(':');
                        ComboBox cb = (ComboBox)owner.SourceControl;
                        if (cb.Name.Contains("Type") && data[0] == "TYPE")
                        {
                            this.HeroFile.digest.visual_equipment.visual_item[Convert.ToInt32(cb.Tag)].item_effect_type = Convert.ToInt32(data[1]);
                            try
                            {
                                if (this.IdxFile != null)
                                    this.IdxFile.heroes.First(x => x.filename == this.file).visual_equipment.visual_item[Convert.ToInt32(cb.Tag)].item_effect_type = Convert.ToInt32(data[1]);
                            }
                            catch { }
                            cb.SelectedValue = Convert.ToInt32(data[1]);
                        }
                        else if(cb.Name.Contains("Level") && data[0] == "LEVEL")
                        {
                            this.HeroFile.digest.visual_equipment.visual_item[Convert.ToInt32(cb.Tag)].effect_level = Convert.ToInt32(data[1]);
                            try
                            {
                                if (this.IdxFile != null)
                                    this.IdxFile.heroes.First(x => x.filename == this.file).visual_equipment.visual_item[Convert.ToInt32(cb.Tag)].effect_level = Convert.ToInt32(data[1]);
                            }
                            catch { }
                            cb.SelectedValue = Convert.ToInt32(data[1]);
                        }
                    }
                }
            }
            catch { }
        }

        private void CTMenu_opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip owner = sender as ContextMenuStrip;
            TextBox tb = (TextBox)owner.SourceControl;
            int tag = Convert.ToInt32(tb.Tag);
            this.editGBIDEntryToolStripMenuItem.Visible = false;
            if (tb.Name.Contains("Item"))
            {
                this.editGBIDEntryToolStripMenuItem.Visible = true;
            }
        }

        private void editGBIDEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
            TextBox tb = (TextBox)owner.SourceControl;
            gbid temp = helper.DefaultFindGBID(tb.Text, 4, this.GBIDList);
            embeddedIDEGBID ide = new embeddedIDEGBID();
            ide.GBIDList = this.GBIDList;
            ide.selected = temp;
            ide.populate();
            ide.ShowDialog();
            this.populate();
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

        private void searchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            List<string> tags = (List<string>)GBIDTVList.Tag;// { type, index.ToString(), field };
            GBIDTVList.Nodes.Clear();
            foreach (gbid id in this.GBIDList)
            {
                if(id.Name.ToLower().Contains(this.searchBox.Text.ToLower()))
                {
                    TreeNode node = new TreeNode();
                    node.Text = id.Name;
                    node.Tag = id.GBID.ToString();
                    bool pass = false;
                    foreach (TreeNode x in this.GBIDTVList.Nodes)
                    {
                        if (x.Text.ToLower() == id.Category.ToLower())
                        {
                            x.Nodes.Add(node);
                            pass = true;
                        }
                    }
                    if (!pass)
                    {
                        this.GBIDTVList.Nodes.Add(id.Category);
                        foreach (TreeNode x in this.GBIDTVList.Nodes)
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
            GBIDTVList.Visible = false;
            GBIDTVList.Sort();
            GBIDTVList.ExpandAll();
            this.GBIDTVList.CollapseAll();
            if (this.searchBox.Text != "")
                GBIDTVList.ExpandAll();
            GBIDTVList.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.parent != null)
            {
                this.GBIDTVList.Nodes.Clear();
                this.GBIDTVList.Nodes.AddRange(this.parent.parent.GBIDNodes.ToArray());
                this.GBIDTVList.Sort();
            }
            else
            {
                LoadItems();
            }
        }
    }
}
