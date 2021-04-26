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
        string RE;
        string IM;
        double trueAirSpeed;
        double airSpeed;
        int targetAddress;
        TimeSpan timeOfMessageReceptionPosition;
        string FSI;
        TimeSpan timeOfMessageReceptionPositionHighResolution;
        TimeSpan timeOfMessageReceptionVelocity;
        TimeSpan Timeofmessagereceptionvelocityhighprecision;

        double GeometricHeight;

        string vn;
        string vns;
        string ltt;
        string M3ACode;
        double RollAngle;
        double FlightLevel;
        double MagneticHeading;
        double TargetStatus;
        double BarometricVerticalRate;
        string REbarometric;
        double GeometricVerticalRate;
        string REgeometric;
        string REairbornegroundvector;
        double GroundSpeed;
        double TrackAngle;
        double TrackAngleRate;
        TimeSpan timeOfAsterixReportTransmission;

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

            this.RE = "N/A";
            this.IM= "N/A";
            this.trueAirSpeed = double.NaN;
            this.airSpeed = double.NaN;
            this.targetAddress = -1;
            this.timeOfMessageReceptionPosition = new TimeSpan();
            this.FSI= "N/A";
            this.timeOfMessageReceptionPositionHighResolution = new TimeSpan();

            this.timeOfMessageReceptionVelocity = new TimeSpan();
            this.Timeofmessagereceptionvelocityhighprecision = new TimeSpan();
            this.GeometricHeight = double.NaN;

            this.vn= "N/A";
            this.vns = "N/A";
            this.ltt = "N/A";
            this.M3ACode = "N/A";
            this.RollAngle = double.NaN;
            this.FlightLevel = double.NaN;
            this.MagneticHeading = double.NaN;
            this.TargetStatus= double.NaN;
            this.BarometricVerticalRate = double.NaN;
            this.REbarometric = "N/A";
            this.GeometricVerticalRate = double.NaN;
            this.REgeometric = "N/A";
            this.REairbornegroundvector = "N/A";
            this.GroundSpeed = double.NaN;
            this.TrackAngle = double.NaN;
            this.TrackAngleRate = double.NaN;
            this.timeOfAsterixReportTransmission = new TimeSpan();




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
                    DecodeMOPSversion(datItem);

                }

                if (boolFSPEC[19] == true) //Mode 3/A Code
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeMode3Acode(datItem);

                }

                if (boolFSPEC[18] == true) //Roll Angle
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeRollangle(datItem);

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
                    DecodeMagneticheading(datItem);

                }

                if (boolFSPEC[30] == true) //Target status
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 1);
                    DecodeTargetstatus(datItem);
                }

                if (boolFSPEC[29] == true) //Barometric vertical rate
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeBarometricverticalrate(datItem);
                }

                if (boolFSPEC[28] == true) //Geometric vertical rate
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeGeometricverticalrate(datItem);
                }

                if (boolFSPEC[27] == true) //Airborne Ground Vector
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 4);
                    DecodeAirborngroundvector(datItem);

                }

                if (boolFSPEC[26] == true) //Track angle rate
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 2);
                    DecodeTrackanglerate(datItem);

                }

                if (boolFSPEC[25] == true) //Time of Report Transmission
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 3);
                    DecodeTimeofreporttransmission(datItem);

                }
            }
            if (FSPEC.Length >= 5)
            {
                if (boolFSPEC[39] == true) //Target Identification
                {
                    byte[] datItem = utilities.GetFixedLengthDataItem(message, 6);

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
            int c = 1;
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
                    this.RE = "Value in defined range";
                    break;
                case 1:
                    this.RE = "Value exceeds defined range";
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
                    this.FSI = "TOMRp whole seconds=(1021/073) Whole seconds";
                    break;
                case 1:
                    this.FSI = "TOMRp whole seconds = (1021 / 073) Whole seconds+1";
                    break;
                case 2:
                    this.FSI = "TOMRp whole seconds = (1021 / 073) Whole seconds-1";
                    break;
                case 3:
                    this.FSI= "Reserved";
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
            this.Timeofmessagereceptionvelocityhighprecision = TimeSpan.FromSeconds(seconds);


            switch (FSI)
            {
                case 0:
                    this.FSI = "TOMRp whole seconds=(1021/073) Whole seconds";
                    break;
                case 1:
                    this.FSI = "TOMRp whole seconds = (1021 / 073) Whole seconds+1";
                    break;
                case 2:
                    this.FSI = "TOMRp whole seconds = (1021 / 073) Whole seconds-1";
                    break;
                case 3:
                    this.FSI = "Reserved";
                    break;
            }
        }
        public void DecodeGeometricheight (byte[] dataItem)
        {
            double resolution = 6.25;//ft
            this.GeometricHeight = utilities.DecodeTwosComplementToDouble(dataItem, resolution);
        }
        public void QualityIndicators(byte[] dataItem)
        {

        }
        public void DecodeMOPSversion(byte[] dataItem)
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
                    this.vn = "ED102/DO-260[Ref.8]";
                    break;
                case 1:
                    this.vn = "DO-260A[Ref.9]";
                    break;
                case 2:
                    this.vn = "ED102A/DO-260B[Ref.11]";
                    break;

            }

            switch (vns)
            {
                case 0:
                    this.vns = "The MOPS Version is supported by the GS";
                    break;
                case 1:
                    this.vns = "The MOPS Version is not supported by the GS";
                    break;

            }

            switch (LTT)
            {
                case 0:
                    this.ltt = "Other";
                    break;
                case 1:
                    this.ltt = "UAT";
                    break;
                   
                    
                case 2:
                    this.ltt = "1090 ES";
                    break;
                case 3:
                    this.ltt = "VDL 4";
                    break;
                case 4:
                    this.ltt = "Not assigned";
                    break;
                case 5:
                    this.ltt = "Not assigned";
                    break;
                case 6:
                    this.ltt = "Not assigned";
                    break;
                case 7:
                    this.ltt = "Not assigned";
                    break;


            }
        

        }
        public void DecodeMode3Acode(byte[] dataItem)
        {
            int firstByte = (byte)((dataItem[0]));

            int A = (byte)(firstByte >> 1);
            byte B4 = (byte)((firstByte & 1) << 2);
            byte B21 = (byte)((dataItem[1] & 192) >> 6);
            int B = (int)(B4 + B21);
            int C = (int)((dataItem[1] & 56) >> 3);
            int D = (int)(dataItem[1] & 7);

            this.M3ACode = (A * 1000 + B * 100 + C * 10 + D).ToString();
        }
        public void DecodeRollangle(byte[] dataItem)
        {
            double resolution = 0.01;//degrees
            this.RollAngle = utilities.DecodeTwosComplementToDouble(dataItem, resolution);
        }
        public void DecodeFlightLevel(byte[] dataItem)
        {
            double resolution = (1 / 4);
            this.FlightLevel = utilities.DecodeTwosComplementToDouble(dataItem, resolution);
        }
        public void DecodeMagneticheading(byte[] dataItem)
        {
            double resolution = (360 / 2 ^ 16);
            this.MagneticHeading = utilities.DecodeUnsignedByteToDouble(dataItem,resolution);
        }
        public void DecodeTargetstatus(byte[] dataItem)
        {
            double resolution = 0.1;//seconds
            this.TargetStatus = utilities.DecodeUnsignedByteToDouble(dataItem, resolution);

        }

        public void DecodeBarometricverticalrate(byte[] dataItem)
        {   double resolution = 6.25;//ft/min
            byte REmask = 128;
            byte secondmask = 127;
            int RE = (int)((REmask & dataItem[0]) >> 7);
            byte firstbyte = (byte)(secondmask & dataItem[0]);
            byte[] mybytes = { firstbyte, dataItem[1] };
            switch (RE)
            {
                case 0:
                    this.REbarometric = "Value in defined range";
                    break;
                case 1:
                    this.REbarometric = "Value exceeds defined range";
                    break;
            }
            this.BarometricVerticalRate = utilities.DecodeTwosComplementToDouble(mybytes, resolution);
        }
        public void DecodeGeometricverticalrate(byte[] dataItem)
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
                    this.REgeometric = "Value in defined range";
                    break;
                case 1:
                    this.REgeometric = "Value exceeds defined range";
                    break;
            }
            this.GeometricVerticalRate = utilities.DecodeTwosComplementToDouble(mybytes, resolution);

        }
        public void DecodeAirborngroundvector(byte[] dataItem)
        {
            double resolutiongroundspeed = (1/2^14);//NM/S
            double resolutiontrackangle = (360 / 2 ^ 16);//degrees
            byte REmask = 128;
            byte secondmask = 127;
            int RE = (int)((REmask & dataItem[0]) >> 7);
            byte firstbyte = (byte)(secondmask & dataItem[0]);
            byte[] groundspeed = { firstbyte, dataItem[1] };
            byte[] trackangle = {dataItem[2],dataItem[3] };

            switch (RE)
            {
                case 0:
                    this.REairbornegroundvector = "Value in defined range";
                    break;
                case 1:
                    this.REairbornegroundvector = "Value exceeds defined range";
                    break;
            }
            this.GroundSpeed = utilities.DecodeUnsignedByteToDouble(groundspeed, resolutiongroundspeed);
            this.TrackAngle = utilities.DecodeUnsignedByteToDouble(trackangle, resolutiontrackangle);
        }
        public void DecodeTrackanglerate(byte[] dataItem)
        {
            double resolution = (1/32);//deg/s
            
            byte secondmask = 3;
            
            byte firstbyte = (byte)(secondmask & dataItem[0]);
            byte[] mybytes = { firstbyte, dataItem[1] };
           
            this.TrackAngleRate = utilities.DecodeTwosComplementToDouble(mybytes, resolution);
        }
        public void DecodeTimeofreporttransmission(byte[] dataItem)
        {
            double resolution = Math.Pow(2, -7);
            double seconds = utilities.DecodeUnsignedByteToDouble(dataItem, resolution);
            this.timeOfAsterixReportTransmission = TimeSpan.FromSeconds(seconds);
        }
        public void Targetidentification(byte[] dataItem)
        {

        }
        public void Emittercategory(byte[] dataItem)
        {

        }
        public void Metinformation(byte[] dataItem)
        {

        }
        public void Selectedaltitude(byte[] dataItem)
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
