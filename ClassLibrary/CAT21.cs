using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class CAT21 : DataBlock
    {
        public Utilities utilities;


        int length;
        List<byte> message;
        byte[] FSPEC;

        int systemAreaCode;
        int systemIdentificationCode;

        int trackNumber;


        public CAT21(int length)
        {
            this.utilities = Utilities.GetInstance();

            this.length = length;
            this.message = null;
            this.FSPEC = null;

            this.systemIdentificationCode = -1;
            this.systemAreaCode = -1;

            this.trackNumber = -1;
        }

        public void SetMessage(List<byte> message)
        {
            this.message = message;
        }

        public List<byte> GetMessage()
        {
            return this.message;
        }

        public byte[] GetFSPEC(List<byte> message) //Obtiene el FSPEC y lo separa del array mensaje
        {
            byte lastBitCheck = 1;
            List<byte> FSPEC = new List<byte>();
            int i = 0;
            int moreFSPEC = 1;
            while (moreFSPEC == 1)
            {
                moreFSPEC = message[0] & lastBitCheck;
                FSPEC.Add(message[0]);
                message.RemoveAt(0);
            }
            byte[] finalFSPEC = FSPEC.ToArray();
            this.FSPEC = finalFSPEC;
            return finalFSPEC;
        }
        public void fullDecode()
        {
            BitArray boolFSPEC = new BitArray(FSPEC);
            if (FSPEC.Length >= 1)
            {
                if (boolFSPEC[7] == true) // Data Source Identifier
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeDataSourceIdentifier(dataItem);
                }
                if (boolFSPEC[6] == true) // Target Report Descriptor
                {
                    byte[] dataItem = utilities.GetVariableLengthDataItem(message);
                }
                if (boolFSPEC[5] == true) // Track Number
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeTrackNumber(dataItem);
                }
                if (boolFSPEC[4] == true) // Service Identification
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 1);
                }
                if (boolFSPEC[3] == true) //Time of Applicability for Position
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 3);
                }
                if (boolFSPEC[2] == true) // Position in WGS84 coordinates
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 6);
                }
                if (boolFSPEC[1] == true) // Position in WGS84 coordinates, high resolution
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 8);
                }
            }
            if (FSPEC.Length >= 2)
            {
                if (boolFSPEC[15] == true) //Time of Applicability for Velocity
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 3);
                }
                if (boolFSPEC[14] == true) //Air Speed
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 2);
                }

                if (boolFSPEC[13] == true) //True AirSpeed
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 2);
                }

                if (boolFSPEC[12] == true) //Target Address
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 3);
                }

                if (boolFSPEC[11] == true)//Time of Message Reception of Position
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 3);
                }

                if (boolFSPEC[10] == true)//Time of Message Reception of Position high res
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 4);
                }

                if (boolFSPEC[9] == true)//Time of Message Reception of Velocity
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 3);
                }
            }
        }

        public void DecodeDataSourceIdentifier(byte[] dataItem)
        {
            this.systemIdentificationCode = dataItem[1];
            this.systemAreaCode = dataItem[0];
        }

        public void DecodeTargetReportDescriptor(byte[] dataItem)
        { 
        }

        public void DecodeTrackNumber(byte[] dataItem)
        {
            byte[] trackBytes = { dataItem[0], dataItem[1] };
            double resolution = 1;
            double number = utilities.DecodeUnsignedByteToDouble(trackBytes, resolution);
            this.trackNumber = (int)number;
        }

        public int GetLength() {
            return this.length;
        }

    }
}
