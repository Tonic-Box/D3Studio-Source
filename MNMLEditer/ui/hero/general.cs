using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D3Studio.ui.hero
{
    public partial class general : UserControl
    {
        public PB.Hero.SavedDefinition HeroFile { get; set; }

        public PB.Console.HeroInfoList IdxFile { get; set; }
        public string file { get; set; }

        public bool loaded = false;

        public general()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }
        public void populate()
        {
            this.fileName.Text = this.file;
            this.heroName.Text = this.HeroFile.digest.hero_name;
            this.heroLevel.Value = Convert.ToDecimal(this.HeroFile.digest.level);
            LoadClassCombo();
            this.classCombo.SelectedValue = this.HeroFile.digest.gbid_class;
            LoadHeroMode();
            loadSexCore();
            int hc = BitConverter.GetBytes(this.HeroFile.digest.player_flags)[0];
            this.herocore.SelectedValue = hc;
            LoadHighestAct();
            this.highestAct.SelectedValue = this.HeroFile.digest.highest_unlocked_act;
            AddMissingAttributes();
            LoadHeroStats();
            if (this.HeroFile.digest.quest_history.Count >= 40)
            {
                this.quests.Checked = true;
            }
            try
            {
                this.soloGR.Value = Convert.ToDecimal(this.HeroFile.digest.highest_solo_rift_completed);
            }
            catch
            {
                this.HeroFile.digest.highest_solo_rift_completed = 0;
                this.soloGR.Value = Convert.ToDecimal(0);
            }
            this.heroID.Value = Convert.ToDecimal(this.HeroFile.digest.hero_id.id_low);
            this.loaded = true;
        }

        public void LoadHeroStats()
        {
            this.ParagonStatsGrid.Controls.Clear();
            this.ParagonStatsGrid.RowStyles.Clear();
            ParagonStatsGrid.RowCount = 0;
            this.HeroFile.saved_attributes.attributes = this.HeroFile.saved_attributes.attributes.GroupBy(x => x.key).Select(x => x.First()).ToList();
            foreach (PB.AttributeSerializer.SavedAttribute attr in this.HeroFile.saved_attributes.attributes)
            {
                if (this.Checkvalue(attr.key) != attr.key.ToString())
                {
                    ParagonStatsGrid.RowCount = ParagonStatsGrid.RowCount + 1;
                    ParagonStatsGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
                    stat Stat = new stat();
                    try
                    {
                        Stat.HeroFile = this.HeroFile;
                        Stat.key = attr.key;
                        Stat.parent = this;
                        Stat.populate();
                    }
                    catch (Exception e)
                    {
                        //MessageBox.Show(e.ToString());
                    }
                    this.ParagonStatsGrid.Controls.Add(Stat, 0, ParagonStatsGrid.RowCount - 1);
                    Stat.Dock = DockStyle.Fill;
                }
            }
            ParagonStatsGrid.RowCount = ParagonStatsGrid.RowCount + 1;
            ParagonStatsGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
        }

        private string Checkvalue(int key)
        {
            string str = key.ToString();
            switch (key)
            {
                case -934182592:
                    str = "Gold Find/Pickup Radius";
                    break;
                case -1973739200:
                    str = "Attack Speed";
                    break;
                case -1811361472:
                    str = "Cooldown Reduction";
                    break;
                case -1673830080:
                    str = "Vitality";
                    break;
                case -1656495808:
                    str = "[Crusader] Max Wrath";
                    break;
                case -895147712:
                    str = "Life Percent";
                    break;
                case -879546048:
                    str = "Life Regeneration";
                    break;
                case -661155520:
                    str = "[Wizard] Max Arcane Power";
                    break;
                case -501998414:
                    str = "[Necromancer] Max Essence";
                    break;
                case -82398912:
                    str = "[Necromancer] Max Essence";
                    break;
                case -339066560:
                    str = "[Wizard] Intelligence";
                    break;
                case -161611456:
                    str = "Critical Hit Damage";
                    break;
                case -100925120:
                    str = "[Necromancer] Intelligence";
                    break;
                case -4016:
                    str = "level";
                    break;
                case 64844096:
                    str = "[Monk] Dexterity";
                    break;
                case 299651392:
                    str = "Area Damage";
                    break;
                case 402223424:
                    str = "Armor";
                    break;
                case 580981056:
                    str = "[Barbarian] Strength";
                    break;
                case 737493312:
                    str = "Critical Hit Chance";
                    break;
                case 776950080:
                    str = "Movement Speed";
                    break;
                case 831545664:
                    str = "[Legacy] Gold Find/Pickup Radius";
                    break;
                case 877273408:
                    str = "Life on Hit";
                    break;
                case 930300224:
                    str = "Resource Cost Reduction";
                    break;
                case 1076269376:
                    str = "Resist All";
                    break;
                case 1081442624:
                    str = "[Barbarian] Max Fury";
                    break;
                case 1167896896:
                    str = "[Demon Hunter] Dexterity";
                    break;
                case 1255055680:
                    str = "[Demon Hunter] Max Hatred";
                    break;
                case 1272348992:
                    str = "[Crusader] Strength";
                    break;
                case 1557123392:
                    str = "[Witch Doctor] Intelligence";
                    break;
                case 1832702272:
                    str = "[Monk] Max Spirit";
                    break;
                case 2021978432:
                    str = "[Witch Doctor] Max Mana";
                    break;
                case -3632:
                    str = "Hidden Life Stat";
                    break;
            }
            return str;
        }

        private void LoadHeroMode()
        {
            if (this.HeroFile.digest.season_created == 22)
            {
                this.heroType.Text = "Seasonal";
            }
            else
            {
                this.heroType.Text = "";
            }
            int hc = BitConverter.GetBytes(this.HeroFile.digest.player_flags)[0];
            if (hc == 1 || hc == 3 || hc == 5 || hc == 7)
            {
                this.heroType.Text = "HardCore " + this.heroType.Text;
            }
            else if (hc == 8 || hc == 9 || hc == 10 || hc == 11)
            {
                this.heroType.Text = "Dead HardCore " + this.heroType.Text;
            }
            else
            {
                this.heroType.Text = "SoftCore " + this.heroType.Text;
            }
            if (hc == 0 || hc == 1 || hc == 4 || hc == 5 || hc == 8 || hc == 9)
            {
                this.heroType.Text = this.heroType.Text + " Male";
            }
            else
            {
                this.heroType.Text = this.heroType.Text + " Female";
            }
        }

        private void LoadHighestAct()
        {
            var acts = new[]
            {
                new { Text = "Act I", Value = 0 },
                new { Text = "Act II", Value = 100 },
                new { Text = "Act III", Value = 200 },
                new { Text = "Act IV", Value = 300 },
                new { Text = "Act V", Value = 400 },
                new { Text = "Adventure Mode", Value = 3000 }
            };
            this.highestAct.DisplayMember = "Text";
            this.highestAct.ValueMember = "Value";
            this.highestAct.DataSource = acts;
        }

        public void loadSexCore()
        {
            var core = new[]
            {
                new { Text = "[0] Normal Male", Value = 0 },
                new { Text = "[4] Normal Male (Seasonal)", Value = 4 },
                new { Text = "[6] Normal Female", Value = 6 },
                new { Text = "[2] Normal Female (Seasonal)", Value = 2 },
                new { Text = "[5] Hardcore Male", Value = 5 },
                new { Text = "[1] Hardcore Male (Seasonal)", Value = 1 },
                new { Text = "[7] Hardcore Female", Value = 7 },
                new { Text = "[3] Hardcore Female (Seasonal)", Value = 3 },
                new { Text = "[8] Dead Hardcore male", Value = 8 },
                new { Text = "[9] Dead Hardcore male", Value = 9 },
                new { Text = "[10] Dead Hardcore female", Value = 10 },
                new { Text = "[11] Dead Hardcore female", Value = 11 }
            };
            this.herocore.DisplayMember = "Text";
            this.herocore.ValueMember = "Value";
            this.herocore.DataSource = core;
        }

        private void LoadClassCombo()
        {
            var classes = new[]
            {
                new { Text = "Barbarian", Value = 1337532130 },
                new { Text = "Demon Hunter", Value = -930376119 },
                new { Text = "Monk", Value = 4041749 },
                new { Text = "Witch Doctor", Value = 54772266 },
                new { Text = "Wizard", Value = 491159985 },
                new { Text = "Crusader", Value = -1104684007 },
                new { Text = "Necromancer", Value = -1924295443 }
            };
            this.classCombo.DisplayMember = "Text";
            this.classCombo.ValueMember = "Value";
            this.classCombo.DataSource = classes;
        }

        private void heroName_TextChanged(object sender, EventArgs e)
        {
            this.HeroFile.digest.hero_name = this.heroName.Text;
            try
            {
                if (this.IdxFile != null)
                    this.IdxFile.heroes.First(x => x.filename == this.file).hero_name = this.heroName.Text;
            }
            catch { }
        }

        private void classCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                this.HeroFile.digest.gbid_class = int.Parse(this.classCombo.SelectedValue.ToString());
                this.HeroFile.saved_attributes.gb_handle.gbid = int.Parse(this.classCombo.SelectedValue.ToString());
                try
                {
                    if (this.IdxFile != null)
                        this.IdxFile.heroes.First(x => x.filename == this.file).gbid_class = int.Parse(this.classCombo.SelectedValue.ToString());
                }
                catch { }
            }
        }

        private void highestAct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                this.HeroFile.digest.highest_unlocked_act = int.Parse(this.highestAct.SelectedValue.ToString());
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void heroLevel_KeyUp(object sender, KeyEventArgs e)
        {
            for (int index = 0; index <= this.HeroFile.saved_attributes.attributes.Count - 1; ++index)
            {
                if (this.HeroFile.saved_attributes.attributes[index].key == -4016)
                    this.HeroFile.saved_attributes.attributes[index].value = Convert.ToInt32(heroLevel.Value);
            }
            this.HeroFile.digest.level = Convert.ToInt32(heroLevel.Value);
            try
            {
                if (this.IdxFile != null)
                    this.IdxFile.heroes.First(x => x.filename == this.file).level = Convert.ToInt32(heroLevel.Value);
            }
            catch { }
            LoadHeroStats();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void quests_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.loaded)
                return;
            if (this.quests.Checked)
            {
                int[] quests =
                {
                    87700, 72095, 72221, 72061, 117779, 72738, 73236, 72546, 72801, 136656, 80322, 93396, 74128,
                    57331, 78264, 78266, 57335, 57337, 121792, 57339, 93595, 93684, 93697, 203595, 101756, 101750,
                    101758, 112498, 113910, 114795, 114901, 251355, 284683, 285098, 257120, 263851, 273790, 269552,
                    273408, 312429
                };
                this.HeroFile.digest.quest_history.Clear();
                foreach (int quest in quests)
                {
                    PB.Hero.QuestHistoryEntry questHistoryEntry = new PB.Hero.QuestHistoryEntry();
                    questHistoryEntry.difficulty = 0;
                    questHistoryEntry.sno_quest = quest;
                    questHistoryEntry.highest_played_quest_step = -3;
                    this.HeroFile.digest.quest_history.Add(questHistoryEntry);
                }
            }
            else
            {
                this.HeroFile.digest.quest_history.Clear();
            }
        }

        private void AddMissingAttributes()
        {
            //Hero Level
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == -4016)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = -4016,
                    value = 1
                });
            }
            //Attack Speed
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == -1973739200)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = -1973739200,
                    value = 0
                });
            }
            //CDR
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == -1811361472)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = -1811361472,
                    value = 0
                });
            }
            //Vitality
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == -1673830080)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = -1673830080,
                    value = 0
                });
            }
            //Life Percent
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == -895147712)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = -895147712,
                    value = 0
                });
            }
            //Life Regeneration
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == -879546048)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = -879546048,
                    value = 0
                });
            }
            //Crit Hit Damage
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == -161611456)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = -161611456,
                    value = 0
                });
            }
            //Area Damage
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 299651392)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = 299651392,
                    value = 0
                });
            }
            //Armor
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 402223424)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = 402223424,
                    value = 0
                });
            }
            //Crit Hit Chance
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 737493312)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = 737493312,
                    value = 0
                });
            }
            //Movement Speed
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 776950080)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = 776950080,
                    value = 0
                });
            }
            //Gold Find
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 831545664)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = 831545664,
                    value = 0
                });
            }
            //Gold Find 2
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == -934182592)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = -934182592,
                    value = 0
                });
            }
            //Life on Hit
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 877273408)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = 877273408,
                    value = 0
                });
            }
            //RCR
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 930300224)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = 930300224,
                    value = 0
                });
            }
            //Resist All
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1076269376)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = 1076269376,
                    value = 0
                });
            }
            //If Barb
            if (HeroFile.digest.gbid_class == 1337532130)
            {
                //Max Fury
                if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1081442624)))
                {
                    this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                    {
                        key = 1081442624,
                        value = 0
                    });
                }
                //[Barbarian] Strength
                if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 580981056)))
                {
                    this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                    {
                        key = 580981056,
                        value = 0
                    });
                }
                //[Monk] Dexterity
                if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 64844096)) &&
                    !(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1167896896)))
                {
                    this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                    {
                        key = 64844096,
                        value = 0
                    });
                }
                //[WitchDoctor] Intelligence
                if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1557123392)) &&
                    !(this.HeroFile.saved_attributes.attributes.Any(item => item.key == -339066560)) &&
                    !(this.HeroFile.saved_attributes.attributes.Any(item => item.key == -100925120)))
                {
                    this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                    {
                        key = 1557123392,
                        value = 0
                    });
                }
            }

            //If DH
            if (HeroFile.digest.gbid_class == -930376119)
            {
                //Max Hatred
                if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1255055680)))
                {
                    this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                    {
                        key = 1255055680,
                        value = 0
                    });
                }
                //[DemonHunter] Dexterity
                if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1167896896)))
                {
                    this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                    {
                        key = 1167896896,
                        value = 0
                    });
                }
                //[Barbarian] Strength
                if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 580981056)) &&
                    !(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1272348992)))
                {
                    this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                    {
                        key = 580981056,
                        value = 0
                    });
                }
                //[WitchDoctor] Intelligence
                if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1557123392)) &&
                    !(this.HeroFile.saved_attributes.attributes.Any(item => item.key == -339066560)) &&
                    !(this.HeroFile.saved_attributes.attributes.Any(item => item.key == -100925120)))
                {
                    this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                    {
                        key = 1557123392,
                        value = 0
                    });
                }
            }

            //if Monk
            if (HeroFile.digest.gbid_class == 4041749)
            {
                //Max Spirit
                if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1832702272)))
                {
                    this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                    {
                        key = 1832702272,
                        value = 0
                    });
                }
                //[Monk] Dexterity
                if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 64844096)))
                {
                    this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                    {
                        key = 64844096,
                        value = 0
                    });
                }
                //[Barbarian] Strength
                if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 580981056)) &&
                    !(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1272348992)))
                {
                    this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                    {
                        key = 580981056,
                        value = 0
                    });
                }
                //[WitchDoctor] Intelligence
                if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1557123392)) &&
                    !(this.HeroFile.saved_attributes.attributes.Any(item => item.key == -339066560)) &&
                    !(this.HeroFile.saved_attributes.attributes.Any(item => item.key == -100925120)))
                {
                    this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                    {
                        key = 1557123392,
                        value = 0
                    });
                }
            }

            //if WD
            if (HeroFile.digest.gbid_class == 54772266)
            {
                //Max Mana
                if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 2021978432)))
                {
                    this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                    {
                        key = 2021978432,
                        value = 0
                    });
                }
                //[WitchDoctor] Intelligence
                if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1557123392)))
                {
                    this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                    {
                        key = 1557123392,
                        value = 0
                    });
                }
                //[Barbarian] Strength
                if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 580981056)) &&
                    !(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1272348992)))
                {
                    this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                    {
                        key = 580981056,
                        value = 0
                    });
                }
                //[Monk] Dexterity
                if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 64844096)) &&
                    !(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1167896896)))
                {
                    this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                    {
                        key = 64844096,
                        value = 0
                    });
                }
            }

            //If Wizard
            if (HeroFile.digest.gbid_class == 491159985)
            {
                //Max Arcane Power
                if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == -661155520)))
                {
                    this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                    {
                        key = -661155520,
                        value = 0
                    });
                }
                //[Wizard] Intelligence
                if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == -339066560)))
                {
                    this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                    {
                        key = -339066560,
                        value = 0
                    });
                }
                //[Barbarian] Strength
                if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 580981056)) &&
                    !(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1272348992)))
                {
                    this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                    {
                        key = 580981056,
                        value = 0
                    });
                }
                //[Monk] Dexterity
                if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 64844096)) &&
                    !(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1167896896)))
                {
                    this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                    {
                        key = 64844096,
                        value = 0
                    });
                }
            }

            //If Sader
            if (HeroFile.digest.gbid_class == -1104684007)
            {
                //Max Wrath
                if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == -1656495808)))
                {
                    this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                    {
                        key = -1656495808,
                        value = 0
                    });
                }
                //[Crusader] Strength
                if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1272348992)))
                {
                    this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                    {
                        key = 1272348992,
                        value = 0
                    });
                }
                //[Monk] Dexterity
                if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 64844096)) &&
                    !(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1167896896)))
                {
                    this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                    {
                        key = 64844096,
                        value = 0
                    });
                }
                //[WitchDoctor] Intelligence
                if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1557123392)) &&
                    !(this.HeroFile.saved_attributes.attributes.Any(item => item.key == -339066560)) &&
                    !(this.HeroFile.saved_attributes.attributes.Any(item => item.key == -100925120)))
                {
                    this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                    {
                        key = 1557123392,
                        value = 0
                    });
                }
            }
        }

        public void AddAllClassMS()
        {
            //[Barbarian] Strength
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 580981056)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = 580981056,
                    value = 0
                });
            }
            //[Crusader] Strength
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1272348992)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = 1272348992,
                    value = 0
                });
            }
            //[Monk] Dexterity
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 64844096)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = 64844096,
                    value = 0
                });
            }
            //[DemonHunter] Dexterity
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1167896896)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = 1167896896,
                    value = 0
                });
            }
            //[WitchDoctor] Intelligence
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1557123392)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = 1557123392,
                    value = 0
                });
            }
            //[Wizard] Intelligence
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == -339066560)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = -339066560,
                    value = 0
                });
            }
            //[Necromancer] Intelligence
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == -100925120)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = -100925120,
                    value = 0
                });
            }
        }

        public void AddAllClassResources()
        {
            //Max Essence
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == -82398912)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = -82398912,
                    value = 0
                });
            }
            //Max Wrath
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == -1656495808)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = -1656495808,
                    value = 0
                });
            }
            //Max Arcane Power
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == -661155520)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = -661155520,
                    value = 0
                });
            }
            //Max Mana
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 2021978432)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = 2021978432,
                    value = 0
                });
            }
            //Max Spirit
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1832702272)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = 1832702272,
                    value = 0
                });
            }
            //Max Hatred
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1255055680)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = 1255055680,
                    value = 0
                });
            }
            //Max Fury
            if (!(this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1081442624)))
            {
                this.HeroFile.saved_attributes.attributes.Add(new PB.AttributeSerializer.SavedAttribute
                {
                    key = 1081442624,
                    value = 0
                });
            }
        }

        private void Auto21Dots()
        {
            this.AddMissingAttributes();
            //HeroFile.saved_attributes.attributes.Single(x => x.key == myValue).value = newValue;
            //[Barbarian] Strength
            if ((this.HeroFile.saved_attributes.attributes.Any(item => item.key == 580981056)))
            {
                this.HeroFile.saved_attributes.attributes.Single(x => x.key == 580981056).value = -1999999500;
            }
            //[Crusader] Strength
            if ((this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1272348992)))
            {
                this.HeroFile.saved_attributes.attributes.Single(x => x.key == 1272348992).value = -1999999500;
            }
            //[Monk] Dexterity
            if ((this.HeroFile.saved_attributes.attributes.Any(item => item.key == 64844096)))
            {
                this.HeroFile.saved_attributes.attributes.Single(x => x.key == 64844096).value = -1999999500;
            }
            //[DemonHunter] Dexterity
            if ((this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1167896896)))
            {
                this.HeroFile.saved_attributes.attributes.Single(x => x.key == 1167896896).value = -1999999500;
            }
            //[WitchDoctor] Intelligence
            if ((this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1557123392)))
            {
                this.HeroFile.saved_attributes.attributes.Single(x => x.key == 1557123392).value = -1999999500;
            }
            //[Wizard] Intelligence
            if ((this.HeroFile.saved_attributes.attributes.Any(item => item.key == -339066560)))
            {
                this.HeroFile.saved_attributes.attributes.Single(x => x.key == -339066560).value = -1999999500;
            }
            //[Necromancer] Intelligence
            if ((this.HeroFile.saved_attributes.attributes.Any(item => item.key == -100925120)))
            {
                this.HeroFile.saved_attributes.attributes.Single(x => x.key == -100925120).value = -1999999500;
            }
            //Vitality
            this.HeroFile.saved_attributes.attributes.Single(x => x.key == -1673830080).value = -1999999500;
            //Res All
            this.HeroFile.saved_attributes.attributes.Single(x => x.key == 1076269376).value = 225000000;
            //Life %
            this.HeroFile.saved_attributes.attributes.Single(x => x.key == -895147712).value = -2147483647;
            //Regen
            this.HeroFile.saved_attributes.attributes.Single(x => x.key == -879546048).value = 0;
            //Life per hit
            this.HeroFile.saved_attributes.attributes.Single(x => x.key == 877273408).value = -2147483647;
            //Armor
            this.HeroFile.saved_attributes.attributes.Single(x => x.key == 402223424).value = -200;
            //Crit Chance
            this.HeroFile.saved_attributes.attributes.Single(x => x.key == 737493312).value = 2147483647;
            //Crit Damage
            this.HeroFile.saved_attributes.attributes.Single(x => x.key == -161611456).value = -2147483647;
            //Area Damage
            this.HeroFile.saved_attributes.attributes.Single(x => x.key == 299651392).value = 2147483647;

            //Max Essence
            if ((this.HeroFile.saved_attributes.attributes.Any(item => item.key == -82398912)))
            {
                this.HeroFile.saved_attributes.attributes.Single(x => x.key == -82398912).value = 999;
            }
            //Max Wrath
            if ((this.HeroFile.saved_attributes.attributes.Any(item => item.key == -1656495808)))
            {
                this.HeroFile.saved_attributes.attributes.Single(x => x.key == -1656495808).value = 999;
            }
            //Max Arcane Power
            if ((this.HeroFile.saved_attributes.attributes.Any(item => item.key == -661155520)))
            {
                this.HeroFile.saved_attributes.attributes.Single(x => x.key == -661155520).value = 999;
            }
            //Max Mana
            if ((this.HeroFile.saved_attributes.attributes.Any(item => item.key == 2021978432)))
            {
                this.HeroFile.saved_attributes.attributes.Single(x => x.key == 2021978432).value = 999;
            }
            //Max Spirit
            if ((this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1832702272)))
            {
                this.HeroFile.saved_attributes.attributes.Single(x => x.key == 1832702272).value = 999;
            }
            //Max Hatred
            if ((this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1255055680)))
            {
                this.HeroFile.saved_attributes.attributes.Single(x => x.key == 1255055680).value = 999;
            }
            //Max Fury
            if ((this.HeroFile.saved_attributes.attributes.Any(item => item.key == 1081442624)))
            {
                this.HeroFile.saved_attributes.attributes.Single(x => x.key == 1081442624).value = 999;
            }
            //Attack Speed
            this.HeroFile.saved_attributes.attributes.Single(x => x.key == -1973739200).value = 999;
            //CDR
            this.HeroFile.saved_attributes.attributes.Single(x => x.key == -1811361472).value = 999;
            //Movement Speed
            this.HeroFile.saved_attributes.attributes.Single(x => x.key == 776950080).value = 999;
            //Gold Find
            if ((this.HeroFile.saved_attributes.attributes.Any(item => item.key == 831545664)))
            {
                this.HeroFile.saved_attributes.attributes.Single(x => x.key == 831545664).value = 999;
            }
            //Seasonal Gold Find
            if ((this.HeroFile.saved_attributes.attributes.Any(item => item.key == -934182592)))
            {
                this.HeroFile.saved_attributes.attributes.Single(x => x.key == -934182592).value = 999;
            }
            //RCR
            this.HeroFile.saved_attributes.attributes.Single(x => x.key == 930300224).value = 999;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddAllClassMS();
            LoadHeroStats();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddAllClassResources();
            LoadHeroStats();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Auto21Dots();
            LoadHeroStats();
        }

        private void soloGR_ValueChanged(object sender, EventArgs e)
        {
            if(loaded)
            {
                this.HeroFile.digest.highest_solo_rift_completed = Convert.ToInt32(this.soloGR.Value);
            }
        }

        private void soloGR_ValueChanged(object sender, KeyEventArgs e)
        {
            if (loaded)
            {
                this.HeroFile.digest.highest_solo_rift_completed = Convert.ToInt32(this.soloGR.Value);
            }
        }

        private void heroID_ValueChanged(object sender, EventArgs e)
        {
            if (!loaded)
                return;
            this.HeroFile.digest.hero_id.id_low = Convert.ToUInt64(this.heroID.Value);
        }

        private void herocore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loaded)
                return;
            this.HeroFile.digest.player_flags = Convert.ToUInt32(this.herocore.SelectedValue);
        }
    }
}
