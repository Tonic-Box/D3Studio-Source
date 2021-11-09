using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace D3Studio.lists.types
{
    public class skill
    {
        public skill(int? sno, string name, string heroClass, string details)
        {
            SNO = sno;
            Name = name;
            Details = details;
            Class = heroClass;
        }

        public int? SNO { get; set; }

        public string Name { get; set; }

        public string Details { get; set; }

        public string Class { get; set; }
    }
}
