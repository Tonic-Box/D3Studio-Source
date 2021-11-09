using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PB.Items;
using D3Studio.lists.types;
using D3Studio.lists;

namespace D3Studio.ui.hero.inventoryControls
{
    public partial class rareName : UserControl
    {
        public PB.Items.SavedItem item;

        public List<PB.Items.SavedItem> items;

        public List<sno> SNOList = new List<sno>();

        public inventory parrent;

        //public dynamic SNO_Name;

        private bool loaded;

        public rareName()
        {
            InitializeComponent();
            //this.SNOList.AddRange(snoList.snos(Application.StartupPath + "\\db\\ENsno_item.txt"));
            //this.AddSNOTreeView();
            SnoTV.TreeViewNodeSorter = new NodeSorter();
        }

        public void populate()
        {
            //this.SnoTV.Nodes.Clear();
            if (item.generator.rare_item_name == null)
                item.generator.rare_item_name = new RareItemName();
            sno_affix_string_list.Value = item.generator.rare_item_name.sno_affix_string_list;
            item_name_is_prefix.Checked = item.generator.rare_item_name.item_name_is_prefix;
            item_string_list_index.Value = item.generator.rare_item_name.item_string_list_index;
            affix_string_list_index.Value = item.generator.rare_item_name.affix_string_list_index;
            this.SelectSNOTreeView(item.generator.rare_item_name.sno_affix_string_list, item.generator.rare_item_name.affix_string_list_index);
            this.loaded = true;
        }

        private void item_name_is_prefix_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.loaded)
                return;
            item.generator.rare_item_name.item_name_is_prefix = this.item_name_is_prefix.Checked;
        }

        private void sno_affix_string_list_KeyUp(object sender, KeyEventArgs e)
        {
            if (!this.loaded)
                return;
            item.generator.rare_item_name.sno_affix_string_list = Convert.ToInt32(sno_affix_string_list.Value);
        }

        private void item_string_list_index_KeyUp(object sender, KeyEventArgs e)
        {
            if (!this.loaded)
                return;
            item.generator.rare_item_name.item_string_list_index = Convert.ToInt32(item_string_list_index.Value);
        }

        private void affix_string_list_index_KeyUp(object sender, KeyEventArgs e)
        {
            if (!this.loaded)
                return;
            item.generator.rare_item_name.affix_string_list_index = Convert.ToInt32(affix_string_list_index.Value);
        }

        private void SelectSNOName(int s, int i)
        {
            try
            {
                sno entry = this.SNOList.Where(x => x.Sno_Affix_String_List == s && x.Affix_String_List_Index == i).First();
                this.NameLabel.Text = "[" + entry.Name + "]";
            }
            catch
            {
                if(s > 1)
                    this.NameLabel.Text = "[" + s.ToString() + "]";
                else
                    this.NameLabel.Text = "[No Prefix]";
            }
            //this.SNOList.Where(x => x.Sno_Affix_String_List == s && x.Affix_String_List_Index == i).First();
        }

        private void SelectSNOTreeView(int s, int i)
        {
            try
            {
                var result = this.SnoTV.Descendants().Where(x => ((x.Tag as sno).Sno_Affix_String_List == s &&
                               (x.Tag as sno).Affix_String_List_Index == i)).FirstOrDefault();
                if (result != null)
                {
                    this.SnoTV.Focus();
                    this.SnoTV.SelectedNode = result;
                }
            }
            catch { }
            SelectSNOName(s,i);
        }

        public void AddSNOTreeView()
        {
            this.SnoTV.Nodes.Clear();
            this.SnoTV.Nodes.Add("Stable SNO Names");
            this.SnoTV.Nodes.Add("Unstable SNO Names");
            this.SnoTV.Nodes.Add("Stable Names");
            this.SnoTV.Nodes.Add("[No Prefix]");
            foreach (sno id in this.SNOList) 
            {
                if(id.Name.StartsWith("("))
                {
                    TreeNode node = new TreeNode();
                    node.Text = id.Name;
                    node.Tag = id;
                    foreach (TreeNode x in this.SnoTV.Nodes)
                    {
                        if (x.Text == "Stable SNO Names")
                        {
                            x.Nodes.Add(node);
                            break;
                        }
                    }
                }
                else if(id.Name.Contains("NEW"))
                {
                    TreeNode node = new TreeNode();
                    node.Text = id.Name;
                    node.Tag = id;
                    foreach(TreeNode x in this.SnoTV.Nodes)
                    {
                        if(x.Text == "Unstable SNO Names")
                        {
                            x.Nodes.Add(node);
                            break;
                        }
                    }
                }
                else if(id.Name.Contains("No Prefix"))
                {
                    TreeNode node = new TreeNode();
                    node.Text = id.Name;
                    node.Tag = id;
                    foreach (TreeNode x in this.SnoTV.Nodes)
                    {
                        if (x.Text == "[No Prefix]")
                        {
                            x.Nodes.Add(node);
                            break;
                        }
                    }
                }
                else
                {
                    TreeNode node = new TreeNode();
                    node.Text = id.Name;
                    node.Tag = id;
                    foreach (TreeNode x in this.SnoTV.Nodes)
                    {
                        if (x.Text == "Stable Names")
                        {
                            x.Nodes.Add(node);
                            break;
                        }
                    }
                }
            }
            this.SnoTV.Sort();
        }

        private void SnoTV_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Random r = new Random();
                int x = r.Next(0, 25);
                TreeNode item = this.SnoTV.SelectedNode;
                sno s = (sno)item.Tag;
                this.item.generator.rare_item_name.affix_string_list_index = s.Affix_String_List_Index;
                this.item.generator.rare_item_name.item_string_list_index = x;
                this.item.generator.rare_item_name.sno_affix_string_list = s.Sno_Affix_String_List;

                this.affix_string_list_index.Value = s.Affix_String_List_Index;
                this.item_string_list_index.Value = x;
                this.sno_affix_string_list.Value = s.Sno_Affix_String_List;
                this.NameLabel.Text = s.Name;
                this.parrent.SNO_Name = this.item;
                foreach (PB.Items.SavedItem i in this.items)
                {
                    if (i.generator.contents != null)
                    {
                        foreach (PB.Items.EmbeddedGenerator emb in i.generator.contents)
                        {
                            if (emb.id.id_low == this.item.id.id_low)
                            {
                                emb.generator = this.item.generator.DeepClone<PB.Items.Generator>();
                                emb.generator.rare_item_name = this.item.generator.rare_item_name.DeepClone<PB.Items.RareItemName>();
                            }
                        }
                    }
                }
                if (this.parrent.HeroFile != null)
                    this.parrent.HeroFile.items.items = this.items;
                else if (this.parrent.AccountFile != null)
                    parrent.AccountFile.partitions[parrent.partition].items.items = this.items;
                else if (this.parrent.Locker != null)
                    parrent.Locker.items = this.items;
                //this.parrent.refreshList();
                this.parrent.UpdateName("");
                this.parrent.listControl.UpdateRareName(s.Name);
                //this.SNO_Name = this.item.generator.rare_item_name;
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

        private void searchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || this.item == null)
                return;
            int s = item.generator.rare_item_name.sno_affix_string_list;
            int i = item.generator.rare_item_name.affix_string_list_index;
            string term = this.searchBox.Text;
            if (term == "")
            {
                this.AddSNOTreeView();
                return;
            }
            this.SnoTV.Nodes.Clear();
            foreach (sno id in this.SNOList)
            {
                TreeNode node = new TreeNode();
                node.Text = id.Name;
                node.Tag = id;
                if(node.Text.ToLower().Contains(term.ToLower()))
                    SnoTV.Nodes.Add(node);
            }
            this.SnoTV.Sort();
            try
            {
                var result = this.SnoTV.Descendants().Where(x => ((x.Tag as sno).Sno_Affix_String_List == s &&
                                (x.Tag as sno).Affix_String_List_Index == i)).FirstOrDefault();
                if (result != null)
                {
                    this.SnoTV.Focus();
                    this.SnoTV.SelectedNode = result;
                    this.SnoTV.SelectedNode.BackColor = Color.Cyan;
                    //this.NameLabel.Text = SnoTV.SelectedNode.Text;
                    //this.SelectedChildNode = result;
                }
            }
            catch { }
        }

        private void SnoTV_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            try
            {
                Random r = new Random();
                int x = r.Next(0, 25);
                TreeNode item = this.SnoTV.SelectedNode;
                sno s = (sno)item.Tag;
                this.item.generator.rare_item_name.affix_string_list_index = s.Affix_String_List_Index;
                this.item.generator.rare_item_name.item_string_list_index = x;
                this.item.generator.rare_item_name.sno_affix_string_list = s.Sno_Affix_String_List;

                this.affix_string_list_index.Value = s.Affix_String_List_Index;
                this.item_string_list_index.Value = x;
                this.sno_affix_string_list.Value = s.Sno_Affix_String_List;
                this.NameLabel.Text = s.Name;
                //this.parrent.refreshList();
                this.parrent.listControl.UpdateRareName(s.Name);
                this.parrent.UpdateName("");
                //this.SNO_Name = this.item.generator.rare_item_name;
            }
            catch { }
        }

        /*public static sno snoitem(RareItemName s)
        {
            return new sno(s.sno_affix_string_list, s.item_string_list_index, s.affix_string_list_index, s.name);
        }*/
    }
}
