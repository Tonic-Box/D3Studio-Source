using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using D3Studio.lists;
using D3Studio.lists.types;
using System.IO;
using TonicBox.Data;
using System.Runtime.Serialization.Formatters.Binary;

namespace D3Studio.ui.hero.inventoryControls
{
    public partial class listControl : UserControl
    {
        public bool isLocker = false;

        public PB.Items.SavedItem item;

        public List<PB.Items.SavedItem> items;

        public List<gbid> GBIDList = new List<gbid>();

        public List<affix> AffixList = new List<affix>();

        public List<sno> SNOList = new List<sno>();

        private bool loaded = false;
        public inventory parrent { get; set; }

        public TreeNode SelectedChildNode;
        public listControl()
        {
            InitializeComponent();
            this.refreshLists.Visible = false;
            GBIDTVList.TreeViewNodeSorter = new NodeSorter();
            AffixTVList.TreeViewNodeSorter = new NodeSorter();
        }

        public void populate()
        {
            this.loaded = false;
            AddInfo();
            fillFields();
            hideArrows();
            this.GBIDTVList.Visible = false;
            this.AffixTVList.Visible = false;
            this.searchBox.Visible = false;
            this.refreshLists.Visible = false;
            this.sCategory.Visible = false;
            this.sName.Visible = false;
            this.sDescription.Visible = false;
            this.sLabel.Visible = false;
            if (GBIDTVList.Nodes.Count < 1)
            {
                if(this.isLocker)
                {
                    this.GBIDTVList.Nodes.AddRange(this.parrent.hParent.parent.GBIDNodes.ToArray());
                    this.GBIDTVList.Sort();
                }
                else
                {
                    populateGBIDs();
                }
            }
            if (AffixTVList.Nodes.Count < 1)
                populateAffixes();
            this.loaded = true;
        }

        private void fillFields()
        {
            try
            {
                if (this.item.generator.base_affixes.Count() < 6)
                {
                    while(this.item.generator.base_affixes.Count() < 6)
                    {
                        this.item.generator.base_affixes.Add(-1);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            try { this.ItemField.Text = helper.FindGBID(this.item.generator.gb_handle.gbid.ToString(), 0, this.GBIDList).Name; }
            catch { this.ItemField.Text = this.item.generator.gb_handle.gbid.ToString(); }
            try { this.Affix0.Text = helper.FindAffix(this.item.generator.base_affixes[0].ToString(), 0, this.AffixList).Name; }
            catch { this.Affix0.Text = this.item.generator.base_affixes[0].ToString(); }
            try { this.Affix1.Text = helper.FindAffix(this.item.generator.base_affixes[1].ToString(), 0, this.AffixList).Name; }
            catch { this.Affix1.Text = this.item.generator.base_affixes[1].ToString(); }
            try { this.Affix2.Text = helper.FindAffix(this.item.generator.base_affixes[2].ToString(), 0, this.AffixList).Name; }
            catch { this.Affix2.Text = this.item.generator.base_affixes[2].ToString(); }
            try { this.Affix3.Text = helper.FindAffix(this.item.generator.base_affixes[3].ToString(), 0, this.AffixList).Name; }
            catch { this.Affix3.Text = this.item.generator.base_affixes[3].ToString(); }
            try { this.Affix4.Text = helper.FindAffix(this.item.generator.base_affixes[4].ToString(), 0, this.AffixList).Name; }
            catch { this.Affix4.Text = this.item.generator.base_affixes[4].ToString(); }
            try { this.Affix5.Text = helper.FindAffix(this.item.generator.base_affixes[5].ToString(), 0, this.AffixList).Name; }
            catch { this.Affix5.Text = this.item.generator.base_affixes[5].ToString(); }
            if (item.generator.rare_item_name == null)
                item.generator.rare_item_name = new PB.Items.RareItemName();
            PB.Items.RareItemName rn = item.generator.rare_item_name;
            //rn.sno_affix_string_list && n.Affix_String_List_Index == rn.affix_string_list_index
            string str = "";
            foreach(sno n in this.SNOList)
            {
                if (n.Sno_Affix_String_List == rn.sno_affix_string_list && n.Affix_String_List_Index == rn.affix_string_list_index)
                    str = n.Name;
            }
            if (str != "" && str != "No Prefix")
                this.rareName.Text = str;
            else
                this.rareName.Text = "[No Prefix]";


            try { this.oldAffix.Text = helper.FindAffix(this.item.generator.existing_affix.ToString(), 0, this.AffixList).Name; }
            catch { try { this.oldAffix.Text = this.item.generator.existing_affix.ToString(); } catch { } }
            try { this.newAffix.Text = helper.FindAffix(this.item.generator.enchanted_affix.ToString(), 0, this.AffixList).Name; }
            catch { try { this.newAffix.Text = this.item.generator.enchanted_affix.ToString(); } catch { } }
            try { this.tmog.Text = helper.FindGBID(this.item.generator.transmogrify_gbid.ToString(), 0, this.GBIDList).Name; }
            catch { try { this.tmog.Text = this.item.generator.transmogrify_gbid.ToString(); } catch { } }
            try { this.tier.Text = helper.FindGBID(this.item.generator.legendary_tier_quality.ToString(), 0, this.GBIDList).Name; }
            catch { try { this.tier.Text = this.item.generator.legendary_tier_quality.ToString(); } catch { } }

            if(this.item.custom_name == null)
            {
                this.item.custom_name = "";
            }
            this.CustomName.Text = this.item.custom_name;
            if(this.item.custom_description == null)
            {
                this.item.custom_description = "";
            }
            this.itemDescription.Text = this.item.custom_description.Left(300).Replace("~", System.Environment.NewLine);
        }

        private void populateGBIDs()
        {
            foreach (gbid id in this.GBIDList)
            {
                TreeNode node = new TreeNode();
                node.Text = id.Name;
                node.Name = id.Category;
                node.Tag = id.GBID.ToString();
                bool pass = false;
                foreach (TreeNode x in this.GBIDTVList.Nodes)
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
                    this.GBIDTVList.Nodes.Add(category);
                }
            }
        }

        private void populateAffixes()
        {
            foreach (affix id in this.AffixList)
            {
                TreeNode node = new TreeNode();
                node.Text = id.Name;
                node.Name = id.Category;
                node.Tag = id.Affix.ToString();
                bool pass = false;
                foreach (TreeNode x in this.AffixTVList.Nodes)
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
                    this.AffixTVList.Nodes.Add(category);
                }
            }
        }

        private void AddItemTreeView(string gb)
        {
            try
            {
                var result = this.GBIDTVList.Descendants().Where(x => (x.Text as string) == gb).FirstOrDefault();
                if (result != null)
                {
                    this.GBIDTVList.Focus();
                    this.GBIDTVList.SelectedNode = result;
                    //this.TVList.SelectedNode.BackColor = Color.Cyan;
                    this.SelectedChildNode = result;
                }
            }
            catch { }
        }

        private void AddAffixTreeView(string gb)
        {
            try
            {
                var result = this.AffixTVList.Descendants().Where(x => (x.Text as string) == gb).FirstOrDefault();
                if (result != null)
                {
                    this.AffixTVList.Focus();
                    this.AffixTVList.SelectedNode = result;
                    //this.AffixTVList.SelectedNode.BackColor = Color.Cyan;
                    this.SelectedChildNode = result;
                }
            }
            catch { }
        }

        private void AddInfo()
        {
            if (helper.FindGBID(this.item.generator.gb_handle.gbid.ToString(), 0, this.GBIDList) != null)
            {
                this.InfoBox.name = helper.FindGBID(this.item.generator.gb_handle.gbid.ToString(), 0, this.GBIDList).Name;
                this.InfoBox.description = helper.FindGBID(this.item.generator.gb_handle.gbid.ToString(), 0, this.GBIDList).Details;
            }
            else
            {
                this.InfoBox.name = this.item.generator.gb_handle.gbid.ToString();
                this.InfoBox.description = "~Item not found...";
            }
            this.InfoBox.populate();
        }

        private void hideArrows()
        {
            this.ItemArrow.Visible = false;
            this.A0Arrow.Visible = false;
            this.A1Arrow.Visible = false;
            this.A2Arrow.Visible = false;
            this.A3Arrow.Visible = false;
            this.A4Arrow.Visible = false;
            this.A5Arrow.Visible = false;
            this.oldArrow.Visible = false;
            this.newArrow.Visible = false;
            this.tmogArrow.Visible = false;
            this.tierArrow.Visible = false;
        }

        private void swapPanes(bool isGBID)
        {
            if(isGBID)
            {
                this.tableLayoutPanel3.RowStyles[1] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F);
                this.tableLayoutPanel3.RowStyles[0] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F);
            }
            else
            {
                this.tableLayoutPanel3.RowStyles[0] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F);
                this.tableLayoutPanel3.RowStyles[1] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F);
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            this.GBIDTVList.CollapseAll();
            this.AffixTVList.CollapseAll();
            this.searchBox.Text = "Search...";
            string t = tb.Tag.ToString();
            if (t == "-1")
            {
                this.AffixTVList.Visible = false;
                if (this.ItemArrow.Visible)
                {
                    if (this.GBIDTVList.Visible)
                    {
                        this.GBIDTVList.Visible = false;
                        this.ItemArrow.Visible = false;
                        this.searchBox.Visible = false;
                        this.SelectedChildNode = null;
                    }
                }
                else
                {
                    this.hideArrows();
                    this.ItemArrow.Visible = true;
                    this.GBIDTVList.Visible = true;
                    this.searchBox.Visible = true;
                    this.GBIDTVList.Tag = tb.Tag;
                    this.swapPanes(true);
                    this.AddItemTreeView(this.ItemField.Text);
                }
            }
            else if (t == "tmog")
            {
                this.AffixTVList.Visible = false;
                if (this.tmogArrow.Visible)
                {
                    if (this.GBIDTVList.Visible)
                    {
                        this.GBIDTVList.Visible = false;
                        this.tmogArrow.Visible = false;
                        this.searchBox.Visible = false;
                        this.SelectedChildNode = null;
                    }
                }
                else
                {
                    this.hideArrows();
                    this.tmogArrow.Visible = true;
                    this.GBIDTVList.Visible = true;
                    this.searchBox.Visible = true;
                    this.GBIDTVList.Tag = tb.Tag;
                    this.swapPanes(true);
                    this.AddItemTreeView(this.tmog.Text);
                }
            }
            else if (t == "tier")
            {
                this.AffixTVList.Visible = false;
                if (this.tierArrow.Visible)
                {
                    if (this.GBIDTVList.Visible)
                    {
                        this.GBIDTVList.Visible = false;
                        this.tierArrow.Visible = false;
                        this.searchBox.Visible = false;
                        this.SelectedChildNode = null;
                    }
                }
                else
                {
                    this.hideArrows();
                    this.tierArrow.Visible = true;
                    this.AddItemTreeView(this.tier.Text);
                    this.GBIDTVList.Visible = true;
                    this.searchBox.Visible = true;
                    this.GBIDTVList.Tag = tb.Tag;
                    this.swapPanes(true);
                    this.AddItemTreeView(this.tier.Text);
                }
            }
            else if (tb.Tag.ToString() == "0")
            {
                this.GBIDTVList.Visible = false;
                if (this.A0Arrow.Visible)
                {
                    if (this.AffixTVList.Visible)
                    {
                        this.AffixTVList.Visible = false;
                        this.A0Arrow.Visible = false;
                        this.searchBox.Visible = false;
                        this.SelectedChildNode = null;
                    }
                }
                else
                {
                    this.hideArrows();
                    this.A0Arrow.Visible = true;
                    this.AffixTVList.Visible = true;
                    this.searchBox.Visible = true;
                    this.AffixTVList.Tag = tb.Tag;
                    this.swapPanes(false);
                    this.AddAffixTreeView(this.Affix0.Text);
                }
            }
            else if (tb.Tag.ToString() == "1")
            {
                this.GBIDTVList.Visible = false;
                if (this.A1Arrow.Visible)
                {
                    if (this.AffixTVList.Visible)
                    {
                        this.AffixTVList.Visible = false;
                        this.A1Arrow.Visible = false;
                        this.searchBox.Visible = false;
                        this.SelectedChildNode = null;
                    }
                }
                else
                {
                    this.hideArrows();
                    this.A1Arrow.Visible = true;
                    this.AffixTVList.Visible = true;
                    this.searchBox.Visible = true;
                    this.AffixTVList.Tag = tb.Tag;
                    this.swapPanes(false);
                    this.AddAffixTreeView(this.Affix1.Text);
                }
            }
            else if (tb.Tag.ToString() == "2")
            {
                this.GBIDTVList.Visible = false;
                if (this.A2Arrow.Visible)
                {
                    if (this.AffixTVList.Visible)
                    {
                        this.AffixTVList.Visible = false;
                        this.A2Arrow.Visible = false;
                        this.searchBox.Visible = false;
                        this.SelectedChildNode = null;
                    }
                }
                else
                {
                    this.hideArrows();
                    this.A2Arrow.Visible = true;
                    this.AffixTVList.Visible = true;
                    this.searchBox.Visible = true;
                    this.AffixTVList.Tag = tb.Tag;
                    this.swapPanes(false);
                    this.AddAffixTreeView(this.Affix2.Text);
                }
            }
            else if (tb.Tag.ToString() == "3")
            {
                this.GBIDTVList.Visible = false;
                if (this.A3Arrow.Visible)
                {
                    if (this.AffixTVList.Visible)
                    {
                        this.AffixTVList.Visible = false;
                        this.A3Arrow.Visible = false;
                        this.searchBox.Visible = false;
                        this.SelectedChildNode = null;
                    }
                }
                else
                {
                    this.hideArrows();
                    this.A3Arrow.Visible = true;
                    this.AffixTVList.Visible = true;
                    this.searchBox.Visible = true;
                    this.AffixTVList.Tag = tb.Tag;
                    this.swapPanes(false);
                    this.AddAffixTreeView(this.Affix3.Text);
                }
            }
            else if (tb.Tag.ToString() == "4")
            {
                this.GBIDTVList.Visible = false;
                if (this.A4Arrow.Visible)
                {
                    if (this.AffixTVList.Visible)
                    {
                        this.AffixTVList.Visible = false;
                        this.A4Arrow.Visible = false;
                        this.searchBox.Visible = false;
                        this.SelectedChildNode = null;
                    }
                }
                else
                {
                    this.hideArrows();
                    this.A4Arrow.Visible = true;
                    this.AffixTVList.Visible = true;
                    this.searchBox.Visible = true;
                    this.AffixTVList.Tag = tb.Tag;
                    this.swapPanes(false);
                    this.AddAffixTreeView(this.Affix4.Text);
                }
            }
            else if (tb.Tag.ToString() == "5")
            {
                this.GBIDTVList.Visible = false;
                if (this.A5Arrow.Visible)
                {
                    if (this.AffixTVList.Visible)
                    {
                        this.AffixTVList.Visible = false;
                        this.A5Arrow.Visible = false;
                        this.searchBox.Visible = false;
                        this.SelectedChildNode = null;
                    }
                }
                else
                {
                    this.hideArrows();
                    this.A5Arrow.Visible = true;
                    this.AffixTVList.Visible = true;
                    this.searchBox.Visible = true;
                    this.AffixTVList.Tag = tb.Tag;
                    this.swapPanes(false);
                    this.AddAffixTreeView(this.Affix5.Text);
                }
            }
            else if (tb.Tag.ToString() == "old")
            {
                this.GBIDTVList.Visible = false;
                if (this.oldArrow.Visible)
                {
                    if (this.AffixTVList.Visible)
                    {
                        this.AffixTVList.Visible = false;
                        this.oldArrow.Visible = false;
                        this.searchBox.Visible = false;
                        this.SelectedChildNode = null;
                    }
                }
                else
                {
                    this.hideArrows();
                    this.oldArrow.Visible = true;
                    this.AffixTVList.Visible = true;
                    this.searchBox.Visible = true;
                    this.AffixTVList.Tag = tb.Tag;
                    this.swapPanes(false);
                    this.AddAffixTreeView(this.oldAffix.Text);
                }
            }
            else if (tb.Tag.ToString() == "new")
            {
                this.GBIDTVList.Visible = false;
                if (this.newArrow.Visible)
                {
                    if (this.AffixTVList.Visible)
                    {
                        this.AffixTVList.Visible = false;
                        this.newArrow.Visible = false;
                        this.searchBox.Visible = false;
                        this.SelectedChildNode = null;
                    }
                }
                else
                {
                    this.hideArrows();
                    this.newArrow.Visible = true;
                    this.AffixTVList.Visible = true;
                    this.searchBox.Visible = true;
                    this.AffixTVList.Tag = tb.Tag;
                    this.swapPanes(false);
                    this.AddAffixTreeView(this.newAffix.Text);
                }
            }
            if(this.GBIDTVList.Visible || this.AffixTVList.Visible)
            {
                this.refreshLists.Visible = true;
                this.sCategory.Visible = true;
                this.sName.Visible = true;
                this.sDescription.Visible = true;
                this.sLabel.Visible = true;
            }
            else
            {
                this.refreshLists.Visible = false;
                this.sCategory.Visible = false;
                this.sName.Visible = false;
                this.sDescription.Visible = false;
                this.sLabel.Visible = false;
            }
        }

        private void searchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            TreeView view = new TreeView();
            if (this.GBIDTVList.Visible)
                view = GBIDTVList;
            else if (this.AffixTVList.Visible)
                view = AffixTVList;
            else
                return;
            view.BeginUpdate();
            string search = ((TextBox)sender).Text;
            view.Nodes.Clear();
            if(view.Tag.ToString() == "-1" || view.Tag.ToString() == "tmog" || view.Tag.ToString() == "tier")
            {
                foreach (gbid id in this.GBIDList)
                {
                    if(this.sName.Checked)
                    {
                        if (id.Name.ToLower().Contains(search.ToLower()))
                        {
                            TreeNode node = new TreeNode();
                            node.Text = id.Name;
                            node.Tag = id.GBID.ToString();
                            bool pass = false;
                            foreach (TreeNode x in view.Nodes)
                            {
                                if (x.Text.ToLower() == id.Category.ToLower())
                                {
                                    x.Nodes.Add(node);
                                    pass = true;
                                }
                            }
                            if (!pass)
                            {
                                view.Nodes.Add(id.Category);
                                foreach (TreeNode x in view.Nodes)
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
                    else if(this.sCategory.Checked)
                    {
                        if (id.Category.ToLower().Contains(search.ToLower()))
                        {
                            TreeNode node = new TreeNode();
                            node.Text = id.Name;
                            node.Tag = id.GBID.ToString();
                            bool pass = false;
                            foreach (TreeNode x in view.Nodes)
                            {
                                if (x.Text.ToLower() == id.Category.ToLower())
                                {
                                    x.Nodes.Add(node);
                                    pass = true;
                                }
                            }
                            if (!pass)
                            {
                                view.Nodes.Add(id.Category);
                                foreach (TreeNode x in view.Nodes)
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
                    else if(this.sDescription.Checked)
                    {
                        if (id.Details.ToLower().Contains(search.ToLower()))
                        {
                            TreeNode node = new TreeNode();
                            node.Text = id.Name;
                            node.Tag = id.GBID.ToString();
                            bool pass = false;
                            foreach (TreeNode x in view.Nodes)
                            {
                                if (x.Text.ToLower() == id.Category.ToLower())
                                {
                                    x.Nodes.Add(node);
                                    pass = true;
                                }
                            }
                            if (!pass)
                            {
                                view.Nodes.Add(id.Category);
                                foreach (TreeNode x in view.Nodes)
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
                }
                this.swapPanes(true);
            }
            else
            {
                foreach (affix id in this.AffixList)
                {
                    if(this.sName.Checked)
                    {
                        if (id.Name.ToLower().Contains(search.ToLower()))
                        {
                            TreeNode node = new TreeNode();
                            node.Text = id.Name;
                            node.Tag = id.Affix.ToString();
                            bool pass = false;
                            foreach (TreeNode x in view.Nodes)
                            {
                                if (x.Text.ToLower() == id.Category.ToLower())
                                {
                                    x.Nodes.Add(node);
                                    pass = true;
                                }
                            }
                            if (!pass)
                            {
                                view.Nodes.Add(id.Category);
                                foreach (TreeNode x in view.Nodes)
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
                    else if(this.sCategory.Checked)
                    {
                        if (id.Category.ToLower().Contains(search.ToLower()))
                        {
                            TreeNode node = new TreeNode();
                            node.Text = id.Name;
                            node.Tag = id.Affix.ToString();
                            bool pass = false;
                            foreach (TreeNode x in view.Nodes)
                            {
                                if (x.Text.ToLower() == id.Category.ToLower())
                                {
                                    x.Nodes.Add(node);
                                    pass = true;
                                }
                            }
                            if (!pass)
                            {
                                view.Nodes.Add(id.Category);
                                foreach (TreeNode x in view.Nodes)
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
                    else if(this.sDescription.Checked)
                    {
                        if (id.Details.ToLower().Contains(search.ToLower()))
                        {
                            TreeNode node = new TreeNode();
                            node.Text = id.Name;
                            node.Tag = id.Affix.ToString();
                            bool pass = false;
                            foreach (TreeNode x in view.Nodes)
                            {
                                if (x.Text.ToLower() == id.Category.ToLower())
                                {
                                    x.Nodes.Add(node);
                                    pass = true;
                                }
                            }
                            if (!pass)
                            {
                                view.Nodes.Add(id.Category);
                                foreach (TreeNode x in view.Nodes)
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
                }
                this.swapPanes(false);
            }

            view.Sort();
            view.Visible = false;
            if (search == "")
            {
                try
                {
                    var result = view.Descendants().Where(x => (x.Tag as string) == this.item.generator.gb_handle.gbid.ToString()).FirstOrDefault();
                    if (result != null)
                    {
                        view.Focus();
                        view.SelectedNode = result;
                        //this.TVList.SelectedNode.BackColor = Color.Cyan;
                        view.SelectedNode.EnsureVisible();
                        this.SelectedChildNode = result;
                    }
                }
                catch 
                { 
                    try
                    {
                        var result = view.Descendants().Where(x => (x.Tag as string) == this.item.generator.base_affixes[Convert.ToInt32(view.Tag.ToString())].ToString()).FirstOrDefault();
                        if (result != null)
                        {
                            view.Focus();
                            view.SelectedNode = result;
                            //this.TVList.SelectedNode.BackColor = Color.Cyan;
                            view.SelectedNode.EnsureVisible();
                            this.SelectedChildNode = result;
                        }
                    }
                    catch { }
                }
            }
            else
                view.ExpandAll();
            view.EndUpdate();
            this.GBIDTVList.CollapseAll();
            this.AffixTVList.CollapseAll();
            if (search != "")
                view.ExpandAll();
            view.Visible = true;
            this.searchBox.Focus();
            return;
        }

        private void TVList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.SelectNew();
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void SelectNew()
        {

            TreeView view = new TreeView();
            if (this.GBIDTVList.Visible)
                view = GBIDTVList;
            else if (this.AffixTVList.Visible)
                view = AffixTVList;
            else
                return;
            if (view.SelectedNode.Tag == null)
                return;
            string t = view.Tag.ToString();
            if (t == "-1" || t == "tmog" || t == "tier" || t == "old" || t == "new")
            {
                try
                {
                    if (t == "-1")
                    {
                        this.item.generator.gb_handle.gbid = Convert.ToInt32(view.SelectedNode.Tag);
                        this.ItemField.Text = helper.FindGBID(this.item.generator.gb_handle.gbid.ToString(), 0, this.GBIDList).Name;
                        //this.parrent.items = this.items;
                        this.parrent.updateItem(this.item);
                    }
                    else if (t == "tmog")
                    {
                        this.item.generator.transmogrify_gbid = Convert.ToInt32(view.SelectedNode.Tag);
                        this.tmog.Text = helper.FindGBID(this.item.generator.transmogrify_gbid.ToString(), 0, this.GBIDList).Name;
                        //this.parrent.items = this.items;
                        this.parrent.updateItem(this.item);
                    }
                    else if (t == "tier")
                    {
                        this.item.generator.legendary_tier_quality = Convert.ToInt32(view.SelectedNode.Tag);
                        this.tier.Text = helper.FindGBID(this.item.generator.legendary_tier_quality.ToString(), 0, this.GBIDList).Name;
                        //this.parrent.items = this.items;
                        this.parrent.updateItem(this.item);
                    }
                    else if (t == "old")
                    {
                        this.item.generator.existing_affix = Convert.ToInt32(view.SelectedNode.Tag);
                        this.oldAffix.Text = helper.FindAffix(this.item.generator.existing_affix.ToString(), 0, this.AffixList).Name;
                        if (this.item.generator.enchant_seed == 0U)
                            this.item.generator.enchant_seed = RandCalc.Rnd32();
                        if (this.item.generator.enchanted_count == 0)
                            this.item.generator.enchanted_count = 3;
                        //this.parrent.items = this.items;
                        this.parrent.updateItem(this.item);
                    }
                    else if (t == "new")
                    {
                        this.item.generator.enchanted_affix = Convert.ToInt32(view.SelectedNode.Tag);
                        this.newAffix.Text = helper.FindAffix(this.item.generator.enchanted_affix.ToString(), 0, this.AffixList).Name;
                        if (this.item.generator.enchant_seed == 0U)
                            this.item.generator.enchant_seed = RandCalc.Rnd32();
                        if (this.item.generator.enchanted_count == 0)
                            this.item.generator.enchanted_count = 3;
                        //this.parrent.items = this.items;
                        this.parrent.updateItem(this.item);
                    }
                }
                catch { }
            }
            else
            {
                try
                {
                    int i = Convert.ToInt32(view.Tag.ToString());
                    try
                    {
                        this.item.generator.base_affixes[i] = Convert.ToInt32(view.SelectedNode.Tag);
                    }
                    catch
                    {
                        int c = this.item.generator.base_affixes.Count() - 1;
                        int initializer = -1;
                        for (int f = c; f <= 5; f++)
                        {
                            this.item.generator.base_affixes.Add(initializer);
                        }
                        this.item.generator.base_affixes[i] = Convert.ToInt32(view.SelectedNode.Tag);
                    }
                    foreach (PB.Items.SavedItem z in this.items)
                    {
                        try
                        {
                            foreach (PB.Items.EmbeddedGenerator emb in z.generator.contents)
                            {
                                if (emb.id.id_low == this.item.id.id_low)
                                {
                                    emb.generator.base_affixes = this.item.generator.base_affixes;
                                }
                            }
                        }
                        catch { }
                    }
                    this.item.generator.base_affixes[i] = Convert.ToInt32(view.SelectedNode.Tag);
                    if (view.Tag.ToString() == "0")
                    {
                        this.Affix0.Text = helper.FindAffix(view.SelectedNode.Tag.ToString(), 0, this.AffixList).Name;
                    }
                    else if (view.Tag.ToString() == "1")
                    {
                        this.Affix1.Text = helper.FindAffix(view.SelectedNode.Tag.ToString(), 0, this.AffixList).Name;
                    }
                    else if (view.Tag.ToString() == "2")
                    {
                        this.Affix2.Text = helper.FindAffix(view.SelectedNode.Tag.ToString(), 0, this.AffixList).Name;
                    }
                    else if (view.Tag.ToString() == "3")
                    {
                        this.Affix3.Text = helper.FindAffix(view.SelectedNode.Tag.ToString(), 0, this.AffixList).Name;
                    }
                    else if (view.Tag.ToString() == "4")
                    {
                        this.Affix4.Text = helper.FindAffix(view.SelectedNode.Tag.ToString(), 0, this.AffixList).Name;
                    }
                    else if (view.Tag.ToString() == "5")
                    {
                        this.Affix5.Text = helper.FindAffix(view.SelectedNode.Tag.ToString(), 0, this.AffixList).Name;
                    }
                    this.parrent.updateItem(this.item);
                    //this.parrent.refreshList();
                }
                catch { }
            }
            foreach (PB.Items.SavedItem temp in this.items)
            {
                if (temp.generator.contents != null && temp.generator.contents.Count() > 0)
                {
                    foreach (PB.Items.EmbeddedGenerator emb in temp.generator.contents)
                    {
                        if (emb.id.id_low == this.item.id.id_low)
                        {
                            emb.generator = this.item.generator;
                        }
                    }
                }
            }
        }

        private void TVList_Click(object sender, EventArgs e)
        {

        }
        private void TVList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeView view = new TreeView();
                if (this.GBIDTVList.Visible)
                    view = GBIDTVList;
                else if (this.AffixTVList.Visible)
                    view = AffixTVList;
                else
                    return;
                if (view.SelectedNode.Tag == null)
                    return;
                if (this.SelectedChildNode != null)
                {
                    SelectedChildNode.BackColor = Color.WhiteSmoke;
                }
                string tag = view.Tag.ToString();
                if (tag == "-1" || tag == "tier")
                {
                    if (helper.FindGBID(this.item.generator.gb_handle.gbid.ToString(), 0, this.GBIDList) != null)
                    {
                        this.InfoBox.name = helper.FindGBID(view.SelectedNode.Tag.ToString(), 0, this.GBIDList).Name;
                        this.InfoBox.description = helper.FindGBID(view.SelectedNode.Tag.ToString(), 0, this.GBIDList).Details;
                    }
                    else
                    {
                        this.InfoBox.name = view.SelectedNode.Tag.ToString();
                        this.InfoBox.description = "~Item not found...";
                    }
                    this.InfoBox.populate();

                }
            }
            catch { }
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
                        string tag = tb.Tag.ToString();
                        string[] afx = new[]
                        {
                            "0",
                            "1",
                            "2",
                            "3",
                            "4",
                            "5",
                            "old",
                            "new"
                        };
                        string str = "";
                        if(tag == "-1")
                        {
                            str = "GBID:" + Base64Encode(this.item.generator.gb_handle.gbid.ToString());
                        }
                        else if(tag == "tmog")
                        {
                            str = "GBID:" + Base64Encode(this.item.generator.transmogrify_gbid.ToString());
                        }
                        else if (tag == "tier")
                        {
                            str = "GBID:" + Base64Encode(this.item.generator.legendary_tier_quality.ToString());
                        }
                        else if (tag == "old")
                        {
                            str = "AFFIX:" + Base64Encode(this.item.generator.existing_affix.ToString());
                        }
                        else if (tag == "new")
                        {
                            str = "AFFIX:" + Base64Encode(this.item.generator.enchanted_affix.ToString());
                        }
                        else if (tag == "0")
                        {
                            str = "AFFIX:" + Base64Encode(this.item.generator.base_affixes[0].ToString());
                        }
                        else if (tag == "1")
                        {
                            str = "AFFIX:" + Base64Encode(this.item.generator.base_affixes[1].ToString());
                        }
                        else if (tag == "2")
                        {
                            str = "AFFIX:" + Base64Encode(this.item.generator.base_affixes[2].ToString());
                        }
                        else if (tag == "3")
                        {
                            str = "AFFIX:" + Base64Encode(this.item.generator.base_affixes[3].ToString());
                        }
                        else if (tag == "4")
                        {
                            str = "AFFIX:" + Base64Encode(this.item.generator.base_affixes[4].ToString());
                        }
                        else if (tag == "5")
                        {
                            str = "AFFIX:" + Base64Encode(this.item.generator.base_affixes[5].ToString());
                        }
                        else if (tag == "rn")
                        {
                            PB.Items.RareItemName rn = item.generator.rare_item_name;
                            //rn.sno_affix_string_list && n.Affix_String_List_Index == rn.affix_string_list_index
                            str = "RARENAME:" + rn.affix_string_list_index + ":" + rn.sno_affix_string_list + ":" + Base64Encode(this.rareName.Text);
                        }
                        Clipboard.SetText(str);
                    }
                }
            }
            catch { }
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
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                TextBox tb = (TextBox)owner.SourceControl;
                string str = Clipboard.GetText();
                string tag = tb.Tag.ToString();
                string name;
                string[] afx = new[]
                        {
                            "0",
                            "1",
                            "2",
                            "3",
                            "4",
                            "5",
                            "old",
                            "new"
                        };
                if ((str.Split(':'))[0] == "AFFIX" && afx.Contains(tag))
                {
                    int fx = Convert.ToInt32(Base64Decode((str.Split(':'))[1]));
                    name = "";
                    try
                    {
                        name = helper.FindAffix(fx.ToString(), 0, this.AffixList).Name;
                    }
                    catch
                    {
                        name = fx.ToString();
                    }
                    if (tag == "old")
                    {
                        this.item.generator.existing_affix = fx;
                        this.oldAffix.Text = name;
                        this.parrent.updateItem(this.item);
                    }
                    else if (tag == "new")
                    {
                        this.item.generator.enchanted_affix = fx;
                        this.newAffix.Text = name;
                        this.parrent.updateItem(this.item);
                    }
                    else if (tag == "0")
                    {
                        this.Affix0.Text = name;
                        this.item.generator.base_affixes[0] = fx;
                    }
                    else if (tag == "1")
                    {
                        this.Affix1.Text = name;
                        this.item.generator.base_affixes[1] = fx;
                    }
                    else if (tag == "2")
                    {
                        this.Affix2.Text = name;
                        this.item.generator.base_affixes[2] = fx;
                    }
                    else if (tag == "3")
                    {
                        this.Affix3.Text = name;
                        this.item.generator.base_affixes[3] = fx;
                    }
                    else if (tag == "4")
                    {
                        this.Affix4.Text = name;
                        this.item.generator.base_affixes[4] = fx;
                    }
                    else if (tag == "5")
                    {
                        this.Affix5.Text = name;
                        this.item.generator.base_affixes[5] = fx;
                    }

                }
                else if ((str.Split(':'))[0] == "GBID" && !afx.Contains(tag))
                {
                    int gb = Convert.ToInt32(Base64Decode((str.Split(':'))[1]));
                    name = "";
                    try
                    {
                        name = helper.FindGBID(gb.ToString(), 0, this.GBIDList).Name;
                    }
                    catch
                    {
                        name = gb.ToString();
                    }
                    if (tag == "-1")
                    {
                        this.item.generator.gb_handle.gbid = gb;
                        this.ItemField.Text = name;
                        this.parrent.updateItem(this.item);
                    }
                    else if (tag == "tmog")
                    {
                        this.item.generator.transmogrify_gbid = gb;
                        this.tmog.Text = name;
                        this.parrent.updateItem(this.item);
                    }
                    else if (tag == "tier")
                    {
                        this.item.generator.legendary_tier_quality = gb;
                        this.tier.Text = name;
                        this.parrent.updateItem(this.item);
                    }
                }
                else if((str.Split(':'))[0] == "RARENAME" && tag == "rn")
                {
                    try
                    {
                        Random r = new Random();
                        int x = r.Next(0, 25);
                        this.item.generator.rare_item_name.affix_string_list_index = Convert.ToInt32((str.Split(':'))[1]);
                        this.item.generator.rare_item_name.item_string_list_index = x;
                        this.item.generator.rare_item_name.sno_affix_string_list = Convert.ToInt32((str.Split(':'))[2]);
                        this.parrent.updateItem(this.item);
                        this.parrent.rareName1.populate();
                        //this.parrent.refreshList();
                    }
                    catch
                    {
                        return;
                    }
                    this.rareName.Text = Base64Decode((str.Split(':'))[3]);
                }
                else
                    return;
            }
            catch { }
            foreach(PB.Items.SavedItem i in this.items)
            {
                if(i.generator.contents.Count > 0)
                {
                    foreach(PB.Items.EmbeddedGenerator emb in i.generator.contents)
                    {
                        if(emb.id.id_low == this.item.id.id_low)
                        {
                            emb.generator = this.item.generator;
                        }
                    }
                }
            }
            this.parrent.items = this.items;
            this.parrent.updateItem(this.item);
        }
        
        public void UpdateRareName(string str)
        {
            this.rareName.Text = str;
        }

        private void rareName_Click(object sender, EventArgs e)
        {
            this.parrent.tabControl1.SelectedIndex = 2;
        }

        private void TVList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            this.SelectNew();
        }

        private void CTMenu_opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip owner = sender as ContextMenuStrip;
            TextBox tb = (TextBox)owner.SourceControl;
            string tag = (string)tb.Tag;
            this.editGBIDEntryToolStripMenuItem.Visible = false;
            this.editAffixEntryToolStripMenuItem.Visible = false;
            this.floodToAllInventoryItemsToolStripMenuItem.Visible = false;
            this.floodToolStripMenuItem.Visible = false;
            if (tag == "-1" || tag == "tier" || tag == "tmog")
            {
                this.editGBIDEntryToolStripMenuItem.Visible = true;
            }
            else if(tag != "rn")
            {
                this.editAffixEntryToolStripMenuItem.Visible = true;
                if(tag != "old" && tag != "new")
                {
                    this.floodToolStripMenuItem.Visible = true;
                }
            }

            if(tag == "tier" || tag == "tmog" || tag == "rn")
            {
                this.floodToAllInventoryItemsToolStripMenuItem.Visible = true;
            }
        }

        private void editGBIDEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripItem menuItem = sender as ToolStripItem;
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                TextBox tb = (TextBox)owner.SourceControl;
                string tag = (string)tb.Tag;
                gbid temp = new gbid(0, "a", "b", "Console", "d");
                if (tag == "-1")
                {
                    temp = helper.DefaultFindGBID(this.item.generator.gb_handle.gbid.ToString(), 0, this.GBIDList);
                }
                else if (tag == "tier")
                {
                    temp = helper.DefaultFindGBID(this.item.generator.legendary_tier_quality.ToString(), 0, this.GBIDList);
                }
                else if (tag == "tmog")
                {
                    temp = helper.DefaultFindGBID(this.item.generator.transmogrify_gbid.ToString(), 0, this.GBIDList);
                }
                else
                {
                    return;
                }
                embeddedIDEGBID ide = new embeddedIDEGBID();
                ide.GBIDList = this.GBIDList;
                ide.selected = temp;
                ide.populate();
                ide.ShowDialog();
                this.fillFields();
                parrent.refreshList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void editAffixEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
            TextBox tb = (TextBox)owner.SourceControl;
            affix temp = helper.FindAffix(tb.Text, 4, this.AffixList);
            embeddedIDEAffix ide = new embeddedIDEAffix();
            ide.AffixList = this.AffixList;
            ide.selected = temp;
            ide.populate();
            ide.ShowDialog();
            this.fillFields();
            parrent.refreshList();
        }

        private void floodToAllInventoryItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.item == null)
                return;
            ToolStripItem menuItem = sender as ToolStripItem;
            ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
            TextBox tb = (TextBox)owner.SourceControl;
            string tag = (string)tb.Tag;
            if(tag == "tmog")
            {
                foreach (PB.Items.SavedItem temp in this.items)
                {
                    temp.generator.transmogrify_gbid = this.item.generator.transmogrify_gbid.DeepClone();
                    if (temp.generator.contents != null && temp.generator.contents.Count() > 0)
                    {
                        foreach (PB.Items.EmbeddedGenerator emb in temp.generator.contents)
                        {
                            emb.generator.transmogrify_gbid = this.item.generator.transmogrify_gbid.DeepClone();
                        }
                    }
                }
            }
            else if(tag == "tier")
            {
                foreach (PB.Items.SavedItem temp in this.items)
                {
                    temp.generator.legendary_tier_quality = this.item.generator.legendary_tier_quality.DeepClone();
                    if (temp.generator.contents != null && temp.generator.contents.Count() > 0)
                    {
                        foreach (PB.Items.EmbeddedGenerator emb in temp.generator.contents)
                        {
                            emb.generator.legendary_tier_quality = this.item.generator.legendary_tier_quality.DeepClone();
                        }
                    }
                }
            }
            else if(tag == "rn")
            {
                PB.Items.RareItemName rn = item.generator.rare_item_name;
                int n = rn.affix_string_list_index;
                foreach (PB.Items.SavedItem temp in this.items)
                {
                    temp.generator.rare_item_name = rn.DeepClone();
                    temp.generator.rare_item_name.affix_string_list_index = n;
                    if (temp.generator.contents != null && temp.generator.contents.Count() > 0)
                    {
                        foreach (PB.Items.EmbeddedGenerator emb in temp.generator.contents)
                        {
                            emb.generator.rare_item_name = rn.DeepClone();
                            emb.generator.rare_item_name.affix_string_list_index = n;
                        }
                    }
                    n = n + 1;
                }
                parrent.refreshList();
                /*
                PB.Items.RareItemName rn = item.generator.rare_item_name;
                foreach(PB.Items.SavedItem temp in this.items)
                {
                    temp.generator.rare_item_name = rn.DeepClone();
                    if(temp.generator.contents != null && temp.generator.contents.Count() > 0)
                    {
                        foreach(PB.Items.EmbeddedGenerator emb in temp.generator.contents)
                        {
                            emb.generator.rare_item_name = rn.DeepClone();
                        }
                    }
                }
                parrent.refreshList();*/
            }
        }

        private void floodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.item == null)
                return;
            ToolStripMenuItem mi = sender as ToolStripMenuItem;
            if (mi == null)
                return;
            ContextMenuStrip contextMenuStrip = mi.OwnerItem.Owner as ContextMenuStrip;
            if (contextMenuStrip == null)
                return;
            TextBox tb = (TextBox)contextMenuStrip.SourceControl;
            int tag = 10;
            try
            {
                tag = Convert.ToInt32(tb.Tag);
            }
            catch
            {
                return;
            }
            if(tag >=0 && tag < 6)
            {
                int afx = this.item.generator.base_affixes[tag];
                this.item.generator.base_affixes[0] = afx;
                this.item.generator.base_affixes[1] = afx;
                this.item.generator.base_affixes[2] = afx;
                this.item.generator.base_affixes[3] = afx;
                this.item.generator.base_affixes[4] = afx;
                this.item.generator.base_affixes[5] = afx;
                foreach (PB.Items.SavedItem temp in this.items)
                {
                    if (temp.generator.contents != null && temp.generator.contents.Count() > 0)
                    {
                        foreach (PB.Items.EmbeddedGenerator emb in temp.generator.contents)
                        {
                            if(emb.id == this.item.id && temp.id == this.item.socket_id)
                            {
                                emb.generator.base_affixes = this.item.generator.base_affixes;
                            }
                        }
                    }
                }
                try { this.Affix0.Text = helper.FindAffix(this.item.generator.base_affixes[0].ToString(), 0, this.AffixList).Name; }
                catch { this.Affix0.Text = this.item.generator.base_affixes[0].ToString(); }
                try { this.Affix1.Text = helper.FindAffix(this.item.generator.base_affixes[1].ToString(), 0, this.AffixList).Name; }
                catch { this.Affix1.Text = this.item.generator.base_affixes[1].ToString(); }
                try { this.Affix2.Text = helper.FindAffix(this.item.generator.base_affixes[2].ToString(), 0, this.AffixList).Name; }
                catch { this.Affix2.Text = this.item.generator.base_affixes[2].ToString(); }
                try { this.Affix3.Text = helper.FindAffix(this.item.generator.base_affixes[3].ToString(), 0, this.AffixList).Name; }
                catch { this.Affix3.Text = this.item.generator.base_affixes[3].ToString(); }
                try { this.Affix4.Text = helper.FindAffix(this.item.generator.base_affixes[4].ToString(), 0, this.AffixList).Name; }
                catch { this.Affix4.Text = this.item.generator.base_affixes[4].ToString(); }
                try { this.Affix5.Text = helper.FindAffix(this.item.generator.base_affixes[5].ToString(), 0, this.AffixList).Name; }
                catch { this.Affix5.Text = this.item.generator.base_affixes[5].ToString(); }
            }
        }

        private void downToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.item == null)
                return;
            ToolStripMenuItem mi = sender as ToolStripMenuItem;
            if (mi == null)
                return;
            ContextMenuStrip contextMenuStrip = mi.OwnerItem.Owner as ContextMenuStrip;
            if (contextMenuStrip == null)
                return;
            TextBox tb = (TextBox)contextMenuStrip.SourceControl;
            int tag = 10;
            int afx = -1;
            try
            {
                tag = Convert.ToInt32(tb.Tag);
                afx = this.item.generator.base_affixes[tag];
            }
            catch
            {
                return;
            }
            if (tag >= 0 && tag < 6)
            {
                while(tag != 6)
                {
                    this.item.generator.base_affixes[tag] = afx;
                    tag = tag + 1;
                }
                foreach (PB.Items.SavedItem temp in this.items)
                {
                    if (temp.generator.contents != null && temp.generator.contents.Count() > 0)
                    {
                        foreach (PB.Items.EmbeddedGenerator emb in temp.generator.contents)
                        {
                            if (emb.id == this.item.id && temp.id == this.item.socket_id)
                            {
                                emb.generator.base_affixes = this.item.generator.base_affixes;
                            }
                        }
                    }
                }
                try { this.Affix0.Text = helper.FindAffix(this.item.generator.base_affixes[0].ToString(), 0, this.AffixList).Name; }
                catch { this.Affix0.Text = this.item.generator.base_affixes[0].ToString(); }
                try { this.Affix1.Text = helper.FindAffix(this.item.generator.base_affixes[1].ToString(), 0, this.AffixList).Name; }
                catch { this.Affix1.Text = this.item.generator.base_affixes[1].ToString(); }
                try { this.Affix2.Text = helper.FindAffix(this.item.generator.base_affixes[2].ToString(), 0, this.AffixList).Name; }
                catch { this.Affix2.Text = this.item.generator.base_affixes[2].ToString(); }
                try { this.Affix3.Text = helper.FindAffix(this.item.generator.base_affixes[3].ToString(), 0, this.AffixList).Name; }
                catch { this.Affix3.Text = this.item.generator.base_affixes[3].ToString(); }
                try { this.Affix4.Text = helper.FindAffix(this.item.generator.base_affixes[4].ToString(), 0, this.AffixList).Name; }
                catch { this.Affix4.Text = this.item.generator.base_affixes[4].ToString(); }
                try { this.Affix5.Text = helper.FindAffix(this.item.generator.base_affixes[5].ToString(), 0, this.AffixList).Name; }
                catch { this.Affix5.Text = this.item.generator.base_affixes[5].ToString(); }
            }
        }

        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.item == null)
                return;
            ToolStripMenuItem mi = sender as ToolStripMenuItem;
            if (mi == null)
                return;
            ContextMenuStrip contextMenuStrip = mi.OwnerItem.Owner as ContextMenuStrip;
            if (contextMenuStrip == null)
                return;
            TextBox tb = (TextBox)contextMenuStrip.SourceControl;

            int tag = 10;
            int afx = -1;
            try
            {
                tag = Convert.ToInt32(tb.Tag);
                afx = this.item.generator.base_affixes[tag];
            }
            catch
            {
                return;
            }
            if (tag >= 0 && tag < 6)
            {
                while (tag >=0)
                {
                    this.item.generator.base_affixes[tag] = afx;
                    tag = tag - 1;
                }
                foreach (PB.Items.SavedItem temp in this.items)
                {
                    if (temp.generator.contents != null && temp.generator.contents.Count() > 0)
                    {
                        foreach (PB.Items.EmbeddedGenerator emb in temp.generator.contents)
                        {
                            if (emb.id == this.item.id && temp.id == this.item.socket_id)
                            {
                                emb.generator.base_affixes = this.item.generator.base_affixes;
                            }
                        }
                    }
                }
                try { this.Affix0.Text = helper.FindAffix(this.item.generator.base_affixes[0].ToString(), 0, this.AffixList).Name; }
                catch { this.Affix0.Text = this.item.generator.base_affixes[0].ToString(); }
                try { this.Affix1.Text = helper.FindAffix(this.item.generator.base_affixes[1].ToString(), 0, this.AffixList).Name; }
                catch { this.Affix1.Text = this.item.generator.base_affixes[1].ToString(); }
                try { this.Affix2.Text = helper.FindAffix(this.item.generator.base_affixes[2].ToString(), 0, this.AffixList).Name; }
                catch { this.Affix2.Text = this.item.generator.base_affixes[2].ToString(); }
                try { this.Affix3.Text = helper.FindAffix(this.item.generator.base_affixes[3].ToString(), 0, this.AffixList).Name; }
                catch { this.Affix3.Text = this.item.generator.base_affixes[3].ToString(); }
                try { this.Affix4.Text = helper.FindAffix(this.item.generator.base_affixes[4].ToString(), 0, this.AffixList).Name; }
                catch { this.Affix4.Text = this.item.generator.base_affixes[4].ToString(); }
                try { this.Affix5.Text = helper.FindAffix(this.item.generator.base_affixes[5].ToString(), 0, this.AffixList).Name; }
                catch { this.Affix5.Text = this.item.generator.base_affixes[5].ToString(); }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.AffixTVList.Nodes.Clear();
            this.GBIDTVList.Nodes.Clear();
            this.populateAffixes();
            if (this.isLocker)
            {
                this.parrent.hParent.parent.populateGBIDs();
                this.GBIDTVList.Nodes.AddRange(this.parrent.hParent.parent.GBIDNodes.ToArray());
                this.GBIDTVList.Sort();
            }
            else
            {
                populateGBIDs();
            }
            this.searchBox.Text = "Search...";
            this.searchBox.ForeColor = Color.DimGray;
        }

        private void CustomNameSet(object sender, EventArgs e)
        {
            if (!loaded)
                return;
            this.item.custom_name = this.CustomName.Text;
        }

        private void CustomNameSet(object sender, KeyEventArgs e)
        {
            if (!loaded)
                return;
            if(e.KeyCode == Keys.Enter && false)
            {
                this.parrent.refreshList();
                return;
            }
            this.item.custom_name = this.CustomName.Text;
            parrent.UpdateName(this.CustomName.Text);
        }

        private void CustomName_Leave(object sender, EventArgs e)
        {
            //parrent.refreshList();
        }

        private void itemDescription_KeyUp(object sender, KeyEventArgs e)
        {
            if (!loaded)
                return;
            this.item.custom_description = this.itemDescription.Text.Replace(System.Environment.NewLine,"~");
        }
    }
}
