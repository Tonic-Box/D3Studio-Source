using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D3Studio.lists.types
{
    public class affix
    {
        public affix(int? affix, string name, string details)
        {
            Affix = affix;
            Name = name;
            if(details == "")
            {
                if (name.Contains("Passive: "))
                {
                    Category = "Passives";
                }
                else
                {
                    try
                    {
                        Category = Regex.Replace(name, @"\d[\d,\.\%]*", "X");//@"[-\d]\S[\.%\d-,]*\b", " X-X ");
                    }
                    catch
                    {
                        Category = " [UNSORTED]";
                    }
                }
            }
            else
            {
                Category = details;
            }
            Details = details;
        }

        public int? Affix { get; set; }

        public string Name { get; set; }

        public string Details { get; set; }

        public string Category { get; set; }
    }
}
