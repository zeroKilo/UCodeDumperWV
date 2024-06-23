using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCodeDumperWV
{
    public class UCodeTLV
    {
        public Defines.iwl_ucode_tlv_type type;
        public byte[] data;
        public long _readAddress;
        public UCodeTLV(MemoryStream m)
        {
            _readAddress = m.Position;
            type = (Defines.iwl_ucode_tlv_type)Helper.ReadU32(m);
            int len = (int)Helper.ReadU32(m);
            data = new byte[len];
            m.Read(data, 0, len);
        }
    }
}
