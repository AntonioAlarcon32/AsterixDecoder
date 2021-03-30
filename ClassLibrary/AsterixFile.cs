using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary
{
    public class AsterixFile
    {
        string path;
        BinaryReader fileReader;
        List<CAT10> cat10DataBlocks;
        public AsterixFile() 
        {
            this.cat10DataBlocks = new List<CAT10>();
        }
        public int ReadFile(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    this.fileReader = new BinaryReader(File.Open(path, FileMode.Open));

                    while (fileReader.BaseStream.Position != fileReader.BaseStream.Length) {
                        int category = fileReader.ReadByte();

                        byte[] lengthBytes = fileReader.ReadBytes(2);
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(lengthBytes);
                        int length = BitConverter.ToInt16(lengthBytes, 0);
                        if (Convert.ToInt16(category) == 10) {
                            CAT10 dataBlock = new CAT10(length);
                            List<byte> data = fileReader.ReadBytes(length - 3).ToList<byte>();
                            dataBlock.SetMessage(data);
                            dataBlock.GetFSPEC(data);
                            dataBlock.fullDecode();
                            this.cat10DataBlocks.Add(dataBlock);
                        
                        }
                        else { 

                        }
                    }
                        return 0;
                }
                catch(Exception e)
                {
                    return -1;
                }
            }
            else 
            {
                return -2;
            }
        }
        public List<CAT10> GetCAT10Blocks() {
            return this.cat10DataBlocks;
        }
    }
}
