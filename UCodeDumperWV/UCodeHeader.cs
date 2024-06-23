using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCodeDumperWV
{
    public class UCodeHeader
    {
        public uint zero;
        public uint magic;
        public byte[] human_readable = new byte[Defines.FW_VER_HUMAN_READABLE_SZ];
        public uint version;
        public uint build;
        public byte[] ignore = new byte[8];
        public UCodeHeader(MemoryStream m)
        {
            zero = Helper.ReadU32(m);
            if (zero != 0) throw new Exception();
            magic = Helper.ReadU32(m);
            if (magic != Defines.IWL_TLV_UCODE_MAGIC) throw new Exception();
            m.Read(human_readable, 0, human_readable.Length);
            version = Helper.ReadU32(m);
            build = Helper.ReadU32(m);
            m.Read(ignore, 0, 8);
        }
    }
}
