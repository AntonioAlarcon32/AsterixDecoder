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
using System.Windows.Input;

namespace GUI
{
    public partial class MoreInfoOfFlight : Form
    {
        Flight selectedFlight;
        Bitmap blueBmp = new Bitmap(Properties.Resources.blueMarker, new Size(7, 7));
        Bitmap yellowBmp = new Bitmap(Properties.Resources.yellowMarker, new Size(7, 7));

        public MoreInfoOfFlight(Flight flight)
        {
            InitializeComponent();
            selectedFlight = flight;
        }

        private void MoreInfoOfFlight_Load(object sender, EventArgs e)
        {
            callsignLabel.Text = selectedFlight.GetID();
            mlatLabel.Text = selectedFlight.GetAllCoordinatesCat10().Count().ToString();
            adsbLabel.Text = selectedFlight.GetAllCoordinatesCat21().Count().ToString();
            trackMap.MapProvider = GoogleSatelliteMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            trackMap.DragButton = MouseButtons.Left;
            trackMap.Position = new PointLatLng(41.29722, 2.083056);
            trackMap.ShowCenter = false;
            GMapOverlay markers = new GMapOverlay("markers");
            foreach (Coordinates coordinate in selectedFlight.GetAllCoordinatesCat21())
            {
               GMapMarker marker = new GMarkerGoogle(
                  new PointLatLng(coordinate.GetLatitude(), coordinate.GetLongitude()),
                  blueBmp);
               markers.Markers.Add(marker);
            }
            foreach (Coordinates coordinate in selectedFlight.GetAllCoordinatesCat10())
            {
                GMapMarker marker = new GMarkerGoogle(
                   new PointLatLng(coordinate.GetLatitude(), coordinate.GetLongitude()),
                   yellowBmp);
                markers.Markers.Add(marker);
            }
            trackMap.Overlays.Add(markers);
            trackMap.Zoom = 7;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            trackMap.Position = new PointLatLng(41.29722, 2.083056);
            trackMap.Zoom = 14;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            trackMap.Position = new PointLatLng(40.002384, 1.686835);
            trackMap.Zoom = 7;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            trackMap.Position = new PointLatLng(40.298517, 6.212262);
            trackMap.Zoom = 6;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            trackMap.Position = new PointLatLng(41.881681, 1.576703);
            trackMap.Zoom = 8;
        }
    }
}
