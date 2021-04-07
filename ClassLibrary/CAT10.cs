using System;
using System.Collections;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class CAT10
    {
        public Utilities utilities;


        //Data Block Parameters
        int length;
        List<byte> message;
        byte[] FSPEC;

        int systemAreaCode;
        int systemIdentificationCode;
        string messageType;
        string typeOfData;
        string differentialCorrection;
        string chain;
        string groundTransponder;
        string corruptedReplies;
        string simulatedTarget;
        string testTarget;
        string reportType;
        string loopStatus;
        string aircraftType;
        string specialPosition;
        double polarRho;
        double polarTheta;
        double cartesianX;
        double cartesianY;
        double polarGroundSpeed;
        double polarTrackAngle;
        double cartesianVx;
        double cartesianVy;



        public CAT10(int lenght)
        {
            this.length = lenght;
            this.message = null;
            this.FSPEC = null;

            this.systemAreaCode = -1;
            this.systemIdentificationCode = -1;
            this.messageType = "N/A";

            this.typeOfData = "N/A";
            this.differentialCorrection = "N/A";
            this.chain = "N/A";
            this.groundTransponder = "N/A";
            this.corruptedReplies = "N/A";
            this.simulatedTarget = "N/A";
            this.testTarget = "N/A";
            this.reportType = "N/A";
            this.loopStatus = "N/A";
            this.aircraftType = "N/A";
            this.specialPosition = "N/A";
            this.polarRho = -1;
            this.polarTheta = -1;
            this.polarGroundSpeed = -1;
            this.polarTrackAngle = -1;
            this.cartesianVx = -1;
            this.cartesianVy = -1;
            this.utilities = Utilities.GetInstance();

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
                    byte[] dataItem = new byte[2];
                    dataItem[0] = message[0];
                    dataItem[1] = message[1];
                    message.RemoveAt(0);
                    message.RemoveAt(0);
                    DecodeDataSourceIdentifier(dataItem);
                }
                if (boolFSPEC[6] == true) // Message Type
                {
                    byte[] dataItem = new byte[1];
                    dataItem[0] = message[0];
                    message.RemoveAt(0);
                    DecodeMessageType(dataItem);
                }
                if (boolFSPEC[5] == true) // Target Report Descriptor
                {
                    byte mask = 1;
                    List<byte> dataItem = new List<byte>();
                    dataItem.Add(message[0]);
                    message.RemoveAt(0);
                    if ((dataItem[0] & mask) == 1)
                    {
                        dataItem.Add(message[0]);
                        message.RemoveAt(0);
                        if ((dataItem[1] & mask) == 1)
                        {
                            dataItem.Add(message[0]);
                            message.RemoveAt(0);
                        }
                    }
                    byte[] data = dataItem.ToArray();
                    DecodeTargetReportDescriptor(data);
                }
                if (boolFSPEC[4] == true) // Time of Day
                {
                    byte[] dataItem = new byte[3];
                    dataItem[0] = message[0];
                    dataItem[1] = message[1];
                    dataItem[2] = message[2];
                    message.RemoveAt(0);
                    message.RemoveAt(0);
                    message.RemoveAt(0);
                    DecodeTimeOfDay(dataItem);
                }
                if (boolFSPEC[3] == true) // Position in WGS84 Coordinates
                {
                    int i = 0;
                    byte[] dataItem = new byte[8];

                    while (i < 8)
                    {
                        dataItem[i] = message[0];
                        message.RemoveAt(0);
                        i++;
                    }
                    DecodeWGS84Coordinates(dataItem);
                }
                if (boolFSPEC[2] == true) // Position in polar coordinates
                {
                    int i = 0;
                    byte[] dataItem = new byte[4];

                    while (i < 4)
                    {
                        dataItem[i] = message[0];
                        message.RemoveAt(0);
                        i++;
                    }
                    DecodePolarCoordinatesPosition(dataItem);
                }
                if (boolFSPEC[1] == true) // Position in Cartesian coordinates
                {
                    int i = 0;
                    byte[] dataItem = new byte[4];

                    while (i < 4)
                    {
                        dataItem[i] = message[0];
                        message.RemoveAt(0);
                        i++;
                    }
                    DecodeCartesianCoordinatesPosition(dataItem);
                }

            }
            if (FSPEC.Length >= 2)
            {
                if (boolFSPEC[15] == true)//Calculated Track Velocity in Polar Co-ordinates
                {
                    int i = 0;
                    byte[] dataItem = new byte[4];

                    while (i < 4)
                    {
                        dataItem[i] = message[0];
                        message.RemoveAt(0);
                        i++;
                    }

                    DecodeCalculatedTrackVelocityInPolarCoordinates(dataItem);

                }
                if (boolFSPEC[14] == true)//Calculated Track Velocity in Cartesian Coord.
                {
                    int i = 0;
                    byte[] dataItem = new byte[4];

                    while (i < 4)
                    {
                        dataItem[i] = message[0];
                        message.RemoveAt(0);
                        i++;
                    }

                    DecodeCalculatedTrackVelocityInCartesianCoordinates(dataItem);


                }

                if (boolFSPEC[13] == true)//Track Number
                {

                }

                if (boolFSPEC[12] == true)//Track Status
                {

                }

                if (boolFSPEC[11] == true)//Mode-3/A Code in Octal Representation
                {

                }

                if (boolFSPEC[10] == true)//Target Address
                {

                }

                if (boolFSPEC[9] == true)//Target Identification
                {

                }


            }
        }




        ///DECODING FUNCTIONS
        public void DecodeDataSourceIdentifier(byte[] dataItem)
        {
            this.systemIdentificationCode = dataItem[1];
            this.systemAreaCode = dataItem[0];
        }

        public void DecodeMessageType(byte[] dataItem)
        {

            byte data = dataItem[0];
            switch (data)
            {
                case 1:
                    this.messageType = "Target Report";
                    break;
                case 2:
                    this.messageType = "Start of Update Cycle";
                    break;
                case 3:
                    this.messageType = "Periodic Status Message";
                    break;
                case 4:
                    this.messageType = "Event-triggered Status Message";
                    break;

            };
        }
        public void DecodeTargetReportDescriptor(byte[] dataItem)
        {
            byte typMask = 224;
            byte dcrMask = 16;
            byte chnMask = 8;
            byte gbsMask = 4;
            byte crtMask = 2;

            int typ = ((dataItem[0] & typMask) >> 5);
            int dcr = ((dataItem[0] & dcrMask) >> 4);
            int chn = ((dataItem[0] & chnMask) >> 3);
            int gbs = ((dataItem[0] & gbsMask) >> 2);
            int crt = ((dataItem[0] & crtMask) >> 1);
            switch (typ)
            {
                case 0:
                    this.typeOfData = "SSR multilateration";
                    break;
                case 1:
                    this.typeOfData = "Mode S multilateration";
                    break;
                case 2:
                    this.typeOfData = "ADS-B";
                    break;
                case 3:
                    this.typeOfData = "PSR";
                    break;
                case 4:
                    this.typeOfData = "Magnetic Loop System";
                    break;
                case 5:
                    this.typeOfData = "HF multilateration";
                    break;
                case 6:
                    this.typeOfData = "Not defined";
                    break;
                case 7:
                    this.typeOfData = "Other types";
                    break;
            }
            switch (dcr)
            {
                case 0:
                    this.differentialCorrection = "No differential correction";
                    break;
                case 1:
                    this.typeOfData = "Differential correction";
                    break;
            }
            switch (chn)
            {
                case 0:
                    this.chain = "Chain 1";
                    break;
                case 1:
                    this.typeOfData = "Chain 2";
                    break;
            }
            switch (gbs)
            {
                case 0:
                    this.groundTransponder = "Transponder Ground bit not set";
                    break;
                case 1:
                    this.groundTransponder = "Transponder Ground bit set";
                    break;
            }
            switch (crt)
            {
                case 0:
                    this.corruptedReplies = "No Corrupted reply in multilateration";
                    break;
                case 1:
                    this.corruptedReplies = "Corrupted replies in multilateration";
                    break;
            }

            if (dataItem.Length >= 2)
            {
                byte simMask = 128;
                byte tstMask = 64;
                byte rabMask = 32;
                byte lopMask = 24;
                byte totMask = 6;
                int sim = ((dataItem[1] & simMask) >> 7);
                int tst = ((dataItem[1] & tstMask) >> 6);
                int rab = ((dataItem[1] & rabMask) >> 5);
                int lop = ((dataItem[1] & lopMask) >> 3);
                int tot = ((dataItem[1] & totMask) >> 1);
                switch (sim)
                {
                    case 0:
                        this.simulatedTarget = "Actual target report";
                        break;
                    case 1:
                        this.simulatedTarget = "Simulated target report";
                        break;
                }
                switch (tst)
                {
                    case 0:
                        this.testTarget = "Default";
                        break;
                    case 1:
                        this.testTarget = "Test Target";
                        break;
                }
                switch (rab)
                {
                    case 0:
                        this.reportType = "Report from target transponder";
                        break;
                    case 1:
                        this.reportType = "Report from field monitor (fixed transponder)";
                        break;
                }
                switch (lop)
                {
                    case 0:
                        this.loopStatus = "Undetermined";
                        break;
                    case 1:
                        this.loopStatus = "Loop Start";
                        break;
                    case 2:
                        this.loopStatus = "Loop Finish";
                        break;
                }
                switch (tot)
                {
                    case 0:
                        this.loopStatus = "Undetermined";
                        break;
                    case 1:
                        this.loopStatus = "Aircraft";
                        break;
                    case 2:
                        this.loopStatus = "Ground Vehicle";
                        break;
                    case 3:
                        this.loopStatus = "Helicopter";
                        break;
                }
            }
            if (dataItem.Length >= 3)
            {
                if (dataItem[2] == 0)
                    this.specialPosition = "Absence of PSI";
                else if (dataItem[2] > 0)
                    this.specialPosition = "Special Position Identification";
            }
        }


        public void DecodeTimeOfDay(byte[] dataItem)
        {
            int c = 0;
        }

        public void DecodeWGS84Coordinates(byte[] dataItem)
        {
            int c = 0;
        }

        public void DecodePolarCoordinatesPosition(byte[] dataItem)
        {
            byte[] rhoBytes = { dataItem[0], dataItem[1] };
            double rhoResolution = 1;
            this.polarRho = utilities.DecodeUnsignedByteToDouble(rhoBytes, rhoResolution);
            byte[] thetaBytes = { dataItem[2], dataItem[3] };
            double thetaResolution = 360 / Math.Pow(2, 16);
            this.polarTheta = utilities.DecodeUnsignedByteToDouble(thetaBytes, thetaResolution);
        }
        public void DecodeCartesianCoordinatesPosition(byte[] dataItem)
        {
            byte[] xBytes = { dataItem[0], dataItem[1] };
            double xResolution = 1;
            this.cartesianX = utilities.DecodeTwosComplementToDouble(xBytes, xResolution);
            byte[] yBytes = { dataItem[2], dataItem[3] };
            double yResolution = 1;
            this.cartesianY = utilities.DecodeTwosComplementToDouble(yBytes, yResolution);
        }
        public void DecodeCalculatedTrackVelocityInPolarCoordinates(byte[] dataItem)
        {
            byte[] speedBytes = { dataItem[0], dataItem[1] };
            double speedResolution = Math.Pow(2, -14) * 3600;
            this.polarGroundSpeed = utilities.DecodeUnsignedByteToDouble(speedBytes, speedResolution);
            byte[] trackAngleBytes = { dataItem[2], dataItem[3] };
            double trackAngleResolution = (360 / Math.Pow(2, 16));
            this.polarTrackAngle = utilities.DecodeUnsignedByteToDouble(trackAngleBytes, trackAngleResolution);
        }
        public void DecodeCalculatedTrackVelocityInCartesianCoordinates(byte[] dataItem)
        {
            byte[] xBytes = { dataItem[0], dataItem[1] };
            double xResolution = 0.25;
            this.cartesianVx = utilities.DecodeTwosComplementToDouble(xBytes, xResolution);
            byte[] yBytes = { dataItem[2], dataItem[3] };
            double yResolution = 0.25;
            this.cartesianVy = utilities.DecodeTwosComplementToDouble(yBytes, yResolution);
        }
    }


}
