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
        int serviceIdentification;
        TimeSpan timeOfAppicabilityPosition;

        double wgs84latitude;
        double wgs84longitude;
        double wgs84latitudehigh;
        double wgs84longitudehigh;

        TimeSpan timeOfApplicabilityVelocity;
        string RETrueAirspeed;
        string IM;
        double trueAirSpeed;
        double airSpeed;
        int targetAddress;
        TimeSpan timeOfMessageReceptionPosition;
        string FSITimeofMessageReceptionPositionHighResolution;
        string FSITimeofMessageReceptionVelocityhighprecision;
        TimeSpan timeOfMessageReceptionPositionHighResolution;
        TimeSpan timeOfMessageReceptionVelocity;
        TimeSpan timeofmessagereceptionvelocityhighprecision;

        double geometricHeight;

        string mopsVN;
        string mopsVNS;
        string mopsLTT;
        string m3ACode;
        double rollAngle;
        double flightLevel;
        double magneticHeading;

        string tsIcf;
        string tsLnav;
        string tsPs;
        string tsSs;

        double barometricVerticalRate;
        string barometricRE;
        double geometricVerticalRate;
        string geometricRE;
        string airborneGroundVectorRE;
        double groundSpeed;
        double trackAngle;
        double trackAngleRate;
        TimeSpan timeOfAsterixReportTransmission;

        string targetIdentification;

        string trAtp;
        string trArc;
        string trRc;
        string trRab;
        string trDcr;
        string trGbs;
        string trSim;
        string trTst;
        string trSaa;
        string trCl;
        string trIpc;
        string trNogo;
        string trCpr;
        string trLdpj;
        string trRcf;




        public CAT21(int length)
        {
            this.utilities = Utilities.GetInstance();

            this.length = length;
            this.message = null;
            this.FSPEC = null;

            this.systemIdentificationCode = -1;
            this.systemAreaCode = -1;

            this.trackNumber = -1;
            this.serviceIdentification = -1;
            this.timeOfAppicabilityPosition = new TimeSpan();

            this.wgs84latitude = double.NaN;
            this.wgs84longitude = double.NaN;
            this.wgs84latitudehigh = double.NaN;
            this.wgs84longitudehigh = double.NaN;

            this.timeOfApplicabilityVelocity = new TimeSpan();

            this.RETrueAirspeed = "N/A";
            this.IM= "N/A";
            this.trueAirSpeed = double.NaN;
            this.airSpeed = double.NaN;
            this.targetAddress = -1;
            this.timeOfMessageReceptionPosition = new TimeSpan();
            this.FSITimeofMessageReceptionVelocityhighprecision= "N/A";
            this.FSITimeofMessageReceptionPositionHighResolution = "N/A";
            this.timeOfMessageReceptionPositionHighResolution = new TimeSpan();

            this.timeOfMessageReceptionVelocity = new TimeSpan();
            this.timeofmessagereceptionvelocityhighprecision = new TimeSpan();
            this.geometricHeight = double.NaN;

            this.mopsVN= "N/A";
            this.mopsVNS = "N/A";
            this.mopsLTT = "N/A";
            this.m3ACode = "N/A";
            this.rollAngle = double.NaN;
            this.flightLevel = double.NaN;
            this.magneticHeading = double.NaN;

            this.tsIcf = "N/A";
            this.tsLnav = "N/A";
            this.tsPs = "N/A";
            this.tsSs = "N/A";



            this.barometricVerticalRate = double.NaN;
            this.barometricRE = "N/A";
            this.geometricVerticalRate = double.NaN;
            this.geometricRE = "N/A";
            this.airborneGroundVectorRE = "N/A";
            this.groundSpeed = double.NaN;
            this.trackAngle = double.NaN;
            this.trackAngleRate = double.NaN;
            this.timeOfAsterixReportTransmission = new TimeSpan();
            this.targetIdentification = "N/A";

            this.trAtp= "N/A";
            this.trArc = "N/A";
            this.trRc = "N/A";
            this.trRab = "N/A";
            this.trDcr = "N/A";
            this.trGbs = "N/A";
            this.trSim = "N/A";
            this.trTst = "N/A";
            this.trSaa = "N/A";
            this.trCl = "N/A";
            this.trIpc = "N/A";
            this.trNogo = "N/A";
            this.trCpr = "N/A";
            this.trLdpj = "N/A";
            this.trRcf = "N/A";
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
                    DecodeTargetReportDescriptor(dataItem);
                }
                if (boolFSPEC[5] == true) // Track Number
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeTrackNumber(dataItem);
                }
                if (boolFSPEC[4] == true) // Service Identification
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 1);
                    DecodeServiceIdentification(dataItem);
                }
                if (boolFSPEC[3] == true) //Time of Applicability for Position
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 3);
                    DecodeTimeOfApplicabilityForPosition(dataItem);
                }
                if (boolFSPEC[2] == true) // Position in WGS84 coordinates
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 6);
                    DecodePositionInWGS84Coordinates(dataItem);
                }
                if (boolFSPEC[1] == true) // Position in WGS84 coordinates, high resolution
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 8);
                    DecodeHighResolutionPostionInWGS84Coordinates(dataItem);
                }
            }
            if (FSPEC.Length >= 2)
            {
                if (boolFSPEC[15] == true) //Time of Applicability for Velocity
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 3);
                    DecodeTimeOfApplicabilityForVelocity(dataItem);
                }
                if (boolFSPEC[14] == true) //Air Speed
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeAirspeed(dataItem);

                }

                if (boolFSPEC[13] == true) //True AirSpeed
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeTrueAirspeed(dataItem);
                }

                if (boolFSPEC[12] == true) //Target Address
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 3);
                    DecodeTargetAddress(dataItem);
                }

                if (boolFSPEC[11] == true)//Time of Message Reception of Position
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 3);
                    DecodeTimeOfMessageReceptionOfPosition(dataItem);
                }

                if (boolFSPEC[10] == true)//Time of Message Reception of Position high res
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 4);
                    DecodeTimeOfMessageReceptionOfPositionHighResolution(dataItem);
                }

                if (boolFSPEC[9] == true)//Time of Message Reception of Velocity
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 3);
                    DecodeTimeOfMessageReceptionOfVelocity(dataItem);
                }
            }

            if (FSPEC.Length >= 3)
            {
                if (boolFSPEC[23] == true) //Time of Message Reception of Velocity-High Precision 
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 4);
                    DecodeTimeofmessagereceptionvelocityhighprecision(datItem);
                }

                if (boolFSPEC[22] == true) //Geometric Height
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeGeometricheight(datItem);

                }

                if (boolFSPEC[21] == true) //Quality Indicators 
                {
                    byte[] datItem = utilities.GetVariableLengthDataItem(message);

                }

                if (boolFSPEC[20] == true) //MOPS Version 
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 1);
                    DecodeMOPSVersion(datItem);

                }

                if (boolFSPEC[19] == true) //Mode 3/A Code
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeMode3ACode(datItem);

                }

                if (boolFSPEC[18] == true) //Roll Angle
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeRollAngle(datItem);

                }

                if (boolFSPEC[17] == true) //Flight Level
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeFlightLevel(datItem);

                }


            }

            if (FSPEC.Length >= 4)
            {
                if (boolFSPEC[31] == true) //Magnetic heading
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeMagneticHeading(datItem);

                }

                if (boolFSPEC[30] == true) //Target status
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 1);
                    DecodeTargetStatus(datItem);
                }

                if (boolFSPEC[29] == true) //Barometric vertical rate
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeBarometricVerticalRate(datItem);
                }

                if (boolFSPEC[28] == true) //Geometric vertical rate
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeGeometricVerticalRate(datItem);
                }

                if (boolFSPEC[27] == true) //Airborne Ground Vector
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 4);
                    DecodeAirbornGroundVector(datItem);

                }

                if (boolFSPEC[26] == true) //Track angle rate
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeTrackAngleRate(datItem);

                }

                if (boolFSPEC[25] == true) //Time of Report Transmission
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 3);
                    DecodeTimeOfReportTransmission(datItem);

                }
            }
            if (FSPEC.Length >= 5)
            {
                if (boolFSPEC[39] == true) //Target Identification
                {
                    byte[] dataItem = utilities.GetFixedLengthDataItem(message, 6);
                    DecodeTargetIdentification(dataItem);
                }

                if (boolFSPEC[38] == true) //Emitter category
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 1);

                }

                if (boolFSPEC[37] == true) //Met information
                {
                    byte[] datItem = utilities.GetVariableLengthDataItem(message);

                }

                if (boolFSPEC[36] == true) //Selected altitude
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 2);

                }

                if (boolFSPEC[35] == true) //Final state selected altitude
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 2);

                }

                if (boolFSPEC[34] == true) //Trajectory intent
                {
                    byte[] datItem = utilities.GetVariableLengthDataItem(message);

                }
                if (boolFSPEC[33] == true) //Service management
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 1);

                }
            }

            if (FSPEC.Length >= 6)
            {
                if (boolFSPEC[47] == true) //Aircraft Operational Status
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 1);

                }

                if (boolFSPEC[46] == true) //Surfce capabilities and charcterisitcs
                {
                    byte[] datItem = utilities.GetVariableLengthDataItem(message);


                }

                if (boolFSPEC[45] == true) //Message Amplitude
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 1);

                }

                if (boolFSPEC[44] == true) //Mode S MB Data
                {


                }

                if (boolFSPEC[43] == true) //ACAS Resolution Advisory Report
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 7);

                }

                if (boolFSPEC[42] == true) //Reciever ID
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 1);

                }

                if (boolFSPEC[41] == true) //Data Ages
                {
                    byte[] datItem = utilities.GetVariableLengthDataItem(message);

                }
            }
            if (FSPEC.Length >= 7)
            {
                if (boolFSPEC[50] == true) //Reserved expansion field
                {
                    byte[] datItem = utilities.GetVariableLengthDataItem(message);

                }

                if (boolFSPEC[49] == true) //Special purpose field
                {
                    byte[] datItem = utilities.GetVariableLengthDataItem(message);
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
            
                byte atpMask = 224;
               
                byte arcMask = 24;
                byte rcMask = 4;
                byte rabMask = 2;

                int atp = ((dataItem[0] & atpMask) >> 5);
              
                int arc = ((dataItem[0] & arcMask) >> 3);
                int rc = ((dataItem[0] & rcMask) >> 2);
                int rab = ((dataItem[0] & rabMask) >> 1);
                switch (atp)
                {
                    case 0:
                        this.trAtp= "24-BIT ICAO address";
                        break;
                    case 1:
                        this.trAtp = "Duplicate address";
                        break;
                    case 2:
                        this.trAtp = "Surface vehicle address";
                        break;
                    case 3:
                        this.trAtp = "Anonmous address";
                        break;
                    case 4:
                        this.trAtp = "Reserved for future use";
                        break;
                    case 5:
                        this.trAtp = "Reserved for future use";
                        break;
                    case 6:
                        this.trAtp= "Reserved for future use";
                        break;
                    case 7:
                        this.trAtp = "Reserved for future use";
                        break;
                }
                 switch (arc)
                 {
                    case 0:
                        this.trArc ="25 ft";
                        break;
                    case 1:
                        this.trArc = "100 ft";
                        break;
                    case 2:
                        this.trArc = "Uknown";
                        break;
                    case 3:
                        this.trArc = "Invalid";
                        break;
                    }
                    switch (rc)
                {
                    case 0:
                        this.trRc = "Default";
                        break;
                    case 1:
                        this.trRc = "Range Check passed, CPR Validation pending";
                        break;
                }
                switch (rab)
                {
                    case 0:
                        this.trRab = "Report from taget transponder";
                        break;
                    case 1:
                        this.trRab = "Report from field monitor(fixed transponder)";
                        break;
                }

                if (dataItem.Length >= 2)
                {
                    byte dcrMask = 128;
                    byte gbsMask = 64;
                    byte simMask = 32;
                    byte tstMask = 16;
                    byte saaMask = 8;
                    byte clMask = 6;

                    int dcr = ((dataItem[1] & dcrMask) >> 7);
                    int gbs = ((dataItem[1] & gbsMask) >> 6);
                    int sim = ((dataItem[1] & simMask) >> 5);
                    int tst = ((dataItem[1] & tstMask) >> 4);
                    int saa = ((dataItem[1] & saaMask) >> 3);
                    int cl = ((dataItem[1] & clMask) >> 1);
                    switch (dcr)
                    {
                        case 0:
                            this.trDcr = "No differential correction(ADS-B)";
                            break;
                        case 1:
                            this.trDcr = "Differential correction(ADS-B)";
                            break;
                    }
                    switch (gbs)
                    {
                        case 0:
                            this.trGbs = "Ground Bit no set";
                            break;
                        case 1:
                            this.trGbs = "Ground bit set";
                            break;
                    }
                    switch (sim)
                    {
                        case 0:
                            this.trSim = "Actual target report";
                            break;
                        case 1:
                            this.trSim = "Simulated target report";
                            break;
                }
                switch (tst)
                {
                    case 0:
                        this.trTst = "Default";
                        break;
                    case 1:
                        this.trTst = "Test target";
                        break;
                }
                switch (saa)
                {
                    case 0:
                        this.trSaa = "equipment capable to provide selected altitude";
                        break;
                    case 1:
                        this.trSaa = "Equipment not capable to provide selected altitude";
                        break;
                }
                switch (dcr)
                    {
                        case 0:
                            this.trDcr = "No differential correction(ADS-B)";
                            break;
                        case 1:
                            this.trDcr = "Differential correction(ADS-B)";
                            break;
                    }
                   
                    switch (cl)
                    {
                        case 0:
                            this.trCl = "Report Valid";
                            break;
                        case 1:
                            this.trCl = "Report suspect";
                            break;
                        case 2:
                            this.trCl = "No information";
                            break;
                        case 3:
                            this.trCl = "Reserved future use";
                            break;
                    }
                }
                if (dataItem.Length >= 3)
                {
                byte ipcMask = 32;
                byte nogoMask = 16;
                byte cprMask = 8;
                byte ldpjMask = 4;
                byte rcfMask = 2;
                int ipc = ((dataItem[2] & ipcMask) >> 5);
                int nogo = ((dataItem[2] & nogoMask) >> 4);
                int cpr= ((dataItem[2] & cprMask) >> 3);
                int ldpj = ((dataItem[2] & ldpjMask) >> 2);
                int rcf = ((dataItem[2] & rcfMask) >> 1);

                switch (ipc)
                {
                    case 0:
                        this.trIpc = "default(see note)";
                        break;
                    case 1:
                        this.trIpc = "independent Position Check failed";
                        break;
                }
                switch (nogo)
                {
                    case 0:
                        this.trNogo= "NOGO-bit not set";
                        break;
                    case 1:
                        this.trNogo = "NOGO-bit set";
                        break;
                }
                switch (cpr)
                {
                    case 0:
                        this.trCpr = "CPR Validation correct";
                        break;
                    case 1:
                        this.trCpr = "CPR Validation failed";
                        break;
                }
                switch (ldpj)
                {
                    case 0:
                        this.trLdpj = "LDPJ not detected";
                        break;
                    case 1:
                        this.trLdpj = "LDPJ detected";
                        break;
                }
                switch (rcf)
                {
                    case 0:
                        this.trRcf = "default";
                        break;
                    case 1:
                        this.trRcf= "Range Check failed";
                        break;
                }
            }
            }

        public void DecodeTrackNumber(byte[] dataItem)
        {
            byte[] trackBytes = { dataItem[0], dataItem[1] };
            double resolution = 1;
            double number = utilities.DecodeUnsignedByteToDouble(trackBytes, resolution);
            this.trackNumber = (int)number;
        }

        public void DecodeServiceIdentification(byte[] dataItem)
        {
            double resolution = 1;
            double number = utilities.DecodeUnsignedByteToDouble(dataItem, resolution);
            this.serviceIdentification = (int)number;
        }

        public void DecodeTimeOfApplicabilityForPosition(byte[] dataItem)
        {
            double resolution = Math.Pow(2, -7);
            double number = utilities.DecodeUnsignedByteToDouble(dataItem, resolution);
            this.timeOfAppicabilityPosition = TimeSpan.FromSeconds(number);
        }


        public void DecodePositionInWGS84Coordinates(byte[] dataItem)
        {
            int i = 0;
            byte[] latitudeBytes = new byte[3];
            byte[] longitudeBytes = new byte[3];
            while (i < dataItem.Length)
            {
                if (i <= 2)
                    latitudeBytes[i] = dataItem[i];
                else if (i > 2)
                    longitudeBytes[i - 3] = dataItem[i];
                i++;
            }
            double resolution = 180 / Math.Pow(2, 23);
            this.wgs84latitude = utilities.DecodeTwosComplementToDouble(latitudeBytes, resolution);
            this.wgs84longitude = utilities.DecodeTwosComplementToDouble(longitudeBytes, resolution);

        }

        public void DecodeHighResolutionPostionInWGS84Coordinates(byte[] dataItem)
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
            double resolution = 180 / Math.Pow(2, 30);
            this.wgs84latitudehigh = utilities.DecodeTwosComplementToDouble(latitudeBytes, resolution);
            this.wgs84longitudehigh = utilities.DecodeTwosComplementToDouble(longitudeBytes, resolution);
        }

        public void DecodeTimeOfApplicabilityForVelocity(byte[] dataItem)
        {
            double resolution = Math.Pow(2, -7);
            double number = utilities.DecodeUnsignedByteToDouble(dataItem, resolution);
            this.timeOfApplicabilityVelocity = TimeSpan.FromSeconds(number);
        }

        public void DecodeAirspeed(byte[] dataItem)
        {
            double resolution = 1;
            byte maskIM = 128;
            byte secondmask = 127;
            int IM = ((dataItem[0] & maskIM) >> 7);
            byte firstbyte = (byte)(dataItem[0] & secondmask);
            byte[] mybytes = { firstbyte, dataItem[1] };


            if (IM == 1) { resolution = 0.001; }//mach
            else if (IM == 0) { resolution = (2 ^ -14); }//NM/s
            this.airSpeed = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);


            switch (IM)
            {
                case 0:
                    this.IM = "IAS";
                    break;
                case 1:
                    this.IM = "MACH";
                    break;
            }
        }

        public void DecodeTrueAirspeed(byte[] dataItem)
        {
            byte maskRE = 128;
            byte secondmask = 127;
            int RE = ((dataItem[0] & maskRE) >> 7);
            byte firstbyte = (byte)(dataItem[0] & secondmask);
            byte[] mybytes = { firstbyte, dataItem[1] };
            double resolution = 1;//knots
            this.trueAirSpeed = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);


            switch (RE)
            {
                case 0:
                    this.RETrueAirspeed = "Value in defined range";
                    break;
                case 1:
                    this.RETrueAirspeed = "Value exceeds defined range";
                    break;
            }

        }

        public void DecodeTargetAddress(byte[] dataItem) {
           double resolution = 1;
            this.targetAddress = (int)utilities.DecodeUnsignedByteToDouble(dataItem, resolution);

        }

        public void DecodeTimeOfMessageReceptionOfPosition(byte[] dataItem)
        {
            double resolution = Math.Pow(2, -7);
            double seconds = utilities.DecodeUnsignedByteToDouble(dataItem, resolution);
            this.timeOfMessageReceptionPosition = TimeSpan.FromSeconds(seconds);
        }

        public void DecodeTimeOfMessageReceptionOfPositionHighResolution(byte[] dataItem)
        {
            byte maskFSI = 192;
            byte secondmask = 63;
            int FSI=((dataItem[0] & maskFSI) >>6 );
            byte firstbyte = (byte)(dataItem[0] & secondmask);
            byte[] mybytes = { firstbyte, dataItem[1],dataItem[2],dataItem[3] };
            double resolution = (1/Math.Pow(2,30));//seconds
            double seconds = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            this.timeOfMessageReceptionPositionHighResolution = TimeSpan.FromSeconds(seconds);


            switch (FSI)
            {
                case 0:
                    this.FSITimeofMessageReceptionPositionHighResolution = "TOMRp whole seconds=(1021/073) Whole seconds";
                    break;
                case 1:
                    this.FSITimeofMessageReceptionPositionHighResolution = "TOMRp whole seconds = (1021 / 073) Whole seconds+1";
                    break;
                case 2:
                    this.FSITimeofMessageReceptionPositionHighResolution = "TOMRp whole seconds = (1021 / 073) Whole seconds-1";
                    break;
                case 3:
                    this.FSITimeofMessageReceptionPositionHighResolution = "Reserved";
                    break;
            }

        }

        public void DecodeTimeOfMessageReceptionOfVelocity(byte[] dataItem) 
        {
            double resolution = Math.Pow(2,-7);
            double seconds = utilities.DecodeUnsignedByteToDouble(dataItem, resolution);
            this.timeOfMessageReceptionVelocity = TimeSpan.FromSeconds(seconds);

        }

        public void DecodeTimeofmessagereceptionvelocityhighprecision(byte[] dataItem)
        {
            byte maskFSI = 192;
            byte secondmask = 63;
            int FSI = ((dataItem[0] & maskFSI) >> 6);
            byte firstbyte = (byte)(dataItem[0] & secondmask);
            byte[] mybytes = { firstbyte, dataItem[1], dataItem[2], dataItem[3] };
            double resolution = (1 / Math.Pow(2, 30));//seconds
            double seconds = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            this.timeofmessagereceptionvelocityhighprecision = TimeSpan.FromSeconds(seconds);


            switch (FSI)
            {
                case 0:
                    this.FSITimeofMessageReceptionVelocityhighprecision = "TOMRp whole seconds=(1021/073) Whole seconds";
                    break;
                case 1:
                    this.FSITimeofMessageReceptionVelocityhighprecision = "TOMRp whole seconds = (1021 / 073) Whole seconds+1";
                    break;
                case 2:
                    this.FSITimeofMessageReceptionVelocityhighprecision = "TOMRp whole seconds = (1021 / 073) Whole seconds-1";
                    break;
                case 3:
                    this.FSITimeofMessageReceptionVelocityhighprecision = "Reserved";
                    break;
            }
        }
        public void DecodeGeometricheight (byte[] dataItem)
        {
            double resolution = 6.25;//ft
            this.geometricHeight = utilities.DecodeTwosComplementToDouble(dataItem, resolution);
        }
        public void QualityIndicators(byte[] dataItem)
        {

        }
        public void DecodeMOPSVersion(byte[] dataItem)
        {
            byte VNSmask = 64;
            byte VNmask = 56;
            byte LTTmask = 7;
            int vns = ((VNSmask & dataItem[0]) >> 6);
            int vn = ((VNmask & dataItem[0]) >> 3);
            int LTT = (LTTmask & dataItem[0]);

            switch (vn)
            {
                case 0:
                    this.mopsVN = "ED102/DO-260[Ref.8]";
                    break;
                case 1:
                    this.mopsVN = "DO-260A[Ref.9]";
                    break;
                case 2:
                    this.mopsVN = "ED102A/DO-260B[Ref.11]";
                    break;

            }

            switch (vns)
            {
                case 0:
                    this.mopsVNS = "The MOPS Version is supported by the GS";
                    break;
                case 1:
                    this.mopsVNS = "The MOPS Version is not supported by the GS";
                    break;

            }

            switch (LTT)
            {
                case 0:
                    this.mopsLTT = "Other";
                    break;
                case 1:
                    this.mopsLTT = "UAT";
                    break;
                   
                    
                case 2:
                    this.mopsLTT = "1090 ES";
                    break;
                case 3:
                    this.mopsLTT = "VDL 4";
                    break;
                case 4:
                    this.mopsLTT = "Not assigned";
                    break;
                case 5:
                    this.mopsLTT = "Not assigned";
                    break;
                case 6:
                    this.mopsLTT = "Not assigned";
                    break;
                case 7:
                    this.mopsLTT = "Not assigned";
                    break;


            }
        

        }
        public void DecodeMode3ACode(byte[] dataItem)
        {
            int firstByte = (byte)((dataItem[0]));

            int A = (byte)(firstByte >> 1);
            byte B4 = (byte)((firstByte & 1) << 2);
            byte B21 = (byte)((dataItem[1] & 192) >> 6);
            int B = (int)(B4 + B21);
            int C = (int)((dataItem[1] & 56) >> 3);
            int D = (int)(dataItem[1] & 7);

            this.m3ACode = (A * 1000 + B * 100 + C * 10 + D).ToString();
        }
        public void DecodeRollAngle(byte[] dataItem)
        {
            double resolution = 0.01;//degrees
            this.rollAngle = utilities.DecodeTwosComplementToDouble(dataItem, resolution);
        }
        public void DecodeFlightLevel(byte[] dataItem)
        {
            double resolution = (1.0 / 4.0);
            this.flightLevel = utilities.DecodeTwosComplementToDouble(dataItem, resolution);
        }
        public void DecodeMagneticHeading(byte[] dataItem)
        {
            double resolution = (360 / Math.Pow(2,16));
            this.magneticHeading = utilities.DecodeUnsignedByteToDouble(dataItem,resolution);
        }
        public void DecodeTargetStatus(byte[] dataItem)
        {
            byte ICFmask = 128;
            byte LNAVmask = 64;
            byte PSmask = 28;
            byte SSmask = 3;

            int icf = ((ICFmask & dataItem[0])>>7);
            int lnav = ((LNAVmask & dataItem[0]) >> 6);
            int ps = ((PSmask & dataItem[0]) >> 2);
            int SS=(SSmask & dataItem[0]);
            switch (icf)
            {
                case 0:
                    this.tsIcf = "No intent change active";
                    break;
                case 1:
                    this.tsIcf = "Intent change flag raised";
                    break; 
            }

            switch (lnav)
            {
                case 0:
                    this.tsLnav = "LNAV Mode engaged";
                    break;
                case 1:
                    this.tsLnav = "LNAV Mode not engaged";
                    break;
            }
            switch (ps)
            {
                case 0:
                    this.tsPs = "No emergency/not reported";
                    break;
                case 1:
                    this.tsPs = "General Emergency";
                    break;
                case 2:
                    this.tsPs = "Lifeguard/medical emergency";
                    break;
                case 3:
                    this.tsPs = "Minimum fuel";
                    break;
                case 4:
                    this.tsPs = "No communications";
                    break;
                case 5:
                    this.tsPs = "Unlawful interference";
                    break;
                case 6:
                    this.tsPs = "'Downed' Aircraft";
                    break;




            }
            switch (SS)
            {
                case 0:
                    this.tsSs = "No condition reported";
                    break;
                case 1:
                    this.tsSs = "Permanent Alert (Emergency condition)";
                    break;
                case 2:
                    this.tsSs = "Temporary Alert (change in Mode 3/A Code other than emergency)";
                    break;
                case 3:
                    this.tsSs = "SPI set";
                    break;

            }


        }

        public void DecodeBarometricVerticalRate(byte[] dataItem)
        {   double resolution = 6.25;//ft/min
            byte REmask = 128;
            byte secondmask = 127;
            int RE = (int)((REmask & dataItem[0]) >> 7);
            byte firstbyte = (byte)(secondmask & dataItem[0]);
            byte[] mybytes = { firstbyte, dataItem[1] };
            switch (RE)
            {
                case 0:
                    this.barometricRE = "Value in defined range";
                    break;
                case 1:
                    this.barometricRE = "Value exceeds defined range";
                    break;
            }
            this.barometricVerticalRate = utilities.DecodeTwosComplementToDouble(mybytes, resolution);
        }
        public void DecodeGeometricVerticalRate(byte[] dataItem)
        {
            double resolution = 6.25;//ft/min
            byte REmask = 128;
            byte secondmask = 127;
            int RE = (int)((REmask & dataItem[0]) >> 7);
            byte firstbyte = (byte)(secondmask & dataItem[0]);
            byte[] mybytes = { firstbyte, dataItem[1] };
            switch (RE)
            {
                case 0:
                    this.geometricRE = "Value in defined range";
                    break;
                case 1:
                    this.geometricRE = "Value exceeds defined range";
                    break;
            }
            this.geometricVerticalRate = utilities.DecodeTwosComplementToDouble(mybytes, resolution);

        }
        public void DecodeAirbornGroundVector(byte[] dataItem)
        {
            double resolutiongroundspeed = (1/Math.Pow(2,14));//NM/S
            double resolutiontrackangle = (360 / Math.Pow(2,16));//degrees
            byte REmask = 128;
            byte secondmask = 127;
            int RE = (int)((REmask & dataItem[0]) >> 7);
            byte firstbyte = (byte)(secondmask & dataItem[0]);
            byte[] groundspeed = { firstbyte, dataItem[1] };
            byte[] trackangle = {dataItem[2],dataItem[3] };

            switch (RE)
            {
                case 0:
                    this.airborneGroundVectorRE = "Value in defined range";
                    break;
                case 1:
                    this.airborneGroundVectorRE = "Value exceeds defined range";
                    break;
            }
            this.groundSpeed = utilities.DecodeUnsignedByteToDouble(groundspeed, resolutiongroundspeed);
            this.trackAngle = utilities.DecodeUnsignedByteToDouble(trackangle, resolutiontrackangle);
        }
        public void DecodeTrackAngleRate(byte[] dataItem)
        {
            double resolution = (1/32);//deg/s
            
            byte secondmask = 3;
            
            byte firstbyte = (byte)(secondmask & dataItem[0]);
            byte[] mybytes = { firstbyte, dataItem[1] };
           
            this.trackAngleRate = utilities.DecodeTwosComplementToDouble(mybytes, resolution);
        }
        public void DecodeTimeOfReportTransmission(byte[] dataItem)
        {
            double resolution = Math.Pow(2, -7);
            double seconds = utilities.DecodeUnsignedByteToDouble(dataItem, resolution);
            this.timeOfAsterixReportTransmission = TimeSpan.FromSeconds(seconds);
        }
        public void DecodeTargetIdentification(byte[] dataItem)
        {
            byte char8 = (byte)((dataItem[5] & 63));
            byte char7 = (byte)(((dataItem[5] & 192) >> 6) + ((dataItem[4] & 15) << 2));
            byte char6 = (byte)(((dataItem[4] & 240) >> 4) + ((dataItem[3] & 3) << 4));
            byte char5 = (byte)((dataItem[3] & 252) >> 2);
            byte char4 = (byte)((dataItem[2] & 63));
            byte char3 = (byte)(((dataItem[2] & 192) >> 6) + ((dataItem[1] & 15) << 2));
            byte char2 = (byte)(((dataItem[1] & 240) >> 4) + ((dataItem[0] & 3) << 4));
            byte char1 = (byte)((dataItem[0] & 252) >> 2);


            byte[] chars = { char1, char2, char3, char4, char5, char6, char7, char8 };
            this.targetIdentification = utilities.GetAircraftIdFromBytes(chars);
        }
        public void DecodeEmitterCategory(byte[] dataItem)
        {

        }
        public void MetInformation(byte[] dataItem)
        {

        }
        public void SelectedAltitude(byte[] dataItem)
        {

        }
        public void Finalstateselectedaltitude(byte[] dataItem)
        {

        }
        public void Trajectoryintent(byte[] dataItem)
        {

        }
        public void ServiceManagement(byte[] dataItem)
        {

        }
        public void Aircraftoperationalstatus(byte[] dataItem)
        {

        }
        public void Surfacecapabilitiesandcharacteristics(byte[] dataItem)
        {

        }
        public void Messageamplitude(byte[] dataItem)
        {

        }
        public void ModeSMData(byte[] dataItem)
        {

        }
        public void ACASResolutionadvisoryreport(byte[] dataItem)
        {

        }
        public void Recieverid(byte[] dataItem)
        {

        }
        public void Dataages(byte[] dataItem)
        {

        }
        public void Reservedexpansionfield(byte[] dataItem)
        {

        }
        public void Specialpurposefield(byte[] dataItem)
        {

        }






















        public int GetLength()
        {
            return this.length;


        }
    }
}
