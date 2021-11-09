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
using D3Studio.ui.hero;
using System.Text.RegularExpressions;
using System.IO;
using D3Studio.ui.hero.inventoryControls;
using D3Studio.lists;

namespace D3Studio.ide
{
    public partial class IDEAffix : UserControl
    {
        public List<affix> AffixList = new List<affix>();

        public affix selected;

        public embeddedIDEAffix parent;

        public IDEBase mParent;

        public bool embeded = false;
        public IDEAffix()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            TVList.TreeViewNodeSorter = new NodeSorter();
        }

        public void resize()
        {
            this.tableLayoutPanel1.ColumnStyles[3].Width = 0;
            this.tableLayoutPanel1.RowStyles[0].Height = 0;
            this.tableLayoutPanel1.RowStyles[1].Height = 0;
            this.button1.Visible = false;
        }

        public void populate()
        {
            if (this.embeded)
            {
                this.TVList.Visible = false;
                this.searchBox.Visible = false;
                this.newButton.Visible = false;
                this.deleteButton.Visible = false;

                this.gbidBox.Value = Convert.ToDecimal(selected.Affix);
                this.nameBox.Text = selected.Name;
                this.categoryBox.Text = selected.Category;
                this.gbidBox.ReadOnly = true;
                this.gbidBox.Enabled = false;
                return;
            }
            this.TVList.Nodes.Clear();
            foreach (affix id in this.AffixList)
            {
                TreeNode node = new TreeNode();
                node.Text = id.Name;
                node.Tag = id;
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
                    TreeNode cat = new TreeNode();
                    cat.Text = id.Category;
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

        private void TVList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                TreeNode node = (TreeNode)e.Node;
                affix entry = (affix)node.Tag;
                this.gbidBox.Value = Convert.ToDecimal(entry.Affix);
                this.nameBox.Text = entry.Name;
                this.categoryBox.Text = entry.Category;
                this.selected = entry;
            }
            catch { }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                affix temp = new affix(
                    Convert.ToInt32(this.gbidBox.Value),
                    this.nameBox.Text,
                    this.categoryBox.Text
                );
                int i = this.AffixList.IndexOf(this.selected);
                this.AffixList[i] = temp;
                //this.populate();
                this.UpdateFile();
                if (this.mParent != null)
                    this.mParent.parent.showToolTip("Successfully saved Affix entry!");
                this.selected = temp;
            }
            catch
            {
                if (!this.embeded)
                    return;
                newButton_Click(sender, e);
            }
            if (this.embeded)
            {
                //this.parent.parent.refreshList();
                this.parent.Close();
            }
        }

        public void UpdateFile()
        {
            using (StreamWriter newTask = new StreamWriter(Application.StartupPath + "\\Affix_List.txt", false))
            {
                foreach (affix id in this.AffixList)
                {
                    newTask.WriteLine(id.Affix.ToString() + "\t=\t" + id.Name + "\t=\t" + id.Category);
                }
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            affix temp = new affix(
                Convert.ToInt32(this.gbidBox.Value),
                this.nameBox.Text,
                this.categoryBox.Text
            );
            this.AffixList.Add(temp);
            UpdateFile();
            //populate();
            this.selected = temp;
            if (this.mParent != null)
                this.mParent.parent.showToolTip("Successfully added Affix entry!");
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (selected == null)
                return;
            affix temp = this.AffixList.First(x => x == this.selected);
            this.AffixList.Remove(temp);
            UpdateFile();
            this.populate();
            this.selected = null;
            if (this.mParent != null)
                this.mParent.parent.showToolTip("Successfully removed Affix entry!");
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if (this.searchBox.Text == "Search...")
            {
                this.searchBox.Text = "";
                this.searchBox.ForeColor = Color.Black;
            }
        }

        public void AddText(object sender, EventArgs e)
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
            string search = ((TextBox)sender).Text;
            if (search == "")
            {
                populate();
                return;
            }
            this.TVList.BeginUpdate();
            this.TVList.Nodes.Clear();
            foreach (affix id in this.AffixList)
            {
                if(id.Name.ToLower().Contains(this.searchBox.Text.ToLower()))
                {
                    TreeNode node = new TreeNode();
                    node.Text = id.Name;
                    node.Tag = id;
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
            this.TVList.ExpandAll();
            this.TVList.EndUpdate();
            this.TVList.Visible = false;
            this.TVList.Sort();
            this.TVList.CollapseAll();
            if (this.searchBox.Text != "")
                this.TVList.ExpandAll();
            this.TVList.Visible = true;
            this.searchBox.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.searchBox.Text != "Search...")
            {
                string search = this.searchBox.Text;
                if (search == "")
                {
                    populate();
                    return;
                }
                this.TVList.BeginUpdate();
                this.TVList.Nodes.Clear();
                foreach (affix id in this.AffixList)
                {
                    if (id.Name.ToLower().Contains(this.searchBox.Text.ToLower()))
                    {
                        TreeNode node = new TreeNode();
                        node.Text = id.Name;
                        node.Tag = id;
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
                this.TVList.EndUpdate();
                this.searchBox.Focus();
            }
            this.populate();
        }
    }
}
