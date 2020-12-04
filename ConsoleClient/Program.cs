using System.IO;
using System.Reflection;
using TrailsCalculator;
using TrailsCalculator.Calculators;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathToFile = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "twister.gpx"
            );

            var track = new GpxTrackReader(pathToFile)
                .GetTrack("Twister");

            var calculatorProcessor = new TrackCalculatorProcessor(track)
                .AddCalculator(new DistanceCalculator())
                .AddCalculator(new SpeedCalculator())
                .AddCalculator(new ElevationCalculator())
                .AddCalculator(new TimeCalculator());

            foreach (var calculator in calculatorProcessor.GetResult())
                calculator.Presentation();
        }
    }
}