using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary
{
    public class Flight
    {
        string identification;
        List<Coordinates> coordinatesCAT21;
        List<TimeSpan> timestampsCAT21;
        Queue<Coordinates> queueCoordCat21;
        Queue<TimeSpan> queueTimestampsCat21;
        int lastCoordinate;

        public Flight(string id)
        {
            this.identification = id;
            coordinatesCAT21 = new List<Coordinates>();
            timestampsCAT21 = new List<TimeSpan>();
            lastCoordinate = 0;
        }

        public void AddPosition(double[] coordinates, TimeSpan timestamp)
        {
            Coordinates newCoordinates = new Coordinates(coordinates[0], coordinates[1]);
            coordinatesCAT21.Add(newCoordinates);
            timestampsCAT21.Add(timestamp);
        }

        public string GetID()
        {
            return this.identification;
        }

        public TimeSpan GetFirstReport()
        {
            return timestampsCAT21[0];
        }
        public TimeSpan GetLastReport()
        {
            return timestampsCAT21.Last();
        }

        public List<Coordinates> GetAllCoordinates() 
        {
            return this.coordinatesCAT21;
        }
    }

    public class Coordinates
    {
        double latitude;
        double longitude;

        public Coordinates(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public double GetLatitude()
        {
            return this.latitude;
        }

        public double GetLongitude()
        {
            return this.longitude;
        }
    }

   
}
