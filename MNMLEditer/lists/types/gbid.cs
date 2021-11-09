using System;
using System.IO;

namespace D3Studio.lists.types
{
    public class gbid
    {
        public gbid(long? gbid, string name, string category, string type, string details)
        {
            GBID = gbid;
            Name = name;
            Category = category;
            ConsoleType = (gbid.PlatFormType)Enum.Parse(typeof(gbid.PlatFormType), type);
            Details = details;
        }

        public long? GBID { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public gbid.PlatFormType ConsoleType { get; set; }

        public string Details { get; set; }

        public enum PlatFormType
        {
            PC,
            Console
        }
    }
}
