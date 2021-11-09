
using System.IO;

namespace TonicBox.Data
{
    public class XorMagic
    {
        public static Stream Savedecryptfile(string file)
        {
            byte[] buffer = File.ReadAllBytes(file);
            ulong num = 3485666093803610139;
            for (int index = 0; index < buffer.Length; ++index)
            {
                buffer[index] ^= (byte)(num & byte.MaxValue);
                num = (ulong)(((long)num ^ buffer[index]) << 56) | num >> 8;
            }
            return new MemoryStream(buffer);
        }

        public static FileStream Saveencryptfile(string file)
        {
            byte[] buffer = File.ReadAllBytes(file);
            ulong num1 = 3485666093803610139;
            for (int index = 0; index < buffer.Length; ++index)
            {
                byte num2 = buffer[index];
                buffer[index] ^= (byte)(num1 & byte.MaxValue);
                num1 = (ulong)(((long)num1 ^ num2) << 56) | num1 >> 8;
            }
            FileStream newFile = null;
            new MemoryStream(buffer).CopyTo(newFile);
            return newFile;

        }

        public static Stream Savedecryptstreeam(Stream instream)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                instream.CopyTo(memoryStream);
                byte[] array = memoryStream.ToArray();
                ulong num = 3485666093803610139;
                for (int index = 0; index < array.Length; ++index)
                {
                    array[index] ^= (byte)(num & byte.MaxValue);
                    num = (ulong)(((long)num ^ array[index]) << 56) | num >> 8;
                }
                return new MemoryStream(array);
            }
        }

        public static Stream Saveencryptstream(Stream instream)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                instream.Position = 0L;
                instream.CopyTo(memoryStream);
                byte[] array = memoryStream.ToArray();
                ulong num1 = 3485666093803610139;
                for (int index = 0; index < array.Length; ++index)
                {
                    byte num2 = array[index];
                    array[index] ^= (byte)(num1 & byte.MaxValue);
                    num1 = (ulong)(((long)num1 ^ num2) << 56) | num1 >> 8;
                }
                return new MemoryStream(array);
            }
        }
    }
}
