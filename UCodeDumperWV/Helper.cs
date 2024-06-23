using System;
using System.IO;
using System.Text;

namespace UCodeDumperWV
{
    public static class Helper
    {
        public static ushort ReadU16(Stream s)
        {
            byte[] buff = new byte[2];
            s.Read(buff, 0, 2);
            return BitConverter.ToUInt16(buff, 0);
        }

        public static uint ReadU32(Stream s)
        {
            byte[] buff = new byte[4];
            s.Read(buff, 0, 4);
            return BitConverter.ToUInt32(buff, 0);
        }

        public static ulong ReadU64(Stream s)
        {
            byte[] buff = new byte[8];
            s.Read(buff, 0, 8);
            return BitConverter.ToUInt64(buff, 0);
        }

        public static float ReadFloat(Stream s)
        {
            byte[] buff = new byte[4];
            s.Read(buff, 0, 4);
            return BitConverter.ToSingle(buff, 0);
        }

        public static string ReadCString(Stream s)
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                int b = s.ReadByte();
                if (b == 0)
                    break;
                sb.Append((char)b);
            }
            return sb.ToString();
        }

        public static void WriteU16(Stream s, ushort u)
        {
            s.Write(BitConverter.GetBytes(u), 0, 2);
        }

        public static void WriteU32(Stream s, uint u)
        {
            s.Write(BitConverter.GetBytes(u), 0, 4);
        }

        public static void WriteU64(Stream s, ulong u)
        {
            s.Write(BitConverter.GetBytes(u), 0, 8);
        }

        public static void WriteFloat(Stream s, float f)
        {
            s.Write(BitConverter.GetBytes(f), 0, 4);
        }

        public static void WriteCString(Stream s, string str)
        {
            foreach (char c in str)
                s.WriteByte((byte)c);
            s.WriteByte(0);
        }
        public static void WriteArray(Stream s, byte[] data)
        {
            WriteU32(s, (uint)data.Length);
            s.Write(data, 0, data.Length);
        }

        public static byte[] ReadArray(Stream s)
        {
            int len = (int)ReadU32(s);
            byte[] result = new byte[len];
            s.Read(result, 0, len);
            return result;
        }
    }
}
