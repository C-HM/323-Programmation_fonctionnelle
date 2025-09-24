namespace Rando
{
    public class Trackpoint
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Elevation { get; set; } // meters
        public DateTime? Time { get; set; } // optional
    }
}
