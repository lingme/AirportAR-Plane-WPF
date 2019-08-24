using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using System.Collections.ObjectModel;
using Domain.Models;
using System.Windows.Media;

namespace MainShell
{
    [AddINotifyPropertyChangedInterface]
    public class MainWindowVM
    {
        public ObservableCollection<AircraftAR> AircraftList { get; set; } = new ObservableCollection<AircraftAR>();

        public MainWindowVM()
        {
            AircraftList.Add(new AircraftAR {
                FlightNumber="MU6543",
                AirWay = Domain.AirWays.A,
                FlightX = 0.5,
                FlightY = 0.5,
                FlightAngle = 90
            });


            AircraftList.Add(new AircraftAR
            {
                FlightNumber = "MU6543",
                AirWay = Domain.AirWays.A,
                FlightX = 0.5,
                FlightY = 0.5,
                FlightAngle = 90
            });
        }
    }
}
