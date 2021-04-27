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
        List<CAT21> cat21DataBlocks;
        List<DataBlock> dataBlocks;
        int otherCategories;
        public AsterixFile() 
        {
            this.cat10DataBlocks = new List<CAT10>();
            this.cat21DataBlocks = new List<CAT21>();
            this.dataBlocks = new List<DataBlock>();
            this.otherCategories = 0;
        }
        public int ReadFile(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    this.fileReader = new BinaryReader(File.Open(path, FileMode.Open));



                    while (fileReader.BaseStream.Position != fileReader.BaseStream.Length) {
                        if (cat21DataBlocks.Count == 47)
                        {
                            int c = 1;
                        }

                        int category = fileReader.ReadByte();

                        byte[] lengthBytes = fileReader.ReadBytes(2);
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(lengthBytes);
                        int length = BitConverter.ToInt16(lengthBytes, 0);
                        if (Convert.ToInt16(category) == 10)
                        {
                            CAT10 dataBlock = new CAT10(length);
                            List<byte> data = fileReader.ReadBytes(length - 3).ToList<byte>();
                            dataBlock.SetMessage(data);
                            dataBlock.GetFSPEC(data);
                            dataBlock.fullDecode();
                            this.dataBlocks.Add(dataBlock);

                        }
                        else if (Convert.ToInt16(category) == 21)
                        {
                            CAT21 dataBlock = new CAT21(length);
                            List<byte> data = fileReader.ReadBytes(length - 3).ToList<byte>();
                            dataBlock.SetMessage(data);
                            dataBlock.GetFSPEC(data);
                            dataBlock.fullDecode();
                            this.dataBlocks.Add(dataBlock);
                        }
                        else
                        {
                            List<byte> data = fileReader.ReadBytes(length - 3).ToList<byte>();
                            this.otherCategories += 1;
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
        public List<CAT21> GetCAT21Blocks()
        {
            return this.cat21DataBlocks;
        }
        public List<DataBlock> GetDataBlocks()
        {
            return this.dataBlocks;
        }
    }
}
