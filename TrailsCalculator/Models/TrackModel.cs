using System.Collections.Generic;

namespace TrailsCalculator.Models
{
    public class TrackModel
    {
        public string Name { get; set; }
        public IReadOnlyCollection<PointModel> Points { get; set; }

        public TrackModel(string name, IReadOnlyCollection<PointModel> points)
        {
            Name = name;
            Points = points;
        }
    }
}