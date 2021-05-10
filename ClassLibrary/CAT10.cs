using System;
using System.Collections;
using System.Collections.Generic;
using MultiCAT6.Utils;

namespace ClassLibrary
{
    public class CAT10 : DataBlock
    {
        public Utilities utilities;


        //Data Block Parameters
        int length;
        List<byte> message;
        byte[] FSPEC;

        int systemAreaCode;
        int systemIdentificationCode;

        string messageType;

        string trTYP;
        string trDCR;
        string trCHN;
        string trGBS;
        string trCRT;
        string trSIM;
        string trTST;
        string trRAB;
        string trLOP;
        string trTOT;
        string trSPI;

        TimeSpan timeOfDay;

        double wgs84latitude;
        double wgs84longitude;

        double polarRho;
        double polarTheta;

        double cartesianX;
        double cartesianY;

        string M3AValidated;
        string M3AGarbled;
        string M3ACode;

        string targetAddress;

        string targetIdentification;

        double polarGroundSpeed;
        double polarTrackAngle;

        double cartesianVx;
        double cartesianVy;

        int trackNumber;

        string tsCNF;
        string tsTRE;
        string tsCST;
        string tsMAH;
        string tsTCC;
        string tsSTH;
        string tsTOM;
        string tsDOU;
        string tsMRS;
        string tsGHO;


        string flValidated;
        string flGarbled;
        double flFlightLevel;

        double targetLength;
        double targetOrientation;
        double targetWidth;

        double calcAccelerationX;
        double calcAccelerationY;

        string ssNOGO;
        string ssOVL;
        string ssTSV;
        string ssDIV;
        string ssTTF;

        string vehicleFleetId;

        double measuredHeight;

        string ppmTRB;
        string ppMSG;

        double standardDeviationX;
        double standardDeviationY;
        double standardDeviationXY;

        double amplitudeOfPrimaryPlot;

        List<byte[]> ModeSMBData;
        List<byte[]> ModeSMBCodes;
        List<double> presenceDrho;
        List<double> presenceDtheta;


        public CAT10(int lenght)
        {
            this.length = lenght;
            this.message = null;
            this.FSPEC = null;

            this.systemAreaCode = -1;
            this.systemIdentificationCode = -1;

            this.messageType = "N/A";

            this.trTYP = "N/A";
            this.trDCR = "N/A";
            this.trCHN = "N/A";
            this.trGBS = "N/A";
            this.trCRT = "N/A";
            this.trSIM = "N/A";
            this.trTST = "N/A";
            this.trRAB = "N/A";
            this.trLOP = "N/A";
            this.trTOT = "N/A";
            this.trSPI = "N/A";

            this.timeOfDay = new TimeSpan();

            this.wgs84latitude = double.NaN;
            this.wgs84longitude = double.NaN;

            this.polarRho = double.NaN;
            this.polarTheta = double.NaN;

            this.cartesianX = double.NaN;
            this.cartesianY = double.NaN;

            this.M3AValidated = "N/A";
            this.M3AGarbled = "N/A";
            this.M3ACode = "N/A";

            this.targetAddress = "N/A";

            this.targetIdentification = "N/A";

            this.polarGroundSpeed = double.NaN;
            this.polarTrackAngle = double.NaN;

            this.cartesianVx = double.NaN;
            this.cartesianVy = double.NaN;

            this.trackNumber = -1;

            this.tsCNF = "N/A";
            this.tsTRE = "N/A";
            this.tsCST = "N/A";
            this.tsMAH = "N/A";
            this.tsTCC = "N/A";
            this.tsSTH = "N/A";
            this.tsTOM = "N/A";
            this.tsDOU = "N/A";
            this.tsMRS = "N/A";
            this.tsGHO = "N/A";

            this.targetLength = double.NaN;
            this.targetOrientation = double.NaN;
            this.targetWidth = double.NaN;

            this.calcAccelerationX = double.NaN;
            this.calcAccelerationY = double.NaN;

            this.ssNOGO = "N/A";
            this.ssOVL = "N/A";
            this.ssTSV = "N/A";
            this.ssDIV = "N/A";
            this.ssTTF = "N/A";

            this.flFlightLevel = double.NaN;
            this.flGarbled = "N/A";
            this.flValidated = "N/A";

            this.vehicleFleetId= "N/A";

            this.measuredHeight = double.NaN;

            this.ppmTRB = "N/A";
            this.ppMSG= "N/A";

            this.standardDeviationX = double.NaN;
            this.standardDeviationY = double.NaN;
            this.standardDeviationXY = double.NaN;
            this.amplitudeOfPrimaryPlot= double.NaN;

            this.utilities = Utilities.GetInstance();

            this.ModeSMBData = new List<byte[]>();
            this.ModeSMBCodes = new List<byte[]>();

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

        public void FullDecode()
        {
            BitArray boolFSPEC = new BitArray(FSPEC);
            if (FSPEC.Length >= 1)
            {
                if (boolFSPEC[7] == true) // Data Source Identifier
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeDataSourceIdentifier(dataItem);
                }
                if (boolFSPEC[6] == true) // Message Type
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 1);
                    DecodeMessageType(dataItem);
                }
                if (boolFSPEC[5] == true) // Target Report Descriptor
                {
                    byte[] dataItem = utilities.GetVariableLengthDataItem(message);
                    DecodeTargetReportDescriptor(dataItem);
                }
                if (boolFSPEC[4] == true) // Time of Day
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 3);
                    DecodeTimeOfDay(dataItem);
                }
                if (boolFSPEC[3] == true) // Position in WGS84 Coordinates
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 8);
                    DecodeWGS84Coordinates(dataItem);
                }
                if (boolFSPEC[2] == true) // Position in polar coordinates
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 4);
                    DecodePolarCoordinatesPosition(dataItem);
                }
                if (boolFSPEC[1] == true) // Position in Cartesian coordinates
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 4);
                    DecodeCartesianCoordinatesPosition(dataItem);
                }

            }
            if (FSPEC.Length >= 2)
            {
                if (boolFSPEC[15] == true)//Calculated Track Velocity in Polar Co-ordinates
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 4);
                    DecodeCalculatedTrackVelocityInPolarCoordinates(dataItem);
                }
                if (boolFSPEC[14] == true)//Calculated Track Velocity in Cartesian Coord.
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 4);
                    DecodeCalculatedTrackVelocityInCartesianCoordinates(dataItem);
                }

                if (boolFSPEC[13] == true)//Track Number
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeTrackNumber(dataItem);
                }

                if (boolFSPEC[12] == true)//Track Status
                {
                    byte[] dataItem =  utilities.GetVariableLengthDataItem(message);
                    DecodeTrackStatus(dataItem);
                }

                if (boolFSPEC[11] == true)//Mode-3/A Code in Octal Representation
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeMode3A(dataItem);
                }

                if (boolFSPEC[10] == true)//Target Address
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 3);
                    DecodeTargetAddress(dataItem);
                }

                if (boolFSPEC[9] == true)//Target Identification
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 7);
                    DecodeTargetIdentification(dataItem);
                }
            }
            if (FSPEC.Length >= 3)
            {
                if (boolFSPEC[23] == true)//Mode S MB Data
                {
                    List<byte[]> ItemsList = utilities.GetRepetitiveItems(message, 8);
                    DecodeModeSMBData(ItemsList);

                }

                if (boolFSPEC[22] == true)//Vehicle Fleet Identification
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 1);
                    DecodeVehicleFleetIdentification(dataItem);
                }

                if (boolFSPEC[21] == true)//Flight Level in Binary Representation
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeFlightLevel(dataItem);
                }
                if (boolFSPEC[20] == true)//Measured Height
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeMeasuredHeight(dataItem);
                }

                if (boolFSPEC[19] == true)//Target Size & Orientation
                {
                    byte[] dataItem = utilities.GetVariableLengthDataItem(message);
                    DecodeTargetSizeAndOrientation(dataItem);
                }

                if (boolFSPEC[18] == true)//System Status
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 1);
                    DecodeSystemStatus(dataItem);
                }

                if (boolFSPEC[17] == true)//Pre-Programmed Message
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 1);
                    DecodePreProgrammedMessage(dataItem);
                }
            }
            if (FSPEC.Length >= 4)
            {
                if (boolFSPEC[31] == true)//Standard Deviation of Position
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 4);
                    DecodeStandardDeviationOfPosition(dataItem);
                }

                if (boolFSPEC[30] == true)//Presence
                {
                    List<byte[]> ItemsList = utilities.GetRepetitiveItems(message, 2);
                    DecodePresence(ItemsList);
                }

                if (boolFSPEC[29] == true)//Amplitude of Primary Plot
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 1);
                    DecodeTrackNumber(dataItem);
                }
                if (boolFSPEC[28] == true)//Calculated Acceleration
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeCalculatedAcceleration(dataItem);
                }

                if (boolFSPEC[27] == true) //Spare
                {

                }

                if (boolFSPEC[26] == true)//Special Purpose Field
                {

                }

                if (boolFSPEC[25] == true)//Reserve Expansion Field
                {

                }
            }
        }

        ///DECODING FUNCTIONS
        void DecodeDataSourceIdentifier(byte[] dataItem)
        {
            this.systemIdentificationCode = dataItem[1];
            this.systemAreaCode = dataItem[0];
        }

        void DecodeMessageType(byte[] dataItem)
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
        void DecodeTargetReportDescriptor(byte[] dataItem)
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
                    this.trTYP = "SSR multilateration";
                    break;
                case 1:
                    this.trTYP = "Mode S multilateration";
                    break;
                case 2:
                    this.trTYP = "ADS-B";
                    break;
                case 3:
                    this.trTYP = "PSR";
                    break;
                case 4:
                    this.trTYP = "Magnetic Loop System";
                    break;
                case 5:
                    this.trTYP = "HF multilateration";
                    break;
                case 6:
                    this.trTYP = "Not defined";
                    break;
                case 7:
                    this.trTYP = "Other types";
                    break;
            }
            switch (dcr)
            {
                case 0:
                    this.trDCR = "No differential correction";
                    break;
                case 1:
                    this.trDCR = "Differential correction";
                    break;
            }
            switch (chn)
            {
                case 0:
                    this.trCHN = "Chain 1";
                    break;
                case 1:
                    this.trCHN = "Chain 2";
                    break;
            }
            switch (gbs)
            {
                case 0:
                    this.trGBS = "Transponder Ground bit not set";
                    break;
                case 1:
                    this.trGBS = "Transponder Ground bit set";
                    break;
            }
            switch (crt)
            {
                case 0:
                    this.trCRT = "No Corrupted reply in multilateration";
                    break;
                case 1:
                    this.trCRT = "Corrupted replies in multilateration";
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
                        this.trSIM = "Actual target report";
                        break;
                    case 1:
                        this.trSIM = "Simulated target report";
                        break;
                }
                switch (tst)
                {
                    case 0:
                        this.trTST = "Default";
                        break;
                    case 1:
                        this.trTST = "Test Target";
                        break;
                }
                switch (rab)
                {
                    case 0:
                        this.trRAB = "Report from target transponder";
                        break;
                    case 1:
                        this.trRAB = "Report from field monitor (fixed transponder)";
                        break;
                }
                switch (lop)
                {
                    case 0:
                        this.trLOP = "Undetermined";
                        break;
                    case 1:
                        this.trLOP = "Loop Start";
                        break;
                    case 2:
                        this.trLOP = "Loop Finish";
                        break;
                }
                switch (tot)
                {
                    case 0:
                        this.trTOT = "Undetermined";
                        break;
                    case 1:
                        this.trTOT = "Aircraft";
                        break;
                    case 2:
                        this.trTOT = "Ground Vehicle";
                        break;
                    case 3:
                        this.trTOT = "Helicopter";
                        break;
                }
            }
            if (dataItem.Length >= 3)
            {
                if (dataItem[2] == 0)
                    this.trSPI = "Absence of PSI";
                else if (dataItem[2] > 0)
                    this.trSPI = "Special Position Identification";
            }
        }


        void DecodeTimeOfDay(byte[] dataItem)
        {
            byte[] timeBytes = { dataItem[0], dataItem[1], dataItem[2] };
            double timeResolution = Math.Pow(2,-7);
            double seconds = utilities.DecodeUnsignedByteToDouble(timeBytes, timeResolution);
            this.timeOfDay = TimeSpan.FromSeconds(seconds);
        }

        void DecodeWGS84Coordinates(byte[] dataItem)
        {
            int i = 0;
            byte[] latitudeBytes = new byte[4];
            byte[] longitudeBytes = new byte[4];
            while (i < dataItem.Length)
            {
                if (i <= 3)
                    latitudeBytes[i] = dataItem[i];
                else if (i > 3)
                    longitudeBytes[i - 4] = dataItem[i];
                i++;
            }
            double resolution = 180 / Math.Pow(2,31);
            this.wgs84latitude = utilities.DecodeTwosComplementToDouble(latitudeBytes, resolution);
            this.wgs84longitude = utilities.DecodeTwosComplementToDouble(longitudeBytes, resolution);
        }

        void DecodePolarCoordinatesPosition(byte[] dataItem)
        {
            byte[] rhoBytes = { dataItem[0], dataItem[1] };
            double rhoResolution = 1;
            this.polarRho = utilities.DecodeUnsignedByteToDouble(rhoBytes, rhoResolution);
            byte[] thetaBytes = { dataItem[2], dataItem[3] };
            double thetaResolution = 360 / Math.Pow(2, 16);
            this.polarTheta = utilities.DecodeUnsignedByteToDouble(thetaBytes, thetaResolution);
        }
        void DecodeCartesianCoordinatesPosition(byte[] dataItem)
        {
            byte[] xBytes = { dataItem[0], dataItem[1] };
            double xResolution = 1;
            this.cartesianX = utilities.DecodeTwosComplementToDouble(xBytes, xResolution);
            byte[] yBytes = { dataItem[2], dataItem[3] };
            double yResolution = 1;
            this.cartesianY = utilities.DecodeTwosComplementToDouble(yBytes, yResolution);
        }
        void DecodeCalculatedTrackVelocityInPolarCoordinates(byte[] dataItem)
        {
            byte[] speedBytes = { dataItem[0], dataItem[1] };
            double speedResolution = Math.Pow(2, -14) * 3600;
            this.polarGroundSpeed = utilities.DecodeUnsignedByteToDouble(speedBytes, speedResolution);
            byte[] trackAngleBytes = { dataItem[2], dataItem[3] };
            double trackAngleResolution = (360 / Math.Pow(2, 16));
            this.polarTrackAngle = utilities.DecodeUnsignedByteToDouble(trackAngleBytes, trackAngleResolution);
        }
        void DecodeCalculatedTrackVelocityInCartesianCoordinates(byte[] dataItem)
        {
            byte[] xBytes = { dataItem[0], dataItem[1] };
            double xResolution = 0.25;
            this.cartesianVx = utilities.DecodeTwosComplementToDouble(xBytes, xResolution);
            byte[] yBytes = { dataItem[2], dataItem[3] };
            double yResolution = 0.25;
            this.cartesianVy = utilities.DecodeTwosComplementToDouble(yBytes, yResolution);
        }

        void DecodeTrackNumber(byte[] dataItem)
        {
            byte[] trackBytes = { dataItem[0], dataItem[1] };
            double resolution = 1;
            double number = utilities.DecodeUnsignedByteToDouble(trackBytes, resolution);
            this.trackNumber = (int)number;
        }

        void DecodeTrackStatus(byte[] dataItem)
        {
            byte cnfMask = 128;
            byte treMask = 64;
            byte cstMask = 48;
            byte mahMask = 8;
            byte tccMask = 4;
            byte sthMask = 2;
            int cnf = ((dataItem[0] & cnfMask) >> 7);
            int tre = ((dataItem[0] & treMask) >> 6);
            int cst = ((dataItem[0] & cstMask) >> 4);
            int mah = ((dataItem[0] & mahMask) >> 3);
            int tcc = ((dataItem[0] & tccMask) >> 2);
            int sth = ((dataItem[0] & sthMask) >> 1);

            switch (cnf)
            {
                case 0:
                    this.tsCNF = "Confirmed Track";
                    break;
                case 1:
                    this.tsCNF = "Track in Initialization Phase";
                    break;
            }
            switch (tre)
            {
                case 0:
                    this.tsTRE = "Default";
                    break;
                case 1:
                    this.tsTRE = "Last Report for a Track";
                    break;
            }
            switch (cst)
            {
                case 0:
                    this.tsCST = "No extrapolation";
                    break;
                case 1:
                    this.tsCST = "Predictable extrapolation due to sensor refresh period";
                    break;
                case 2:
                    this.tsCST = "Predictable extrapolation in masked area";
                    break;
                case 3:
                    this.tsCST = "Extrapolation due to unpredictable absence of detection";
                    break;
            }
            switch (mah)
            {
                case 0:
                    this.tsMAH = "Default";
                    break;
                case 1:
                    this.tsMAH = "Horizontal manoeuvre";
                    break;
            }
            switch (tcc)
            {
                case 0:
                    this.tsTCC = "Tracking performed in 'Sensor Plane'";
                    break;
                case 1:
                    this.tsTCC = "Slant range correction";
                    break;
            }
            switch (sth)
            {
                case 0:
                    this.tsSTH = "Measured position";
                    break;
                case 1:
                    this.tsSTH = "Smoothed position";
                    break;
            }
            if (dataItem.Length >= 2)
            {
                byte tomMask = 192;
                byte douMask = 56;
                byte mrsMask = 6;
                int tom = ((dataItem[1] & tomMask) >> 6);
                int dou = ((dataItem[1] & douMask) >> 3);
                int mrs = ((dataItem[1] & mrsMask) >> 1);
                switch (tom)
                {
                    case 0:
                        this.tsTOM = "Unknown type of movement";
                        break;
                    case 1:
                        this.tsTOM = "Taking-off";
                        break;
                    case 2:
                        this.tsTOM = "Landing";
                        break;
                    case 3:
                        this.tsTOM = "Other types of movement";
                        break;
                }
                switch (dou)
                {
                    case 0:
                        this.tsDOU = "No doubt";
                        break;
                    case 1:
                        this.tsDOU = "Doubtful correlation (undetermined reason)";
                        break;
                    case 2:
                        this.tsDOU = "Doubtful correlation in clutter";
                        break;
                    case 3:
                        this.tsDOU = "Loss of accuracy";
                        break;
                    case 4:
                        this.tsDOU = "Loss of accuracy in clutter";
                        break;
                    case 5:
                        this.tsDOU = "Unstable track";
                        break;
                    case 6:
                        this.tsDOU = "Previously coasted";
                        break;
                }
                switch (mrs)
                {
                    case 0:
                        this.tsMRS = "Merge or split indication undetermined";
                        break;
                    case 1:
                        this.tsMRS = "Track merged by association to plot";
                        break;
                    case 2:
                        this.tsMRS = "Track merged by non-association to plot";
                        break;
                    case 3:
                        this.tsMRS = "Splittrack";
                        break;
                }
            }
            if (dataItem.Length >= 3)
            {
                if (dataItem[2] == 0)
                    this.tsGHO = "Default";
                else if (dataItem[2] > 0)
                    this.tsGHO = "Ghost track";
            }
        }
        void DecodeMode3A(byte[] dataItem)
        {
            byte vMask = 128;
            byte gMask = 64;
            byte m3aMask = 15;

            int validated = (vMask & dataItem[0]);
            int garbled = (gMask & dataItem[0]);
            int firstByte = (byte)((m3aMask & dataItem[0]));

            int A = (byte)(firstByte >> 1);
            byte B4 = (byte)((firstByte & 1) << 2);
            byte B21 = (byte)((dataItem[1] & 192) >> 6);
            int B = (int)(B4 + B21);
            int C = (int)((dataItem[1] & 56) >> 3);
            int D = (int)(dataItem[1] & 7);

            this.M3ACode = (A * 1000 + B * 100 + C * 10 + D).ToString();
            switch (validated)
            {
                case 0:
                    this.M3AValidated = "Code Validated";
                    break;
                case 1:
                    this.M3AValidated = "Code Not Validated";
                    break;
            }
            switch (garbled)
            {
                case 0:
                    this.M3AValidated = "Default";
                    break;
                case 1:
                    this.M3AValidated = "Garbled Code";
                    break;
            }
        }
        void DecodeTargetAddress(byte[] dataItem)
        {
            this.targetAddress ="0x" + BitConverter.ToString(dataItem).Replace("-", string.Empty);
        }
        void DecodeTargetIdentification(byte[] dataItem)
        {
            byte char8 = (byte)((dataItem[6] & 63));
            byte char7 = (byte)(((dataItem[6] & 192) >> 6) + ((dataItem[5] & 15) << 2));
            byte char6 = (byte)(((dataItem[5] & 240) >> 4) + ((dataItem[4] & 3)<< 4));
            byte char5 = (byte)((dataItem[4] & 252) >> 2);
            byte char4 = (byte)((dataItem[3] & 63));
            byte char3 = (byte)(((dataItem[3] & 192) >> 6) + ((dataItem[2] & 15) << 2));
            byte char2 = (byte)(((dataItem[2] & 240) >> 4) + ((dataItem[1] & 3) << 4));
            byte char1 = (byte)((dataItem[1] & 252) >> 2);


            byte[] chars = {char1, char2, char3, char4, char5, char6, char7, char8 };
            this.targetIdentification = utilities.GetAircraftIdFromBytes(chars);
        }
        void DecodeModeSMBData(List<byte[]> ItemsList)
        {
            int i = 0;
            while (i < ItemsList.Count)
            {
                byte[] bytes=ItemsList[i];
                byte[] ModeSMBDatabytes = { bytes[0], bytes[1], bytes[2], bytes[3], bytes[4], bytes[5], bytes[6] };
                byte[] ModeSMBCode = { bytes[7] };
                ModeSMBData.Add(ModeSMBDatabytes);
                ModeSMBCodes.Add(ModeSMBCode);

                i++;
            }
        }
        void DecodeVehicleFleetIdentification(byte[] dataItem)
        {
            int value = dataItem[0];
            switch (value) {
                case 0:
                    this.vehicleFleetId= "Unknown";
                    break;
                case 1:
                    this.vehicleFleetId = "ATC equipment maintenance";
                    break;
                case 2:
                    this.vehicleFleetId = "Airport maintenance";
                    break;
                case 3:
                    this.vehicleFleetId = "Fire";
                    break;
                case 4:
                    this.vehicleFleetId = "Bird scarer";
                    break;
                case 5:
                    this.vehicleFleetId = "Snow plough";
                    break;
                case 6:
                    this.vehicleFleetId = "Runaway Sweeper";
                    break;
                case 7:
                    this.vehicleFleetId = "Emergency";
                    break;
                case 8:
                    this.vehicleFleetId = "Police";
                    break;
                case 9:
                    this.vehicleFleetId = "Bus";
                    break;
                case 10:
                    this.vehicleFleetId = "Tug(push/tow)";
                    break;
                case 11:
                    this.vehicleFleetId = "Grass cutter";
                    break;
                case 12:
                    this.vehicleFleetId = "Fuel";
                    break;
                case 13:
                    this.vehicleFleetId = "Baggage";
                    break;
                case 14:
                    this.vehicleFleetId = "Catering";
                    break;
                case 15:
                    this.vehicleFleetId = "Aircraft maintenance";
                    break;
                case 16:
                    this.vehicleFleetId = "Flyco (follow me)";
                    break;
            }

        }
        void DecodeFlightLevel(byte[] dataItem)
        {
            byte vMask = 128;
            byte gMask = 64;
            byte flFirstByteMask = 63;

            int validated = ((dataItem[0] & vMask) >> 7);
            int garbled = ((dataItem[0] & gMask) >> 6);
            byte flFirstByte = (byte)(dataItem[0] & flFirstByteMask);

            byte[] flightLevel = { flFirstByte, dataItem[1] };
            double resolution = 1.0/4.0;
            this.flFlightLevel= utilities.DecodeUnsignedByteToDouble(flightLevel, resolution);

            switch (validated)
            {
                case 0:
                    this.flValidated = "Code Validated";
                    break;
                case 1:
                    this.flValidated = "Code not Validated";
                    break;
            }
            switch (garbled)
            {
                case 0:
                    this.flGarbled = "Default";
                    break;
                case 1:
                    this.flGarbled = "Garbled Code";
                    break;
            }
        }
        void DecodeMeasuredHeight(byte[] dataItem)
        {
            byte[] heightByte = { dataItem[0], dataItem[1] };
            double resolution = 6.25;
            this.measuredHeight = utilities.DecodeTwosComplementToDouble(dataItem, resolution);
        }
        void DecodeTargetSizeAndOrientation(byte[] dataItem)
        {
            byte lengthMask = 254;
            byte orientationMask = 254;
            byte widthMask = 254;
            byte length = (byte)((dataItem[0] & lengthMask) >> 1);
            byte[] lengthByte = { length };
            double lengthResolution = 1;
            this.targetLength = utilities.DecodeUnsignedByteToDouble(lengthByte, lengthResolution);

            if (dataItem.Length >= 2)
            {
                byte orientation = (byte)((dataItem[1] & orientationMask) >> 1);
                byte[] orientationByte = { orientation };
                double orientationResolution = 360.0 / 128.0;
                this.targetOrientation = utilities.DecodeUnsignedByteToDouble(orientationByte, orientationResolution);
            }
            if (dataItem.Length >= 3)
            {
                byte width = (byte)((dataItem[2] & widthMask) >> 1);
                byte[] widthByte = { width };
                double widthResolution = 1;
                this.targetWidth = utilities.DecodeUnsignedByteToDouble(widthByte, widthResolution);
            }
        }
        void DecodeSystemStatus(byte[] dataItem)
        {
            byte nogoMask = 192;
            byte ovlMask = 32;
            byte tsvMask = 16;
            byte divMask = 8;
            byte ttfMask = 4;

            int nogo = ((dataItem[0] & nogoMask) >> 6);
            int ovl = ((dataItem[0] & ovlMask) >> 5);
            int tsv = ((dataItem[0] & tsvMask) >> 4);
            int div = ((dataItem[0] & divMask) >> 3);
            int ttf = ((dataItem[0] & ttfMask) >> 2);

            switch(nogo) 
            {
                case 0:
                    this.ssNOGO = "Operational";
                    break;
                case 1:
                    this.ssNOGO = "Degraded";
                    break;

                case 2:
                    this.ssNOGO = "NOGO";
                    break;
            }
            switch (ovl)
            {
                case 0:
                    this.ssOVL = "No overload";
                    break;
                case 1:
                    this.ssOVL = "Overload";
                    break;
            }
            switch (tsv)
            {
                case 0:
                    this.ssTSV = "valid";
                    break;
                case 1:
                    this.ssTSV = "invalid";
                    break;
            }
            switch (div)
            {
                case 0:
                    this.ssDIV = "Normal Operation";
                    break;
                case 1:
                    this.ssDIV = "Diversity degraded";
                    break;
            }
            switch (ttf)
            {
                case 0:
                    this.ssTTF = "Test Target Operative";
                    break;
                case 1:
                    this.ssTTF = "Test Target Failure";
                    break;
            }
        }
        void DecodePreProgrammedMessage(byte[] dataItem)
        {
            byte octet= dataItem[0];
            byte maskTrb = 128;
            byte maskMsg = 127;
            
           
            int TRB = ((maskTrb & octet)>>7);
            int MSG = ((maskMsg & octet));

            switch (TRB)
            {
                case 0:
                    this.ppmTRB = "Default";
                    break;
                case 1:
                    this.ppmTRB = "In Trouble";
                    break;
            }

            switch (MSG)
            {
                case 1:
                    this.ppMSG = "Towing Aircraft";
                    break;
                case 2:
                    this.ppMSG = "'Follow me' operation";
                    break;
                case 3:
                    this.ppMSG = "Runway check";
                    break;
                case 4:
                    this.ppMSG = "Emergency operation(fire,medical...)";
                    break;
                case 5:
                    this.ppMSG = "Work in progress(maintenance,birds scarer,sweepers...)";
                    break;
            }
        }
        void DecodeStandardDeviationOfPosition(byte[] dataItem)
        {
            byte[] xstandarddeviation = { dataItem[0] };
            byte[] ystandarddeviation = { dataItem[1] };
            byte[] xystandardeviation = {dataItem[2],dataItem[3]};

            this.standardDeviationX = utilities.DecodeUnsignedByteToDouble(xstandarddeviation, 0.25);
            this.standardDeviationY= utilities.DecodeUnsignedByteToDouble(ystandarddeviation, 0.25);
            this.standardDeviationXY= utilities.DecodeUnsignedByteToDouble(xystandardeviation, 0.25);
        }
        void DecodePresence(List<byte[]> ItemsList)
        {
            int i = 0;
            while (i < ItemsList.Count)
            {
                byte[] bytes = ItemsList[i];
                byte[] DRHO = { bytes[0]};
                byte[] DTHETA = { bytes[1] };

                double resolution = 1;

                double drho = utilities.DecodeTwosComplementToDouble(DRHO, resolution);
                double dtheta = utilities.DecodeTwosComplementToDouble(DTHETA, resolution);


                presenceDrho.Add(drho);
                presenceDtheta.Add(dtheta);

                i++;
            }
        }
            void DecodeAmplitudeOfPrimaryPlot(byte[] dataItem)
        {
            
            this.amplitudeOfPrimaryPlot = utilities.DecodeUnsignedByteToDouble(dataItem,0.255);
        }
        void DecodeCalculatedAcceleration(byte[] dataItem)
        {
            byte[] xBytes = { dataItem[0] };
            double xResolution = 0.25;
            this.calcAccelerationX = utilities.DecodeTwosComplementToDouble(xBytes, xResolution);
            byte[] yBytes = { dataItem[1] };
            double yResolution = 0.25;
            this.calcAccelerationY = utilities.DecodeTwosComplementToDouble(yBytes, yResolution);
        }
        //FUNCIONES GET PARAMETERS


        public string GetDataSourceIdentifier()
        {
            return this.systemAreaCode.ToString() + this.systemIdentificationCode.ToString();
        }

        public string GetTimeOfDay()
        {
            if (timeOfDay != new TimeSpan())
                return this.timeOfDay.ToString();
            else
                return "N/A";
        }

        public string GetTargetAddress()
        {
            return targetAddress;
        }

        public string GetTargetID()
        {
            return targetIdentification;
        }

        public string[] GetTargetReportDescriptor()
        {
            string[] result = { trTYP, trDCR, trCHN, trGBS, trCRT, trSIM, trTST, trRAB, trLOP, trTOT, trSPI };
            return result;
        }

        public Dictionary<string, string> GetPolarPosition()
        {
            return new Dictionary<string, string>
            {
                {"rho", polarRho.ToString() },
                {"theta", polarTheta.ToString() },
            };
        }
        public Dictionary<string, string> GetCartesianPosition()
        {
            return new Dictionary<string, string>
            {
                {"X", cartesianX.ToString() },
                {"Y", cartesianY.ToString() },
            };
        }
        public Dictionary<string, string> GetPolarVelocity()
        {
            return new Dictionary<string, string>
            {
                {"ground speed", polarGroundSpeed.ToString() },
                {"track angle", polarTrackAngle.ToString() },
            };
        }
        public Dictionary<string, string> GetCartesianVelocity()
        {
            return new Dictionary<string, string>
            {
                {"Vx", cartesianVx.ToString() },
                {"Vy", cartesianVy.ToString() },
            };
        }

        public Dictionary<string, string> GetSizeAndOrientation()
        {
            return new Dictionary<string, string>
            {
                {"width", targetWidth.ToString() },
                {"length", targetLength.ToString() },
                {"orientation", targetOrientation.ToString() }
            };
        }
        public Dictionary<string, string> GetWGS84CoordinatesString()
        {
            return new Dictionary<string, string>
            {
                {"latitude", wgs84latitude.ToString() },
                {"longitude", wgs84longitude.ToString() },
            };
        }
        public Dictionary<string, string> GetCalculatedAcceleration()
        {
            return new Dictionary<string, string>
            {
                {"Ax", calcAccelerationX.ToString() },
                {"Ay", calcAccelerationY.ToString() },
            };
        }
        public Dictionary<string, string> GetFlightLevel()
        {
            return new Dictionary<string, string>
            {
                {"validated", flValidated },
                {"garbled", flGarbled },
                {"flight level", flFlightLevel.ToString() },
            };
        }
        public Dictionary<string, string> GetStandardDeviationOfPosition()
        {
            return new Dictionary<string, string>
            {
                {"X", (standardDeviationX.ToString() !="NaN" ? standardDeviationX.ToString() + " m" : "N/A")},
                {"Y", (standardDeviationY.ToString() !="NaN" ? standardDeviationY.ToString() + " m" : "N/A") },
                {"XY", (standardDeviationXY.ToString() !="NaN" ? standardDeviationXY.ToString() + " m^2" : "N/A") },
            };
        }

        public string GetMeasuredHeight()
        {
            return measuredHeight.ToString();
        }

        // FUNCIONES INTERFAZ
        public int GetLength()
        {
            return this.length;
        }

        public int GetCategory()
        {
            return 10;
        }

        public TimeSpan GetTime()
        {
            return this.timeOfDay;
        }

        public string GetTypeOfMessage()
        {
            if (this.systemIdentificationCode == 7)
                return "SMR";
            else
                return "MLAT";
        }

        public double[] GetWGS84Coordinates()
        {
            if (!Double.IsNaN(wgs84latitude))
            {
                double[] wgs84 = { wgs84latitude, wgs84longitude };
                return wgs84;
            }

            else
            {
                if (GetTypeOfMessage() == "SMR")
                {
                    GeoUtils geoUtils = new GeoUtils();
                    Coordinates radarCoordinates = utilities.GetCoordinatesOfRadar("SMRLebl");
                    CoordinatesWGS84 radarWGS84 = new CoordinatesWGS84(radarCoordinates.GetLatitude()* (Math.PI/180.0), radarCoordinates.GetLongitude()* (Math.PI / 180.0));
                    CoordinatesXYZ objectCartesian = new CoordinatesXYZ(cartesianX, cartesianY, 0);
                    CoordinatesXYZ objectGeocentric = geoUtils.change_radar_cartesian2geocentric(radarWGS84, objectCartesian);
                    CoordinatesWGS84 objectWGS84 = geoUtils.change_geocentric2geodesic(objectGeocentric);
                    double[] wgs84 = { objectWGS84.Lat* (180.0/Math.PI), objectWGS84.Lon * (180.0 / Math.PI) };
                    return wgs84;
                }
                else if (GetTypeOfMessage() == "MLAT")
                {
                    GeoUtils geoUtils = new GeoUtils();
                    Coordinates radarCoordinates = utilities.GetCoordinatesOfRadar("ARPLebl");
                    CoordinatesWGS84 radarWGS84 = new CoordinatesWGS84(radarCoordinates.GetLatitude() * (Math.PI / 180.0), radarCoordinates.GetLongitude() * (Math.PI / 180.0));
                    CoordinatesXYZ objectCartesian = new CoordinatesXYZ(cartesianX, cartesianY, 0);
                    CoordinatesXYZ objectGeocentric = geoUtils.change_radar_cartesian2geocentric(radarWGS84, objectCartesian);
                    CoordinatesWGS84 objectWGS84 = geoUtils.change_geocentric2geodesic(objectGeocentric);
                    double[] wgs84 = { objectWGS84.Lat * (180.0 / Math.PI), objectWGS84.Lon * (180.0 / Math.PI) };
                    return wgs84;
                }
                else
                {
                    return null;
                }
            }
        }

        public CAT10 GetCAT10()
        {
            return this;
        }

        public CAT21 GetCAT21()
        {
            return null;
        }
    }
}
