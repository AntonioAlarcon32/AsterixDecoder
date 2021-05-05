using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ClassLibrary
{
    public class AsterixFile
    {
        string path;
        BinaryReader fileReader;
        List<DataBlock> dataBlocks;
        int otherCategories;
        List<Flight> flights;
        public AsterixFile()
        {
            this.dataBlocks = new List<DataBlock>();
            this.otherCategories = 0;
            this.flights = new List<Flight>();
        }
        public int ReadFile(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    this.fileReader = new BinaryReader(File.Open(path, FileMode.Open));

                    while (fileReader.BaseStream.Position != fileReader.BaseStream.Length)
                    {

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
                            //dataBlock.FullDecode();
                            this.dataBlocks.Add(dataBlock);

                        }
                        else if (Convert.ToInt16(category) == 21)
                        {
                            CAT21 dataBlock = new CAT21(length);
                            List<byte> data = fileReader.ReadBytes(length - 3).ToList<byte>();
                            dataBlock.SetMessage(data);
                            dataBlock.GetFSPEC(data);
                            //dataBlock.FullDecode();
                            this.dataBlocks.Add(dataBlock);
                        }
                        else
                        {
                            List<byte> data = fileReader.ReadBytes(length - 3).ToList<byte>();
                            this.otherCategories += 1;
                        }
                    }
                    Parallel.ForEach(dataBlocks, DataBlock =>
                    {
                        DataBlock.FullDecode();
                    });
                    DecodeFlights();
                    return 0;
                }
                catch (Exception e)
                {
                    return -1;
                }
            }
            else
            {
                return -2;
            }
        }

        public void DecodeFlights()
        {
            foreach (DataBlock dataBlock in dataBlocks)
            {
                if (dataBlock.GetCAT21() != null && dataBlock.GetWGS84Coordinates() != null)
                {
                    bool found = false;
                    int index = 0;
                    CAT21 cat21Block = dataBlock.GetCAT21();
                    foreach (Flight flight in flights)
                    {
                        if (cat21Block.GetTargetID() != "N/A" && cat21Block.GetTargetID() == flight.GetID())
                        {
                            found = true;
                            index = flights.IndexOf(flight);
                            flight.AddPosition(dataBlock.GetWGS84Coordinates(), dataBlock.GetTime());
                        }
                    }
                    if (!found && dataBlock.GetWGS84Coordinates() != null)
                    {
                        Flight newFlight = new Flight(cat21Block.GetTargetID());
                        newFlight.AddPosition(dataBlock.GetWGS84Coordinates(), dataBlock.GetTime());
                        flights.Add(newFlight);
                    }
                }
            }
        }

        public List<DataBlock> GetDataBlocks()
        {
            return this.dataBlocks;
        }

        public List<Flight> GetFlights()
        {
            return this.flights;
        }

       
    }
}
