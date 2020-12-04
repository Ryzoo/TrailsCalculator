using System;
using TrailsCalculator.Models;

namespace TrailsCalculator
{
    public class GeoPoints
    {
        private readonly double _lat1;
        private readonly double _lon1;
        private readonly double _lat2;
        private readonly double _lon2;

        public GeoPoints(PointModel pointOne, PointModel pointTwo)
        {
            _lat1 = pointOne.Latitude;
            _lon1 = pointOne.Longitude;
            _lat2 = pointTwo.Latitude;
            _lon2 = pointTwo.Longitude;
        }
        
        public double GetDistance()
        {
            var R = 6372.8;
            var dLat = ToRadians(_lat2 - _lat1);
            var dLon = ToRadians(_lon2 - _lon1);
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(ToRadians(_lat1)) * Math.Cos(ToRadians(_lat2));
            return R * 2 * Math.Asin(Math.Sqrt(a));
        }
        
        private double ToRadians(double val)
        {
            return Math.PI * val / 180.0;
        }
    }
}