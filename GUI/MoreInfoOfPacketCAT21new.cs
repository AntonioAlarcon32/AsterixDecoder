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
    }
}
