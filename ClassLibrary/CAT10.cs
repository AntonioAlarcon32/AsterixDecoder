using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CAT10
    {
        //Data Block Parameters
        int length;
        byte[] message;
        byte[] FSPEC;


        public CAT10(int lenght)
        {
            this.length = lenght;
            this.message = null;
            this.FSPEC = null;
        }

        public void SetMessage(byte[] message) 
        {
            this.message = message;
        }

        public byte[] GetMessage() 
        {
            return this.message;
        }


        public byte[] GetFSPEC(byte[] message)
        {
            byte lastBitCheck = 1;
            List<byte> FSPEC = new List<byte>();
            int i = 0;
            int moreFSPEC = 1;
            while (moreFSPEC == 1)
            {
                moreFSPEC = message[i] & lastBitCheck;
                FSPEC.Add(message[i]);
                i++;
            }
            byte[] finalFSPEC = FSPEC.ToArray();
            int c = 1;
            this.FSPEC = finalFSPEC;
            return finalFSPEC;
        }


    }


}
