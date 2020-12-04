using System;
using System.Collections.Generic;
using TrailsCalculator.Calculators;
using TrailsCalculator.Models;

namespace TrailsCalculator
{
    public class TrackCalculatorProcessor
    {
        private readonly TrackModel _track;
        private ICollection<ICalculator> _calculators;

        public TrackCalculatorProcessor(TrackModel track)
        {
            _track = track;
            _calculators = new List<ICalculator>();
        }

        public TrackCalculatorProcessor AddCalculator(ICalculator calculator)
        {
            _calculators.Add(calculator);
            return this;
        }

        public ICollection<ICalculator> GetResult()
        {
            if (_track is null)
                throw new Exception("Track no exist");
                
            foreach (var point in _track.Points)
                foreach (var calculator in _calculators)
                    calculator.Handle(point);
                        
            return _calculators;
        }
    }
}