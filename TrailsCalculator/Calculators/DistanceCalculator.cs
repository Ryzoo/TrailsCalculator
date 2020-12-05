using System;
using TrailsCalculator.Models;

namespace TrailsCalculator.Calculators
{
    public class DistanceCalculator : BaseCalculator
    {
        private double _totalDistance;
        private double _climbingDistance;
        private double _descentDistance;
        private double _flatDistance;

        protected override void Calculate(PointModel point)
        {
            _totalDistance += CurrentDistance;
            _climbingDistance += CurrentClimb > Tollerance ? CurrentDistance : 0;
            _descentDistance += CurrentClimb < -Tollerance ? CurrentDistance : 0;
            _flatDistance += CurrentClimb > -Tollerance && CurrentClimb < Tollerance ? CurrentDistance : 0;
        }
        
        public override void Presentation()
        {
            Console.WriteLine("---------- Distance ----------");
            Console.WriteLine("Total distance: {0:F}km", _totalDistance);
            Console.WriteLine("Climbing distance: {0:F}km", _climbingDistance);
            Console.WriteLine("Descent distance: {0:F}km", _descentDistance);
            Console.WriteLine("Flat distance: {0:F}km", _flatDistance);
            Console.WriteLine("------------------------------");
            Console.WriteLine();
        }
    }
}