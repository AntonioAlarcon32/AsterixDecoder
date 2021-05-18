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
        List<Coordinates> coordinatesCAT10;
        List<TimeSpan> timestampsCAT10;

        public Flight(string id)
        {
            this.identification = id;
            coordinatesCAT21 = new List<Coordinates>();
            timestampsCAT21 = new List<TimeSpan>();
            coordinatesCAT10 = new List<Coordinates>();
            timestampsCAT10 = new List<TimeSpan>();
        }

        public void AddPosition(double[] coordinates, TimeSpan timestamp, int category)
        {
            if (category == 21)
            {
                Coordinates newCoordinates = new Coordinates(coordinates[0], coordinates[1]);
                coordinatesCAT21.Add(newCoordinates);
                timestampsCAT21.Add(timestamp);
            }
            else if (category == 10)
            {
                Coordinates newCoordinates = new Coordinates(coordinates[0], coordinates[1]);
                coordinatesCAT10.Add(newCoordinates);
                timestampsCAT10.Add(timestamp);
            }
        }

        public string GetID()
        {
            return this.identification;
        }

        public TimeSpan GetFirstReport()
        {
            if (timestampsCAT21.Count == 0)
                return timestampsCAT10[0];
            else if (timestampsCAT10.Count == 0)
                return timestampsCAT21[0];
            else if (timestampsCAT21.Count > 0 && timestampsCAT10.Count > 0)
            {
                int comparer = TimeSpan.Compare(timestampsCAT10[0], timestampsCAT21[0]);
                if (comparer == -1)
                    return timestampsCAT10[0];
                else if (comparer == 1)
                    return timestampsCAT21[0];
                else
                    return timestampsCAT21[0];
            }
            else
                return TimeSpan.FromSeconds(0);
        }
        public TimeSpan GetLastReport()
        {
            if (timestampsCAT21.Count == 0)
                return timestampsCAT10.Last();
            else if (timestampsCAT10.Count == 0)
                return timestampsCAT21.Last();
            else if (timestampsCAT21.Count > 0 && timestampsCAT10.Count > 0)
            {
                int comparer = TimeSpan.Compare(timestampsCAT10.Last(), timestampsCAT21.Last());
                if (comparer == 1)
                    return timestampsCAT10.Last();
                else if (comparer == -1)
                    return timestampsCAT21.Last();
                else
                    return timestampsCAT21.Last();
            }
            else
                return TimeSpan.FromSeconds(0);
        }

        public List<Coordinates> GetAllCoordinatesCat21() 
        {
            return this.coordinatesCAT21;
        }
        public List<Coordinates> GetAllCoordinatesCat10()
        {
            return this.coordinatesCAT10;
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
