
using System.Drawing;

namespace TonicBox.Data
{
    public class Dye
    {
        public Dye(string text, int value)
        {
            
        }
        public static Color DyeColor(int index)
        {
            Color color;
            switch (index)
            {
                case 1:
                    color = Color.Black;
                    break;
                case 2:
                    color = Color.Red;
                    break;
                case 3:
                    color = Color.White;
                    break;
                case 4:
                    color = Color.Pink;
                    break;
                case 5:
                    color = Color.Purple;
                    break;
                case 6:
                    color = Color.Fuchsia;
                    break;
                case 7:
                    color = Color.Yellow;
                    break;
                case 8:
                    color = Color.Gold;
                    break;
                case 9:
                    color = Color.Orange;
                    break;
                case 10:
                    color = Color.Blue;
                    break;
                case 11:
                    color = Color.LightBlue;
                    break;
                case 12:
                    color = Color.Gray;
                    break;
                case 13:
                    color = Color.DarkSlateGray;
                    break;
                case 14:
                    color = Color.Green;
                    break;
                case 15:
                    color = Color.DarkRed;
                    break;
                case 16:
                    color = Color.LightGreen;
                    break;
                case 17:
                    color = Color.YellowGreen;
                    break;
                case 18:
                    color = Color.SaddleBrown;
                    break;
                case 19:
                    color = Color.SandyBrown;
                    break;
                case 20:
                    color = Color.WhiteSmoke;
                    break;
                default:
                    color = Color.Cyan;
                    break;
            }
            return color;
        }
    }
}
