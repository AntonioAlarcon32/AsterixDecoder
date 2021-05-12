using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace GUI
{
    public partial class MoreInfoOfPacketCAT10 : Form
    {
        CAT10 selectedPacket;
        public MoreInfoOfPacketCAT10(CAT10 packet)
        {
            InitializeComponent();
            this.selectedPacket = packet;
        }

        private void MoreInfoOfPacketCAT10_Load(object sender, EventArgs e)
        {
            dsiLabel.Text = selectedPacket.GetDataSourceIdentifier();
            tomLabel.Text = selectedPacket.GetTypeOfMessage();
            todLabel.Text = selectedPacket.GetTimeOfDay();
            taLabel.Text = selectedPacket.GetTargetAddress();
            tidLabel.Text = selectedPacket.GetTargetID();
            string[] trd = selectedPacket.GetTargetReportDescriptor();
            trdTypeLabel.Text = trd[0];
            trdDcLabel.Text = trd[1];
            trdChainLabel.Text = trd[2];
            trdTGLabel.Text = trd[3];
            trdCRLabel.Text = trd[4];
            trdSTLabel.Text = trd[5];
            trdTTLabel.Text = trd[6];
            trdToRLabel.Text = trd[7];
            trdLoopLabel.Text = trd[8];
            trdToTLabel.Text = trd[9];
            trdSPILabel.Text = trd[10];
            Dictionary<string, string> polarPosition = selectedPacket.GetPolarPosition();
            positionRhoLabel.Text = (polarPosition["rho"] != "NaN" ? polarPosition["rho"] + " m" : "N/A");
            positionThetaLabel.Text = (polarPosition["theta"] != "NaN" ? polarPosition["theta"] + " º" : "N/A");
            Dictionary<string, string> cartesianPosition = selectedPacket.GetCartesianPosition();
            positionYLabel.Text = (cartesianPosition["Y"] != "NaN" ? cartesianPosition["Y"] + " m" : "N/A");
            positionXLabel.Text = (cartesianPosition["X"] != "NaN" ? cartesianPosition["X"] + " m" : "N/A");
            Dictionary<string, string> wgs84Position = selectedPacket.GetWGS84CoordinatesString();
            wgsLatitudeLabel.Text = (wgs84Position["latitude"] != "NaN" ? wgs84Position["latitude"] + " º" : "N/A");
            wgsLongitudeLabel.Text = (wgs84Position["longitude"] != "NaN" ? wgs84Position["longitude"] + " º" : "N/A");
            Dictionary<string, string> flightLevel = selectedPacket.GetFlightLevel();
            flValidatedLabel.Text = flightLevel["validated"];
            flGarbledLabel.Text = flightLevel["garbled"];
            flFlightLevelLabel.Text = (flightLevel["flight level"] != "NaN" ? "FL" + flightLevel["flight level"] : "N/A");
            Dictionary<string, string> calcAcc = selectedPacket.GetCalculatedAcceleration();
            accelerationXLabel.Text = (calcAcc["Ax"] != "NaN" ? calcAcc["Ax"] + " m/s^2" : "N/A");
            accelerationYLabel.Text = (calcAcc["Ay"] != "NaN" ? calcAcc["Ay"] + " m/s^2" : "N/A");
            Dictionary<string, string> sizeAndOrientation = selectedPacket.GetSizeAndOrientation();
            widthLabel.Text = (sizeAndOrientation["width"] != "NaN" ? sizeAndOrientation["width"] + " m" : "N/A"); 
            widthLengthLabel.Text = (sizeAndOrientation["length"] != "NaN" ? sizeAndOrientation["length"] + " m" : "N/A");
            widthOrientationLabel.Text = (sizeAndOrientation["orientation"] != "NaN" ? sizeAndOrientation["orientation"] + " º" : "N/A");
            measuredHeigthLabel.Text = (selectedPacket.GetMeasuredHeight() != "NaN" ? selectedPacket.GetMeasuredHeight() + " m" : "N/A");
            Dictionary<string, string> polarVelocity = selectedPacket.GetPolarVelocity();
            velocityRhoLabel.Text = (polarVelocity["ground speed"] != "NaN" ? polarVelocity["ground speed"] + " m/s" : "N/A");
            velocityThetaLabel.Text = (polarVelocity["track angle"] != "NaN" ? polarVelocity["track angle"] + " º" : "N/A");
            Dictionary<string, string> cartesianVelocity = selectedPacket.GetCartesianVelocity();
            velocityXLabel.Text = (cartesianVelocity["Vx"] != "NaN" ? cartesianVelocity["Vx"] + " m/s" : "N/A");
            velocityYLabel.Text = (cartesianVelocity["Vy"] != "NaN" ? cartesianVelocity["Vy"] + " m/s" : "N/A");
            Dictionary<string, string> sdp = selectedPacket.GetStandardDeviationOfPosition();
            sdpXLabel.Text = sdp["X"];
            sdpYLabel.Text = sdp["Y"];
            sdpCovarianceLabel.Text = sdp["XY"];
            Dictionary<string, string> trackNumber = selectedPacket.GetTrackNumber();
            labelTrackNumber.Text = (trackNumber["tracknumber"] != "-1" ? trackNumber["tracknumber"] : "-1");

            Dictionary<string, string> trackStatus = selectedPacket.GetTrackStatus();
            labelTSConfirmed.Text = (trackStatus["cnf"] != "NaN" ? trackStatus["cnf"] : "N/A");
            labelTSLastReport.Text = (trackStatus["tre"] != "NaN" ? trackStatus["tre"] : "N/A");
            labelTSExtrapolationType.Text = (trackStatus["cst"] != "NaN" ? trackStatus["cst"] : "N/A");
            labelTSHorizontalManoeuvre.Text = (trackStatus["mah"] != "NaN" ? trackStatus["mah"] : "N/A");
            labelTSSRC.Text = (trackStatus["tcc"] != "NaN" ? trackStatus["tcc"] : "N/A");
            labelTSSmoothed.Text = (trackStatus["sth"] != "NaN" ? trackStatus["sth"] : "N/A");
            labelTSTOM.Text = (trackStatus["tom"] != "NaN" ? trackStatus["tom"] : "N/A");
            labelTSDoubtful.Text = (trackStatus["dou"] != "NaN" ? trackStatus["dou"] : "N/A");
            labelTSMOS.Text = (trackStatus["mrs"] != "NaN" ? trackStatus["mrs"] : "N/A");
            labelTSGT.Text = (trackStatus["gho"] != "NaN" ? trackStatus["gho"] : "N/A");


            Dictionary<string, string> SystemStatus = selectedPacket.GetSystemStatus();
            labelSSNOGO.Text = (SystemStatus["nogo"] != "NaN" ? SystemStatus["nogo"] : "N/A");
            labelSSOVL.Text = (SystemStatus["ovl"] != "NaN" ? SystemStatus["ovl"] : "N/A");
            labelSSTSV.Text = (SystemStatus["tsv"] != "NaN" ? SystemStatus["tsv"] : "N/A");
            labelSSDIV.Text = (SystemStatus["div"] != "NaN" ? SystemStatus["div"] : "N/A");
            labelSSTTF.Text = (SystemStatus["ttf"] != "NaN" ? SystemStatus["ttf"] : "N/A");


            //M3A
            labelM3AValidated.Text = selectedPacket.GetMode3AValidated();
            labelM3AGarbled.Text = selectedPacket.GetMode3AGarbled();
            labelM3ADerivation.Text = selectedPacket.GetMode3Derivation();
            labelM3ACode.Text = selectedPacket.GetMode3ACode();
            //vehicle fleet id
            labelVehicleFleetId.Text = selectedPacket.GetVehicleFleetId();
            //Pre-programmed message
            labelppTRB.Text = selectedPacket.GetpreprogrammedTRB();
            labelppMSG.Text = selectedPacket.GetpreprogrammedMSG();
            //Track info

        }

        private void label76_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void labelTrackNumber_Click(object sender, EventArgs e)
        {

        }

        private void labelTSConfirmed_Click(object sender, EventArgs e)
        {

        }

        private void labelTSExtrapolationType_Click(object sender, EventArgs e)
        {

        }
    }
}
