using D3Studio.lists.types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3Studio.lists
{
    public static class snoList
    {
        public static List<sno> snos(string path)
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                List<sno> entrys = new List<sno>();
                string end = streamReader.ReadToEnd();
                string[] separator1 = new string[1] { "\r\n" };
                foreach (string str in end.Split(separator1, StringSplitOptions.None))
                {
                    string[] separator2 = new string[1] { "\t=\t" };
                    string[] strArray = str.Split(separator2, StringSplitOptions.None);
                    if (strArray.Length == 4)
                        entrys.Add(new sno(int.Parse(strArray[0]), int.Parse(strArray[1]), int.Parse(strArray[2]), strArray[3]));
                }
                return entrys;
            }
        }
    }
}
