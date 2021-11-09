using D3Studio.lists.types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D3Studio.lists
{
    public static class helper
    {
        public static gbid FindGBID(string search, int field, List<gbid> list)
        {
            //fields: 0 = gbid, 1 = name, 2 = category, 3 = description
            try
            {
                if (field == 0)
                    return list.First(x => x.GBID == Convert.ToInt32(search));
                else if (field == 1)
                    return list.First(x => x.Name.ToLower().Contains(search.ToLower()));
                else if (field == 2)
                    return list.First(x => x.Category.ToLower().Contains(search.ToLower()));
                else if (field == 3)
                    return list.First(x => x.Details.ToLower().Contains(search.ToLower()));
                else if (field == 4)
                    return list.First(x => x.Name.ToLower() == search.ToLower());
            }
            catch { }
            return null;
        }

        public static gbid DefaultFindGBID(string search, int field, List<gbid> list)
        {
            //fields: 0 = gbid, 1 = name, 2 = category, 3 = description
            try
            {
                if (field == 0)
                {
                    try
                    {
                        gbid id = list.First(x => x.GBID == Convert.ToInt32(search));
                        if (id != null)
                            return id;
                        else
                            return new gbid(Convert.ToInt32(search), search, "Unknown", "Console", "");
                    }
                    catch
                    {
                        return new gbid(Convert.ToInt32(search), search, "Unknown", "Console", "");
                    }
                }

                else if (field == 1)
                    return list.First(x => x.Name.ToLower().Contains(search.ToLower()));
                else if (field == 2)
                    return list.First(x => x.Category.ToLower().Contains(search.ToLower()));
                else if (field == 3)
                    return list.First(x => x.Details.ToLower().Contains(search.ToLower()));
                else if (field == 4)
                    return list.First(x => x.Name.ToLower() == search.ToLower());
            }
            catch(Exception e) { MessageBox.Show(e.ToString()); }
            return new gbid(-1, "None", "None", "Console", "");
        }

        public static affix FindAffix(string search, int field, List<affix> list)
        {
            //fields: 0 = gbid, 1 = name, 2 = category, 3 = description
            try
            {
                if (field == 0)
                {
                    try
                    {

                    }
                    catch
                    {

                    }
                    return list.First(x => x.Affix == Convert.ToInt32(search));
                }
                else if (field == 1)
                    return list.First(x => x.Name.ToLower().Contains(search.ToLower()));
                else if (field == 2)
                    return list.First(x => x.Category.ToLower().Contains(search.ToLower()));
                else if (field == 3)
                    return list.First(x => x.Details.ToLower().Contains(search.ToLower()));
                else if (field == 4)
                {
                    try
                    {
                        return list.First(x => x.Name.ToLower() == search.ToLower());
                    }
                    catch
                    {
                        return new affix(Convert.ToInt32(search), search, "");
                    }
                }
            }
            catch { }
            return new affix(-1, search, "");
        }
    }

    public static class Extensions
    {
        public static T DeepClone<T>(this T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }
        public static List<TreeNode> Descendants(this TreeView tree)
        {
            var nodes = tree.Nodes.Cast<TreeNode>();
            return nodes.SelectMany(x => x.Descendants()).Concat(nodes).ToList();
        }

        public static List<TreeNode> Descendants(this TreeNode node)
        {
            var nodes = node.Nodes.Cast<TreeNode>().ToList();
            return nodes.SelectMany(x => Descendants(x)).Concat(nodes).ToList();
        }
    }

    public class NodeSorter : IComparer
    {
        public int Compare(object x, object y)
        {
            TreeNode tx = (TreeNode)x;
            TreeNode ty = (TreeNode)y;

            if(Regex.IsMatch(tx.Text, @"-?\d[\d\.\,]*") && Regex.IsMatch(ty.Text, @"-?\d[\d\.\,]*"))
            {
                
                Regex pattern = new Regex(@"-?\d[\d\.\,]*");
                Match txm = pattern.Match(tx.Text);
                Match tym = pattern.Match(ty.Text);
                int tx_int = Convert.ToInt32(txm.Groups[0].Value.Trim().Replace(".","").Replace(",",""));
                int ty_int = Convert.ToInt32(tym.Groups[0].Value.Trim().Replace(".", "").Replace(",", ""));
                if (tx_int > ty_int)
                    return 1;
                else if(tx_int == ty_int && txm.Groups[1] != null && tym.Groups[1] != null
                     && txm.Groups[1].Value != null && tym.Groups[1].Value != null
                     && txm.Groups[1].Value != "" && tym.Groups[1].Value != "")
                {
                    int tx_int2 = Convert.ToInt32(txm.Groups[1].Value.Trim().Replace(".", "").Replace(",", "").Replace("-", ""));
                    int ty_int2 = Convert.ToInt32(tym.Groups[1].Value.Trim().Replace(".", "").Replace(",", "").Replace("-", ""));
                    if (tx_int2 > ty_int2)
                        return 1;
                    else
                        return 0;
                }
                else
                    return 0;
            }
            return string.Compare(tx.Text, ty.Text);
        }
    }
    public static class TreeNodeHelper
    {
        public static IEnumerable<TreeNode> Flatten(this TreeNode root)
        {
            yield return root;

            foreach (TreeNode node in root.Nodes)
                yield return node;
        }
    }

    public static class StringExtensions
    {
        public static string Left(this string str, int length)
        {
            return str.Substring(0, Math.Min(length, str.Length));
        }

        public static string Right(this string str, int length)
        {
            return str.Substring(str.Length - Math.Min(length, str.Length));
        }
    }
}
