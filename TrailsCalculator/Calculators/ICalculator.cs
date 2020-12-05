using TrailsCalculator.Models;

namespace TrailsCalculator.Calculators
{
    public interface ICalculator
    {
        void Presentation();
        void Handle(PointModel point);
    }
}