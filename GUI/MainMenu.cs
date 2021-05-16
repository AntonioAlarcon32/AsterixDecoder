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
using MultiCAT6.Utils;

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
        TimeSpan currentTime = TimeSpan.FromHours(8.0);
        int packetIndex = 0;
        GMapOverlay overlay = new GMapOverlay();
        Bitmap redBmp = new Bitmap(Properties.Resources.redMarker, new Size(7, 7));
        Bitmap blueBmp = new Bitmap(Properties.Resources.blueMarker, new Size(7, 7));
        Bitmap yellowBmp = new Bitmap(Properties.Resources.yellowMarker, new Size(7, 7));
        public MainMenu()
        {
            InitializeComponent();    
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            map.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            map.DragButton = MouseButtons.Left;
            map.Position = new GMap.NET.PointLatLng(41.29722, 2.083056);
            map.ShowCenter = false;
            timeLabel.Text = currentTime.ToString();
            map.OnMarkerClick += new MarkerClick(map_OnMarkerClick);
        }
        void map_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            selectedMarker.Text = item.Tag.ToString();
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
        bool AreEqual(TimeSpan a, TimeSpan b, TimeSpan precision)
        {
            return Math.Abs((a - b).TotalMilliseconds) < precision.TotalMilliseconds;
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
            if (dataBlockList[packet].GetCAT21() != null)
            {
                MoreInfoOfPacketCAT21 newForm = new MoreInfoOfPacketCAT21(dataBlockList[packet].GetCAT21());
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
            overlay.Markers.Clear();
            while (true)
            {
                if (packetIndex >= dataBlockList.Count())
                {
                    timer1.Stop();
                    MessageBox.Show("End of File");
                    break;
                }
                TimeSpan difference = currentTime - dataBlockList[packetIndex].GetTime();
                if (AreEqual(currentTime, dataBlockList[packetIndex].GetTime(), TimeSpan.FromSeconds(1)) && dataBlockList[packetIndex].GetCategory() == 21)
                {
                    if (mapADSBCheck.Checked == true)
                    {
                        CAT21 cat21 = dataBlockList[packetIndex].GetCAT21();
                        double[] coordinates = cat21.GetWGS84Coordinates();
                        GMapMarker marker = new GMarkerGoogle(
                            new PointLatLng(coordinates[0], coordinates[1]),
                            blueBmp);
                        marker.Tag = cat21.GetTargetID();
                        overlay.Markers.Add(marker);
                    }
                    packetIndex++;

                }
                else if ((AreEqual(currentTime, dataBlockList[packetIndex].GetTime(), TimeSpan.FromSeconds(1)) && dataBlockList[packetIndex].GetCategory() == 10))
                {
                    CAT10 cat10 = dataBlockList[packetIndex].GetCAT10();
                    double[] coordinates = cat10.GetWGS84Coordinates();
                    if (cat10.GetTypeOfMessage() == "SMR" && mapSMRCheck.Checked == true)
                    {
                        GMapMarker marker = new GMarkerGoogle(
                           new PointLatLng(coordinates[0], coordinates[1]),
                           redBmp);
                        overlay.Markers.Add(marker);
                    }
                    else if (cat10.GetTypeOfMessage() == "MLAT" && mapMLATCheck.Checked == true)
                    {
                        GMapMarker marker = new GMarkerGoogle(
                           new PointLatLng(coordinates[0], coordinates[1]),
                           yellowBmp);
                        overlay.Markers.Add(marker);
                    }
                    packetIndex++;
                }
                else
                    break;
            }
            map.Overlays.Add(overlay);
            map.Zoom = map.Zoom;
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

        private void button1_Click(object sender, EventArgs e)
        {
            map.Position = new PointLatLng(41.29722, 2.083056);
            map.Zoom = 14;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            map.Position = new PointLatLng(41.881681, 1.576703);
            map.Zoom = 8;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            map.Position = new PointLatLng(40.002384, 1.686835);
            map.Zoom = 7;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            map.Position = new PointLatLng(40.298517, 6.212262);
            map.Zoom = 6;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void x1Button_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
        }

        private void x2Button_Click(object sender, EventArgs e)
        {
            timer1.Interval = 500;
        }

        private void x4Button_Click(object sender, EventArgs e)
        {
            timer1.Interval = 250;
        }

        private void x16Button_Click(object sender, EventArgs e)
        {
            timer1.Interval = 62;
        }
    }
}

