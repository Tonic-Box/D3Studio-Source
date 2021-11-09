using D3Studio.lists.types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3Studio.lists
{
    public static class gbidList
    {
        public static List<gbid> gbids(string path)
        {
            List<string> blob = File.ReadAllLines(path).ToList();
            List<gbid> GBList = new List<gbid>();
            foreach (string line in blob)
            {
                if(line != "")
                {
                    string[] parts = line.Split(new string[1] { "\t=\t" }, StringSplitOptions.None);
                    GBList.Add(new gbid(Convert.ToInt32(parts[0]), parts[1], parts[2], parts[3], parts[4]));
                }
            }
            return GBList;
        }
    }
}
