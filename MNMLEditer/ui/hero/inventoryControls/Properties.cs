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
using TonicBox.Data;
using D3Studio.lists;

namespace D3Studio.ui.hero.inventoryControls
{
    public partial class Properties : UserControl
    {
        public PB.Items.SavedItem item;

        public List<PB.Items.SavedItem> items;

        public List<gbid> GBIDList = new List<gbid>();

        public List<affix> AffixList = new List<affix>();

        private List<IL> ItemLevelSource = new List<IL>();

        public bool isFormat = false;

        public Dictionary<string, bool> changed = new Dictionary<string, bool>()
        {
            { "durability", false },
            { "maxDurability", false },
            { "itemLevel", false },
            { "legendaryLevel", false },
            { "rarity", false },
            { "rank", false },
            { "dye", false },
            { "quantity", false },
            { "bindingBox", false },
            { "bindingCB", false },
            { "numericUpDown1", false },
            { "itemSlot", false },
            { "augmentLevel", false },
            { "augmentType", false },
            { "flagNum", false },
            { "hierling", false }
        };
        /*
         * Color inactive = Color.LightGray;
            this.durability.BackColor = inactive;
            this.maxDurability.BackColor = inactive;
            this.itemLevel.BackColor = inactive;
            this.legendaryLevel.BackColor = inactive;
            this.rarity.BackColor = inactive;
            this.rank.BackColor = inactive;
            this.dye.BackColor = inactive;
            this.quantity.BackColor = inactive;
            this.bindingBox.BackColor = inactive;
            this.bindingCB.BackColor = inactive;
            this.numericUpDown1.BackColor = inactive;
            this.itemSlot.BackColor = inactive;
            this.augmentLevel.BackColor = inactive;
            this.augmentType.BackColor = inactive;
            this.flagNum.BackColor = inactive;
            */

        public inventory parrent { get; set; }

        public bool loaded = false;

        private bool update_tb = true;

        private uint _flags;

        private enum FlagPos
        {
            Identified = 0,
            Junk = 6,
            NotSalvagable = 7,
            Enchantedable = 8,
            NaturalSocket = 9,
            Ancient = 10, // 0x0000000A
            L1 = 12, // 0x0000000C
            P = 14 // 0x0000000E
        }

        public uint flags
        {
            get
            {
                bool[] arr = new bool[31];
                IEnumerable<CheckBox> checkboxes = this.flagPanel.Controls.OfType<CheckBox>();
                foreach (CheckBox checkbox in checkboxes) 
                {
                    int index = (int)Enum.Parse(typeof(FlagPos), checkbox.Tag.ToString());
                    arr[index] = checkbox.Checked;
                }
                _flags = ItemFlagList.BoolArrayToUint(arr);
                return _flags;
            }
            set
            {
                _flags = value;
                bool[] flagArray = ItemFlagList.Dec2Bin((int)value);
                IEnumerable<CheckBox> checkboxes = this.flagPanel.Controls.OfType<CheckBox>();
                foreach (CheckBox checkbox in checkboxes)
                {
                    int index = (int)Enum.Parse(typeof(FlagPos), checkbox.Tag.ToString());
                    if (flagArray.Length >= index)
                    {
                        checkbox.Checked = flagArray[index];
                    }
                }
            }
        }

        public Properties()
        {
            InitializeComponent();
        }

        public void setInactiveColors()
        {
            Color inactive = Color.LightGray;
            this.durability.BackColor = inactive;
            this.maxDurability.BackColor = inactive;
            this.itemLevel.BackColor = inactive;
            this.legendaryLevel.BackColor = inactive;
            this.rarity.BackColor = inactive;
            this.rank.BackColor = inactive;
            this.dye.BackColor = inactive;
            this.quantity.BackColor = inactive;
            this.bindingBox.BackColor = inactive;
            this.bindingCB.BackColor = inactive;
            this.numericUpDown1.BackColor = inactive;
            this.itemSlot.BackColor = inactive;
            this.augmentLevel.BackColor = inactive;
            this.augmentType.BackColor = inactive;
            this.flagNum.BackColor = inactive;
        }

        public void populate()
        {
            if(this.isFormat)
            {
                this.itemSlot.Enabled = false;
            }
            this.durability.Value = this.item.generator.durability;
            this.maxDurability.Value = this.item.generator.max_durability;
            this.itemLevel.Value = this.item.generator.item_level;
            this.legendaryLevel.Value = this.item.generator.legendary_item_level;
            AddRarity();
            this.rank.Value = this.item.generator.rank;
            LoadDye();
            this.quantity.Value = this.item.generator.stack_size;
            LoadSlots();
            LoadAugment();
            this.augmentLevel.Value = this.item.generator.augment_gem_level;
            this.flagNum.Value = this.item.generator.flags;
            this.flags = this.item.generator.flags;
            LoadBinding();
            LoadHierling();
            this.loaded = true;

        }

        public void LoadHierling()
        {
            if (this.item.hireling_class == null)
                return;
            //new ComboTreeNode("0", _rm.GetString("Profile")),
            //new ComboTreeNode("1", _rm.GetString("Templar")),
            //new ComboTreeNode("2", _rm.GetString("Scoundrel")),
            //new ComboTreeNode("3", _rm.GetString("Enchantress"))
            var HS = new[]
            {
                new { Text = "Profile", Value = 0 },
                new { Text = "Templar", Value = 1 },
                new { Text = "Scoundrel", Value = 2 },
                new { Text = "Enchantress", Value = 3 }
            };
            this.hireling.DisplayMember = "Text";
            this.hireling.ValueMember = "Value";
            this.hireling.DataSource = HS;
            this.hireling.SelectedValue = (int)this.item.hireling_class;
        }

        public void LoadBinding()
        {
            var BDS = new[]
            {
                new { Text = "UnBound", Value = 0 },
                new { Text = "Account_Bound_on_Equip", Value = 1 },
                new { Text = "Account_Bound", Value = 2 },
                new { Text = "No_Binding", Value = 3 }
            };
            this.bindingBox.DisplayMember = "Text";
            this.bindingBox.ValueMember = "Value";
            this.bindingBox.DataSource = BDS;
            this.bindingBox.SelectedValue = (int)this.item.generator.item_binding_level;
            this.bindingCB.Checked = Convert.ToBoolean(this.item.generator.item_binding);
        }

        public void LoadAugment()
        {
            var DS = new[]
            {
                new { Text = "None", Value = 0 },
                new { Text = "Vitality", Value = 1 },
                new { Text = "Dexterity", Value = 2 },
                new { Text = "Strength", Value = 3 },
                new { Text = "Intelligence", Value = 4 }
            };
            this.augmentType.DisplayMember = "Text";
            this.augmentType.ValueMember = "Value";
            this.augmentType.DataSource = DS;
            this.augmentType.SelectedValue = (int)this.item.generator.augment_gem_type;
        }

        public void LoadSlots()
        {
            var DS = new[]
            {
                new { Value = 0, Text = "Locker" },
                new { Value = 272, Text = "Inventory" },
                new { Value = 288, Text = "Head" },
                new { Value = 304, Text = "Chest" },
                new { Value = 320, Text = "Off_Hand" },
                new { Value = 336, Text = "Main_Hand" },
                new { Value = 352, Text = "Gloves" },
                new { Value = 368, Text = "Belt" },
                new { Value = 384, Text = "Boots" },
                new { Value = 400, Text = "Shoulders" },
                new { Value = 416, Text = "Pants" },
                new { Value = 432, Text = "Wrist" },
                new { Value = 448, Text = "Ring_2" },
                new { Value = 464, Text = "Ring_1" },
                new { Value = 480, Text = "Necklace" },
                new { Value = 544, Text = "Stash" },
                new { Value = 560, Text = "gold" },
                new { Value = 1024, Text = "Socket" },
                new { Value = 1296, Text = "Follower_Off_Hand" },
                new { Value = 1312, Text = "Follower_Main_Hand" },
                new { Value = 1328, Text = "Follower_Relic" },
                new { Value = 1344, Text = "Follower_Necklace" },
                new { Value = 1360, Text = "Follower_Ring1" },
                new { Value = 1376, Text = "Follower_Ring2" }
            };

            this.itemSlot.DisplayMember = "Text";
            this.itemSlot.ValueMember = "Value";
            this.itemSlot.DataSource = DS;
            this.itemSlot.SelectedValue = (int)this.item.item_slot;
        }

        public void AddRarity()
        {
            this.ItemLevelSource.Add(new IL("-2 Common", -2));
            this.ItemLevelSource.Add(new IL("-1 Common", -1));
            this.ItemLevelSource.Add(new IL("0 Common", 0));
            this.ItemLevelSource.Add(new IL("1 Common", 1));
            this.ItemLevelSource.Add(new IL("2 Common", 2));
            this.ItemLevelSource.Add(new IL("3 Magical", 3));
            this.ItemLevelSource.Add(new IL("4 Magical", 4));
            this.ItemLevelSource.Add(new IL("5 Magical", 5));
            this.ItemLevelSource.Add(new IL("6 Rare", 6));
            this.ItemLevelSource.Add(new IL("7 Rare", 7));
            this.ItemLevelSource.Add(new IL("8 Rare", 8));
            this.ItemLevelSource.Add(new IL("9 Legendary", 9));
            this.ItemLevelSource.Add(new IL("10 Magical", 10));
            this.rarity.DisplayMember = "Text";
            this.rarity.ValueMember = "Value";
            this.rarity.DataSource = ItemLevelSource;

            this.rarity.SelectedValue = this.item.generator.item_quality_level;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (loaded && update_tb)
            {
                this.flagNum.BackColor = System.Drawing.SystemColors.Window;
                this.changed["flagNum"] = true;
                this.flagNum.Value = this.flags;
                this.item.generator.flags = this.flags;
                if (!this.isFormat)
                {
                    foreach (PB.Items.SavedItem i in this.items)
                    {
                        try
                        {
                            foreach (PB.Items.EmbeddedGenerator emb in i.generator.contents)
                            {
                                if (emb.id.id_low == this.item.id.id_low)
                                {
                                    emb.generator.flags = Convert.ToUInt32(this.flags);
                                }
                            }
                        }
                        catch { }
                    }
                }
            }
        }

        private void flagNum_KeyUp(object sender, KeyEventArgs e)
        {
            if(loaded)
            {
                this.flagNum.BackColor = System.Drawing.SystemColors.Window;
                this.changed["flagNum"] = true;
                this.update_tb = false;
                this.flags = (uint)this.flagNum.Value; ;
                this.update_tb = true;
                this.item.generator.flags = (uint)this.flagNum.Value;
                if(!this.isFormat)
                {
                    foreach (PB.Items.SavedItem i in this.items)
                    {
                        try
                        {
                            foreach (PB.Items.EmbeddedGenerator emb in i.generator.contents)
                            {
                                if (emb.id.id_low == this.item.id.id_low)
                                {
                                    emb.generator.flags = Convert.ToUInt32(this.flags);
                                }
                            }
                        }
                        catch { }
                    }
                }
            }
        }

        public void LoadDye()
        {
            var DSD = new[]
            {
                new { Value = 1, Text = "Abyssal_Dye" },
                new { Value = 0, Text = "All_Soaps" },
                new { Value = 11, Text = "Aquatic_Dye" },
                new { Value = 9, Text = "Autumn_Dye" },
                new { Value = 20, Text = "BottledCloud" },
                new { Value = 13, Text = "BottledSmoke" },
                new { Value = 15, Text = "Cardinal_Dye" },
                new { Value = 19, Text = "Desert_Dye" },
                new { Value = 6, Text = "Elegant_Dye" },
                new { Value = 14, Text = "Foresters_Dye" },
                new { Value = 8, Text = "Golden_Dye" },
                new { Value = 2, Text = "Infernal_Dye" },
                new { Value = 4, Text = "Lovely_Dye" },
                new { Value = 10, Text = "Mariners_Dye" },
                new { Value = 3, Text = "Purity_Dye" },
                new { Value = 17, Text = "Rangers_Dye" },
                new { Value = 5, Text = "Royal_Dye" },
                new { Value = 16, Text = "Spring_Dye" },
                new { Value = 7, Text = "Summer_Dye" },
                new { Value = 18, Text = "Tanners_Dye" },
                new { Value = 21, Text = "Vanishing_Dye" },
                new { Value = 12, Text = "Winter_Dye" }
            };

            this.dye.DisplayMember = "Text";
            this.dye.ValueMember = "Value";
            this.dye.DataSource = DSD;
            this.dye.SelectedValue = (int)this.item.generator.dye_type;
        }

        public void ApplyAugTypeToGenerator(int value, ulong id)
        {
            if (this.isFormat)
                return;
            foreach (PB.Items.SavedItem i in this.items)
            {
                if (i.generator.contents != null && i.generator.contents.Count() > 0)
                {
                    try
                    {
                        foreach (PB.Items.EmbeddedGenerator emb in i.generator.contents)
                        {
                            if (emb.id.id_low == id)
                            {
                                emb.generator.augment_gem_type = value;
                            }
                        }
                    }
                    catch { }
                }
            }
        }

        public void ApplyAugLevelToGenerator(int value, ulong id)
        {
            if (this.isFormat)
                return;
            foreach (PB.Items.SavedItem i in this.items)
            {
                if (i.generator.contents != null && i.generator.contents.Count() > 0)
                {
                    try
                    {
                        foreach (PB.Items.EmbeddedGenerator emb in i.generator.contents)
                        {
                            if (emb.id.id_low == id)
                            {
                                emb.generator.augment_gem_level = value;
                            }
                        }
                    }
                    catch { }
                }
            }
        }

        private void durability_KeyUp(object sender, KeyEventArgs e)
        {
            if(loaded)
            {
                this.durability.BackColor = System.Drawing.SystemColors.Window;
                this.changed["durability"] = true;
                this.item.generator.durability = (uint)this.durability.Value;
                if(!this.isFormat)
                {
                    foreach (PB.Items.SavedItem i in this.items)
                    {
                        try
                        {
                            foreach (PB.Items.EmbeddedGenerator emb in i.generator.contents)
                            {
                                if (emb.id.id_low == this.item.id.id_low)
                                {
                                    emb.generator.durability = (uint)this.durability.Value;
                                }
                            }
                        }
                        catch { }
                    }
                }
            }
        }

        private void maxDurability_KeyUp(object sender, KeyEventArgs e)
        {
            if (loaded)
            {
                this.maxDurability.BackColor = System.Drawing.SystemColors.Window;
                this.changed["maxDurability"] = true;
                this.item.generator.max_durability = (uint)this.maxDurability.Value;
                if (this.isFormat)
                    return;
                foreach (PB.Items.SavedItem i in this.items)
                {
                    try
                    {
                        foreach (PB.Items.EmbeddedGenerator emb in i.generator.contents)
                        {
                            if (emb.id.id_low == this.item.id.id_low)
                            {
                                emb.generator.max_durability = (uint)this.maxDurability.Value;
                            }
                        }
                    }
                    catch { }
                }
            }
        }

        private void itemLevel_ValueChanged(object sender, EventArgs e)
        {
            if (loaded && false)
            {
                this.itemLevel.BackColor = System.Drawing.SystemColors.Window;
                this.changed["itemLevel"] = true;
                this.item.generator.item_level = (uint)this.itemLevel.Value;
                if (this.isFormat)
                    return;
                foreach (PB.Items.SavedItem i in this.items)
                {
                    try
                    {
                        foreach (PB.Items.EmbeddedGenerator emb in i.generator.contents)
                        {
                            if (emb.id.id_low == this.item.id.id_low)
                            {
                                emb.generator.item_level = (uint)this.itemLevel.Value;
                            }
                        }
                    }
                    catch { }
                }
            }
        }

        private void itemLevel_KeyUp(object sender, KeyEventArgs e)
        {
            if (loaded)
            {
                this.itemLevel.BackColor = System.Drawing.SystemColors.Window;
                this.changed["itemLevel"] = true;
                this.item.generator.item_level = (uint)this.itemLevel.Value;
                if (this.isFormat)
                    return;
                foreach (PB.Items.SavedItem i in this.items)
                {
                    try
                    {
                        foreach (PB.Items.EmbeddedGenerator emb in i.generator.contents)
                        {
                            if (emb.id.id_low == this.item.id.id_low)
                            {
                                emb.generator.item_level = (uint)this.itemLevel.Value;
                            }
                        }
                    }
                    catch { }
                }
            }
        }

        private void legendaryLevel_KeyUp(object sender, KeyEventArgs e)
        {
            if (loaded)
            {
                this.legendaryLevel.BackColor = System.Drawing.SystemColors.Window;
                this.changed["legendaryLevel"] = true;
                this.item.generator.legendary_item_level = (uint)this.legendaryLevel.Value;
                if (this.isFormat)
                    return;
                foreach (PB.Items.SavedItem i in this.items)
                {
                    try
                    {
                        foreach (PB.Items.EmbeddedGenerator emb in i.generator.contents)
                        {
                            if (emb.id.id_low == this.item.id.id_low)
                            {
                                emb.generator.legendary_item_level = (uint)this.legendaryLevel.Value;
                            }
                        }
                    }
                    catch { }
                }
            }
        }

        private void rarity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                this.rarity.BackColor = System.Drawing.SystemColors.Window;
                this.changed["rarity"] = true;
                this.item.generator.item_quality_level = (int)this.rarity.SelectedValue;
                if(!this.isFormat)
                {
                    foreach (PB.Items.SavedItem i in this.items)
                    {
                        try
                        {
                            foreach (PB.Items.EmbeddedGenerator emb in i.generator.contents)
                            {
                                if (emb.id.id_low == this.item.id.id_low)
                                {
                                    emb.generator.item_quality_level = (int)this.rarity.SelectedValue;
                                }
                            }
                        }
                        catch { }
                    }
                    this.parrent.refreshList();
                }
            }
        }

        private void rank_KeyUp(object sender, KeyEventArgs e)
        {
            if (loaded)
            {
                this.rank.BackColor = System.Drawing.SystemColors.Window;
                this.changed["rank"] = true;
                this.item.generator.rank = (uint)this.rank.Value;
                if (this.isFormat)
                    return;
                foreach (PB.Items.SavedItem i in this.items)
                {
                    try
                    {
                        foreach (PB.Items.EmbeddedGenerator emb in i.generator.contents)
                        {
                            if (emb.id.id_low == this.item.id.id_low)
                            {
                                emb.generator.rank = (uint)this.rank.Value;
                            }
                        }
                    }
                    catch { }
                }
            }
        }

        private void dye_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                this.dye.BackColor = System.Drawing.SystemColors.Window;
                this.changed["dye"] = true;
                this.item.generator.dye_type = Convert.ToUInt32(this.dye.SelectedValue);
                if (this.isFormat)
                    return;
                foreach (PB.Items.SavedItem i in this.items)
                {
                    try
                    {
                        foreach (PB.Items.EmbeddedGenerator emb in i.generator.contents)
                        {
                            if (emb.id.id_low == this.item.id.id_low)
                            {
                                emb.generator.dye_type = Convert.ToUInt32(this.dye.SelectedValue);
                            }
                        }
                    }
                    catch { }
                }
            }
        }

        private void quantity_KeyUp(object sender, KeyEventArgs e)
        {
            if (loaded)
            {
                this.quantity.BackColor = System.Drawing.SystemColors.Window;
                this.changed["quantity"] = true;
                this.item.generator.stack_size = (uint)this.quantity.Value;
                if (this.isFormat)
                    return;
                foreach (PB.Items.SavedItem i in this.items)
                {
                    try
                    {
                        foreach (PB.Items.EmbeddedGenerator emb in i.generator.contents)
                        {
                            if (emb.id.id_low == this.item.id.id_low)
                            {
                                emb.generator.stack_size = Convert.ToUInt32(this.quantity.Value);
                            }
                        }
                    }
                    catch { }
                }
            }
        }

        public int nextSquareIndex(int slot)
        {
            if (this.isFormat)
                return 0;
            int temp = 0;
            foreach (PB.Items.SavedItem i in items)
            {
                if (item.item_slot == slot)
                {
                    if(i.square_index > temp)
                    {
                        temp = i.square_index.DeepClone();
                    }
                }
            }
            return temp + 1;
        }

        private void itemSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                this.item.item_slot = (int)this.itemSlot.SelectedValue;
                this.item.square_index = nextSquareIndex((int)this.itemSlot.SelectedValue);
                if (this.isFormat)
                    return;
                this.parrent.refreshList();
            }
        }

        private void augmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                this.augmentType.BackColor = System.Drawing.SystemColors.Window;
                this.changed["augmentType"] = true;
                this.item.generator.augment_gem_type = (int)this.augmentType.SelectedValue;
                if (this.isFormat)
                    return;
                this.ApplyAugTypeToGenerator((int)this.augmentType.SelectedValue, item.id.id_low);
            }
        }

        private void augmentLevel_KeyUp(object sender, KeyEventArgs e)
        {
            if (loaded)
            {
                this.augmentLevel.BackColor = System.Drawing.SystemColors.Window;
                this.changed["augmentLevel"] = true;
                this.item.generator.augment_gem_level = (int)this.augmentLevel.Value;
                if (this.isFormat)
                    return;
                this.ApplyAugLevelToGenerator((int)this.augmentLevel.Value, item.id.id_low);
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (!loaded)
                return;
            this.bindingCB.BackColor = System.Drawing.SystemColors.Window;
            this.changed["bindingCB"] = true;
            this.item.generator.item_binding = Convert.ToInt32(this.bindingCB.Checked);
        }

        private void bindingBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(loaded)
            {
                this.bindingBox.BackColor = System.Drawing.SystemColors.Window;
                this.changed["bindingBox"] = true;
                this.item.generator.item_binding_level = Convert.ToInt32(this.bindingBox.SelectedValue);
            }
        }

        private void hireling_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loaded)
                return;
            this.bindingCB.BackColor = System.Drawing.SystemColors.Window;
            this.changed["hireling"] = true;
            this.item.hireling_class = Convert.ToInt32(this.hireling.SelectedValue);
        }
    }

    public static class ItemFlagList
    {
        public static bool[] Dec2Bin(int value)
        {
            if (value == 0)
                return new bool[1];
            int num1 = (int)(Math.Log(value) / Math.Log(2.0));
            bool[] flagArray = new bool[31];
            for (int index = num1; index >= 0; --index)
            {
                int num2 = (int)Math.Pow(2.0, index);
                if (num2 <= value)
                {
                    flagArray[index] = true;
                    value -= num2;
                }
            }
            return flagArray;
        }

        public static uint BoolArrayToUint(bool[] arr)
        {
            if (arr.Length > 31)
                throw new ApplicationException("too many elements to be converted to a single int");
            int num = 0;
            for (int index = 0; index < arr.Length; ++index)
            {
                if (arr[index])
                    num |= 1 << index;
            }
            return (uint)num;
        }
    }
}
