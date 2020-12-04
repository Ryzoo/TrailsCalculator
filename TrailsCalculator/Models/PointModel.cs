using System;

namespace TrailsCalculator.Models
{
    public class PointModel
    {
        public double Latitude;
        public double Longitude;
        public double Elevation;
        public DateTime Time;
        public PointModel(double latitude, double longitude, double elevation, DateTime time)
        {
            Latitude = latitude;
            Longitude = longitude;
            Elevation = elevation / 1000;
            Time = time;
        }
    }
}