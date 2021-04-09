using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Utilities
    {

        private Utilities()
        {
        }

        private static Utilities instance;


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
    }
}
