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
using System.IO;
using D3Studio.lists;
using D3Studio.ui.hero;
using System.Diagnostics;

namespace D3Studio.ide
{
    public partial class IDEGBID : UserControl
    {
        public List<gbid> GBIDList = new List<gbid>();

        public gbid selected;

        public inventory invent;

        public embeddedIDEGBID parent;
        public IDEBase mParent;

        public bool embeded = false;
        public IDEGBID()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            TVList.TreeViewNodeSorter = new NodeSorter();
            this.urlBox.Text = "https://us.diablo3.com/en-us/item/...";
            this.urlBox.ForeColor = Color.DimGray;
        }
        public void resize()
        {
            this.tableLayoutPanel1.ColumnStyles[3].Width = 0;
            this.tableLayoutPanel1.RowStyles[0].Height = 0;
            this.tableLayoutPanel1.RowStyles[1].Height = 0;
            this.button1.Visible = false;
            this.label5.Visible = false;
            this.label6.Visible = false;
            this.label7.Visible = false;
            this.hashBox.Visible = false;
            this.GBIDOutput.Visible = false;
            this.button2.Visible = false;
            this.stringname.Visible = false;
            this.url.Visible = false;
            this.urlBox.Visible = false;
        }

        public void populate()
        {
            if(this.embeded)
            {
                this.TVList.Visible = false;
                this.searchBox.Visible = false;
                this.newButton.Visible = false;
                this.deleteButton.Visible = false;

                this.gbidBox.Value = Convert.ToDecimal(selected.GBID);
                this.nameBox.Text = selected.Name;
                this.categoryBox.Text = selected.Category;
                this.descriptionBox.Text = selected.Details.Replace("#", Environment.NewLine).Replace("$", Environment.NewLine);
                this.gbidBox.ReadOnly = true;
                this.gbidBox.Enabled = false;
                return;
            }
            this.TVList.Nodes.Clear();
            foreach (gbid id in this.GBIDList)
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
            this.TVList.Sort();
        }

        private void TVList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                TreeNode node = (TreeNode)e.Node;
                gbid entry = (gbid)node.Tag;
                this.gbidBox.Value = Convert.ToDecimal(entry.GBID);
                this.nameBox.Text = entry.Name;
                this.categoryBox.Text = entry.Category;
                this.descriptionBox.Text = entry.Details.Replace("#", Environment.NewLine).Replace("$", Environment.NewLine);
                this.selected = entry;
            }
            catch { }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                gbid temp = new gbid(
                    Convert.ToInt32(this.gbidBox.Value),
                    this.nameBox.Text,
                    this.categoryBox.Text,
                    "Console",
                    this.descriptionBox.Text.Replace(Environment.NewLine, "$").Replace("\r\n", "$").Replace("\n", "$")
                );
                int i = this.GBIDList.IndexOf(this.selected);
                this.GBIDList[i] = temp;
                this.selected = temp;
                //this.GBIDList.First(x => x == this.selected).GBID = Convert.ToInt32(this.gbidBox.Value);
                //this.GBIDList.First(x => x == this.selected).Name = this.nameBox.Text;
                //this.GBIDList.First(x => x == this.selected).Category = this.categoryBox.Text;
                //string desc = this.descriptionBox.Text.Replace(Environment.NewLine, "$").Replace("\r\n", "$").Replace("\n", "$");
                //this.GBIDList.First(x => x == this.selected).Details = desc;
                    
                //this.populate();
                this.UpdateFile();
                if (this.mParent != null)
                    this.mParent.parent.showToolTip("Successfully saved GBID entry!");
            }
            catch
            {
                if (!this.embeded)
                    return;
                newButton_Click(sender, e);
            }
            if(this.embeded)
            {
                //this.parent.parent.refreshList();
                this.parent.Close();
            }
        }

        public void UpdateFile()
        {
            using (StreamWriter newTask = new StreamWriter(Application.StartupPath + "\\GBID_List.txt", false))
            {
                foreach(gbid id in this.GBIDList)
                {
                    newTask.WriteLine(id.GBID.ToString() + "\t=\t" + id.Name + "\t=\t" + id.Category + "\t=\tConsole\t=\t" + id.Details);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selected == null)
                return;
            gbid temp = this.GBIDList.First(x => x == this.selected);
            this.GBIDList.Remove(temp);
            UpdateFile();
            //this.populate();
            this.selected = null;
            this.gbidBox.Value = 0;
            this.nameBox.Text = "";
            this.categoryBox.Text = "";
            this.descriptionBox.Text = "";
            if (this.mParent != null)
                this.mParent.parent.showToolTip("Successfully removed GBID entry!");
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            gbid temp = new gbid(
                Convert.ToInt32(this.gbidBox.Value), 
                this.nameBox.Text, 
                this.categoryBox.Text, 
                "Console", 
                this.descriptionBox.Text.Replace(Environment.NewLine, "$").Replace("\r\n", "$").Replace("\n", "$")
            );
            this.GBIDList.Add(temp);
            UpdateFile();
            this.selected = temp;
            //populate();
            if (this.mParent != null)
                this.mParent.parent.showToolTip("Successfully added GBID entry!");
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
            foreach (gbid id in this.GBIDList)
            {
                if (id.Name.ToLower().Contains(search.ToLower()) || id.Category.ToLower() == search.ToLower())
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

        private void TVList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            try
            {
                TreeNode node = TVList.SelectedNode;
                gbid entry = (gbid)node.Tag;
                this.gbidBox.Value = Convert.ToDecimal(entry.GBID);
                this.nameBox.Text = entry.Name;
                this.categoryBox.Text = entry.Category;
                this.descriptionBox.Text = entry.Details.Replace("#", Environment.NewLine).Replace("$", Environment.NewLine);
                this.selected = entry;
            }
            catch { }
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
                foreach (gbid id in this.GBIDList)
                {
                    if (id.Name.ToLower().Contains(search.ToLower()) || id.Category.ToLower() == search.ToLower())
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
                this.TVList.Sort();
                this.searchBox.Focus();
                return;
            }

            populate();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if(this.stringname.Checked)
            {
                if (this.hashBox.Text != "" && this.hashBox.Text != "String name...")
                {
                    this.GBIDOutput.Text = this.gbid(this.hashBox.Text).ToString();
                }
            }
            else
            {
                if(this.urlBox.Text != "" && this.urlBox.Text != "https://us.diablo3.com/en-us/item/...")
                {
                    string sn = this.urlBox.Text.Split('-').Last();
                    this.GBIDOutput.Text = this.gbid(sn).ToString();
                }
            }
        }

        public void RemoveTextX(object sender, EventArgs e)
        {
            if (this.urlBox.Text == "https://us.diablo3.com/en-us/item/...")
            {
                this.urlBox.Text = "";
                this.urlBox.ForeColor = Color.Black;
            }
        }

        public void AddTextX(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.urlBox.Text))
            {
                this.urlBox.Text = "https://us.diablo3.com/en-us/item/...";
                this.urlBox.ForeColor = Color.DimGray;
            }
        }

        public int gbid(string input)
        {
            input = input.ToLower();
            int hash = 0;
            for (int i = 0; i < input.Length; i++)
            {
                hash = (hash << 5) + hash + (int)input[i];
            }
            return hash;
        }

        private void GBIDOutput_Click(object sender, EventArgs e)
        {
            if(this.GBIDOutput.Text != "")
                this.GBIDOutput.SelectAll();
        }

        private void stringname_CheckedChanged(object sender, EventArgs e)
        {
            if(this.stringname.Checked)
            {
                this.hashBox.Enabled = true;
                this.urlBox.Enabled = false;
            }
            else
            {
                this.hashBox.Enabled = false;
                this.urlBox.Enabled = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = this.linkLabel1.Text;
            var si = new ProcessStartInfo(url);
            Process.Start(si);
        }
    }
}
