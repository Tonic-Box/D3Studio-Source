
using System.Drawing;

namespace TonicBox.Data
{
    public class IL
    {
        public IL(string text, int value)
        {
            Text = text;
            Value = value;
        }

        public string Text { get; private set; }

        public int Value { get; private set; }

        public static Color RarityColor(int i)
        {
            if (i < -2)
                return Color.Pink;
            else if (i < 0)
                return Color.Cyan;
            else if (i < 3)
                return Color.White;
            else if (i < 5 || i == 10)
                return Color.Blue;
            else if (i <= 8)
                return Color.Yellow;
            else if (i == 9)
                return Color.Orange;
            else
                return Color.Pink;
        }
    }
}
