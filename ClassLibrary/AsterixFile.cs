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
        BinaryReader fileReader;
        List<DataBlock> dataBlocks;
        List<Flight> flights;
        public AsterixFile()
        {
            this.dataBlocks = new List<DataBlock>();
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
                if ((dataBlock.GetCategory() == 21 || dataBlock.GetTypeOfMessage() == "MLAT" ) && dataBlock.GetWGS84Coordinates() != null)
                {
                    if (dataBlock.GetTargetId() != "N/A")
                    {
                        Flight foundFlight = flights.FirstOrDefault(flight => flight.GetID() == dataBlock.GetTargetId());
                        if (foundFlight != null)
                        {
                            
                            foundFlight.AddPosition(dataBlock.GetWGS84Coordinates(), dataBlock.GetTime(), dataBlock.GetCategory());
                        }
                        else
                        {
                            Flight newFlight = new Flight(dataBlock.GetTargetId());
                            newFlight.AddPosition(dataBlock.GetWGS84Coordinates(), dataBlock.GetTime(), dataBlock.GetCategory());
                            flights.Add(newFlight);
                        }
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
