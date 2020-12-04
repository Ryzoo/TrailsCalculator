using System;
using TrailsCalculator.Models;

namespace TrailsCalculator.Calculators
{
    public class ElevationCalculator : BaseCalculator
    {
        private double _minElevation;
        private double _maxElevation;
        private double _avgElevation;
        private double _totalClimbing;
        private double _totalDescent;
        private double _totalBalance;
        
        //TMP
        private double _totalElevation;
        private int _elevationRaportCount;

        public ElevationCalculator()
        {
            _minElevation = double.MaxValue;
            _maxElevation = double.MinValue;
        }
        
        public override void Calculate(PointModel point)
        {
            if (point.Elevation > _maxElevation) _maxElevation = point.Elevation;
            if (point.Elevation < _minElevation) _minElevation = point.Elevation;
            if (CurrentClimb > Tollerance) _totalClimbing += CurrentClimb;
            if (CurrentClimb < -Tollerance) _totalDescent += CurrentClimb;
            _totalBalance = _totalDescent + _totalClimbing;

            _totalElevation += point.Elevation;
            _elevationRaportCount++;
            _avgElevation = _totalElevation / _elevationRaportCount;
        }
        
        public override void Presentation()
        {
            Console.WriteLine("---------- Elevation ---------");
            Console.WriteLine("Minimum elevation: {0:F}km", _minElevation);
            Console.WriteLine("Maximum elevation: {0:F}km", _maxElevation);
            Console.WriteLine("Average elevation: {0:F}km", _avgElevation);
            Console.WriteLine("Total climbing: {0:F}km", _totalClimbing);
            Console.WriteLine("Total descent: {0:F}km", _totalDescent);
            Console.WriteLine("Final balance: {0:F}km", _totalBalance);
            Console.WriteLine("------------------------------");
            Console.WriteLine();
        }
    }
}