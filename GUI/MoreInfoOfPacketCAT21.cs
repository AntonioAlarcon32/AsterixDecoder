using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using ClassLibrary;

namespace GUI
{
    public partial class MoreInfoOfPacketCAT21 : Form
    {
        CAT21 selectedPacket;
      
        public MoreInfoOfPacketCAT21(CAT21 packet)
        {
            InitializeComponent();
            this.selectedPacket = packet;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void label48_Click(object sender, EventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void label58_Click(object sender, EventArgs e)
        {

        }

        private void MoreInfoOfPacketCAT21_Load(object sender, EventArgs e)
        {
            labelsystemareacode.Text = selectedPacket.GetSystemAreaCode();
            labelsystemidentificationcode.Text = selectedPacket.GetSystemIdentificationCode();
            labelserviceidentification.Text = selectedPacket.GetServiceIdentification();
            labeltoaforpositon.Text = selectedPacket.GetTimeOfApplicabilityForPosition();
            labeltimeofapplicabilityvelocity.Text = selectedPacket.GetTimeOfApplicabilityForVelocity();
            labeltargetaddress.Text = selectedPacket.GetTargetAddress();
            labeltimeofmessagereceptionposition.Text = selectedPacket.GetTimeOfMessageReceptionForPosition();
            labelFSITPositionHigh.Text = selectedPacket.GetFSITTimeOfMessageReceptionPositionHigh();
            labelFSITvelocityhigh.Text = selectedPacket.GetFSITTimeOfMessageReceptionVelocityHigh();
            labeltimeformessagereceptionpositionhigh.Text = selectedPacket.GetFSITTimeOfMessageReceptionPositionHigh();
            labeltimeofmessagereceptionvelocity.Text = selectedPacket.GetTimeOfMessageReceptionForVelocity();
            labeltimeofmessagereceptionvelocityhigh.Text = selectedPacket.GetTimeOfMessageReceptionForVelocityHighResolution();
            labelmopsvn.Text = selectedPacket.GetMOPSVN();
            labelmopsvns.Text = selectedPacket.GetMOPSVNS();
            labelMOPSLTT.Text = selectedPacket.GetMOPSLTT();
            labelmode3ACode.Text = selectedPacket.GetMode3ACode();
            labeltimeofreporttransmission.Text = selectedPacket.GetTimeOfReportTransmission();
            labeltargetidentification.Text = selectedPacket.GetTargetIdentification();
            labelatp.Text = selectedPacket.GetTRAtp();
            labelarc.Text = selectedPacket.GetTRArc();
            labelrc.Text = selectedPacket.GetTRRc();
            labelrab.Text = selectedPacket.GetTRRab();
            labeldcr.Text = selectedPacket.GetTDcr();
            labelgbs.Text = selectedPacket.GetTRGbs();
            labelsim.Text = selectedPacket.GetTRSim();
            labeltst.Text = selectedPacket.GetTRTst();
            labelsaa.Text = selectedPacket.GetTRSaa();
            labelcl.Text = selectedPacket.GetTRCl();
            labelipc.Text = selectedPacket.GetTRIpc();
            labelnogo.Text = selectedPacket.GetTRNogo();
            labelcpr.Text = selectedPacket.GetTRCpr();
            labelldpj.Text = selectedPacket.GetTRLdpj();
            labelrcf.Text = selectedPacket.GetTRRcf();
            labelecat.Text = selectedPacket.GeteCat();
            labelmiws.Text = selectedPacket.GetMiws();
            labelmiwd.Text = selectedPacket.GetMiwd();
            labelmitmp.Text = selectedPacket.GetMitmp();
            labelmitrb.Text = selectedPacket.GetMiTurbulence();
            labelreceiverid.Text = selectedPacket.GetReceiverId();
            labeldaaos.Text = selectedPacket.GetDaaos();
            labeldaatrd.Text = selectedPacket.GetDatrd();
            labeldam3a.Text = selectedPacket.GetDam3a();
            labeldaqi.Text = selectedPacket.GetDaqi();
            labeldati.Text = selectedPacket.GetDaTi();
            labeldamam.Text = selectedPacket.GetDamam();
            labeldagh.Text = selectedPacket.GetDagh();
            labeldafl.Text = selectedPacket.GetDafl();
            labeldaisa.Text = selectedPacket.GetDaisa();
            labeldafsa.Text = selectedPacket.GetDafsa();
            labeldaas.Text = selectedPacket.GetDaas();
            labeldatas.Text = selectedPacket.GetDatas();
            labeldaamh.Text = selectedPacket.GetDamh();
            labeldaabvr.Text = selectedPacket.GetDabvr();
            labeldaagvr.Text = selectedPacket.GetDagvr();
            labeldaagv.Text = selectedPacket.GetDagv();
            labeldaatar.Text = selectedPacket.GetDatar();
            labeldati.Text = selectedPacket.GetDaTi();
            labeldaats.Text = selectedPacket.GetDats();
            labeldaamet.Text = selectedPacket.GetDamet();
            labeldaaroa.Text = selectedPacket.GetDaroa();
            labeldascc.Text = selectedPacket.GetDascc();
            



            
            
        }

        private void label68_Click(object sender, EventArgs e)
        {

        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void label77_Click(object sender, EventArgs e)
        {

        }

        private void label81_Click(object sender, EventArgs e)
        {

        }

        private void label88_Click(object sender, EventArgs e)
        {

        }

        private void label107_Click(object sender, EventArgs e)
        {

        }

        private void label113_Click(object sender, EventArgs e)
        {

        }

        private void label115_Click(object sender, EventArgs e)
        {

        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            MoreInfOfPacketCAT21_2_ newForm = new MoreInfOfPacketCAT21_2_(this.selectedPacket);
            newForm.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
