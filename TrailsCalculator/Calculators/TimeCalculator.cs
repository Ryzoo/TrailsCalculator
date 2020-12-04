using System;
using TrailsCalculator.Models;

namespace TrailsCalculator.Calculators
{
    public class TimeCalculator : BaseCalculator
    {
        private double _totalTrackTime;
        private double _climbingTime;
        private double _descentTime;
        private double _flatTime;

        public override void Calculate(PointModel point)
        {
            _totalTrackTime += CurrentTime.TotalHours;
            
            if (CurrentClimb > Tollerance) _climbingTime += CurrentTime.TotalHours;
            if (CurrentClimb < -Tollerance)  _descentTime += CurrentTime.TotalHours;
            if (CurrentClimb > -Tollerance && CurrentClimb < Tollerance) _flatTime += CurrentTime.TotalHours;
        }
        
        public override void Presentation()
        {
            Console.WriteLine("------------ Time ------------");
            Console.WriteLine("Total track time: {0:F}h", _totalTrackTime);
            Console.WriteLine("Climbing time: {0:F}h", _climbingTime);
            Console.WriteLine("Descent time: {0:F}h", _descentTime);
            Console.WriteLine("Flat time: {0:F}h", _flatTime);
            Console.WriteLine("------------------------------");
            Console.WriteLine();
        }
    }
}