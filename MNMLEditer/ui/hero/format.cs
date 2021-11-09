using D3Studio.lists;
using D3Studio.lists.types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TonicBox.Data;

namespace D3Studio.ui.hero
{
    public partial class format : Form
    {
        public PB.Items.SavedItem item = new PB.Items.SavedItem();

        public List<PB.Items.SavedItem> items;

        public List<ListViewItem> selectedItems;

        public inventory parent { get; set; }

        public format()
        {
            InitializeComponent();
            this.item.generator = new PB.Items.Generator();
            this.properties1.items = this.items;
            this.properties1.item = this.item;
            this.properties1.isFormat = true;
            this.properties1.setInactiveColors();
            this.properties1.populate();
        }

        public void updateAndClose()
        {
            Dictionary<string, bool> changed = this.properties1.changed;
            foreach (ListViewItem item in this.selectedItems)
            {
                PB.Items.SavedItem z = (PB.Items.SavedItem)item.Tag;
                PB.Items.SavedItem rem = items.First(x => x == z);
                ulong id = rem.id.id_low;
                if(changed["durability"])
                    rem.generator.durability = this.item.generator.durability;
                if (changed["maxDurability"])
                    rem.generator.max_durability = this.item.generator.max_durability;
                if (changed["itemLevel"])
                    rem.generator.item_level = this.item.generator.item_level;
                if (changed["legendaryLevel"])
                    rem.generator.legendary_item_level = this.item.generator.legendary_item_level;
                if (changed["rarity"])
                    rem.generator.item_quality_level = this.item.generator.item_quality_level;
                if (changed["rank"])
                    rem.generator.rank = this.item.generator.rank;
                if (changed["dye"])
                    rem.generator.dye_type = this.item.generator.dye_type;
                if (changed["bindingCB"])
                    rem.generator.item_binding = this.item.generator.item_binding;
                if (changed["bindingBox"])
                    rem.generator.item_binding_level = this.item.generator.item_binding_level;
                if (changed["augmentLevel"])
                    rem.generator.augment_gem_level = this.item.generator.augment_gem_level;
                if (changed["augmentType"])
                    rem.generator.augment_gem_type = this.item.generator.augment_gem_type;
                if (changed["quantity"])
                    rem.generator.stack_size = this.item.generator.stack_size;
                if (changed["flagNum"])
                    rem.generator.flags = this.item.generator.flags;
                foreach (PB.Items.SavedItem i in items)
                {
                    if (i.generator.contents != null)
                    {
                        List<PB.Items.EmbeddedGenerator> temp = new List<PB.Items.EmbeddedGenerator>();
                        foreach (PB.Items.EmbeddedGenerator emb in i.generator.contents)
                        {
                            if (emb.id.id_low == id)
                            {
                                if (changed["durability"])
                                    emb.generator.durability = this.item.generator.durability;
                                if (changed["maxDurability"])
                                    emb.generator.max_durability = this.item.generator.max_durability;
                                if (changed["itemLevel"])
                                    emb.generator.item_level = this.item.generator.item_level;
                                if (changed["legendaryLevel"])
                                    emb.generator.legendary_item_level = this.item.generator.legendary_item_level;
                                if (changed["rarity"])
                                    emb.generator.item_quality_level = this.item.generator.item_quality_level;
                                if (changed["rank"])
                                    emb.generator.rank = this.item.generator.rank;
                                if (changed["dye"])
                                    emb.generator.dye_type = this.item.generator.dye_type;
                                if (changed["bindingCB"])
                                    emb.generator.item_binding = this.item.generator.item_binding;
                                if (changed["bindingBox"])
                                    emb.generator.item_binding_level = this.item.generator.item_binding_level;
                                if (changed["augmentLevel"])
                                    emb.generator.augment_gem_level = this.item.generator.augment_gem_level;
                                if (changed["augmentType"])
                                    emb.generator.augment_gem_type = this.item.generator.augment_gem_type;
                                if (changed["quantity"])
                                    emb.generator.stack_size = this.item.generator.stack_size;
                                if (changed["flagNum"])
                                    emb.generator.flags = this.item.generator.flags;
                            }
                        }
                    }
                }
            }
            this.parent.items = this.items;
            this.parent.refreshList();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateAndClose();
        }
    }
}