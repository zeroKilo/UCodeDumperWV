using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCodeDumperWV
{
    public class UCodeFile
    {
        public UCodeHeader header;
        public List<UCodeTLV> tlvList = new List<UCodeTLV>();
        public UCodeFile(MemoryStream m)
        {
            header = new UCodeHeader(m);
            long end = m.Length;
            while (m.Position < end)
                tlvList.Add(new UCodeTLV(m));
        }
    }
}
