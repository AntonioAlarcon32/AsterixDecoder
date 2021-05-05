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
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace GUI
{
    public partial class MainMenu : Form
    {
        string path;
        AsterixFile asterixFile = new AsterixFile();
        List<DataBlock> dataBlockList;
        List<Flight> flightList;
        DataTable packetsTable = new DataTable();
        DataTable flightsTable = new DataTable();
        TimeSpan currentTime = TimeSpan.Parse("8");

        public MainMenu()
        {
            InitializeComponent();    
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            map.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            map.Position = new GMap.NET.PointLatLng(41.29722, 2.083056);
            map.ShowCenter = false;
            GMapOverlay markers = new GMapOverlay("markers");
            GMapMarker marker = new GMarkerGoogle(
                new PointLatLng(41.29722, 2.083056),
                GMarkerGoogleType.arrow);
            markers.Markers.Add(marker);
            map.Overlays.Add(markers);
            timeLabel.Text = currentTime.ToString();
        }

        private void loadAsterixFile(string path)
        {
            asterixFile.ReadFile(path);
            dataBlockList = asterixFile.GetDataBlocks();
            flightList = asterixFile.GetFlights();
        }

        private void setDataTables(DataGridView dataGrid)
        {
            packetsTable.Columns.Add("Num");
            packetsTable.Columns.Add("Category");
            packetsTable.Columns.Add("Length");
            packetsTable.Columns.Add("Time");
            packetsTable.Columns.Add("Type Of Message");
            int i = 1;
           foreach (DataBlock dataBlock in dataBlockList)
           {
                string[] row = new string[] { i.ToString(), "Cat " + dataBlock.GetCategory().ToString(), dataBlock.GetLength().ToString(), dataBlock.GetTime().ToString(), dataBlock.GetTypeOfMessage() };
                packetsTable.Rows.Add(row);
                i++;
           }
            flightsTable.Columns.Add("Num");
            flightsTable.Columns.Add("CallSign");
            flightsTable.Columns.Add("First Report On:");
            flightsTable.Columns.Add("Last Report On:");
            i = 1;
            foreach (Flight flight in flightList)
            {
                string[] row = new string[] { i.ToString(), flight.GetID(), flight.GetFirstReport().ToString(), flight.GetLastReport().ToString()};
                flightsTable.Rows.Add(row);
                i++;
            }

            packetGridView.DataSource = packetsTable;
            flightGridView.DataSource = flightsTable;
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
{
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    path = openFileDialog.FileName;
                    loadAsterixFile(path);
                    setDataTables(packetGridView);
                    checkSMR.Enabled = true;
                    checkMLAT.Enabled = true;
                    checkADSB.Enabled = true;
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void moreInfoOfPacket_Click(object sender, EventArgs e)
        {
            int packet = packetGridView.CurrentCell.RowIndex;

            if (dataBlockList[packet].GetCAT10() != null)
            {
                MoreInfoOfPacketCAT10 newForm = new MoreInfoOfPacketCAT10(dataBlockList[packet].GetCAT10());
                newForm.Show();
            }
           
        }

        private void packetGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            moreInfoOfPacket.Enabled = true;
        }

        private void checkADSB_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            currentTime = currentTime.Add(TimeSpan.FromSeconds(1));
            timeLabel.Text = currentTime.ToString();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void moreInfoOfFlight_Click(object sender, EventArgs e)
        {
            Flight flight = flightList[flightGridView.CurrentCell.RowIndex];
            MoreInfoOfFlight newForm = new MoreInfoOfFlight(flight);
            newForm.Show();
        }

        private void flightGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            moreInfoOfFlight.Enabled = true;
        }
    }
}

