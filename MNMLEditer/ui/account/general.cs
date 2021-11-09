using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PB.ItemCrafting;

namespace D3Studio.ui.account
{
    public partial class general : UserControl
    {
        public PB.Account.SavedDefinition AccountFile { get; set; }
        private bool loaded = false;
        public general()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            if(!TonicBox.Data.Settings.Seasonal)
            {
                this.groupBox3.Visible = false;
                this.groupBox4.Visible = false;
            }
        }

        public void populate()
        {
            this.accountFlags.Value = Convert.ToDecimal(this.AccountFile.digest.flags);
            if(this.AccountFile.console_data.legacy_license_bits == 7 && this.AccountFile.deprecated_accepted_license_bits == 7)
            {
                this.checkBox1.Checked = true;
            }
            string text2 = File.ReadAllText(Application.StartupPath + "\\db\\ENCosmetics.txt");
            int num = text2.Split(new char[]
            {
                        '\r'
            }).Length - 1;
            if (this.AccountFile.unlocked_cosmetics == null)
                this.AccountFile.unlocked_cosmetics = new PB.Account.UnlockedCosmetics();
            if (this.AccountFile.unlocked_cosmetics.unlocked_cosmetics_data == null)
                this.AccountFile.unlocked_cosmetics.unlocked_cosmetics_data = new PB.Account.UnlockedCosmeticsData();
            if (this.AccountFile.unlocked_cosmetics.unlocked_cosmetics_data.unlocked_cosmetics == null)
                this.AccountFile.unlocked_cosmetics.unlocked_cosmetics_data.unlocked_cosmetics = new List<int>();
            int Cosmetics = this.AccountFile.unlocked_cosmetics.unlocked_cosmetics_data.unlocked_cosmetics.Count();
            if (num <= Cosmetics)
            {
                this.checkBox2.Checked = true;
            }
            while(this.AccountFile.partitions.Count < 4)
            {
                this.AccountFile.partitions.Add(new PB.Account.AccountPartition());
            }
            for(int i = 0; i < 4; i++)
            {
                if (this.AccountFile.partitions[i].crafter_data == null)
                    this.AccountFile.partitions[i].crafter_data = new CrafterSavedData();
                if (this.AccountFile.partitions[i].crafter_data.crafter_data == null)
                    this.AccountFile.partitions[i].crafter_data.crafter_data = new List<CrafterData>();
                while(this.AccountFile.partitions[i].crafter_data.crafter_data.Count() < 4)
                {
                    this.AccountFile.partitions[i].crafter_data.crafter_data.Add(new CrafterData());
                }
                if (this.AccountFile.partitions[i].saved_attributes == null)
                    this.AccountFile.partitions[i].saved_attributes = new PB.AttributeSerializer.SavedAttributes();
                if (this.AccountFile.partitions[i].saved_attributes.attributes == null)
                    this.AccountFile.partitions[i].saved_attributes.attributes = new List<PB.AttributeSerializer.SavedAttribute>();
                if (this.AccountFile.partitions[i].crafter_data.transmog_data == null)
                    this.AccountFile.partitions[i].crafter_data.transmog_data = new CrafterTransmogData();
                if (this.AccountFile.partitions[i].crafter_data.transmog_data.unlocked_transmogs == null)
                    this.AccountFile.partitions[i].crafter_data.transmog_data.unlocked_transmogs = new List<int>();
            }
            if (this.AccountFile.partitions[0].crafter_data.crafter_data[3].level == 1)
                this.cube_sc.Checked = true;
            if (this.AccountFile.partitions[1].crafter_data.crafter_data[3].level == 1)
                this.cube_hc.Checked = true;
            if (this.AccountFile.partitions[2].crafter_data.crafter_data[3].level == 1)
                this.cube_ssc.Checked = true;
            if (this.AccountFile.partitions[3].crafter_data.crafter_data[3].level == 1)
                this.cube_shc.Checked = true;
            string text = File.ReadAllText(Application.StartupPath + "\\db\\ENPowers.txt");
            num = text.Split(new char[]
            {
                        '\r'
            }).Length;
            if (this.AccountFile.partitions[0].crafter_data == null)
                this.AccountFile.partitions[0].crafter_data = new PB.ItemCrafting.CrafterSavedData();
            if (this.AccountFile.partitions[0].crafter_data.kanais_cube_data == null)
                this.AccountFile.partitions[0].crafter_data.kanais_cube_data = new PB.ItemCrafting.CrafterKanaisCubeData();
            if (this.AccountFile.partitions[0].crafter_data.kanais_cube_data.extracted_legendaries == null)
                this.AccountFile.partitions[0].crafter_data.kanais_cube_data.extracted_legendaries = new List<int>();
            if (this.AccountFile.partitions[0].crafter_data.kanais_cube_data.extracted_legendaries.Count() >= num)
                this.powers_sc.Checked = true;
            if (this.AccountFile.partitions[1].crafter_data == null)
                this.AccountFile.partitions[1].crafter_data = new PB.ItemCrafting.CrafterSavedData();
            if (this.AccountFile.partitions[1].crafter_data.kanais_cube_data == null)
                this.AccountFile.partitions[1].crafter_data.kanais_cube_data = new PB.ItemCrafting.CrafterKanaisCubeData();
            if (this.AccountFile.partitions[1].crafter_data.kanais_cube_data.extracted_legendaries == null)
                this.AccountFile.partitions[1].crafter_data.kanais_cube_data.extracted_legendaries = new List<int>();
            if (this.AccountFile.partitions[1].crafter_data.kanais_cube_data.extracted_legendaries.Count() >= num)
                this.powers_hc.Checked = true;
            if (this.AccountFile.partitions[2].crafter_data == null)
                this.AccountFile.partitions[2].crafter_data = new PB.ItemCrafting.CrafterSavedData();
            if (this.AccountFile.partitions[2].crafter_data.kanais_cube_data == null)
                this.AccountFile.partitions[2].crafter_data.kanais_cube_data = new PB.ItemCrafting.CrafterKanaisCubeData();
            if (this.AccountFile.partitions[2].crafter_data.kanais_cube_data.extracted_legendaries == null)
                this.AccountFile.partitions[2].crafter_data.kanais_cube_data.extracted_legendaries = new List<int>();
            if (this.AccountFile.partitions[2].crafter_data.kanais_cube_data.extracted_legendaries.Count() >= num)
                this.powers_ssc.Checked = true;
            if (this.AccountFile.partitions[3].crafter_data == null)
                this.AccountFile.partitions[3].crafter_data = new PB.ItemCrafting.CrafterSavedData();
            if (this.AccountFile.partitions[3].crafter_data.kanais_cube_data == null)
                this.AccountFile.partitions[3].crafter_data.kanais_cube_data = new PB.ItemCrafting.CrafterKanaisCubeData();
            if (this.AccountFile.partitions[3].crafter_data.kanais_cube_data.extracted_legendaries == null)
                this.AccountFile.partitions[3].crafter_data.kanais_cube_data.extracted_legendaries = new List<int>();
            if (this.AccountFile.partitions[3].crafter_data.kanais_cube_data.extracted_legendaries.Count() >= num)
                this.powers_shc.Checked = true;
            if (this.AccountFile.partitions[0].crafter_data.crafter_data[0].level >= 12 &&
            this.AccountFile.partitions[0].crafter_data.crafter_data[1].level >= 12 &&
            this.AccountFile.partitions[0].crafter_data.crafter_data[2].level >= 12)
            {
                this.ma_sc.Checked = true;
            }
            if (this.AccountFile.partitions[1].crafter_data.crafter_data[0].level >= 12 &&
            this.AccountFile.partitions[1].crafter_data.crafter_data[1].level >= 12 &&
            this.AccountFile.partitions[1].crafter_data.crafter_data[2].level >= 12)
            {
                this.ma_hc.Checked = true;
            }
            if (this.AccountFile.partitions[2].crafter_data.crafter_data[0].level >= 12 &&
            this.AccountFile.partitions[2].crafter_data.crafter_data[1].level >= 12 &&
            this.AccountFile.partitions[2].crafter_data.crafter_data[2].level >= 12)
            {
                this.ma_ssc.Checked = true;
            }
            if (this.AccountFile.partitions[3].crafter_data.crafter_data[0].level >= 12 &&
            this.AccountFile.partitions[3].crafter_data.crafter_data[1].level >= 12 &&
            this.AccountFile.partitions[3].crafter_data.crafter_data[2].level >= 12)
            {
                this.ma_shc.Checked = true;
            }
            this.al_sc.Value = this.AccountFile.partitions[0].alt_level;
            this.al_hc.Value = this.AccountFile.partitions[1].alt_level;
            this.al_ssc.Value = this.AccountFile.partitions[2].alt_level;
            this.al_shc.Value = this.AccountFile.partitions[3].alt_level;

            if (this.AccountFile.partitions[0].crafter_data.transmog_data.unlocked_transmogs.Count() > 200)
                this.tm_sc.Checked = true;
            if (this.AccountFile.partitions[1].crafter_data.transmog_data.unlocked_transmogs.Count() > 200)
                this.tm_hc.Checked = true;
            if (this.AccountFile.partitions[2].crafter_data.transmog_data.unlocked_transmogs.Count() > 200)
                this.tm_ssc.Checked = true;
            if (this.AccountFile.partitions[3].crafter_data.transmog_data.unlocked_transmogs.Count() > 200)
                this.tm_shc.Checked = true;
            try
            {
                if (this.AccountFile.partitions[0].crafter_data.crafter_data[1].recipes_bitfield.Length >= 5 &&
                this.AccountFile.partitions[0].crafter_data.crafter_data[0].recipes_bitfield.Length >= 36 &&
                this.AccountFile.partitions[0].crafter_data.crafter_data[0].recipes.Count >= 11)
                {
                    this.cp_sc.Checked = true;
                }
            }
            catch { }
            try
            {
                if (this.AccountFile.partitions[1].crafter_data.crafter_data[1].recipes_bitfield.Length >= 5 &&
                this.AccountFile.partitions[1].crafter_data.crafter_data[0].recipes_bitfield.Length >= 36 &&
                this.AccountFile.partitions[1].crafter_data.crafter_data[0].recipes.Count >= 11)
                {
                    this.cp_hc.Checked = true;
                }
            }
            catch { }
            try
            {
                if (this.AccountFile.partitions[2].crafter_data.crafter_data[1].recipes_bitfield.Length >= 5 &&
                this.AccountFile.partitions[2].crafter_data.crafter_data[0].recipes_bitfield.Length >= 36 &&
                this.AccountFile.partitions[2].crafter_data.crafter_data[0].recipes.Count >= 11)
                {
                    this.cp_ssc.Checked = true;
                }
            }
            catch { }
            try
            {
                if (this.AccountFile.partitions[3].crafter_data.crafter_data[1].recipes_bitfield.Length >= 5 &&
                this.AccountFile.partitions[3].crafter_data.crafter_data[0].recipes_bitfield.Length >= 36 &&
                this.AccountFile.partitions[3].crafter_data.crafter_data[0].recipes.Count >= 11)
                {
                    this.cp_shc.Checked = true;
                }
            }
            catch { }
            for (int index = 0; index <= this.AccountFile.partitions[0].saved_attributes.attributes.Count - 1; ++index)
            {
                if (this.AccountFile.partitions[0].saved_attributes.attributes[index].key == -4094)
                    this.xp_sc.Value = this.AccountFile.partitions[0].saved_attributes.attributes[index].value;
            }
            for (int index = 0; index <= this.AccountFile.partitions[1].saved_attributes.attributes.Count - 1; ++index)
            {
                if (this.AccountFile.partitions[1].saved_attributes.attributes[index].key == -4094)
                    this.xp_hc.Value = this.AccountFile.partitions[1].saved_attributes.attributes[index].value;
            }
            for (int index = 0; index <= this.AccountFile.partitions[2].saved_attributes.attributes.Count - 1; ++index)
            {
                if (this.AccountFile.partitions[2].saved_attributes.attributes[index].key == -4094)
                    this.xp_ssc.Value = this.AccountFile.partitions[2].saved_attributes.attributes[index].value;
            }
            for (int index = 0; index <= this.AccountFile.partitions[3].saved_attributes.attributes.Count - 1; ++index)
            {
                if (this.AccountFile.partitions[3].saved_attributes.attributes[index].key == -4094)
                    this.xp_shc.Value = this.AccountFile.partitions[3].saved_attributes.attributes[index].value;
            }
            if (this.AccountFile.partitions[0].saved_attributes == null)
                this.AccountFile.partitions[0].saved_attributes = new PB.AttributeSerializer.SavedAttributes();
            if (this.AccountFile.partitions[0].saved_attributes.attributes == null)
                this.AccountFile.partitions[0].saved_attributes.attributes = new List<PB.AttributeSerializer.SavedAttribute>();
            if (this.AccountFile.partitions[1].saved_attributes == null)
                this.AccountFile.partitions[1].saved_attributes = new PB.AttributeSerializer.SavedAttributes();
            if (this.AccountFile.partitions[1].saved_attributes.attributes == null)
                this.AccountFile.partitions[1].saved_attributes.attributes = new List<PB.AttributeSerializer.SavedAttribute>();
            if (this.AccountFile.partitions[2].saved_attributes == null)
                this.AccountFile.partitions[2].saved_attributes = new PB.AttributeSerializer.SavedAttributes();
            if (this.AccountFile.partitions[2].saved_attributes.attributes == null)
                this.AccountFile.partitions[2].saved_attributes.attributes = new List<PB.AttributeSerializer.SavedAttribute>();
            if (this.AccountFile.partitions[3].saved_attributes == null)
                this.AccountFile.partitions[3].saved_attributes = new PB.AttributeSerializer.SavedAttributes();
            if (this.AccountFile.partitions[3].saved_attributes.attributes == null)
                this.AccountFile.partitions[3].saved_attributes.attributes = new List<PB.AttributeSerializer.SavedAttribute>();
            if (this.AccountFile.partitions[0].saved_attributes.gb_handle == null)
                this.AccountFile.partitions[0].saved_attributes.gb_handle = new PB.GameBalance.Handle();
            if (this.AccountFile.partitions[1].saved_attributes.gb_handle == null)
                this.AccountFile.partitions[1].saved_attributes.gb_handle = new PB.GameBalance.Handle();
            if (this.AccountFile.partitions[2].saved_attributes.gb_handle == null)
                this.AccountFile.partitions[2].saved_attributes.gb_handle = new PB.GameBalance.Handle();
            if (this.AccountFile.partitions[3].saved_attributes.gb_handle == null)
                this.AccountFile.partitions[3].saved_attributes.gb_handle = new PB.GameBalance.Handle();
            if (this.AccountFile.partitions[0].saved_attributes.gb_handle.game_balance_type == -1 ||
                this.AccountFile.partitions[0].saved_attributes.gb_handle.gbid == -1)
            {
                this.AccountFile.partitions[0].saved_attributes.gb_handle.game_balance_type = 7;
                this.AccountFile.partitions[0].saved_attributes.gb_handle.gbid = 4041749;
            }
            if (this.AccountFile.partitions[1].saved_attributes.gb_handle.game_balance_type == -1 ||
                this.AccountFile.partitions[1].saved_attributes.gb_handle.gbid == -1)
            {
                this.AccountFile.partitions[1].saved_attributes.gb_handle.game_balance_type = 7;
                this.AccountFile.partitions[1].saved_attributes.gb_handle.gbid = -4041749;
            }
            if (this.AccountFile.partitions[2].saved_attributes.gb_handle.game_balance_type == -1 ||
                this.AccountFile.partitions[2].saved_attributes.gb_handle.gbid == -1)
            {
                this.AccountFile.partitions[2].saved_attributes.gb_handle.game_balance_type = 7;
                this.AccountFile.partitions[2].saved_attributes.gb_handle.gbid = 4041749;
            }
            if (this.AccountFile.partitions[3].saved_attributes.gb_handle.game_balance_type == -1 ||
                this.AccountFile.partitions[3].saved_attributes.gb_handle.gbid == -1)
            {
                this.AccountFile.partitions[3].saved_attributes.gb_handle.game_balance_type = 7;
                this.AccountFile.partitions[3].saved_attributes.gb_handle.gbid = -4041749;
            }
            /*if (this.AccountFile.partitions[0].flags < 3)
                this.AccountFile.partitions[0].flags = 3;
            if (this.AccountFile.partitions[1].flags < 3)
                this.AccountFile.partitions[1].flags = 3;
            if (this.AccountFile.partitions[2].flags < 3)
                this.AccountFile.partitions[2].flags = 3;
            if (this.AccountFile.partitions[3].flags < 3)
                this.AccountFile.partitions[3].flags = 3;*/
            for (int index = 0; index <= this.AccountFile.partitions[0].saved_attributes.attributes.Count - 1; ++index)
            {
                if (this.AccountFile.partitions[0].saved_attributes.attributes[index].key == -4096)
                    this.stash_sc.Value = this.AccountFile.partitions[0].saved_attributes.attributes[index].value;
            }
            for (int index = 0; index <= this.AccountFile.partitions[1].saved_attributes.attributes.Count - 1; ++index)
            {
                if (this.AccountFile.partitions[1].saved_attributes.attributes[index].key == -4096)
                    this.stash_hc.Value = this.AccountFile.partitions[1].saved_attributes.attributes[index].value;
            }
            for (int index = 0; index <= this.AccountFile.partitions[2].saved_attributes.attributes.Count - 1; ++index)
            {
                if (this.AccountFile.partitions[2].saved_attributes.attributes[index].key == -4096)
                    this.stash_ssc.Value = this.AccountFile.partitions[2].saved_attributes.attributes[index].value;
            }
            for (int index = 0; index <= this.AccountFile.partitions[3].saved_attributes.attributes.Count - 1; ++index)
            {
                if (this.AccountFile.partitions[3].saved_attributes.attributes[index].key == -4096)
                    this.stash_shc.Value = this.AccountFile.partitions[3].saved_attributes.attributes[index].value;
            }
            bool isConsole = false;
            try
            {
                if (this.AccountFile.partitions[0].currency_data.currency[0].tab == -1691237125)
                {
                    isConsole = true;
                }
            }
            catch { }
            try
            {
                if (this.AccountFile.partitions[1].currency_data.currency[0].tab == -1691237125)
                {
                    isConsole = true;
                }
            }
            catch { }
            try
            {
                if (this.AccountFile.partitions[2].currency_data.currency[0].tab == -1691237125)
                {
                    isConsole = true;
                }
            }
            catch { }
            try
            {
                if (this.AccountFile.partitions[3].currency_data.currency[0].tab == -1691237125)
                {
                    isConsole = true;
                }
            }
            catch { }
            this.isConsole = isConsole;
            if(isConsole)
            {
                this.mats_sc.Visible = false;
                this.mats_hc.Visible = false;
                this.mats_ssc.Visible = false;
                this.mats_shc.Visible = false;
                this.label38.Visible = false;
                this.label39.Visible = false;
                this.label40.Visible = false;
                this.label41.Visible = false;
                loadConsoleBloodshards(0, this.bloodshards_sc);
                loadConsoleBloodshards(1, this.bloodshards_hc);
                loadConsoleBloodshards(2, this.bloodshards_ssc);
                loadConsoleBloodshards(3, this.bloodshards_shc);
            }
            else
            {
                this.bs0.Visible = false;
                this.bs1.Visible = false;
                this.bs2.Visible = false;
                this.bs3.Visible = false;
                this.bloodshards_sc.Visible = false;
                this.bloodshards_hc.Visible = false;
                this.bloodshards_ssc.Visible = false;
                this.bloodshards_shc.Visible = false;
                try
                {
                    this.PopulateMatKeys(0);
                }
                catch { }
                try
                {
                    this.PopulateMatKeys(1);
                }
                catch { }
                try
                {
                    this.PopulateMatKeys(2);
                }
                catch { }
                try
                {
                    this.PopulateMatKeys(3);
                }
                catch { }
                try
                {
                    bool temp = true;
                    foreach (PB.Items.Currency mat in this.AccountFile.partitions[0].currency_data.currency)
                    {
                        if (mat.amount < 2147483647)
                            temp = false;
                    }
                    if (temp)
                        this.mats_sc.Checked = true;
                }
                catch { }
                try
                {
                    bool temp = true;
                    foreach (PB.Items.Currency mat in this.AccountFile.partitions[1].currency_data.currency)
                    {
                        if (mat.amount < 2147483647)
                            temp = false;
                    }
                    if (temp)
                        this.mats_hc.Checked = true;
                }
                catch { }
                try
                {
                    bool temp = true;
                    foreach (PB.Items.Currency mat in this.AccountFile.partitions[2].currency_data.currency)
                    {
                        if (mat.amount < 2147483647)
                            temp = false;
                    }
                    if (temp)
                        this.mats_ssc.Checked = true;
                }
                catch { }
                try
                {
                    bool temp = true;
                    foreach (PB.Items.Currency mat in this.AccountFile.partitions[3].currency_data.currency)
                    {
                        if (mat.amount < 2147483647)
                            temp = false;
                    }
                    if (temp)
                        this.mats_shc.Checked = true;
                }
                catch { }
            }

            try
            {
                this.soloRift.Checked = this.AccountFile.digest.completed_solo_rift;
            }
            catch
            {
                this.AccountFile.digest.completed_solo_rift = false;
                this.soloRift.Checked = this.AccountFile.digest.completed_solo_rift;
            }

            this.checkGR(0, this.grl_sc);
            this.checkGR(1, this.grl_hc);
            this.checkGR(2, this.grl_ssc);
            this.checkGR(3, this.grl_shc);
            this.loadFlags(0, this.flags_sc);
            this.loadFlags(1, this.flags_hc);
            this.loadFlags(2, this.flags_ssc);
            this.loadFlags(3, this.flags_shc);
            this.loaded = true;
        }

        private void loadConsoleBloodshards(int pIndex, NumericUpDown nu)
        {
            if (this.AccountFile.partitions[pIndex].currency_data == null)
                this.AccountFile.partitions[pIndex].currency_data = new PB.Items.CurrencySavedData();
            if (this.AccountFile.partitions[pIndex].currency_data.currency == null)
                this.AccountFile.partitions[pIndex].currency_data.currency = new List<PB.Items.Currency>();
            if(this.AccountFile.partitions[pIndex].currency_data.currency.Count() == 0)
            {
                this.AccountFile.partitions[pIndex].currency_data.currency.Add(new PB.Items.Currency()
                {
                       tab = -1691237125,
                       index = 2,
                       amount = 0
                });
            }
            if (this.AccountFile.partitions[pIndex].currency_data.currency[0].amount > 2147483647)
                this.AccountFile.partitions[pIndex].currency_data.currency[0].amount = 2147483647;
            nu.Value = Convert.ToDecimal(this.AccountFile.partitions[pIndex].currency_data.currency[0].amount);
        }

        private bool isConsole = false;
        private void loadFlags(int pIndex, NumericUpDown nu)
        {
            try
            {
                nu.Value = Convert.ToDecimal(this.AccountFile.partitions[pIndex].flags);
            }
            catch
            {
                MessageBox.Show("Please open your save and heroes in the game before editing.");
                ((Form)this.TopLevelControl).Close();
            }
        }

        private void checkGR(int pIndex, NumericUpDown nu)
        {
            if (this.AccountFile.partitions[pIndex].saved_attributes == null)
                this.AccountFile.partitions[pIndex].saved_attributes = new PB.AttributeSerializer.SavedAttributes();
            if(this.AccountFile.partitions[pIndex].saved_attributes.attributes == null)
            {
                this.AccountFile.partitions[pIndex].saved_attributes.attributes = new List<PB.AttributeSerializer.SavedAttribute>();
                this.AccountFile.partitions[pIndex].saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute()
                {
                    key = -4077,
                    value = Convert.ToInt32(0)
                });
                this.AccountFile.partitions[pIndex].saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute()
                {
                    key = -4076,
                    value = Convert.ToInt32(0)
                });
            }
            bool exists1 = false;
            bool exists2 = false;
            for (int index = 0; index <= this.AccountFile.partitions[pIndex].saved_attributes.attributes.Count - 1; ++index)
            {
                if (this.AccountFile.partitions[pIndex].saved_attributes.attributes[index].key == -4077)
                {
                    nu.Value = Convert.ToDecimal(this.AccountFile.partitions[pIndex].saved_attributes.attributes[index].value);
                    exists1 = true;
                }
                if (this.AccountFile.partitions[pIndex].saved_attributes.attributes[index].key == -4076)
                {
                    exists2 = true;
                }
            }
            if (!(exists1))
            {
                this.AccountFile.partitions[pIndex].saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute()
                {
                    key = -4077,
                    value = Convert.ToInt32(0)
                });
                nu.Value = Convert.ToDecimal(0);
            }
            if (!(exists2))
            {
                this.AccountFile.partitions[pIndex].saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute()
                {
                    key = -4076,
                    value = Convert.ToInt32(0)
                });
            }
        }

        private void accountFlags_ValueChanged(object sender, EventArgs e)
        {
            this.AccountFile.digest.flags = Convert.ToUInt32(this.accountFlags.Value);
        }

        private void accountFlags_KeyUp(object sender, KeyEventArgs e)
        {
            this.AccountFile.digest.flags = Convert.ToUInt32(this.accountFlags.Value);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                this.AccountFile.console_data.legacy_license_bits = 7;
                this.AccountFile.deprecated_accepted_license_bits = 7;
            }
            else
            {
                this.AccountFile.console_data.legacy_license_bits = 0;
                this.AccountFile.deprecated_accepted_license_bits = 0;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked)
            {
                if (File.Exists(Application.StartupPath + "\\db\\ENCosmetics.txt"))
                {
                    string text = File.ReadAllText(Application.StartupPath + "\\db\\ENCosmetics.txt");
                    int num = text.Split(new char[]
                    {
                        '\r'
                    }).Length;
                    List<int> unlocked_cosmetics = this.AccountFile.unlocked_cosmetics.unlocked_cosmetics_data.unlocked_cosmetics;
                    string[] array = text.Split(new string[]
                    {
                        "\r\n"
                    }, StringSplitOptions.None);
                    bool flag3 = num == unlocked_cosmetics.Count;
                    if (!flag3)
                    {
                        unlocked_cosmetics.Clear();
                        string[] temp = unlocked_cosmetics.Select(x => x.ToString()).ToArray();
                        var comp = array.ToArray().Except(temp);

                        foreach (string text3 in comp)
                        {
                            bool flag4 = string.IsNullOrEmpty(text3.ToString());
                            if (flag4)
                            {
                                break;
                            }
                            unlocked_cosmetics.Add(Convert.ToInt32(text3));
                        }
                    }
                }
            }
            else
            {
                this.AccountFile.unlocked_cosmetics.unlocked_cosmetics_data.unlocked_cosmetics.Clear();
            }
        }

        private void UnlockCube(int i, bool c)
        {
            if (c)
            {
                this.AccountFile.partitions[i].crafter_data.crafter_data[3].level = 1;
            }
            else
            {
                this.AccountFile.partitions[i].crafter_data.crafter_data[3].level = 0;
            }
        }

        private void UnlockPowers(int pIndex, bool c)
        {
            if (c)
            {
                this.AccountFile.partitions[pIndex].crafter_data.kanais_cube_data = new PB.ItemCrafting.CrafterKanaisCubeData
                {
                    extracted_legendaries = new PB.ItemCrafting.CrafterKanaisCubeData().extracted_legendaries
                };
                this.AccountFile.partitions[pIndex].crafter_data.kanais_cube_data.extracted_legendaries = new List<int>();
                if (File.Exists(Application.StartupPath + "\\db\\ENPowers.txt"))
                {
                    string text = File.ReadAllText(Application.StartupPath + "\\db\\ENPowers.txt");
                    int num = text.Split(new char[]
                    {
                        '\r'
                    }).Length;
                    List<int> extracted_legendaries = this.AccountFile.partitions[pIndex].crafter_data.kanais_cube_data.extracted_legendaries;
                    string[] array = text.Split(new string[]
                    {
                        "\r\n"
                    }, StringSplitOptions.None);
                    bool flag3 = num == extracted_legendaries.Count;
                    if (!flag3)
                    {
                        extracted_legendaries.Clear();
                        foreach (string text3 in array)
                        {
                            bool flag4 = string.IsNullOrEmpty(text3.ToString());
                            if (flag4)
                            {
                                break;
                            }
                            extracted_legendaries.Add(Convert.ToInt32(text3));
                        }
                    }
                }
            }
            else
            {
                try
                {
                    this.AccountFile.partitions[pIndex].crafter_data.kanais_cube_data.extracted_legendaries.Clear();
                }
                catch { }
            }
        }

        private void MaxArtisan(int i, bool c)
        {
            if (this.loaded)
            {
                CrafterData crafterData = this.AccountFile.partitions[i].crafter_data.crafter_data[0];
                CrafterData crafterData2 = this.AccountFile.partitions[i].crafter_data.crafter_data[1];
                CrafterData crafterData3 = this.AccountFile.partitions[i].crafter_data.crafter_data[2];
                if (c)
                {
                    crafterData.level = 56;
                    crafterData2.level = 12;
                    crafterData3.level = 12;
                }
                else
                {
                    crafterData.level = 0;
                    crafterData2.level = 0;
                    crafterData3.level = 0;
                }
            }
        }

        private void cube_sc_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            UnlockCube(Convert.ToInt32(cb.Tag.ToString()),cb.Checked);
        }

        private void powers_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            UnlockPowers(Convert.ToInt32(cb.Tag.ToString()), cb.Checked);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            MaxArtisan(Convert.ToInt32(cb.Tag.ToString()), cb.Checked);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if(!this.loaded)
            {
                return;
            }
            NumericUpDown nd = (NumericUpDown)sender;
            int i = Convert.ToInt32(nd.Tag);
            bool flag = false;
            for (int index = 0; index <= this.AccountFile.partitions[i].saved_attributes.attributes.Count - 1; ++index)
            {
                if (this.AccountFile.partitions[i].saved_attributes.attributes[index].key == -4093)
                {
                    this.AccountFile.partitions[i].saved_attributes.attributes[index].value = Convert.ToInt32(al_sc.Value);
                    flag = true;
                }
            }
            if (!flag)
                this.AccountFile.partitions[i].saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute()
                {
                    key = -4093,
                    value = Convert.ToInt32(al_sc.Value)
                });
            this.AccountFile.partitions[i].alt_level = Convert.ToUInt32(al_sc.Value);
        }

        private void al_sc_KeyUp(object sender, KeyEventArgs e)
        {
            if (!this.loaded)
            {
                return;
            }
            NumericUpDown nd = (NumericUpDown)sender;
            int i = Convert.ToInt32(nd.Tag);
            bool flag = false;
            for (int index = 0; index <= this.AccountFile.partitions[i].saved_attributes.attributes.Count - 1; ++index)
            {
                if (this.AccountFile.partitions[i].saved_attributes.attributes[index].key == -4093)
                {
                    this.AccountFile.partitions[i].saved_attributes.attributes[index].value = Convert.ToInt32(nd.Value);
                    flag = true;
                }
            }
            if (!flag)
                this.AccountFile.partitions[i].saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute()
                {
                    key = -4093,
                    value = Convert.ToInt32(nd.Value)
                });
            this.AccountFile.partitions[i].alt_level = Convert.ToUInt32(nd.Value);
        }

        private void GRValueChanged(object sender, EventArgs e)
        {
            if (!this.loaded)
            {
                return;
            }
            NumericUpDown cb = (NumericUpDown)sender;
            int pIndex = Convert.ToInt32(cb.Tag);
            bool exists1 = false;
            bool exists2 = false;
            for (int index = 0; index <= this.AccountFile.partitions[pIndex].saved_attributes.attributes.Count - 1; ++index)
            {
                if (this.AccountFile.partitions[pIndex].saved_attributes.attributes[index].key == -4077)
                {
                    this.AccountFile.partitions[pIndex].saved_attributes.attributes[index].value = Convert.ToInt32(cb.Value);
                    exists1 = true;
                }
                if (this.AccountFile.partitions[pIndex].saved_attributes.attributes[index].key == -4076)
                {
                    this.AccountFile.partitions[pIndex].saved_attributes.attributes[index].value = Convert.ToInt32(cb.Value);
                    exists2 = false;
                }
            }
            if (!(exists1))
            {
                this.AccountFile.partitions[pIndex].saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute()
                {
                    key = -4077,
                    value = Convert.ToInt32(cb.Value)
                });
            }
            if (!(exists2))
            {
                this.AccountFile.partitions[pIndex].saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute()
                {
                    key = -4076,
                    value = Convert.ToInt32(cb.Value)
                });
            }
        }

        private void tm_sc_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.loaded)
            {
                return;
            }
            CheckBox cb = (CheckBox)sender;
            int pIndex = Convert.ToInt32(cb.Tag);
            if (cb.Checked)
            {
                bool flag = string.IsNullOrEmpty(Application.StartupPath + "\\db\\ENTransmogs.txt");
                if (!flag)
                {
                    string text2 = File.ReadAllText(Application.StartupPath + "\\db\\ENTransmogs.txt");
                    int num = text2.Split(new char[]
                    {
                        '\r'
                    }).Length;
                    List<int> unlocked_transmogs = this.AccountFile.partitions[pIndex].crafter_data.transmog_data.unlocked_transmogs;
                    string[] array = text2.Split(new string[]
                    {
                        "\r\n"
                    }, StringSplitOptions.None);
                    bool flag2 = num != unlocked_transmogs.Count;
                    if (flag2)
                    {
                        unlocked_transmogs.Clear();
                        foreach (string text3 in array)
                        {
                            bool flag3 = string.IsNullOrEmpty(text3.ToString());
                            if (flag3)
                            {
                                break;
                            }
                            unlocked_transmogs.Add(Convert.ToInt32(text3));
                        }
                    }
                }
            }
            else
            {
                try
                {
                    this.AccountFile.partitions[pIndex].crafter_data.transmog_data.unlocked_transmogs.Clear();
                }
                catch { }
            }
        }

        private void cp_sc_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.loaded)
            {
                return;
            }
            CheckBox cb = (CheckBox)sender;
            int pIndex = Convert.ToInt32(cb.Tag);
            if (cb.Checked)
            {
                this.AccountFile.partitions[pIndex].crafter_data.crafter_data[0].recipes = new List<int> {
                    168420403,
                    -564058518,
                    -924082710,
                    -1109650836,
                    -1155974231,
                    2085798197,
                    -157976391,
                    -1172072918,
                    -1433699158,
                    -1417600471,
                    -425764311
                };
                this.AccountFile.partitions[pIndex].crafter_data.crafter_data[0].recipes_bitfield = new byte[]
                {
                    35,
                    125,
                    6,
                    160,
                    29,
                    192,
                    18,
                    3,
                    166,
                    44,
                    153,
                    1,
                    64,
                    200,
                    85,
                    84,
                    20,
                    148,
                    137,
                    115,
                    16,
                    194,
                    13,
                    114,
                    152,
                    61,
                    33,
                    195,
                    83,
                    237,
                    217,
                    255,
                    255,
                    255,
                    127,
                    229,
                    7
                };
                this.AccountFile.partitions[pIndex].crafter_data.crafter_data[1].bitfield_leading_null_bytes = 25;
                this.AccountFile.partitions[pIndex].crafter_data.crafter_data[1].recipes_bitfield = new byte[]
                {
                    64,
                    92,
                    32,
                    36,
                    0,
                    36
                };
            }
            else
            {
                this.AccountFile.partitions[pIndex].crafter_data.crafter_data[0].recipes = new List<int>();
                this.AccountFile.partitions[pIndex].crafter_data.crafter_data[0].recipes_bitfield = null;
                this.AccountFile.partitions[pIndex].crafter_data.crafter_data[1].bitfield_leading_null_bytes = 0;
                this.AccountFile.partitions[pIndex].crafter_data.crafter_data[1].recipes_bitfield = null;
            }
        }

        private void xp_sc_ValueChanged(object sender, EventArgs e)
        {
            if (!this.loaded)
            {
                return;
            }
            NumericUpDown nd = (NumericUpDown)sender;
            int i = Convert.ToInt32(nd.Tag);
            for (int index = 0; index <= this.AccountFile.partitions[i].saved_attributes.attributes.Count - 1; ++index)
            {
                if (this.AccountFile.partitions[i].saved_attributes.attributes[index].key == -4094)
                    this.AccountFile.partitions[i].saved_attributes.attributes[index].value = Convert.ToInt32(nd.Value);
            }
        }

        private void xp_sc_KeyUp(object sender, KeyEventArgs e)
        {
            if (!this.loaded)
            {
                return;
            }
            NumericUpDown nd = (NumericUpDown)sender;
            int i = Convert.ToInt32(nd.Tag);
            for (int index = 0; index <= this.AccountFile.partitions[i].saved_attributes.attributes.Count - 1; ++index)
            {
                if (this.AccountFile.partitions[i].saved_attributes.attributes[index].key == -4094)
                    this.AccountFile.partitions[i].saved_attributes.attributes[index].value = Convert.ToInt32(nd.Value);
            }
        }

        private void stash_sc_ValueChanged(object sender, EventArgs e)
        {
            if (!this.loaded)
            {
                return;
            }
            NumericUpDown nd = (NumericUpDown)sender;
            int i = Convert.ToInt32(nd.Tag);
            bool p = false;
            switch (i)
            {
                case 0:
                    for (int index = 0; index <= this.AccountFile.deprecated_saved_attributes.attributes.Count - 1; ++index)
                    {
                        if (this.AccountFile.deprecated_saved_attributes.attributes[index].key == -4096)
                        {
                            this.AccountFile.deprecated_saved_attributes.attributes[index].value = Convert.ToInt32(nd.Value);
                            p = true;
                        }
                    }
                    if (!p)
                        this.AccountFile.deprecated_saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute()
                            { key = 4096, value = Convert.ToInt32(nd.Value) });
                    break;
                case 1:
                    if(this.AccountFile.deprecated_saved_attributes_hardcore != null)
                    {
                        for (int index = 0; index <= this.AccountFile.deprecated_saved_attributes_hardcore.attributes.Count - 1; ++index)
                        {
                            if (this.AccountFile.deprecated_saved_attributes_hardcore.attributes[index].key == -4096)
                            {
                                this.AccountFile.deprecated_saved_attributes_hardcore.attributes[index].value = Convert.ToInt32(nd.Value);
                                p = true;
                            }
                        }
                        if (!p)
                            this.AccountFile.deprecated_saved_attributes_hardcore.attributes.Add(new PB.AttributeSerializer.SavedAttribute()
                            { key = 4096, value = Convert.ToInt32(nd.Value) });
                    }
                    break;
                case 2:
                    for (int index = 0; index <= this.AccountFile.deprecated_saved_attributes.attributes.Count - 1; ++index)
                    {
                        if (this.AccountFile.deprecated_saved_attributes.attributes[index].key == -4096)
                        {
                            this.AccountFile.deprecated_saved_attributes.attributes[index].value = Convert.ToInt32(nd.Value);
                            p = true;
                        }
                    }
                    if (!p)
                        this.AccountFile.deprecated_saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute()
                        { key = 4096, value = Convert.ToInt32(nd.Value) });
                    break;
                case 3:
                    if (this.AccountFile.deprecated_saved_attributes_hardcore != null)
                    {
                        for (int index = 0; index <= this.AccountFile.deprecated_saved_attributes_hardcore.attributes.Count - 1; ++index)
                        {
                            if (this.AccountFile.deprecated_saved_attributes_hardcore.attributes[index].key == -4096)
                            {
                                this.AccountFile.deprecated_saved_attributes_hardcore.attributes[index].value = Convert.ToInt32(nd.Value);
                                p = true;
                            }
                        }
                        if (!p)
                            this.AccountFile.deprecated_saved_attributes_hardcore.attributes.Add(new PB.AttributeSerializer.SavedAttribute()
                            { key = 4096, value = Convert.ToInt32(nd.Value) });
                    }
                    break;
            }
            p = false;
            for (int index = 0; index <= this.AccountFile.partitions[i].saved_attributes.attributes.Count - 1; ++index)
            {
                if (this.AccountFile.partitions[i].saved_attributes.attributes[index].key == -4096)
                {
                    this.AccountFile.partitions[i].saved_attributes.attributes[index].value = Convert.ToInt32(nd.Value);
                    p = true;
                }
            }
            if(!p)
                this.AccountFile.partitions[i].saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute() { key = -4096, value = Convert.ToInt32(nd.Value) } );
        }

        private void stash_sc_KeyUp(object sender, KeyEventArgs e)
        {
            if (!this.loaded)
            {
                return;
            }
            NumericUpDown nd = (NumericUpDown)sender;
            int i = Convert.ToInt32(nd.Tag);
            for (int index = 0; index <= this.AccountFile.partitions[i].saved_attributes.attributes.Count - 1; ++index)
            {
                if (this.AccountFile.partitions[i].saved_attributes.attributes[index].key == -4096)
                    this.AccountFile.partitions[i].saved_attributes.attributes[index].value = Convert.ToInt32(nd.Value);
            }
            this.AccountFile.partitions[i].saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute() { key = -4096, value = Convert.ToInt32(nd.Value) });
        }

        private void mats_CheckedChanged(object sender, EventArgs e)
        {
            if(loaded)
            {
                CheckBox cb = (CheckBox)sender;
                if (cb.Checked)
                {
                    int p = Convert.ToInt32(cb.Tag);
                    try
                    {
                        foreach (PB.Items.Currency mat in this.AccountFile.partitions[p].currency_data.currency)
                        {
                            mat.amount = 2147483647;
                        }
                    }
                    catch { }
                }
                else
                {
                    int p = Convert.ToInt32(cb.Tag);
                    try
                    {
                        foreach (PB.Items.Currency mat in this.AccountFile.partitions[p].currency_data.currency)
                        {
                            mat.amount = 0;
                        }
                    }
                    catch { }
                }
            }
        }

        private void PopulateMatKeys(int pIndex)
        {
            if (this.AccountFile.partitions[pIndex].currency_data == null)
                this.AccountFile.partitions[pIndex].currency_data = new PB.Items.CurrencySavedData();
            if (this.AccountFile.partitions[pIndex].currency_data.currency == null)
                this.AccountFile.partitions[pIndex].currency_data.currency = new List<PB.Items.Currency>();
            //Gold
            if (!(this.AccountFile.partitions[pIndex].currency_data.currency.Any(item => item.index == 0)))
            {
                this.AccountFile.partitions[pIndex].currency_data.currency.Add(new PB.Items.Currency()
                {
                    amount = 1,
                    index = 0,
                    tab = -1
                });
            }
            //Bloodshards
            if (!(this.AccountFile.partitions[pIndex].currency_data.currency.Any(item => item.index == 1)))
            {
                this.AccountFile.partitions[pIndex].currency_data.currency.Add(new PB.Items.Currency()
                {
                    amount = 1,
                    index = 1,
                    tab = -1
                });
            }
            //Reusable Parts
            if (!(this.AccountFile.partitions[pIndex].currency_data.currency.Any(item => item.index == 3)))
            {
                this.AccountFile.partitions[pIndex].currency_data.currency.Add(new PB.Items.Currency()
                {
                    amount = 1,
                    index = 3,
                    tab = -1
                });
            }
            //Arcane Dust
            if (!(this.AccountFile.partitions[pIndex].currency_data.currency.Any(item => item.index == 4)))
            {
                this.AccountFile.partitions[pIndex].currency_data.currency.Add(new PB.Items.Currency()
                {
                    amount = 1,
                    index = 4,
                    tab = -1
                });
            }
            //Veiled Crystal
            if (!(this.AccountFile.partitions[pIndex].currency_data.currency.Any(item => item.index == 5)))
            {
                this.AccountFile.partitions[pIndex].currency_data.currency.Add(new PB.Items.Currency()
                {
                    amount = 1,
                    index = 5,
                    tab = -1
                });
            }
            //Deaths Breath
            if (!(this.AccountFile.partitions[pIndex].currency_data.currency.Any(item => item.index == 6)))
            {
                this.AccountFile.partitions[pIndex].currency_data.currency.Add(new PB.Items.Currency()
                {
                    amount = 1,
                    index = 6,
                    tab = -1
                });
            }
            //Forgotten Souls
            if (!(this.AccountFile.partitions[pIndex].currency_data.currency.Any(item => item.index == 7)))
            {
                this.AccountFile.partitions[pIndex].currency_data.currency.Add(new PB.Items.Currency()
                {
                    amount = 1,
                    index = 7,
                    tab = -1
                });
            }
            //Khanduran Rune
            if (!(this.AccountFile.partitions[pIndex].currency_data.currency.Any(item => item.index == 8)))
            {
                this.AccountFile.partitions[pIndex].currency_data.currency.Add(new PB.Items.Currency()
                {
                    amount = 1,
                    index = 8,
                    tab = -1
                });
            }
            //Caldeum Nightshade
            if (!(this.AccountFile.partitions[pIndex].currency_data.currency.Any(item => item.index == 9)))
            {
                this.AccountFile.partitions[pIndex].currency_data.currency.Add(new PB.Items.Currency()
                {
                    amount = 1,
                    index = 9,
                    tab = -1
                });
            }
            //Arreat War Tapestry
            if (!(this.AccountFile.partitions[pIndex].currency_data.currency.Any(item => item.index == 10)))
            {
                this.AccountFile.partitions[pIndex].currency_data.currency.Add(new PB.Items.Currency()
                {
                    amount = 1,
                    index = 10,
                    tab = -1
                });
            }
            //Corrupted Angel Flesh
            if (!(this.AccountFile.partitions[pIndex].currency_data.currency.Any(item => item.index == 11)))
            {
                this.AccountFile.partitions[pIndex].currency_data.currency.Add(new PB.Items.Currency()
                {
                    amount = 1,
                    index = 11,
                    tab = -1
                });
            }
            //Westmarch Holy Water
            if (!(this.AccountFile.partitions[pIndex].currency_data.currency.Any(item => item.index == 12)))
            {
                this.AccountFile.partitions[pIndex].currency_data.currency.Add(new PB.Items.Currency()
                {
                    amount = 1,
                    index = 12,
                    tab = -1
                });
            }
            //Heart of Fright
            if (!(this.AccountFile.partitions[pIndex].currency_data.currency.Any(item => item.index == 13)))
            {
                this.AccountFile.partitions[pIndex].currency_data.currency.Add(new PB.Items.Currency()
                {
                    amount = 1,
                    index = 13,
                    tab = -1
                });
            }
            //Vial of Putridness
            if (!(this.AccountFile.partitions[pIndex].currency_data.currency.Any(item => item.index == 14)))
            {
                this.AccountFile.partitions[pIndex].currency_data.currency.Add(new PB.Items.Currency()
                {
                    amount = 1,
                    index = 14,
                    tab = -1
                });
            }
            //Idol of Terror
            if (!(this.AccountFile.partitions[pIndex].currency_data.currency.Any(item => item.index == 15)))
            {
                this.AccountFile.partitions[pIndex].currency_data.currency.Add(new PB.Items.Currency()
                {
                    amount = 1,
                    index = 15,
                    tab = -1
                });
            }
            //Leoric's Regret
            if (!(this.AccountFile.partitions[pIndex].currency_data.currency.Any(item => item.index == 16)))
            {
                this.AccountFile.partitions[pIndex].currency_data.currency.Add(new PB.Items.Currency()
                {
                    amount = 1,
                    index = 16,
                    tab = -1
                });
            }
            //Vengeful Eye
            if (!(this.AccountFile.partitions[pIndex].currency_data.currency.Any(item => item.index == 17)))
            {
                this.AccountFile.partitions[pIndex].currency_data.currency.Add(new PB.Items.Currency()
                {
                    amount = 1,
                    index = 17,
                    tab = -1
                });
            }
            //Writhing Spine
            if (!(this.AccountFile.partitions[pIndex].currency_data.currency.Any(item => item.index == 18)))
            {
                this.AccountFile.partitions[pIndex].currency_data.currency.Add(new PB.Items.Currency()
                {
                    amount = 1,
                    index = 18,
                    tab = -1
                });
            }
            //Devil's Fang
            if (!(this.AccountFile.partitions[pIndex].currency_data.currency.Any(item => item.index == 19)))
            {
                this.AccountFile.partitions[pIndex].currency_data.currency.Add(new PB.Items.Currency()
                {
                    amount = 1,
                    index = 19,
                    tab = -1
                });
            }
            //GR Keys
            if (!(this.AccountFile.partitions[pIndex].currency_data.currency.Any(item => item.index == 20)))
            {
                this.AccountFile.partitions[pIndex].currency_data.currency.Add(new PB.Items.Currency()
                {
                    amount = 1,
                    index = 20,
                    tab = -1
                });
            }
        }

        private void GRValueChanged(object sender, KeyEventArgs e)
        {
            if (!this.loaded)
            {
                return;
            }
            NumericUpDown cb = (NumericUpDown)sender;
            int pIndex = Convert.ToInt32(cb.Tag);
            bool exists1 = false;
            bool exists2 = false;
            for (int index = 0; index <= this.AccountFile.partitions[pIndex].saved_attributes.attributes.Count - 1; ++index)
            {
                if (this.AccountFile.partitions[pIndex].saved_attributes.attributes[index].key == -4077)
                {
                    this.AccountFile.partitions[pIndex].saved_attributes.attributes[index].value = Convert.ToInt32(cb.Value);
                    exists1 = true;
                }
                if (this.AccountFile.partitions[pIndex].saved_attributes.attributes[index].key == -4076)
                {
                    this.AccountFile.partitions[pIndex].saved_attributes.attributes[index].value = Convert.ToInt32(cb.Value);
                    exists2 = true;
                }
            }
            if (!(exists1))
            {
                this.AccountFile.partitions[pIndex].saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute()
                {
                    key = -4077,
                    value = Convert.ToInt32(cb.Value)
                });
            }
            if (!(exists2))
            {
                this.AccountFile.partitions[pIndex].saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute()
                {
                    key = -4076,
                    value = Convert.ToInt32(cb.Value)
                });
            }
        }

        private void flags(object sender, EventArgs e)
        {
            if (!loaded)
                return;
            NumericUpDown nu = (NumericUpDown)sender;
            this.AccountFile.partitions[Convert.ToInt32(nu.Tag)].flags = Convert.ToInt32(nu.Value);
        }

        private void flags(object sender, KeyEventArgs e)
        {
            if (!loaded)
                return;
            NumericUpDown nu = (NumericUpDown)sender;
            this.AccountFile.partitions[Convert.ToInt32(nu.Tag)].flags = Convert.ToInt32(nu.Value);
        }

        private void soloRift_CheckedChanged(object sender, EventArgs e)
        {
            if (!loaded)
                return;
            this.AccountFile.digest.completed_solo_rift = ((CheckBox)sender).Checked;
        }

        private void bloodshards_sc_ValueChanged(object sender, EventArgs e)
        {
            if (!loaded)
                return;
            NumericUpDown nu = (NumericUpDown)sender;
            int pIndex = (int)nu.Tag;
            this.AccountFile.partitions[pIndex].currency_data.currency[0].amount = Convert.ToUInt64(nu.Value);
        }

        private void bloodshards_sc_KeyUp(object sender, KeyEventArgs e)
        {
            if (!loaded)
                return;
            NumericUpDown nu = (NumericUpDown)sender;
            int pIndex = (int)nu.Tag;
            this.AccountFile.partitions[pIndex].currency_data.currency[0].amount = Convert.ToUInt64(nu.Value);
        }

        private void isHardcore_CheckedChanged(object sender, EventArgs e)
        {
            if (!loaded)
                return;
            bool chk = ((CheckBox)sender).Checked;
            if(chk)
            {
                this.AccountFile.digest.flags = 2U;
            }
            else
            {
                this.AccountFile.digest.flags = 0U;
            }
        }
    }
}
