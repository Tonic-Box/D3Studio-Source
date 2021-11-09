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
    public partial class stat : UserControl
    {
        public PB.Hero.SavedDefinition HeroFile { get; set; }

        public bool loaded = false;

        public general parent;

        public int key { get; set; }
        public stat()
        {
            InitializeComponent();
        }

        public void populate()
        {
            this.statLabel.Text = this.Checkvalue(this.key);
            this.statValue.Value = Convert.ToDecimal(HeroFile.saved_attributes.attributes.Single(x => x.key == this.key).value);

            this.loaded = true;
        }

        private void statValue_ValueChanged(object sender, EventArgs e)
        {
            if(this.loaded)
            {
                this.HeroFile.saved_attributes.attributes.Single(x => x.key == this.key).value = Convert.ToInt32(((System.Windows.Forms.NumericUpDown)(sender)).Value);
            }
        }

        public string Checkvalue(int key)
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

        private void statValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show("Changed!");
            //this.HeroFile.saved_attributes.attributes.Single(x => x.key == this.key).value = Convert.ToInt32(((System.Windows.Forms.NumericUpDown)(sender)).Value);
        }

        private void statValue_KeyUp(object sender, KeyEventArgs e)
        {
            this.HeroFile.saved_attributes.attributes.Single(x => x.key == this.key).value = Convert.ToInt32(((System.Windows.Forms.NumericUpDown)(sender)).Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.HeroFile.saved_attributes.attributes = this.HeroFile.saved_attributes.attributes.Where(item => item.key != this.key).ToList();
            //this.Parent.Controls.Remove(this);
            this.parent.LoadHeroStats();
        }
    }
}
