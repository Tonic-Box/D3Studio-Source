using D3Studio.lists.types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3Studio.lists
{
    public class skillList
    {
        public static List<skill> skills(string path)
        {
            List<string> blob = File.ReadAllLines(path).ToList();
            List<skill> SKList = new List<skill>();
            foreach (string line in blob)
            {
                if (line != "")
                {
                    string[] parts = line.Split(new string[1] { "\t=\t" }, StringSplitOptions.None);
                    SKList.Add(new skill(Convert.ToInt32(parts[0]), parts[1], parts[2], parts[3]));
                }
            }
            return SKList;
        }
    }
}
