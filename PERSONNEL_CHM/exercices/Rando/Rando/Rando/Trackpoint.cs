using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rando
{
    internal class Trackpoint
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double? Elevation { get; set; }
        public DateTime? Time { get; set; }

        public Trackpoint(double latitude, double longitude, double elevation)
        {
            Latitude = latitude;
            Longitude = longitude;
            Elevation = elevation;
        }
        public override string ToString()
        {
            return $"Lat: {Latitude}, Lon: {Longitude}, Ele: {Elevation}";
        }
    }
}