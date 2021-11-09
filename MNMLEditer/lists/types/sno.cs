using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D3Studio.lists.types
{
    public class sno
    {
        public sno(
          int sno_affix_string_list,
          int item_string_list_index,
          int affix_string_list_index,
          string name)
        {
            Sno_Affix_String_List = sno_affix_string_list;
            Affix_String_List_Index = affix_string_list_index;
            Item_String_List_Index = item_string_list_index;
            Name = name;
        }

        public sno()
        {
        }

        public int Sno_Affix_String_List { get; set; }

        public int Affix_String_List_Index { get; set; }

        public int Item_String_List_Index { get; set; }

        public string Name { get; set; }
    }
}
