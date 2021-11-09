
using System;
using System.Collections.Generic;

namespace TonicBox.Data
{
    public static class RandCalc
    {
        public static Random Rand = new Random();

        public static uint Rnd32() => (uint)(RandCalc.Rand.Next(1073741824) << 2 | RandCalc.Rand.Next(4));

        public static uint Rnd32(List<uint> ignore)
        {
            uint num;
            if (ignore.Count > 0 && ignore.Count < int.MaxValue)
            {
                do
                {
                    num = (uint)(RandCalc.Rand.Next(1073741824) << 2 | RandCalc.Rand.Next(4));
                }
                while (ignore.Contains(num));
            }
            else
                num = (uint)(RandCalc.Rand.Next(1073741824) << 2 | RandCalc.Rand.Next(4));
            return num;
        }
    }
}
