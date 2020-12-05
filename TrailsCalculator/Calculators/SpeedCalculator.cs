using System;
using TrailsCalculator.Models;

namespace TrailsCalculator.Calculators
{
    public class SpeedCalculator : BaseCalculator
    {
        private double _minSpeed;
        private double _maxSpeed;
        private double _avgSpeed;
        private double _avgClimbingSpeed;
        private double _avgDescentSpeed;
        private double _avgFlatSpeed;
        
        //TMP
        private double _totalDistance;
        private TimeSpan _totalTime;
        private TimeSpan _climbingTime;
        private TimeSpan _descentTime;
        private TimeSpan _flatTime;
        private double _climbingDistance;
        private double _descentDistance;
        private double _flatDistance;

        public SpeedCalculator()
        {
            _minSpeed = double.MaxValue;
            _maxSpeed = double.MinValue;
        }

        protected override void Calculate(PointModel point)
        {
            _totalDistance += CurrentDistance;
            _totalTime += CurrentTime;

            if (CurrentSpeed < _minSpeed) _minSpeed = CurrentSpeed;
            if (CurrentSpeed > _maxSpeed) _maxSpeed = CurrentSpeed;

            if (CurrentClimb > Tollerance)
            {
                _climbingDistance += CurrentDistance;
                _climbingTime += CurrentTime;
            }
            
            if (CurrentClimb < -Tollerance)
            {
                _descentDistance += CurrentDistance;
                _descentTime += CurrentTime;
            }
            
            if (CurrentClimb > -Tollerance && CurrentClimb < Tollerance)
            {
                _flatDistance += CurrentDistance;
                _flatTime += CurrentTime;
            }
            
            _avgSpeed = _totalDistance / _totalTime.TotalHours;
            _avgClimbingSpeed = _climbingDistance / _climbingTime.TotalHours;
            _avgDescentSpeed = _descentDistance / _descentTime.TotalHours;
            _avgFlatSpeed = _flatDistance / _flatTime.TotalHours;
        }
        
        public override void Presentation()
        {
            Console.WriteLine("----------- Speed ------------");
            Console.WriteLine("Minimal speed: {0:F}km/h", _minSpeed);
            Console.WriteLine("Maximum speed: {0:F}km/h", _maxSpeed);
            Console.WriteLine("Average speed: {0:F}km/h", _avgSpeed);
            Console.WriteLine("Average climbing speed: {0:F}km/h", _avgClimbingSpeed);
            Console.WriteLine("Average descent speed: {0:F}km/h", _avgDescentSpeed);
            Console.WriteLine("Average flat speed: {0:F}km/h", _avgFlatSpeed);
            Console.WriteLine("------------------------------");
            Console.WriteLine();
        }
    }
}