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

            this.wgs84latitude = -1;
            this.wgs84longitude = -1;

            this.polarRho = -1;
            this.polarTheta = -1;

            this.polarGroundSpeed = -1;
            this.polarTrackAngle = -1;

            this.cartesianVx = -1;
            this.cartesianVy = -1;

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
                    DecodeTrackStatus(data);
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
            if (FSPEC.Length >= 3)
            {
                if (boolFSPEC[23] == true)//Mode S MB Datat
                {

                }

                if (boolFSPEC[22] == true)//Vehicle Fleet Identification
                {

                }

                if (boolFSPEC[21] == true)//Flight Level in Binary Representation
                {

                }
                if (boolFSPEC[20] == true)//Measured Height
                {

                }

                if (boolFSPEC[19] == true)//Target Size & Orientation
                {

                }

                if (boolFSPEC[18] == true)//System Status
                {

                }

                if (boolFSPEC[17] == true)//Pre-Programmed Message
                {

                }
            }
            if (FSPEC.Length >= 4)
            {
                if (boolFSPEC[31] == true)//Standard Deviation of Position
                {

                }

                if (boolFSPEC[30] == true)//Presence
                {

                }

                if (boolFSPEC[29] == true)//Amplitude of Primary Plot
                {

                }
                if (boolFSPEC[28] == true)//Calculated Acceleration
                {

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


        public void DecodeTimeOfDay(byte[] dataItem)
        {
            byte[] timeBytes = { dataItem[0], dataItem[1], dataItem[2] };
            double timeResolution = Math.Pow(2,-7);
            double seconds = utilities.DecodeUnsignedByteToDouble(timeBytes, timeResolution);
            this.timeOfDay = TimeSpan.FromSeconds(seconds);
            int c = 1;
        }

        public void DecodeWGS84Coordinates(byte[] dataItem)
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

        public void DecodeTrackNumber(byte[] dataItem)
        {
            byte[] trackBytes = { dataItem[0], dataItem[1] };
            double resolution = 1;
            double number = utilities.DecodeUnsignedByteToDouble(trackBytes, resolution);
            this.trackNumber = (int)number;
        }

        public void DecodeTrackStatus(byte[] dataItem)
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
        public void DecodeMode3A(byte[] data)
        { 

        }
        public void DecodeTargetAddress(byte[] data)
        {

        }
        public void DecodeTargetIdentification(byte[] data)
        {

        }
        public void DecodeModeSMBData(byte[] data)
        {

        }
        public void DecodeVehicleFleetIdentification(byte[] data)
        {

        }
        public void DecodeFlightLevel(byte[] data)
        {

        }
        public void DecodeMeasuredHeight(byte[] data)
        {

        }
        public void DecodeTargetSizeAndOrientation(byte[] data)
        {

        }
        public void DecodeSystemStatus(byte[] data)
        {

        }
        public void DecodePreProgrammedMessage(byte[] data)
        {

        }
        public void StandardDeviationOfPosition(byte[] data)
        {

        }
        public void DecodePresence(byte[] data)
        {

        }
        public void DecodeAmplitudeOfPrimaryPlot(byte[] data)
        {

        }
        public void DecodeCalculatedAcceleration(byte[] data)
        {

        }

    }
}
