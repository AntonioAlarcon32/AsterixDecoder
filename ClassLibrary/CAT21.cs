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

        string eCat;

        string mIws;
        string mIwd;
        string mItmp;
        string mItrb;

        double mIwindspeed;
        double mIwinddirection;
        double mItemperature;
        int mIturbulence;

        string sAsas;
        string sAsource;
        double sAaltitude;

        string fssAmv;
        string fssAah;
        string fssAam;
        double fssAaltitude;
        double serviceManagement;

        string aoSra;
        string aoStc;
        string aoSts;
        string aoSarv;
        string aoScdtia;
        string aoSnottcas;
        string aoSsa;

        string sCpoa;
        string sCcdtis;
        string sCb2low;
        string sCras;
        string sCident;
        string sClw;

        double messageAmplitude;
        int receiverId;

        string dAaos;
        string dAtrd;
        string dAm3a;
        string dAqi;
        string dAti;
        string dAmam;
        string dAgh;
        string dAfl;
        string dAisa;
        string dAfsa;
        string dAas;
        string dAtas;
        string dAmh;
        string dAbvr;
        string dAgvr;
        string dAgv;
        string dAtar;
        string dATi;
        string dAts;
        string dAmet;
        string dAroa;
        string dAara;
        string dAscc;

        double dAAos;
        double dATrd;
        double dAM3a;
        double dAQi;
        double dATI;
        double dAMam;
        double dAGh;
        double dAFl;
        double dAIsa;
        double dAFsa;
        double dAAs;
        double dATas;
        double dAMh;
        double dABvr;
        double dAGvr;
        double dAGv;
        double dATar;
        double dATTI;
        double dATs;
        double dAMet;
        double dARoa;
        double dAAra;
        double dAScc;

        List<byte[]> ModeSMBData;
        List<byte[]> ModeSMBCodes;
       


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
            this.IM = "N/A";
            this.trueAirSpeed = double.NaN;
            this.airSpeed = double.NaN;
            this.targetAddress = -1;
            this.timeOfMessageReceptionPosition = new TimeSpan();
            this.FSITimeofMessageReceptionVelocityhighprecision = "N/A";
            this.FSITimeofMessageReceptionPositionHighResolution = "N/A";
            this.timeOfMessageReceptionPositionHighResolution = new TimeSpan();

            this.timeOfMessageReceptionVelocity = new TimeSpan();
            this.timeofmessagereceptionvelocityhighprecision = new TimeSpan();
            this.geometricHeight = double.NaN;

            this.mopsVN = "N/A";
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

            this.trAtp = "N/A";
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

            this.eCat = "N/A";

            this.mIws = "N/A";
            this.mIwd = "N/A";
            this.mItmp = "N/A";
            this.mItrb = "N/A";

            this.mIwindspeed = double.NaN; ;
            this.mIwinddirection = double.NaN; ;
            this.mItemperature = double.NaN; ;
            this.mIturbulence = -1;

            this.sAsas = "N/A";
            this.sAsource = "N/A";
            this.sAaltitude = double.NaN;

            this.fssAmv = "N/A";
            this.fssAah = "N/A";
            this.fssAam = "N/A";
            this.fssAaltitude = double.NaN;

            this.serviceManagement = double.NaN;

            this.aoSra = "N/A";
            this.aoStc = "N/A";
            this.aoSts = "N/A";
            this.aoSarv = "N/A";
            this.aoScdtia = "N/A";
            this.aoSnottcas = "N/A";
            this.aoSsa = "N/A";

            this.sCpoa = "N/A";
            this.sCcdtis = "N/A";
            this.sCb2low = "N/A";
            this.sCras = "N/A";
            this.sCident = "N/A";
            this.sClw = "N/A";

            this.messageAmplitude = double.NaN;

            this.receiverId = -1;

            this.dAaos = "N/A";
            this.dAtrd = "N/A";
            this.dAm3a = "N/A";
            this.dAqi = "N/A";
            this.dAti = "N/A";
            this.dAmam = "N/A";
            this.dAgh = "N/A";
            this.dAfl = "N/A";
            this.dAisa = "N/A";
            this.dAfsa = "N/A";
            this.dAas = "N/A";
            this.dAtas = "N/A";
            this.dAmh = "N/A";
            this.dAbvr = "N/A";
            this.dAgvr = "N/A";
            this.dAgv = "N/A";
            this.dAgv = "N/A";
            this.dAgv = "N/A";
            this.dAtar = "N/A";
            this.dATi = "N/A";
            this.dAts = "N/A";
            this.dAmet = "N/A";
            this.dAroa = "N/A";
            this.dAara = "N/A";
            this.dAscc = "N/A";

            this.dAAos = double.NaN;
            this.dATrd = double.NaN;
            this.dAM3a = double.NaN;
            this.dAQi = double.NaN;
            this.dATI = double.NaN;
            this.dAMam = double.NaN;
            this.dAGh = double.NaN;
            this.dAFl = double.NaN;
            this.dAIsa = double.NaN;
            this.dAFsa = double.NaN;
            this.dAAs = double.NaN;
            this.dATas = double.NaN;
            this.dAMh = double.NaN;
            this.dABvr = double.NaN;
            this.dAGvr = double.NaN;
            this.dAGv = double.NaN;
            this.dATar = double.NaN;
            this.dATTI = double.NaN;
            this.dATs = double.NaN;
            this.dAMet = double.NaN;
            this.dARoa = double.NaN;
            this.dAAra = double.NaN;
            this.dAScc = double.NaN;

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
                    DecodeEmitterCategory(datItem);
                }

                if (boolFSPEC[37] == true) //Met information
                {
                    byte[] datItem = utilities.GetVariableLengthDataItem(message);
                    DecodeMetInformation(datItem);
                }

                if (boolFSPEC[36] == true) //Selected altitude
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeSelectedAltitude(datItem);

                }

                if (boolFSPEC[35] == true) //Final state selected altitude
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeFinalstateselectedaltitude(datItem);
                }

                if (boolFSPEC[34] == true) //Trajectory intent
                {
                    byte[] datItem = utilities.GetVariableLengthDataItem(message);
                    DecodeTrajectoryIntent(datItem);
                }
                if (boolFSPEC[33] == true) //Service management
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 1);
                    DecodeServiceManagement(datItem);
                }
            }

            if (FSPEC.Length >= 6)
            {
                if (boolFSPEC[47] == true) //Aircraft Operational Status
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 1);
                    DecodeAircraftOperationalStatus(datItem);
                }

                if (boolFSPEC[46] == true) //Surfce capabilities and charcterisitcs
                {
                    byte[] datItem = utilities.GetVariableLengthDataItem(message);
                    DecoadeSurfaceCapabilitiesAndCharacteristics(datItem);

                }

                if (boolFSPEC[45] == true) //Message Amplitude
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 1);
                    DecodeMessageAmplitude(datItem);
                }

                if (boolFSPEC[44] == true) //Mode S MB Data
                {
                    List<byte[]> ItemsList = utilities.GetRepetitiveItems(message, 8);
                    DecodeModeSMBData(ItemsList);

                }

                if (boolFSPEC[43] == true) //ACAS Resolution Advisory Report
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 7);
                    DecodeACASResolutionAdvisoryReport(datItem);

                }

                if (boolFSPEC[42] == true) //Reciever ID
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 1);
                    DecodeRecieverId(datItem);
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
                    this.trAtp = "24-BIT ICAO address";
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
                    this.trAtp = "Reserved for future use";
                    break;
                case 7:
                    this.trAtp = "Reserved for future use";
                    break;
            }
            switch (arc)
            {
                case 0:
                    this.trArc = "25 ft";
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
                int cpr = ((dataItem[2] & cprMask) >> 3);
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
                        this.trNogo = "NOGO-bit not set";
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
                        this.trRcf = "Range Check failed";
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

        public void DecodeTargetAddress(byte[] dataItem)
        {
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
            int FSI = ((dataItem[0] & maskFSI) >> 6);
            byte firstbyte = (byte)(dataItem[0] & secondmask);
            byte[] mybytes = { firstbyte, dataItem[1], dataItem[2], dataItem[3] };
            double resolution = (1 / Math.Pow(2, 30));//seconds
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
            double resolution = Math.Pow(2, -7);
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
        public void DecodeGeometricheight(byte[] dataItem)
        {
            double resolution = 6.25;//ft
            this.geometricHeight = utilities.DecodeTwosComplementToDouble(dataItem, resolution);
        }
        public void QualityIndicators(byte[] dataItem)

        {
            byte nucrmask = 224;
            byte nucpmask = 30;

            int nucr = ((dataItem[0] & nucrmask) >> 5);
            int nucp = ((dataItem[0] & nucpmask) >> 1);


            if (dataItem.Length >= 2) ;
            if (dataItem.Length >= 3) ;
            if (dataItem.Length >= 4) ;

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
            double resolution = (360 / Math.Pow(2, 16));
            this.magneticHeading = utilities.DecodeUnsignedByteToDouble(dataItem, resolution);
        }
        public void DecodeTargetStatus(byte[] dataItem)
        {
            byte ICFmask = 128;
            byte LNAVmask = 64;
            byte PSmask = 28;
            byte SSmask = 3;

            int icf = ((ICFmask & dataItem[0]) >> 7);
            int lnav = ((LNAVmask & dataItem[0]) >> 6);
            int ps = ((PSmask & dataItem[0]) >> 2);
            int SS = (SSmask & dataItem[0]);
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
            double resolutiongroundspeed = (1 / Math.Pow(2, 14));//NM/S
            double resolutiontrackangle = (360 / Math.Pow(2, 16));//degrees
            byte REmask = 128;
            byte secondmask = 127;
            int RE = (int)((REmask & dataItem[0]) >> 7);
            byte firstbyte = (byte)(secondmask & dataItem[0]);
            byte[] groundspeed = { firstbyte, dataItem[1] };
            byte[] trackangle = { dataItem[2], dataItem[3] };

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
            double resolution = (1 / 32);//deg/s

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
            int ecat = (int)dataItem[0];
            switch (ecat)
            {
                case 0:
                    this.eCat = "No ADS-B Emitter Category Information";
                    break;
                case 1:
                    this.eCat = "light aircraft<=15500 lbs";
                    break;
                case 2:
                    this.eCat = "15500 lbs<small aircraft<300000 lbs";
                    break;
                case 3:
                    this.eCat = "75000 lbs<medium a/c<300000 lbs";
                    break;
                case 4:
                    this.eCat = "High vortex Large";
                    break;
                case 5:
                    this.eCat = "300000lbs<=heavy aircraft";
                    break;
                case 6:
                    this.eCat = "highly manouvrable(5g acceleration capability) and high speed(>400knots cruise)";
                    break;
                case 7:
                    this.eCat = "reserved";
                    break;
                case 8:
                    this.eCat = "reserved";
                    break;
                case 9:
                    this.eCat = "reserved";
                    break;
                case 10:
                    this.eCat = "rotorcraft";
                    break;
                case 11:
                    this.eCat = "glider/sailplane";
                    break;
                case 12:
                    this.eCat = "lighter than air";
                    break;
                case 13:
                    this.eCat = "unmanned aerial vehicle";
                    break;
                case 14:
                    this.eCat = "space/transarmospheric vehicle";
                    break;
                case 15:
                    this.eCat = "ultralight/handglider/paraglider";
                    break;
                case 16:
                    this.eCat = "parachutist/skydiver";
                    break;
                case 17:
                    this.eCat = "reserved";
                    break;
                case 18:
                    this.eCat = "reserved";
                    break;
                case 19:
                    this.eCat = "reserved";
                    break;
                case 20:
                    this.eCat = "surface emergency vehicle";
                    break;
                case 21:
                    this.eCat = "surface service vehicle";
                    break;
                case 22:
                    this.eCat = "fixed ground or tethered obstruction";
                    break;
                case 23:
                    this.eCat = "cluster obstacle";
                    break;
                case 24:
                    this.eCat = "line obstacle";
                    break;
            }
        }
        public void DecodeMetInformation(byte[] dataItem)
        {
            byte maskws = 128;
            byte maskwd = 64;
            byte masktmp = 32;
            byte masktrb = 16;

            int ws = ((dataItem[0] & maskws) >> 7);
            int wd = ((dataItem[0] & maskwd) >> 6);
            int tmp = ((dataItem[0] & masktmp) >> 5);
            int trb = ((dataItem[0] & masktrb) >> 4);

            switch (ws)
            {
                case 0:
                    this.mIws = "Absence of Subfield #1";
                    break;
                case 1:
                    this.mIws = "Presence of Subfield #1";
                    break;


            }
            switch (wd)
            {
                case 0:
                    this.mIwd = "Absence of Subfield #2";
                    break;
                case 1:
                    this.mIwd = "Presence of Subfield #2";
                    break;


            }
            switch (tmp)
            {
                case 0:
                    this.mItmp = "Absence of Subfield #3";
                    break;
                case 1:
                    this.mItmp = "Presence of Subfield #3";
                    break;


            }
            switch (trb)
            {
                case 0:
                    this.mItrb = "Absence of Subfield #4";
                    break;
                case 1:
                    this.mItrb = "Presence of Subfield #4";
                    break;


            }
            if (dataItem.Length >= 2)
            {
                double resolution = 1;//knots
                byte[] mybytes = { dataItem[1], dataItem[2] };
                this.mIwindspeed = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }
            if (dataItem.Length >= 4)
            {
                double resolution = 1;//degrees
                byte[] mybytes = { dataItem[3], dataItem[4] };
                this.mIwinddirection = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }
            if (dataItem.Length >= 6)
            {
                double resolution = 0.25;//temperature C
                byte[] mybytes = { dataItem[5], dataItem[6] };
                this.mItemperature = utilities.DecodeTwosComplementToDouble(mybytes, resolution);

            }
            if (dataItem.Length >= 8)
            {


                this.mIturbulence = (int)dataItem[7];
            }



        }
        public void DecodeSelectedAltitude(byte[] dataItem)
        {
            double resolution = 25;//ft
            byte sasMask = 128;
            byte sourceMask = 96;
            byte firstbyteMask = 31;

            int sas = ((sasMask & dataItem[0]) >> 7);
            int source = ((sourceMask & dataItem[0]) >> 5);
            byte firstbyte = (byte)(dataItem[0] & firstbyteMask);
            byte[] mybytes = { firstbyte, dataItem[1] };

            switch (sas)
            {
                case 0:
                    this.sAsas = "No source information provided";
                    break;
                case 1:
                    this.sAsas = "Source information provided";
                    break;


            }
            switch (source)
            {
                case 0:
                    this.sAsource = "Uknown";
                    break;
                case 1:
                    this.sAsource = "Aircraft Altitude(Holding Altitude)";
                    break;
                case 2:
                    this.sAsource = "MCP/FCU Selected Altitude";
                    break;
                case 3:
                    this.sAsource = "FMS Selected Altitude";
                    break;



            }
            this.sAaltitude = utilities.DecodeTwosComplementToDouble(mybytes, resolution);
        }
        public void DecodeFinalstateselectedaltitude(byte[] dataItem)
        {
            double resolution = 25;//ft
            byte mvMask = 128;
            byte ahMask = 64;
            byte amMask = 32;
            byte firstbyteMask = 31;

            int mv = ((mvMask & dataItem[0]) >> 7);
            int ah = ((ahMask & dataItem[0]) >> 6);
            int am = ((amMask & dataItem[0]) >> 5);
            byte firstbyte = (byte)(dataItem[0] & firstbyteMask);
            byte[] mybytes = { firstbyte, dataItem[1] };

            switch (mv)
            {
                case 0:
                    this.fssAmv = "Not active or uknowun";
                    break;
                case 1:
                    this.fssAmv = "Active";
                    break;


            }
            switch (ah)
            {
                case 0:
                    this.fssAah = "Not active or unknown";
                    break;
                case 1:
                    this.fssAah = "Active";
                    break;


            }
            switch (am)
            {
                case 0:
                    this.fssAam = "Not active or unknown";
                    break;
                case 1:
                    this.fssAam = "Active";
                    break;

            }
            this.fssAaltitude = utilities.DecodeTwosComplementToDouble(mybytes, resolution);
        }
        public void DecodeTrajectoryIntent(byte[] dataItem)
        {
           /* byte tisMask = 128;
            byte tidMask = 64;

            int tis = ((tisMask & dataItem[0]) >> 7);
            int tid = ((tidMask & dataItem[0]) >> 6);
            switch (tis)
            {
                case 0:
                    this.tiTis = "Absence of subfield #1";
                    break;
                case 1:
                    this.tiTis = "Presence of subfield #1";
                    break;


            }
            switch (tid)
            {
                case 0:
                    this.tiTid = "Absence of subfield #2";
                    break;
                case 1:
                    this.tiTid = "Presence of subfield #2";
                    break;


            }
            if (dataItem.Length >= 2)
            {
                byte navMask = 128;
                byte nvbMask = 64;

                int nav = ((navMask & dataItem[1]) >> 7);
                int nvb = ((nvbMask & dataItem[1]) >> 6);
                switch (nav)
                {
                    case 0:
                        this.tiNav = "Trajectory Intent Data is available for this aircraft";
                        break;
                    case 1:
                        this.tiNav = "Trajectory Intent Data is not available for this aircraft";
                        break;


                }
                switch (nvb)
                {
                    case 0:
                        this.tiNvb = "Trajectory Intent Data is valid";
                        break;
                    case 1:
                        this.tiNvb = "Trajectory Intent Data is not valid";
                        break;

            
                }
            }*/
        }
        public void DecodeServiceManagement(byte[] dataItem)
        {
            double resolution = 0.5;//s
            this.serviceManagement = utilities.DecodeUnsignedByteToDouble(dataItem, resolution);

        }
        public void DecodeAircraftOperationalStatus(byte[] dataItem)
        {
            byte ramask = 128;
            byte tcmask = 96;
            byte tsmask = 16;
            byte arvmask = 8;
            byte cdtiamask = 4;
            byte nottcasmask = 2;
            byte samask = 1;

            int ra = ((dataItem[0] & ramask) >> 7);
            int tc = ((dataItem[0] & tcmask) >> 5);
            int ts = ((dataItem[0] & tsmask) >> 4);
            int arv = ((dataItem[0] & arvmask) >> 3);
            int cdtia = ((dataItem[0] & cdtiamask) >> 2);
            int nottcas = ((dataItem[0] & nottcasmask) >> 1);
            int sa = (dataItem[0] & samask);

            switch (ra)
            {
                case 0:
                    this.aoSra = "TCAS II or ACAS RA not active";
                    break;
                case 1:
                    this.aoSra = "TCAS RA active";
                    break;


            }
            switch (tc)
            {
                case 0:
                    this.aoStc = "no capability for Trajectory change report";
                    break;
                case 1:
                    this.aoStc = "support for TC+0 reports only";
                    break;
                case 2:
                    this.aoStc = "support for multiple TC reports";
                    break;
                case 3:
                    this.aoStc = "reserved";
                    break;

            }
            switch (ts)
            {
                case 0:
                    this.aoSts = "no capability to support Target State Reports";
                    break;
                case 1:
                    this.aoSts = "capable of supporting target State Reports";
                    break;


            }
            switch (arv)
            {
                case 0:
                    this.aoSarv = "no capability to generate ARV-reports";
                    break;
                case 1:
                    this.aoSarv = "capable of generate ARV-reports";
                    break;


            }
            switch (cdtia)
            {
                case 0:
                    this.aoScdtia = "cdti not operational";
                    break;
                case 1:
                    this.aoScdtia = "cdti operational";
                    break;


            }
            switch (nottcas)
            {
                case 0:
                    this.aoSnottcas = "TCAS operational";
                    break;
                case 1:
                    this.aoSnottcas = "TCAS not operational";
                    break;


            }
            switch (sa)
            {
                case 0:
                    this.aoSsa = "Antenna diversity";
                    break;
                case 1:
                    this.aoSsa = "Single Antenna Only";
                    break;


            }

        }
        public void DecoadeSurfaceCapabilitiesAndCharacteristics(byte[] dataItem)
        {
            byte poaMask = 32;
            byte cdtisMask = 16;
            byte b2lowMask = 8;
            byte rasMask = 4;
            byte identMask = 2;

            int poa = ((dataItem[0] & poaMask) >> 5);
            int cdtis = ((dataItem[0] & cdtisMask) >> 4);
            int b2low = ((dataItem[0] & b2lowMask) >> 3);
            int ras = ((dataItem[0] & rasMask) >> 2);
            int ident = ((dataItem[0] & identMask) >> 1);

            switch (poa)
            {
                case 0:
                    this.sCpoa = "Postion transmitted is not ADS-B position reference point";
                    break;
                case 1:
                    this.sCpoa = "Postion transmitted is the ADS-B position reference point";
                    break;


            }
            switch (cdtis)
            {
                case 0:
                    this.sCcdtis = "CDTI not operational";
                    break;
                case 1:
                    this.sCcdtis = "CDTI operational";
                    break;


            }
            switch (b2low)
            {
                case 0:
                    this.sCb2low = ">=70 Watts";
                    break;
                case 1:
                    this.sCb2low = "<70 Watts";
                    break;


            }
            switch (ras)
            {
                case 0:
                    this.sCras = "aircraft not receiving ATC-services";
                    break;
                case 1:
                    this.sCras = "aircraft receiving ATC-services";
                    break;


            }
            switch (ident)
            {
                case 0:
                    this.sCident = "IDENT switch not active";
                    break;
                case 1:
                    this.sCident = "IDENT switch active";
                    break;


            }
            if (dataItem.Length >= 2)
            {
                byte lwMask = 15;
                int lw = (dataItem[1] & lwMask);

                switch (lw)
                {
                    case 0:
                        this.sClw = "L<11.5 & W<11.5";
                        break;
                    case 1:
                        this.sClw = "L<11.5 & W<23";
                        break;
                    case 2:
                        this.sClw = "L<25 & W<28.5";
                        break;
                    case 3:
                        this.sClw = "L<25 & W<34";
                        break;
                    case 4:
                        this.sClw = "L<35 & W<33";
                        break;
                    case 5:
                        this.sClw = "L<35 & W<38";
                        break;
                    case 6:
                        this.sClw = "L<45 & W<39.5";
                        break;
                    case 7:
                        this.sClw = "L<45 & W<45";
                        break;
                    case 8:
                        this.sClw = "L<55 & W<45";
                        break;
                    case 9:
                        this.sClw = "L<55 & W<52";
                        break;
                    case 10:
                        this.sClw = "L<65 & W<59.5";
                        break;
                    case 11:
                        this.sClw = "L<65 & W<67";
                        break;
                    case 12:
                        this.sClw = "L<75 & W<72.5";
                        break;
                    case 13:
                        this.sClw = "L<75 & W<80";
                        break;
                    case 14:
                        this.sClw = "L<85 & W<80";
                        break;
                    case 15:
                        this.sClw = "L>85 & W>80";
                        break;


                }
            }
        }
        public void DecodeMessageAmplitude(byte[] dataItem)
        {
            double resolution = 1;//dbm
            this.messageAmplitude = utilities.DecodeUnsignedByteToDouble(dataItem, resolution);
        }
        
            void DecodeModeSMBData(List<byte[]> ItemsList)
            {
                int i = 0;
                while (i < ItemsList.Count)
                {
                    byte[] bytes = ItemsList[i];
                    byte[] ModeSMBDatabytes = { bytes[0], bytes[1], bytes[2], bytes[3], bytes[4], bytes[5], bytes[6] };
                    byte[] ModeSMBCode = { bytes[7] };
                    ModeSMBData.Add(ModeSMBDatabytes);
                    ModeSMBCodes.Add(ModeSMBCode);

                    i++;
                }
            }
        
        public void DecodeACASResolutionAdvisoryReport(byte[] dataItem)
        {
            byte typMask = 240;
            byte stypMask = 7;

            int typ = ((dataItem[0] & typMask) >> 3);
            int styp = ((dataItem[0] & stypMask));

        }
        public void DecodeRecieverId(byte[] dataItem)
        {
            this.receiverId = (int)(dataItem[0]);
        }
        public void Dataages(byte[] dataItem)
        {
            byte aosMask = 128;
            byte trdMask = 64;
            byte m3aMask = 32;
            byte qiMask = 16;
            byte tiMask = 8;
            byte mamMask = 4;
            byte ghMask = 2;

            int aos = ((dataItem[0] & aosMask) >> 7);
            int fl = ((dataItem[1] & aosMask) >> 7);
            int gvr = ((dataItem[2] & aosMask) >> 7);
            int ara = ((dataItem[3] & aosMask) >> 7);

            int trd = ((dataItem[0] & trdMask) >> 6);
            int isa = ((dataItem[1] & trdMask) >> 6);
            int gv = ((dataItem[2] & trdMask) >> 6);
            int scc = ((dataItem[3] & trdMask) >> 6);

            int m3a = ((dataItem[0] & m3aMask) >> 5);
            int fsa = ((dataItem[1] & m3aMask) >> 5);
            int tar = ((dataItem[2] & m3aMask) >> 5);


            int qi = ((dataItem[0] & qiMask) >> 4);
            int ass = ((dataItem[1] & qiMask) >> 4);
            int Ti = ((dataItem[2] & qiMask) >> 4);

            int ti = ((dataItem[0] & tiMask) >> 3);
            int tas = ((dataItem[1] & tiMask) >> 3);
            int ts = ((dataItem[2] & tiMask) >> 3);

            int mam = ((dataItem[0] & mamMask) >> 2);
            int mh = ((dataItem[1] & mamMask) >> 2);
            int met = ((dataItem[2] & mamMask) >> 2);

            int gh = ((dataItem[0] & ghMask) >> 1);
            int bvr = ((dataItem[1] & ghMask) >> 1);
            int roa = ((dataItem[2] & ghMask) >> 1);

            switch (aos)
            {
                case 0:
                    this.dAaos = "Absence of subfield #1";
                    break;
                case 1:
                    this.dAaos = "Presence of subfield #1";
                    break;


            }
            switch (trd)
            {
                case 0:
                    this.dAtrd = "Absence of subfield #2";
                    break;
                case 1:
                    this.dAtrd = "Presence of subfield #2";
                    break;


            }
            switch (m3a)
            {
                case 0:
                    this.dAm3a = "Absence of subfield #3";
                    break;
                case 1:
                    this.dAm3a = "Presence of subfield #3";
                    break;


            }
            switch (qi)
            {
                case 0:
                    this.dAqi = "Absence of subfield #4";
                    break;
                case 1:
                    this.dAqi = "Presence of subfield #4";
                    break;


            }
            switch (Ti)
            {
                case 0:
                    this.dAti = "Absence of subfield #5";
                    break;
                case 1:
                    this.dAti = "Presence of subfield #5";
                    break;


            }
            switch (mam)
            {
                case 0:
                    this.dAmam = "Absence of subfield #6";
                    break;
                case 1:
                    this.dAmam = "Presence of subfield #6";
                    break;


            }
            switch (gh)
            {
                case 0:
                    this.dAgh = "Absence of subfield #7";
                    break;
                case 1:
                    this.dAgh = "Presence of subfield #7";
                    break;


            }
            switch (fl)
            {
                case 0:
                    this.dAfl = "Absence of subfield #8";
                    break;
                case 1:
                    this.dAfl = "Presence of subfield #8";
                    break;


            }
            switch (isa)
            {
                case 0:
                    this.dAisa = "Absence of subfield #9";
                    break;
                case 1:
                    this.dAisa = "Presence of subfield #9";
                    break;


            }
            switch (fsa)
            {
                case 0:
                    this.dAfsa = "Absence of subfield #10";
                    break;
                case 1:
                    this.dAfsa = "Presence of subfield #10";
                    break;


            }
            switch (ass)
            {
                case 0:
                    this.dAas = "Absence of subfield #11";
                    break;
                case 1:
                    this.dAas = "Presence of subfield #11";
                    break;


            }
            switch (tas)
            {
                case 0:
                    this.dAtas = "Absence of subfield #12";
                    break;
                case 1:
                    this.dAtas = "Presence of subfield #12";
                    break;


            }
            switch (mh)
            {
                case 0:
                    this.dAmh = "Absence of subfield #13";
                    break;
                case 1:
                    this.dAmh = "Presence of subfield #13";
                    break;


            }
            switch (bvr)
            {
                case 0:
                    this.dAbvr = "Absence of subfield #14";
                    break;
                case 1:
                    this.dAbvr = "Presence of subfield #14";
                    break;


            }
            switch (gvr)
            {
                case 0:
                    this.dAgvr = "Absence of subfield #15";
                    break;
                case 1:
                    this.dAgvr = "Presence of subfield #15";
                    break;


            }
            switch (gv)
            {
                case 0:
                    this.dAgv = "Absence of subfield #16";
                    break;
                case 1:
                    this.dAgv = "Presence of subfield #16";
                    break;


            }
            switch (tar)
            {
                case 0:
                    this.dAtar = "Absence of subfield #17";
                    break;
                case 1:
                    this.dAtar = "Presence of subfield #17";
                    break;


            }
            switch (ti)
            {
                case 0:
                    this.dATi = "Absence of subfield #18";
                    break;
                case 1:
                    this.dATi = "Presence of subfield #18";
                    break;


            }
            switch (ts)
            {
                case 0:
                    this.dAts = "Absence of subfield #19";
                    break;
                case 1:
                    this.dAts = "Presence of subfield #19";
                    break;


            }
            switch (met)
            {
                case 0:
                    this.dAmet = "Absence of subfield #20";
                    break;
                case 1:
                    this.dAmet = "Presence of subfield #20";
                    break;


            }
            switch (roa)
            {
                case 0:
                    this.dAroa = "Absence of subfield #21";
                    break;
                case 1:
                    this.dAroa = "Presence of subfield #21";
                    break;


            }
            switch (ara)
            {
                case 0:
                    this.dAara = "Absence of subfield #22";
                    break;
                case 1:
                    this.dAara = "Presence of subfield #22";
                    break;


            }
            switch (scc)
            {
                case 0:
                    this.dAscc = "Absence of subfield #23";
                    break;
                case 1:
                    this.dAscc = "Presence of subfield #23";
                    break;


            }
            if (dataItem.Length >= 5)
            {
                double resolution = 0.1;
                byte[] mybytes = { dataItem[4] };
                this.dAAos = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }

            if (dataItem.Length >= 6)
            {
                double resolution = 0.1;
                byte[] mybytes = { dataItem[5] };
                this.dATrd = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }
            if (dataItem.Length >= 7)
            {
                double resolution = 0.1;
                byte[] mybytes = { dataItem[6] };
                this.dAM3a = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }
            if (dataItem.Length >= 8)
            {
                double resolution = 0.1;
                byte[] mybytes = { dataItem[7] };
                this.dAQi = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }

            if (dataItem.Length >= 9)
            {
                double resolution = 0.1;
                byte[] mybytes = { dataItem[8] };
                this.dATI = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }
            if (dataItem.Length >= 10)
            {
                double resolution = 0.1;
                byte[] mybytes = { dataItem[9] };
                this.dAMam = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }
            if (dataItem.Length >= 11)
            {
                double resolution = 0.1;
                byte[] mybytes = { dataItem[10] };
                this.dAGh = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }
            if (dataItem.Length >= 12)
            {
                double resolution = 0.1;
                byte[] mybytes = { dataItem[11] };
                this.dAFl = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }
            if (dataItem.Length >= 13)
            {
                double resolution = 0.1;
                byte[] mybytes = { dataItem[12] };
                this.dAIsa = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }

            if (dataItem.Length >= 14)
            {
                double resolution = 0.1;
                byte[] mybytes = { dataItem[13] };
                this.dAFsa = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }
            if (dataItem.Length >= 15)
            {
                double resolution = 0.1;
                byte[] mybytes = { dataItem[14] };
                this.dAAs = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }
            if (dataItem.Length >= 16)
            {
                double resolution = 0.1;
                byte[] mybytes = { dataItem[15] };
                this.dATas = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }
            if (dataItem.Length >= 17)
            {
                double resolution = 0.1;
                byte[] mybytes = { dataItem[16] };
                this.dAMh = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }
            if (dataItem.Length >= 18)
            {
                double resolution = 0.1;
                byte[] mybytes = { dataItem[17] };
                this.dABvr = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }
            if (dataItem.Length >= 19)
            {
                double resolution = 0.1;
                byte[] mybytes = { dataItem[18] };
                this.dAGvr = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }
            if (dataItem.Length >= 20)
            {
                double resolution = 0.1;
                byte[] mybytes = { dataItem[21] };
                this.dAGv = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }
            if (dataItem.Length >= 21)
            {
                double resolution = 0.1;
                byte[] mybytes = { dataItem[20] };
                this.dATar = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }
            if (dataItem.Length >= 22)
            {
                double resolution = 0.1;
                byte[] mybytes = { dataItem[21] };
                this.dATTI = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }
            if (dataItem.Length >= 23)
            {
                double resolution = 0.1;
                byte[] mybytes = { dataItem[22] };
                this.dATs = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }
            if (dataItem.Length >= 24)
            {
                double resolution = 0.1;
                byte[] mybytes = { dataItem[23] };
                this.dAMet = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }
            if (dataItem.Length >= 25)
            {
                double resolution = 0.1;
                byte[] mybytes = { dataItem[24] };
                this.dARoa = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }
            if (dataItem.Length >= 26)
            {
                double resolution = 0.1;
                byte[] mybytes = { dataItem[25] };
                this.dAAra = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }
            if (dataItem.Length >= 27)
            {
                double resolution = 0.1;
                byte[] mybytes = { dataItem[26] };
                this.dAScc = utilities.DecodeUnsignedByteToDouble(mybytes, resolution);
            }

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

        public int GetCategory()
        {
            return 21;
        }

        public TimeSpan GetTime()
        {
            return timeOfAsterixReportTransmission;
        }

        public string GetTypeOfMessage()
        {
            return "ADS-B";
        }

        public double[] GetWGS84Coordinates()
        {
            double[] wgs84 = { double.NaN, double.NaN };
            if (this.wgs84latitudehigh != double.NaN)
            {
                wgs84[0] = wgs84latitudehigh;
                wgs84[1] = wgs84longitudehigh;
                return wgs84;
            }
            else if (this.wgs84latitude != double.NaN)
            {
                wgs84[0] = wgs84latitude;
                wgs84[1] = wgs84longitude;
                return wgs84;
            }
            else
            {
                return null;
            }

        }

        public string GetTargetID()
        {
            return this.targetIdentification;
        }

        public CAT10 GetCAT10()
        {
            return null;
        }

        public CAT21 GetCAT21()
        {
            return this;
        }
    }
}
