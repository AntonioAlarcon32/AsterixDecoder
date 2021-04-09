using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Utilities
    {

        private Utilities()
        {
            this.targetIdentification = new Dictionary<byte, char>
            {
                {0,' '},{1,'A'},{2,'B'}, {3,'C'},{4,'D'},{5,'E'},{6,'F'},{7,'G'},{8,'H'},{9,'I'},{10,'J'},
                {11,'K'},{12,'L'},{13,'M'},{14,'N'},{15,'O'},{16,'P'},{17,'Q'},{18,'R'},{19,'S'},{20,'T'},
                {21,'U'},{22,'V'},{23,'W'},{24,'X'},{25,'Y'},{26,'Z'},
                {32,' '},{48,'0'},{49,'1'},{50,'2'},{51,'3'},{52,'4'},{53,'5'},{54,'6'},{55,'7'},{56,'8'},
                {57,'9'},
            };
        }

        private static Utilities instance;
        private Dictionary<byte, char> targetIdentification;


        public static Utilities GetInstance()
        {
            if (instance == null)
            {
                instance = new Utilities();
            }
            return instance;
        }

        public byte[] GetFixedLengthDataItem(List<byte> message, int length)
        {
            int i = 0;
            byte[] dataItem = new byte[length];

            while (i < length)
            {
                dataItem[i] = message[0];
                message.RemoveAt(0);
                i++;
            }
            return dataItem;
        }

        public byte[] GetVariableLengthDataItem(List<byte> message) 
        {
            byte mask = 1;
            List<byte> dataItem = new List<byte>();
            dataItem.Add(message[0]);
            message.RemoveAt(0);
            int i = 0;
            while ((dataItem[i] & mask) == 1)
            {
                dataItem.Add(message[0]);
                message.RemoveAt(0);
                i++;
            }
            return dataItem.ToArray();
        }

        public double DecodeUnsignedByteToDouble(byte[] dataItem, double resolution)
        {
            double bytesValue = 0;
            double multiplier = 1;
            for (int c = dataItem.Length - 1; c >= 0; c--)
            {
                bytesValue += (dataItem[c] * multiplier);
                multiplier = multiplier * Math.Pow(2, 8);
            }

            return bytesValue * resolution;
        }

        public double DecodeTwosComplementToDouble(byte[] dataItem, double resolution)
        {
            byte mask = 127;
            bool negative = false;
            if (dataItem[0] > 127)
                negative = true;
            byte noSign = (byte)(dataItem[0] & mask);
            double bytesValue = 0;
            double multiplier = 1;
            for (int c = dataItem.Length - 1; c >= 0; c--)
            {
                if (c == 0)
                {
                    bytesValue += noSign * multiplier;
                    break;
                }
                bytesValue += (dataItem[c] * multiplier);
                multiplier = multiplier * Math.Pow(2, 8);
            }
            if (negative)
                bytesValue = bytesValue - Math.Pow(2, (dataItem.Length * 8) - 1);

            return bytesValue * resolution;
        }

        public string GetAircraftIdFromBytes(byte[] chars)
        {
            int i = 0;
            bool exists = true;
            string result = "";
            while (i < chars.Length)
            {
                if (exists == false)
                    return null;
                result += targetIdentification[chars[i]];
                i++;
            }
            return result;
        }
    }
}
