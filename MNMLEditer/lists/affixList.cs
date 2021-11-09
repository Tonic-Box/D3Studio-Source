using D3Studio.lists.types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3Studio.lists
{
    public static class affixList
    {
        public static List<affix> affixs(string path)
        {
            List<string> blob = File.ReadAllLines(path).ToList();
            List<affix> AffixList = new List<affix>();
            foreach (string line in blob)
            {
                if (line != "")
                {
                    string[] parts = line.Split(new string[1] { "\t=\t" }, StringSplitOptions.None);
                    AffixList.Add(new affix(Convert.ToInt32(parts[0]), parts[1], parts[2]));
                }
            }
            return AffixList;
        }
    }
}
