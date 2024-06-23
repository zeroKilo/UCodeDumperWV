using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCodeDumperWV
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 1)
            {
                Console.WriteLine("UCodeDumperWV yourFile.ucode");
                return;
            }
            try
            {
                MemoryStream m = new MemoryStream(File.ReadAllBytes(args[0]));
                UCodeFile ucode = new UCodeFile(m);
                Console.WriteLine("Name: " + Encoding.UTF8.GetString(ucode.header.human_readable).Trim().Replace("\n",""));
                byte[] v = BitConverter.GetBytes(ucode.header.version);
                Console.WriteLine("Version: {0}.{1}.{2}.{3}", v[3], v[2], v[1], v[0]);
                Console.WriteLine("Build: " + ucode.header.build);
                Console.WriteLine("Found TLVs:");
                foreach (UCodeTLV tlv in ucode.tlvList)
                {
                    Console.WriteLine(" Size=" + tlv.data.Length.ToString("X8") + " Type=" + tlv.type);
                    string filename = tlv._readAddress.ToString("X8") + "_" + tlv.type + ".bin";
                    File.WriteAllBytes(filename, tlv.data);
                }
                Console.WriteLine("Done");
            }
            catch
            {
                Console.WriteLine("Failed");
            }
        }
    }
}
