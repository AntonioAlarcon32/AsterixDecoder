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
    public partial class MoreInfOfPacketCAT21_2_ : Form
    {
        CAT21 selectedPacket;
        public MoreInfOfPacketCAT21_2_(CAT21 packet)
        {
            InitializeComponent();
            this.selectedPacket = packet;
        }

        private void previousBtn_Click(object sender, EventArgs e)
        { this.Close();
           MoreInfoOfPacketCAT21 newForm = new MoreInfoOfPacketCAT21(this.selectedPacket);
           newForm.Show();
        }

        private void MoreInfOfPacketCAT21_2__Load(object sender, EventArgs e)
        {
            labeltracknumber.Text = selectedPacket.GetTrackNumber();
            labelREtrueairspeed.Text = selectedPacket.GetRETrueAirspeed();
            labelIM.Text = selectedPacket.GetIM();
            labeltsicf.Text = selectedPacket.GetTSIcf();
            labeltslnav.Text = selectedPacket.GetTSLnav();
            labeltsps.Text = selectedPacket.GetTSPs();
            labeltsss.Text = selectedPacket.GetTSSs();
            labelrebarometric.Text = selectedPacket.GetReBarometric();
            labelregeometric.Text = selectedPacket.GetReGeometric();
            labelregroundspeed.Text = selectedPacket.GetReGroundSpeed();
            labelsasource.Text = selectedPacket.GetSAsource();
            labelSasas.Text = selectedPacket.GetSAsas();
            labelamv.Text = selectedPacket.Getamv();
            labelaah.Text = selectedPacket.Getaah();
            labelaam.Text = selectedPacket.Getaam();
            labelaosra.Text = selectedPacket.GetAosra();
            labelaostc.Text = selectedPacket.GetAostc();
            labelaosts.Text = selectedPacket.GetAosts();
            labelaosarv.Text = selectedPacket.GetAosarv();
            labelaoscdtia.Text = selectedPacket.GetAoscdtia();
            labelaosnottcas.Text = selectedPacket.GetAosnottcas();
            labelaossa.Text = selectedPacket.GetAossa();
            labelscpoa.Text = selectedPacket.GetScpoa();
            labelsccdtis.Text = selectedPacket.GetSccdtis();
            labelscb2low.Text = selectedPacket.GetScb2low();
            labelsCras.Text = selectedPacket.GetScras();
            labelscident.Text = selectedPacket.GetScident();
            labelsclw.Text = selectedPacket.GetSclw();
            labelWGS84high.Text = selectedPacket.GetWGS84coordinateshigh();
            labelWGS84.Text = selectedPacket.GetWGS84coordinates();
            labeltrueairspeed.Text = selectedPacket.GetTrueAirspeed();
            labelairspeed.Text = selectedPacket.GetAirspeed();
            labelgeometricheight.Text = selectedPacket.GetGeometricHeight();
            labelrollangle.Text = selectedPacket.GetRollAngle();
            labelflightlevel.Text = selectedPacket.GetFlightLevel();
            labelmagneticheading.Text = selectedPacket.GetMagneticHeading();
            labelgeometricverticalrate.Text = selectedPacket.GetGeometricVerticalRate();
            labelbarometricverticalrate.Text = selectedPacket.GetBarometricVerticalRate();
            labeltrackangle.Text = selectedPacket.GetTrackAngle();
            labelgroundspeed.Text = selectedPacket.GetGroundSpeed();
            labeltrackanglerate.Text = selectedPacket.GetTrackAngleRate();
            labelsaaltitude.Text = selectedPacket.GetSaAltitude();
            labelfssaltitude.Text = selectedPacket.GetFSSAltitude();
            labeltis.Text = selectedPacket.GetTis();
            labeltid.Text = selectedPacket.GetTid();
            labelnav.Text = selectedPacket.GetNav();
            labelnvb.Text = selectedPacket.GetNvb();
        }

        private void label60_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label232_Click(object sender, EventArgs e)
        {

        }
    }
}
