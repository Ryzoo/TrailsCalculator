using System;
using TrailsCalculator.Models;

namespace TrailsCalculator.Calculators
{
    public abstract class BaseCalculator : ICalculator
    {
        private readonly TimeSpan _timeTolerance;
        private PointModel _lastPoint;
        
        protected readonly double Tollerance;
        
        protected double CurrentDistance;
        protected double CurrentClimb;
        protected double CurrentSpeed;
        protected TimeSpan CurrentTime;

        protected BaseCalculator()
        {
            Tollerance = 0.0003;
            _timeTolerance = TimeSpan.FromMinutes(3);
        }
        
        protected abstract void Calculate(PointModel point);
        public abstract void Presentation();

        public void Handle(PointModel point)
        {
            if (_lastPoint is null)
            {
                _lastPoint = point;
                return;
            }
            
            CurrentDistance = new GeoPoints(_lastPoint, point).GetDistance();
            CurrentClimb = point.Elevation - _lastPoint.Elevation;
            CurrentTime = point.Time - _lastPoint.Time;

            if (CurrentTime > _timeTolerance) 
                CurrentTime = _timeTolerance;
            
            CurrentSpeed = CurrentDistance / CurrentTime.TotalHours;
                
            Calculate(point);
            
            _lastPoint = point;
        }
    }
}