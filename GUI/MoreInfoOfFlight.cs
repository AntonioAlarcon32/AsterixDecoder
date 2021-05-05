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
        public MoreInfoOfFlight(Flight flight)
        {
            InitializeComponent();
            selectedFlight = flight;
        }

        private void MoreInfoOfFlight_Load(object sender, EventArgs e)
        {
            int c = 0;
            //Bitmap resized = new Bitmap(marker, new Size(20, 20));
            trackMap.MapProvider = GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            trackMap.DragButton = MouseButtons.Left;
            trackMap.Position = new PointLatLng(41.29722, 2.083056);
            trackMap.ShowCenter = false;
            GMapOverlay markers = new GMapOverlay("markers");
            foreach (Coordinates coordinate in selectedFlight.GetAllCoordinates())
            {
               // GMapMarker marker = new GMarkerGoogle(
                  // new PointLatLng(coordinate.GetLatitude(), coordinate.GetLongitude()),
                  // resized);
               // markers.Markers.Add(marker);
            }

            trackMap.Overlays.Add(markers);
        }
    }
}
