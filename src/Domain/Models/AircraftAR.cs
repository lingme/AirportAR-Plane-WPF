using PropertyChanged;
using System.Windows;
using System.Windows.Shapes;
using Wpf=System.Windows.Media;

namespace Domain.Models
{
    [AddINotifyPropertyChangedInterface]
    public class AircraftAR
    {
        public string FlightNumber { get; set; }

        public AirWays AirWay { get; set; }

        public double FlightX { get; set; }

        public double FlightY { get; set; }

        public double FlightAngle { get; set; }

        public bool IsShowFlightNumber { get; set; } = true;

        public bool IsShowAirWay { get; set; } = true;

        public Wpf::Brush ArFill { get; set; }
    }
}
