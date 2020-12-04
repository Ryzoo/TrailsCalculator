﻿using System;
using TrailsCalculator.Models;

namespace TrailsCalculator.Calculators
{
    public abstract class BaseCalculator : ICalculator
    {
        protected readonly double Tollerance;
        
        protected PointModel LastPoint;
        protected double CurrentDistance;
        protected double CurrentClimb;
        protected double CurrentSpeed;
        protected TimeSpan CurrentTime;
        protected TimeSpan TimeTolerance;

        public BaseCalculator()
        {
            Tollerance = 0.0000007;
            TimeTolerance = TimeSpan.FromMinutes(3);
        }
        public abstract void Presentation();
        public abstract void Calculate(PointModel point);

        public void Handle(PointModel point)
        {
            if (LastPoint is null)
            {
                LastPoint = point;
                return;
            }
            
            CurrentDistance = new GeoPoints(LastPoint, point).GetDistance();
            CurrentClimb = point.Elevation - LastPoint.Elevation;
            CurrentTime = point.Time - LastPoint.Time;

            if (CurrentTime > TimeTolerance) 
                CurrentTime = TimeTolerance;
            
            CurrentSpeed = CurrentDistance / CurrentTime.TotalHours;
                
            Calculate(point);
            
            LastPoint = point;
        }
    }
}