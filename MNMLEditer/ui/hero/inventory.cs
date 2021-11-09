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
using TonicBox.Data;
using D3Studio.ui;
using PB.GameBalance;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using D3Studio;
using System.Runtime.InteropServices;
using System.Web.Script.Serialization;
using DGI;
using System.Text.RegularExpressions;
using PB.OnlineService;

namespace D3Studio.ui.hero
{
    public partial class inventory : UserControl
    {
        public PB.Hero.SavedDefinition HeroFile { get; set; }
        public PB.Account.SavedDefinition AccountFile { get; set; }

        public PB.Account.SavedDefinition RolloverFile { get; set; }

        public heroBase hParent = new heroBase();

        public PB.Items.ItemList Locker { get; set; }

        public List<PB.Items.SavedItem> items = new List<PB.Items.SavedItem>();
        private ImageList list = new ImageList();
        public List<gbid> GBIDList = new List<gbid>();
        public List<affix> AffixList = new List<affix>();
        public List<sno> SNOList = new List<sno>();
        public bool embedding = false;
        public bool isIDX = false;
        public int partition;
        private ListViewItem copyItem;
        private bool searching = false;
        private bool loaded = false;
        private int inv_c = 0;
        public string file = "";
        private ErrorLog Log = new ErrorLog(Application.StartupPath + "\\bin\\ErrorLog.txt");

        public bool isRollover = false;

        public D3Studio.MainFrame parent { get; set; }

        public PB.Items.SavedItem SNO_Name
        {
            get
            {
                return SNO_Name;
            }
            set
            {
                if (loaded)
                {
                    items.First(x => x.id.id_low == value.id.id_low &&
                       x.generator.gb_handle.gbid == value.generator.gb_handle.gbid).generator = value.generator;
                    this.refreshList();
                }
            }
        }


        public inventory()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.list.Images.Add(new Bitmap(typeof(Button), "Button.bmp"));
            invList.SmallImageList = list;
            invList.Columns[0].Width = -1;
            ColumnHeader header = new ColumnHeader();
            invList.Columns.Clear();
            header.Text = "";
            header.Name = "MyColumn1";
            header.Width = invList.Width * 2; //Same Width as Entire List Control
            invList.Columns.Add(header);
        }

        public void populate()
        {
            this.SaveLockertoolStripMenuItem.Visible = false;
            if(this.RolloverFile != null)
            {
                foreach(PB.Account.SeasonalRolloverItem itm in this.RolloverFile.partitions[this.partition].console_partition_data.seasonal_rollover_item)
                {
                    this.items.Add(itm.item);
                }
            }
            else if (this.HeroFile != null)
            {
                if (HeroFile.items == null)
                    HeroFile.items = new PB.Items.ItemList();
                if (HeroFile.items.items == null)
                    HeroFile.items.items = new List<PB.Items.SavedItem>();
                this.items = HeroFile.items.items;
            }
            else if (this.AccountFile != null)
            {
                if (AccountFile.partitions[partition].items == null)
                    AccountFile.partitions[partition].items = new PB.Items.ItemList();
                if (AccountFile.partitions[partition].items.items == null)
                    AccountFile.partitions[partition].items.items = new List<PB.Items.SavedItem>();
                this.items = AccountFile.partitions[partition].items.items;
            }
            else if (this.Locker != null)
            {
                this.items = Locker.items;
                this.SaveLockertoolStripMenuItem.Visible = true;
                this.lockerToolStripMenuItem.Visible = false;
            }
            refreshList();
            //main
            this.listControl.SuspendLayout();
            this.listControl.GBIDList = this.GBIDList;
            this.listControl.AffixList = this.AffixList;
            this.listControl.SNOList = this.SNOList;
            this.listControl.items = this.items;
            this.listControl.parrent = this;
            this.listControl.ResumeLayout();
            //rare name
            this.rareName1.SuspendLayout();
            this.rareName1.items = this.items;
            this.rareName1.SNOList = this.SNOList;
            this.rareName1.parrent = this;
            this.rareName1.AddSNOTreeView();
            this.rareName1.ResumeLayout();
            //properties
            this.properties1.SuspendLayout();
            this.properties1.GBIDList = this.GBIDList;
            this.properties1.AffixList = this.AffixList;
            this.properties1.items = this.items;
            this.properties1.parrent = this;
            this.properties1.ResumeLayout();
        }

        private void setRolloverItems()
        {
            return;
            if (this.RolloverFile == null)
                return;
            this.RolloverFile.partitions[this.partition].console_partition_data.seasonal_rollover_item.Clear();
            foreach (PB.Items.SavedItem itm in this.items)
            {
                //if (itm.item_slot != 1024)
                //    itm.item_slot = 544;
                itm.generator.season_id = (Settings.CurrentSeason -1);
                PB.Account.SeasonalRolloverItem sri = new PB.Account.SeasonalRolloverItem()
                {
                    create_time = 1597179413,
                    item = itm
                };
                this.RolloverFile.partitions[this.partition].console_partition_data.seasonal_rollover_item.Add(sri);
            }
        }

        private string GetRareName(PB.Items.RareItemName itm)
        {
            try
            {
                string str = "[" + this.SNOList.Where(x => (x.Sno_Affix_String_List == itm.sno_affix_string_list &&
                                x.Affix_String_List_Index == itm.affix_string_list_index)).FirstOrDefault().Name + "] ";
                if (str == "[No Prefix] ")
                    return "";
                return str;
            }
            catch
            {
                if(Settings.Admin)
                {
                    //if (itm.sno_affix_string_list > 1 && itm.sno_affix_string_list.ToString() != "")
                        //return "[" + itm.sno_affix_string_list.ToString() + "] ";
                }
                return "";
            }

        }

        public void refreshList()
        {
            this.invList.Items.Clear();
            int c = 0;
            //Erm, hacky fix for weird fkn bug that Im honestly to tired to deal with legitimitly
            this.invList.Items.Add("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
            foreach (ListViewItem item in invList.Items)
            {
                if (item.Text == "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx")
                {
                    item.Remove();
                }
            }
            int indent = 0;
            bool MI = false;
            //this.items = this.sortItems(this.items);
            for (int i = 0; i < this.items.Count; i++)
            {
                try
                {
                    ListViewItem item = new ListViewItem();
                    string s = ""; //(" + i.ToString() + ") ";
                    string str = s + GetRareName(items[i].generator.rare_item_name);
                    if(this.items[i].custom_name != null && this.items[i].custom_name != "")
                    {
                        item.Text = str + items[i].custom_name;
                    }
                    else
                    {
                        if (this.items[i].generator.gb_handle.gbid == 0)
                            item.Text = str + "None";
                        else if (helper.FindGBID(this.items[i].generator.gb_handle.gbid.ToString(), 0, this.GBIDList) != null)
                            item.Text = str + helper.FindGBID(this.items[i].generator.gb_handle.gbid.ToString(), 0, this.GBIDList).Name;
                        else
                            item.Text = str + this.items[i].generator.gb_handle.gbid.ToString();
                    }
                    if(this.items[i].generator.enchanted_affix != null && this.items[i].generator.enchanted_affix != 0 && this.items[i].generator.enchanted_affix != -1)
                    {
                        if (this.items[i].generator.enchanted_count < 1)
                            this.items[i].generator.enchanted_count = 3;
                        if(this.items[i].generator.enchant_seed == null || this.items[i].generator.enchant_seed == 0U)
                            this.items[i].generator.enchant_seed = RandCalc.Rnd32();
                    }
                    item.Tag = this.items[i];
                    item.Name = this.items[i].generator.gb_handle.gbid.ToString();
                    item.ToolTipText = this.items[i].id.id_low.ToString();
                    item.ForeColor = IL.RarityColor(this.items[i].generator.item_quality_level);
                    if (this.items[i].socket_id != null)
                    {
                        //item.IndentCount = 1;
                        try
                        {
                            if (items[i].generator.contents != null && items[i].generator.contents.Count() > 0)
                            {
                                MI = true;
                            }
                            else
                            {
                                MI = false;
                                indent = 1;
                            }
                            //item.Group = filterGroup(items.Single(x => x.id.id_low == items[i].socket_id.id_low).item_slot);
                            item.Group = filterGroup(items[i].item_slot, this.items[i].hireling_class);
                            foreach (PB.Items.SavedItem itm in this.items)
                            {
                                if (itm.generator.contents != null && itm.generator.contents.Count() > 0)
                                {
                                    foreach (PB.Items.EmbeddedGenerator emb in itm.generator.contents)
                                    {
                                        if (emb.id.id_low == items[i].id.id_low && emb.generator.gb_handle.gbid == items[i].generator.gb_handle.gbid &&
                                            itm.id.id_low == items[i].socket_id.id_low)
                                        {
                                            item.Group = filterGroup(itm.item_slot, itm.hireling_class);
                                            break;
                                        }
                                    }
                                }
                            }
                            item.IndentCount = 1;
                        }
                        catch (Exception e)
                        {
                            //MessageBox.Show(e.ToString());
                            item.Group = filterGroup(this.items[i].item_slot, this.items[i].hireling_class);
                        }
                    }
                    else
                    {
                        item.Group = filterGroup(this.items[i].item_slot, this.items[i].hireling_class);
                    }
                    if (this.HeroFile != null)
                    {
                        if (this.items[i].item_slot == 272)
                            c = c + 1;
                    }
                    else if (this.AccountFile != null || this.RolloverFile != null)
                    {
                        if (this.items[i].item_slot == 544)
                            c = c + 1;
                    }
                    if(this.RolloverFile != null)
                        this.items[i].generator.season_id = (Settings.CurrentSeason -1);

                    this.invList.Items.Add(item);
                }
                catch { }
            }
            if (this.invList.Items.Count == 0 && false)
            {
                PB.Items.SavedItem newItem = new PB.Items.SavedItem();
                newItem.id = new PB.OnlineService.ItemId();
                if (this.HeroFile != null)
                    newItem.item_slot = 272;
                else
                    newItem.item_slot = 544;
                newItem.square_index = this.nextSquareIndex(272);
                newItem.id.id_high = 1UL;
                List<uint> ignore = new List<uint>();
                foreach (PB.Items.SavedItem items in items)
                    ignore.Add((uint)items.id.id_low);
                newItem.id.id_low = RandCalc.Rnd32(ignore);
                //newItem.id.id_low = (ulong)RandCalc.Rand.Next(2011166548, 2020212897);
                newItem.generator = new PB.Items.Generator();
                newItem.generator.flags = 265U;
                newItem.generator.seed = RandCalc.Rnd32();
                newItem.generator.gb_handle = new Handle();
                newItem.generator.gb_handle.game_balance_type = 2;
                newItem.generator.gb_handle.gbid = 0;
                this.items.Add(newItem);
                this.refreshList();
                if (this.HeroFile != null)
                    this.HeroFile.items.items = this.items;
                else if (this.AccountFile != null)
                    AccountFile.partitions[partition].items.items = this.items;
                else if (this.Locker != null)
                    Locker.items = this.items;
            }
            if (this.HeroFile != null)
                this.invCount.Text = "(" + c.ToString() + "/60)";
            else if (this.AccountFile != null)
            {
                //-4096
                string max = "?";
                if (this.AccountFile.partitions[this.partition].saved_attributes.attributes.Any(item => item.key == -4096))
                {
                    max = this.AccountFile.partitions[this.partition].saved_attributes.attributes.First(item => item.key == -4096).value.ToString();
                }
                this.invCount.Text = "(" + c.ToString() + "/" + max + ")";
            }
            else if (this.Locker != null || this.RolloverFile != null)
                this.invCount.Text = "";
        }

        private List<PB.Items.SavedItem> sortItems(List<PB.Items.SavedItem> oItems)
        {
            //return oItems;
            List<PB.Items.SavedItem> invList = new List<PB.Items.SavedItem>();
            List<PB.Items.SavedItem> eqpList = new List<PB.Items.SavedItem>();
            List<PB.Items.SavedItem> sctList = new List<PB.Items.SavedItem>();
            List<PB.Items.SavedItem> outSctList = new List<PB.Items.SavedItem>();
            List<PB.Items.SavedItem> outList = new List<PB.Items.SavedItem>();
            int[] EquipmentOrder = new int[]
            {
                288,
                304,
                320,
                336,
                352,
                368,
                384,
                400,
                416,
                432,
                448,
                464,
                480
            };
            foreach(PB.Items.SavedItem i in oItems)
            {
                if(EquipmentOrder.Contains(i.item_slot))
                {
                    invList.Add(i);

                }
                else if(i.item_slot == 1024)
                {
                    sctList.Add(i);
                }
                else
                {
                    invList.Add(i);
                }
            }
            invList = invList.OrderBy(x => Array.IndexOf(EquipmentOrder, x.item_slot)).ToList();

            //int index = this.items.IndexOf(destination) + 1;
            //this.items = this.InsertTo(newItem, index, this.items);
            foreach(PB.Items.SavedItem i in sctList)
            {
                try
                {
                    PB.Items.SavedItem dest = eqpList.First(x => x.id.id_low == i.socket_id.id_low);
                    int index = eqpList.IndexOf(dest) + 1;
                    eqpList = this.InsertTo(i, index, eqpList);
                }
                catch(Exception ex)
                {
                    try
                    {
                        PB.Items.SavedItem dest = invList.First(x => x.id.id_low == i.socket_id.id_low);
                        int index = invList.IndexOf(dest) + 1;
                        invList = this.InsertTo(i, index, invList);
                    }
                    catch
                    {
                        MessageBox.Show(ex.Message + " | " + i.item_slot.ToString());
                        outSctList.Add(i);
                    }
                }
            }

            outList.AddRange(invList);
            outList.AddRange(eqpList);
            outList.AddRange(outSctList);

            return outList;
        }

        public void UpdateName(string n)
        {
            if (invList.SelectedItems.Count < 1)
                return;
            string s = this.invList.SelectedItems[0].Text;
            string str = "";
            if (n == "")
            {
                ListViewItem item = this.invList.SelectedItems[0];
                PB.Items.SavedItem z = (PB.Items.SavedItem)item.Tag;
                PB.Items.SavedItem itm = items.First(x => x == z);
                foreach (PB.Items.SavedItem i in this.items)
                {
                    if (i.generator.contents != null)
                    {
                        foreach (PB.Items.EmbeddedGenerator emb in i.generator.contents)
                        {
                            if (emb.id.id_low == z.id.id_low)
                            {
                                emb.generator = z.generator.DeepClone<PB.Items.Generator>();
                                emb.generator.rare_item_name = z.generator.rare_item_name.DeepClone<PB.Items.RareItemName>();
                            }
                        }
                    }
                }
                if (s.Contains("]"))
                    str = (s.Split(']'))[0] + "] ";
                if (itm.generator.gb_handle.gbid == 0)
                    item.Text = str + "None";
                else if (helper.FindGBID(itm.generator.gb_handle.gbid.ToString(), 0, this.GBIDList) != null)
                    item.Text = str + helper.FindGBID(itm.generator.gb_handle.gbid.ToString(), 0, this.GBIDList).Name;
                else
                    item.Text = str + itm.generator.gb_handle.gbid.ToString();
                return;
            }
            if (s.Contains("]"))
                str = (s.Split(']'))[0] + "] ";
            this.invList.SelectedItems[0].Text = str + n;
        }

        private ListViewGroup filterGroup(int slot, int hireling)
        {
            if (slot == 272)
                return invList.Groups["Inventory"];
            else if (slot == 288)
                return invList.Groups["Head"];
            else if (slot == 304)
                return invList.Groups["Chest"];
            else if (slot == 320)
                return invList.Groups["Off_Hand"];
            else if (slot == 336)
                return invList.Groups["Main_Hand"];
            else if (slot == 352)
                return invList.Groups["Gloves"];
            else if (slot == 368)
                return invList.Groups["Belt"];
            else if (slot == 384)
                return invList.Groups["Boots"];
            else if (slot == 400)
                return invList.Groups["Shoulders"];
            else if (slot == 416)
                return invList.Groups["Pants"];
            else if (slot == 432)
                return invList.Groups["Wrist"];
            else if (slot == 448)
                return invList.Groups["Ring_2"];
            else if (slot == 464)
                return invList.Groups["Ring_1"];
            else if (slot == 480)
                return invList.Groups["Necklace"];
            else if (slot == 544)
                return invList.Groups["Stash"];
            else if (slot == 560)
                return invList.Groups["gold"];
            else if (slot == 1024)
                return invList.Groups["Socket"];
            else if (slot == 1296)
                return invList.Groups[folowerSlots(hireling, slot)];
            else if (slot == 1312)
                return invList.Groups[folowerSlots(hireling, slot)];
            else if (slot == 1328)
                return invList.Groups[folowerSlots(hireling, slot)];
            else if (slot == 1344)
                return invList.Groups[folowerSlots(hireling, slot)];
            else if (slot == 1360)
                return invList.Groups[folowerSlots(hireling, slot)];
            else if (slot == 1376)
                return invList.Groups[folowerSlots(hireling, slot)];
            else
                return invList.Groups["Other"];
        }

        public string folowerSlots(int hireling, int slot)
        {
            if (hireling == 0)
            {
                if (slot == 1296)
                    return "Follower_Off_Hand";
                else if (slot == 1312)
                    return "Follower_Main_Hand";
                else if (slot == 1328)
                    return "Follower_Relic";
                else if (slot == 1344)
                    return "Follower_Necklace";
                else if (slot == 1360)
                    return "Follower_Ring1";
                else if (slot == 1376)
                    return "Follower_Ring2";
            }
            else if (hireling == 1)
            {
                if (slot == 1296)
                    return "Templar_Off_Hand";
                else if (slot == 1312)
                    return "Templar_Main_Hand";
                else if (slot == 1328)
                    return "Templar_Relic";
                else if (slot == 1344)
                    return "Templar_Necklace";
                else if (slot == 1360)
                    return "Templar_Ring1";
                else if (slot == 1376)
                    return "Templar_Ring2";
            }
            else if (hireling == 2)
            {
                if (slot == 1296)
                    return "Scoundrel_Off_Hand";
                else if (slot == 1312)
                    return "Scoundrel_Main_Hand";
                else if (slot == 1328)
                    return "Scoundrel_Relic";
                else if (slot == 1344)
                    return "Scoundrel_Necklace";
                else if (slot == 1360)
                    return "Scoundrel_Ring1";
                else if (slot == 1376)
                    return "Scoundrel_Ring2";
            }
            else if (hireling == 3)
            {
                if (slot == 1296)
                    return "Enchantress_Off_Hand";
                else if (slot == 1312)
                    return "Enchantress_Main_Hand";
                else if (slot == 1328)
                    return "Enchantress_Relic";
                else if (slot == 1344)
                    return "Enchantress_Necklace";
                else if (slot == 1360)
                    return "Enchantress_Ring1";
                else if (slot == 1376)
                    return "Enchantress_Ring2";
            }
            return "Other";
        }

        public void updateItem(PB.Items.SavedItem gbid)
        {
            try
            {
                string s = ""; //(" + i.ToString() + ") ";
                string str = s + GetRareName(gbid.generator.rare_item_name);
                if(gbid.custom_name == null || gbid.custom_name == "")
                {
                    if (helper.FindGBID(gbid.generator.gb_handle.gbid.ToString(), 0, this.GBIDList) != null)
                        this.invList.SelectedItems[0].Text = str + helper.FindGBID(gbid.generator.gb_handle.gbid.ToString(), 0, this.GBIDList).Name;
                    else
                        this.invList.SelectedItems[0].Text = str + gbid.generator.gb_handle.gbid.ToString();
                }
                this.invList.SelectedItems[0].Name = gbid.generator.gb_handle.gbid.ToString();
                this.invList.SelectedItems[0].ToolTipText = gbid.id.id_low.ToString();
                this.invList.SelectedItems[0].ForeColor = IL.RarityColor(gbid.generator.item_quality_level);
                if (this.HeroFile != null)
                    this.HeroFile.items.items = this.items;
                else if (this.AccountFile != null)
                    AccountFile.partitions[partition].items.items = this.items;
                else if (this.Locker != null)
                    Locker.items = this.items;
                setRolloverItems();
            }
            catch { }
        }

        private void invList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (invList.SelectedItems.Count > 1)
                return;
            if (searching)
                return;
            try
            {
                this.loaded = false;
                ListViewItem item = this.invList.SelectedItems[0];
                PB.Items.SavedItem z = (PB.Items.SavedItem)item.Tag;
                PB.Items.SavedItem itm = items.First(x => x == z); //items.First(x => x.id.id_low == Convert.ToUInt64(item.ToolTipText) && x.generator.gb_handle.gbid.ToString() == item.Name);
                //main
                this.listControl.item = itm;
                this.listControl.items = this.items;
                this.listControl.populate();
                //properties
                this.properties1.loaded = false;
                this.properties1.items = this.items;
                this.properties1.item = itm;
                this.properties1.populate();

                //rare name
                this.rareName1.item = itm;
                this.rareName1.items = this.items;
                this.rareName1.populate();

                //raw
                this.rawTab1.Item = itm;
                this.rawTab1.setData(4);
                this.loaded = true;
            }
            catch (Exception err)
            {
                //AllErrorCatch
                //MessageBox.Show(err.ToString());
                if(Regex.Replace(err.Message, @"\t|\n|\r", "") != "InvalidArgument=Value of '0' is not valid for 'index'.Parameter name: index")
                    Log.AddLog("inventory", err.Message);
            }
        }

        private void newItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PB.Items.SavedItem newItem = new PB.Items.SavedItem();
            newItem.id = new PB.OnlineService.ItemId();
            if (this.HeroFile != null)
            {
                newItem.item_slot = 272;
                newItem.square_index = this.nextSquareIndex(272);
            }
            else
            {
                newItem.item_slot = 544;
                newItem.square_index = this.nextSquareIndex(544);
            }
            newItem.id.id_high = 1UL;
            List<uint> ignore = new List<uint>();
            foreach (PB.Items.SavedItem items in items)
                ignore.Add((uint)items.id.id_low);
            newItem.id.id_low = RandCalc.Rnd32(ignore);
            //newItem.id.id_low = (ulong)RandCalc.Rand.Next(2011166548, 2020212897);
            newItem.generator = new PB.Items.Generator();
            newItem.generator.flags = 265U;
            newItem.generator.seed = RandCalc.Rnd32();
            newItem.generator.gb_handle = new Handle();
            newItem.generator.gb_handle.game_balance_type = 2;
            newItem.generator.gb_handle.gbid = 0;
            this.items.Add(newItem);
            this.refreshList();
            if (this.HeroFile != null)
                this.HeroFile.items.items = this.items;
            else if (this.AccountFile != null)
                AccountFile.partitions[partition].items.items = this.items;
            else if (this.Locker != null)
                Locker.items = this.items;
            setRolloverItems();
        }

        private int nextSquareIndex(int slot, ItemId SID = null)
        {
            int temp = 0;
            bool z = true;
            foreach (PB.Items.SavedItem item in items)
            {
                if (item.item_slot == slot)
                {
                    if(item.item_slot == 1024 && SID != null)
                    {
                        if(item.socket_id.id_low == SID.id_low)
                        {
                            if (item.square_index >= temp)
                                temp = item.square_index + 1;
                        }
                    }
                    else
                    {
                        if (item.square_index >= temp)
                            temp = item.square_index + 1;
                    }
                    /*if (z || item.square_index != 0)
                        temp = temp + 1;
                    if (item.square_index == 0)
                        z = false;*/
                }
            }
            return temp;
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (invList.SelectedIndices.Count <= 0)
                return;
            try
            {
                ListViewItem item = this.invList.SelectedItems[0];
                int index = this.invList.Items.IndexOf(this.invList.SelectedItems[0]);
                PB.Items.SavedItem newItem = items.First(x => x.id.id_low == Convert.ToUInt64(item.ToolTipText) && x.generator.gb_handle.gbid.ToString() == item.Name).DeepClone<PB.Items.SavedItem>();
                int sid = items.First(x => x.id.id_low == Convert.ToUInt64(item.ToolTipText) && x.generator.gb_handle.gbid.ToString() == item.Name).item_slot;
                if (this.HeroFile != null || this.Locker != null)
                {
                    newItem.item_slot = 272;
                    newItem.square_index = this.nextSquareIndex(272);
                }
                else
                {
                    newItem.item_slot = 544;
                    newItem.square_index = this.nextSquareIndex(544);
                }
                newItem.socket_id = null;
                List<uint> ignore = new List<uint>();
                foreach (PB.Items.SavedItem items in items)
                    ignore.Add((uint)items.id.id_low);
                newItem.id.id_low = RandCalc.Rnd32(ignore);
                newItem.generator.seed = (uint)RandCalc.Rand.Next(311113795, 1311118655);
                this.invList.BeginUpdate();
                this.items.Add(newItem);
                if (newItem.generator.contents != null && newItem.generator.contents.Count() != 0)
                {
                    try
                    {
                        foreach (PB.Items.EmbeddedGenerator emb in newItem.generator.contents)
                        {
                            ulong id = emb.id.id_low;
                            int gb = emb.generator.gb_handle.gbid;
                            this.embedding = true;
                            try
                            {
                                PB.Items.SavedItem newSubItem = items.First(x => x.id.id_low == id && x.generator.gb_handle.gbid == gb).DeepClone<PB.Items.SavedItem>();
                                newSubItem.item_slot = 272;
                                newSubItem.used_socket_count = 0;
                                newSubItem.socket_id = newItem.id.DeepClone<PB.OnlineService.ItemId>();
                                ignore = new List<uint>();
                                foreach (PB.Items.SavedItem items in items)
                                    ignore.Add((uint)items.id.id_low);
                                newSubItem.id.id_low = RandCalc.Rnd32(ignore);
                                emb.id = new ItemId();//newSubItem.id.DeepClone<PB.OnlineService.ItemId>();
                                emb.id.id_low = newSubItem.id.id_low;
                                emb.id.id_high = newSubItem.id.id_high;
                                newSubItem.generator.seed = (uint)RandCalc.Rand.Next(311113795, 1311118655);
                                if (newSubItem.generator.contents != null)
                                {
                                    newSubItem.generator.contents.Clear();
                                }
                                this.items.Add(newSubItem);
                            }
                            catch { }
                            this.embedding = false;
                        }
                    }
                    catch { }
                }
                this.refreshList();
                this.invList.EndUpdate();
                if (this.HeroFile != null)
                    this.HeroFile.items.items = this.items;
                else if (this.AccountFile != null)
                    AccountFile.partitions[partition].items.items = this.items;
                else if (this.Locker != null)
                    Locker.items = this.items;
                setRolloverItems();
                this.invList.Items[index].Selected = true;
                this.invList.Select();
                this.invList.Items[index].EnsureVisible();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (invList.SelectedIndices.Count <= 0)
                    return;
                foreach (ListViewItem item in this.invList.SelectedItems)
                {
                    PB.Items.SavedItem z = (PB.Items.SavedItem)item.Tag;
                    PB.Items.SavedItem rem = items.First(x => x == z);
                    ulong id = rem.id.id_low;
                    foreach (PB.Items.SavedItem i in items)
                    {
                        if (i.generator.contents != null)
                        {
                            List<PB.Items.EmbeddedGenerator> temp = new List<PB.Items.EmbeddedGenerator>();
                            foreach (PB.Items.EmbeddedGenerator emb in i.generator.contents)
                            {
                                if (emb.id.id_low == id && emb.generator.gb_handle.gbid == rem.generator.gb_handle.gbid && i.id.id_low == rem.socket_id.id_low)
                                {
                                    emb.id.id_low = 0;
                                    i.used_socket_count = (uint)i.generator.contents.Count() - 1;
                                }
                            }
                            i.generator.contents = i.generator.contents.Where(x => x.id.id_low != 0).ToList();
                        }
                    }
                    items.Remove(rem);
                }
                if (this.HeroFile != null)
                    this.HeroFile.items.items = this.items;
                else if (this.AccountFile != null)
                    AccountFile.partitions[partition].items.items = this.items;
                else if (this.Locker != null)
                    Locker.items = this.items;
                setRolloverItems();
                this.invList.BeginUpdate();
                this.refreshList();
                this.invList.EndUpdate();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (invList.SelectedIndices.Count <= 0)
                return;
            this.copyItem = this.invList.SelectedItems[0];
            //COPYITEM|{FILENAME}|{id.id_low}|{GBID}
            Clipboard.SetText("COPYITEM|" + this.file + "|" + this.copyItem.ToolTipText + "|" + this.copyItem.Name);
            /*PB.Items.SavedItem origonal = items.First(x => x.id.id_low == Convert.ToUInt64(this.copyItem.ToolTipText) && x.generator.gb_handle.gbid.ToString() == this.copyItem.Name);
            var json = new JavaScriptSerializer().Serialize(origonal);
            Clipboard.SetText("InvITEM:::" + json);*/
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string[] sep = new string[1] { "|" };
                string[] clip = Clipboard.GetText().Split(sep, StringSplitOptions.None);
                if (clip[0] != null && this.file != clip[1] && clip[0] == "COPYITEM")
                {
                    try
                    {
                        int ind = this.invList.Items.IndexOf(this.invList.SelectedItems[0]);
                        this.PasteItemFromClipBoard(clip);
                        this.invList.Items[ind].Selected = true;
                        this.invList.Select();
                        this.invList.Items[ind].EnsureVisible();
                    }
                    catch { }
                    return;
                }
                if (this.copyItem == null || invList.SelectedIndices.Count <= 0)
                    return;
                int inx = this.invList.Items.IndexOf(this.invList.SelectedItems[0]);
                ListViewItem item = this.invList.SelectedItems[0];
                PB.Items.SavedItem origonal = items.First(x => x.id.id_low == Convert.ToUInt64(this.copyItem.ToolTipText) && x.generator.gb_handle.gbid.ToString() == this.copyItem.Name);
                PB.Items.SavedItem destination = items.First(x => x.id.id_low == Convert.ToUInt64(item.ToolTipText) && x.generator.gb_handle.gbid.ToString() == item.Name);
                List<PB.Items.EmbeddedGenerator> oEmb = new List<PB.Items.EmbeddedGenerator>();
                if (destination.generator.contents != null)
                    oEmb = destination.generator.contents.DeepClone();
                destination.generator = origonal.generator.DeepClone<PB.Items.Generator>();
                destination.generator.contents = oEmb;
                foreach (PB.Items.SavedItem i in this.items)
                {
                    if (i.generator.contents != null)
                    {
                        foreach (PB.Items.EmbeddedGenerator emb in i.generator.contents)
                        {
                            if (emb.id.id_low == destination.id.id_low)
                            {
                                emb.generator = destination.generator.DeepClone<PB.Items.Generator>();
                            }
                        }
                    }
                }
                this.invList.BeginUpdate();
                this.refreshList();
                this.invList.EndUpdate();
                if (this.HeroFile != null)
                    this.HeroFile.items.items = this.items;
                else if (this.AccountFile != null)
                    AccountFile.partitions[partition].items.items = this.items;
                else if (this.Locker != null)
                    Locker.items = this.items;
                setRolloverItems();
                this.invList.Items[inx].Selected = true;
                this.invList.Select();
                this.invList.Items[inx].EnsureVisible();
            }
            catch { }
        }

        private void PasteItemFromClipBoard(string[] clip)
        {
            //COPYITEM|{FILENAME}|{id.id_low}|{GBID}
            List<PB.Items.SavedItem> external = new List<PB.Items.SavedItem>();
            if (clip[1] == Application.StartupPath + "\\bin\\locker.pb")
            {
                Stream source = TonicBox.Data.XorMagic.Savedecryptfile(Application.StartupPath + "\\bin\\locker.pb");
                external = (ProtoBuf.Serializer.Deserialize<PB.Items.ItemList>(source)).items;
                source.Close();
            }
            else
            {
                Stream source = TonicBox.Data.XorMagic.Savedecryptfile(clip[1]);
                PB.Hero.SavedDefinition hero = ProtoBuf.Serializer.Deserialize<PB.Hero.SavedDefinition>(source);
                external = hero.items.items;
                source.Close();
            }
            ListViewItem item = this.invList.SelectedItems[0];
            PB.Items.SavedItem origonal = external.First(x => x.id.id_low == Convert.ToUInt64(clip[2]) && x.generator.gb_handle.gbid.ToString() == clip[3]);
            PB.Items.SavedItem destination = items.First(x => x.id.id_low == Convert.ToUInt64(item.ToolTipText) && x.generator.gb_handle.gbid.ToString() == item.Name);
            destination.generator = origonal.generator.DeepClone<PB.Items.Generator>();
            if (destination.generator.contents != null)
                destination.generator.contents.Clear();
            foreach (PB.Items.SavedItem i in this.items)
            {
                if (i.generator.contents != null)
                {
                    foreach (PB.Items.EmbeddedGenerator emb in i.generator.contents)
                    {
                        if (emb.id.id_low == destination.id.id_low)
                        {
                            emb.generator = destination.generator.DeepClone<PB.Items.Generator>();
                        }
                    }
                }
            }
            this.invList.BeginUpdate();
            this.refreshList();
            this.invList.EndUpdate();
            if (this.HeroFile != null)
                this.HeroFile.items.items = this.items;
            else if (this.AccountFile != null)
                AccountFile.partitions[partition].items.items = this.items;
            else if (this.Locker != null)
                Locker.items = this.items;
            setRolloverItems();
        }

        private void RemoveText(object sender, EventArgs e)
        {
            if (this.invSearchBox.Text == "Search...")
            {
                this.invSearchBox.Text = "";
                this.invSearchBox.ForeColor = Color.Black;
            }
        }

        private void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.invSearchBox.Text))
            {
                this.invSearchBox.Text = "Search...";
                this.invSearchBox.ForeColor = Color.DimGray;
            }
        }

        private void invSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.searching = true;
                this.invList.SelectedIndices.Clear();
                foreach (ListViewItem item in invList.Items)
                {
                    if (item.Text.ToLower().Contains(invSearchBox.Text.ToLower()))
                    {
                        item.Selected = true;
                    }
                }
                this.searching = false;
            }
        }

        private List<PB.Items.SavedItem> InsertTo(PB.Items.SavedItem entry, int index, List<PB.Items.SavedItem> list)
        {
            List<PB.Items.SavedItem> temp = new List<PB.Items.SavedItem>();
            int count = 0;
            bool pass = false;
            foreach (PB.Items.SavedItem i in list)
            {
                if (count == index)
                {
                    pass = true;
                    temp.Add(entry);
                }
                temp.Add(i);
                count += 1;
            }
            if (!pass)
                temp.Add(entry);
            return temp;
        }

        private void pasteToSocketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int ind = this.invList.Items.IndexOf(this.invList.SelectedItems[0]);
                string[] sep = new string[1] { "|" };
                string[] clip = Clipboard.GetText().Split(sep, StringSplitOptions.None);
                if (clip[0] != null && this.file != clip[1] && clip[0] == "COPYITEM")
                {
                    try
                    {
                        this.PasteToSocketFromClipBoard(clip);
                    }
                    catch { }
                    return;
                }
                if (this.copyItem == null || invList.SelectedIndices.Count <= 0)
                    return;
                //int index = invList.Items.IndexOf(invList.SelectedItems[0]) + 1;
                ListViewItem item = this.invList.SelectedItems[0];
                PB.Items.SavedItem destination = items.First(x => x.id.id_low == Convert.ToUInt64(item.ToolTipText) && x.generator.gb_handle.gbid.ToString() == item.Name);
                PB.Items.SavedItem origonal = items.First(x => x.id.id_low == Convert.ToUInt64(this.copyItem.ToolTipText) && x.generator.gb_handle.gbid.ToString() == this.copyItem.Name);
                int index = this.items.IndexOf(destination) + 1;
                PB.Items.EmbeddedGenerator tmp = new PB.Items.EmbeddedGenerator();
                List<uint> ignore = new List<uint>();
                foreach (PB.Items.SavedItem items in items)
                    ignore.Add((uint)items.id.id_low);
                uint new_id = RandCalc.Rnd32(ignore);
                tmp.id = origonal.id.DeepClone<PB.OnlineService.ItemId>();
                tmp.id.id_low = new_id.DeepClone<uint>();
                tmp.generator = origonal.generator.DeepClone<PB.Items.Generator>();
                PB.Items.SavedItem newItem = origonal.DeepClone<PB.Items.SavedItem>();
                newItem.square_index = 0;
                destination.generator.contents.Add(tmp);
                destination.used_socket_count = destination.used_socket_count + 1;
                newItem.id.id_low = new_id;
                newItem.socket_id = destination.id.DeepClone<PB.OnlineService.ItemId>();
                newItem.item_slot = 1024;
                //int index = this.items.IndexOf(destination) + 1;
                this.items = this.InsertTo(newItem, index, this.items);
                this.refreshList();
                if (this.HeroFile != null)
                    this.HeroFile.items.items = this.items;
                else if (this.AccountFile != null)
                    AccountFile.partitions[partition].items.items = this.items;
                else if (this.Locker != null)
                    Locker.items = this.items;
                setRolloverItems();
                this.invList.Items[ind].Selected = true;
                this.invList.Select();
                this.invList.Items[ind].EnsureVisible();
            }
            catch { }
        }

        private void PasteToSocketFromClipBoard(string[] clip)
        {
            int ind = this.invList.Items.IndexOf(this.invList.SelectedItems[0]);
            List<PB.Items.SavedItem> external = new List<PB.Items.SavedItem>();
            if (clip[1] == Application.StartupPath + "\\bin\\locker.pb")
            {
                Stream source = TonicBox.Data.XorMagic.Savedecryptfile(Application.StartupPath + "\\bin\\locker.pb");
                external = (ProtoBuf.Serializer.Deserialize<PB.Items.ItemList>(source)).items;
                source.Close();
            }
            else
            {
                Stream source = TonicBox.Data.XorMagic.Savedecryptfile(clip[1]);
                PB.Hero.SavedDefinition hero = ProtoBuf.Serializer.Deserialize<PB.Hero.SavedDefinition>(source);
                external = hero.items.items;
                source.Close();
            }
            ListViewItem item = this.invList.SelectedItems[0];
            PB.Items.SavedItem destination = items.First(x => x.id.id_low == Convert.ToUInt64(item.ToolTipText) && x.generator.gb_handle.gbid.ToString() == item.Name);
            PB.Items.SavedItem origonal = external.First(x => x.id.id_low == Convert.ToUInt64(clip[2]) && x.generator.gb_handle.gbid.ToString() == clip[3]);
            int index = this.items.IndexOf(destination) + 1;
            PB.Items.EmbeddedGenerator tmp = new PB.Items.EmbeddedGenerator();
            List<uint> ignore = new List<uint>();
            foreach (PB.Items.SavedItem items in items)
                ignore.Add((uint)items.id.id_low);
            uint new_id = RandCalc.Rnd32(ignore);
            tmp.id = origonal.id.DeepClone<PB.OnlineService.ItemId>();
            tmp.id.id_low = new_id.DeepClone<uint>();
            tmp.generator = origonal.generator.DeepClone<PB.Items.Generator>();
            destination.generator.contents.Add(tmp);
            destination.used_socket_count = destination.used_socket_count + 1;
            PB.Items.SavedItem newItem = origonal.DeepClone<PB.Items.SavedItem>();
            newItem.id.id_low = new_id;
            newItem.socket_id = destination.id.DeepClone<PB.OnlineService.ItemId>();
            newItem.item_slot = 1024;
            this.items = this.InsertTo(newItem, index, this.items);
            this.refreshList();
            if (this.HeroFile != null)
                this.HeroFile.items.items = this.items;
            else if (this.AccountFile != null)
                AccountFile.partitions[partition].items.items = this.items;
            else if (this.Locker != null)
                Locker.items = this.items;
            setRolloverItems();
            this.invList.Items[ind].Selected = true;
            this.invList.Select();
            this.invList.Items[ind].EnsureVisible();
        }

        private void editGBIDEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (invList.SelectedIndices.Count <= 0)
                return;
            ListViewItem item = this.invList.SelectedItems[0];
            gbid temp = helper.DefaultFindGBID(item.Name, 0, this.GBIDList);
            embeddedIDEGBID ide = new embeddedIDEGBID();
            ide.parent = this;
            ide.GBIDList = this.GBIDList;
            ide.selected = temp;
            ide.populate();
            ide.ShowDialog();
            this.refreshList();
        }

        private void refreshInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.refreshList();
        }

        private void SaveLockertoolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            this.parent.showToolTip("Successfully saved Locker!");
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileName = new OpenFileDialog();
                openFileName.Filter = ("Hero File|*.dat");
                openFileName.Title = "Import hero inventory";
                openFileName.DefaultExt = "dat";
                openFileName.ShowDialog();
                try
                {
                    Stream source = TonicBox.Data.XorMagic.Savedecryptfile(openFileName.FileName);
                    PB.Hero.SavedDefinition temp = ProtoBuf.Serializer.Deserialize<PB.Hero.SavedDefinition>(source);
                    PB.Items.ItemList tempItems = temp.items.DeepClone();
                    foreach (PB.Items.SavedItem itm in tempItems.items)
                    {
                        itm.square_index = nextSquareIndex(itm.item_slot, itm.socket_id);
                        this.items.Add(itm);
                    }
                    //this.items.AddRange(tempItems.items);
                    if (this.HeroFile != null)
                        this.HeroFile.items.items = this.items;
                    else if (this.AccountFile != null)
                        AccountFile.partitions[partition].items.items = this.items;
                    else if (this.Locker != null)
                        Locker.items = this.items;
                    setRolloverItems();
                    this.refreshList();
                }
                catch { }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lockerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Stream source = TonicBox.Data.XorMagic.Savedecryptfile(Application.StartupPath + "\\bin\\locker.pb");
                PB.Items.ItemList LockerFile = ProtoBuf.Serializer.Deserialize<PB.Items.ItemList>(source);
                source.Close();
                PB.Items.ItemList tempItems = LockerFile.DeepClone();
                int[] acceptableSlots = new[]
                {
                    272, 1024, 544, 560
                };
                foreach (PB.Items.SavedItem item in tempItems.items)
                {
                    if (!acceptableSlots.Contains(item.item_slot))
                        item.item_slot = 272;
                    item.square_index = nextSquareIndex(item.item_slot, item.socket_id);
                    this.items.Add(item);
                }
                //this.items.AddRange(tempItems.items);
                if (this.HeroFile != null)
                    this.HeroFile.items.items = this.items;
                else if (this.AccountFile != null)
                    AccountFile.partitions[partition].items.items = this.items;
                else if (this.Locker != null)
                    Locker.items = this.items;
                this.refreshList();
            }
            catch { }
        }

        private List<ListViewItem> GetIndices()
        {
            List<ListViewItem> temp = new List<ListViewItem>();
            foreach (ListViewItem item in this.invList.SelectedItems)
            {
                try
                {
                    ListViewItem tvi = new ListViewItem();
                    tvi.ToolTipText = item.ToolTipText;
                    tvi.Name = item.Name;
                    tvi.Text = item.Text;
                    tvi.Tag = item.Tag;
                    temp.Add(tvi);
                }
                catch { }
            }
            return temp;
        }

        private void formatItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (invList.SelectedIndices.Count <= 0)
                return;
            format fi = new format();
            fi.items = this.items;
            fi.selectedItems = this.GetIndices();
            fi.parent = this;
            fi.ShowDialog();
            if (this.HeroFile != null)
                this.HeroFile.items.items = this.items;
            else if (this.AccountFile != null)
                AccountFile.partitions[partition].items.items = this.items;
            else if (this.Locker != null)
                Locker.items = this.items;
            setRolloverItems();
        }

        private void pasteRareNameToSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string str = Clipboard.GetText();
                if (invList.SelectedIndices.Count <= 0 || (str.Split(':')[0]) != "RARENAME")
                    return;
                List<ListViewItem> selectedItems = this.GetIndices();
                foreach (ListViewItem itm in selectedItems)
                {
                    PB.Items.SavedItem z = (PB.Items.SavedItem)itm.Tag;
                    PB.Items.SavedItem item = items.First(s => s == z);
                    Random r = new Random();
                    int x = r.Next(0, 25);
                    if (item.generator.rare_item_name == null)
                        item.generator.rare_item_name = new PB.Items.RareItemName();
                    item.generator.rare_item_name.affix_string_list_index = Convert.ToInt32((str.Split(':'))[1]);
                    item.generator.rare_item_name.item_string_list_index = x;
                    item.generator.rare_item_name.sno_affix_string_list = Convert.ToInt32((str.Split(':'))[2]);
                    foreach (PB.Items.SavedItem i in this.items)
                    {
                        if (i.generator.contents != null)
                        {
                            foreach (PB.Items.EmbeddedGenerator emb in i.generator.contents)
                            {
                                if (emb.id.id_low == item.id.id_low)
                                {
                                    emb.generator = item.generator.DeepClone<PB.Items.Generator>();
                                    emb.generator.rare_item_name = item.generator.rare_item_name.DeepClone<PB.Items.RareItemName>();
                                }
                            }
                        }
                    }
                }
                rareName1.populate();
                this.refreshList();
                if (this.HeroFile != null)
                    this.HeroFile.items.items = this.items;
                else if (this.AccountFile != null)
                    AccountFile.partitions[partition].items.items = this.items;
                else if (this.Locker != null)
                    Locker.items = this.items;
                //setRolloverItems();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void addAllFromCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            floodCattegory FC = new floodCattegory();
            FC.GBIDList = this.GBIDList;
            FC.parent = this;
            FC.populate();
            FC.ShowDialog();
        }

        public void floodItems(string cat)
        {
            List<PB.Items.SavedItem> temp = new List<PB.Items.SavedItem>();
            foreach(gbid id in this.GBIDList)
            {
                if(id.Category.ToLower() == cat.ToLower())
                {
                    PB.Items.SavedItem newItem = new PB.Items.SavedItem();
                    newItem.id = new PB.OnlineService.ItemId();
                    if (this.HeroFile != null)
                    {
                        newItem.item_slot = 272;
                        newItem.square_index = this.nextSquareIndex(272);
                    }
                    else
                    {
                        newItem.item_slot = 544;
                        newItem.square_index = this.nextSquareIndex(544);
                    }
                    newItem.id.id_high = 1UL;
                    List<uint> ignore = new List<uint>();
                    foreach (PB.Items.SavedItem items in items)
                        ignore.Add((uint)items.id.id_low);
                    newItem.id.id_low = RandCalc.Rnd32(ignore);
                    newItem.generator = new PB.Items.Generator();
                    newItem.generator.flags = 265U;
                    newItem.generator.seed = RandCalc.Rnd32();
                    newItem.generator.gb_handle = new Handle();
                    newItem.generator.gb_handle.game_balance_type = 2;
                    newItem.generator.gb_handle.gbid = Convert.ToInt32(id.GBID);
                    //temp.Add(newItem);
                    this.items.Add(newItem);
                }
            }
            //this.items.AddRange(temp);
            if (this.HeroFile != null)
                this.HeroFile.items.items = this.items;
            else if (this.AccountFile != null)
                AccountFile.partitions[partition].items.items = this.items;
            else if (this.Locker != null)
                Locker.items = this.items;
            setRolloverItems();
            this.refreshList();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void importToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
