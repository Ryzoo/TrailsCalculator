using TrailsCalculator.Models;

namespace TrailsCalculator.Calculators
{
    public interface ICalculator
    {
        void Presentation();
        void Calculate(PointModel point);
        void Handle(PointModel point);
    }
}