using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using System.Collections.ObjectModel;
using Domain.Models;
using System.Windows.Media;
using System.Reactive.Linq;
using Domain.AsyncCollection;

namespace MainShell
{
    [AddINotifyPropertyChangedInterface]
    public class MainWindowVM
    {
        public AsyncObservableCollection<AircraftAR> AircraftList { get; set; } = new AsyncObservableCollection<AircraftAR>();

        public MainWindowVM()
        {
            AircraftList.Add(new AircraftAR {
                FlightNumber="MU6543",
                AirWay = Domain.AirWays.A,
                FlightX = 0.05,
                FlightY = 0.15,
                FlightAngle = 0
            });

            AircraftList.Add(new AircraftAR
            {
                FlightNumber = "MU6543",
                AirWay = Domain.AirWays.A,
                FlightX = 0.05,
                FlightY = 0.35,
                FlightAngle = 0
            });


            AircraftList.Add(new AircraftAR
            {
                FlightNumber = "MU6543",
                AirWay = Domain.AirWays.D,
                FlightX = 0.05,
                FlightY = 0.55,
                FlightAngle = 0
            });


            Observable.Interval(TimeSpan.FromSeconds(0.2)).Subscribe(RunInfo);
        }

        async void RunInfo(long p)
        {
            foreach (var item in AircraftList)
            {
                item.FlightX += 0.01;
                item.FlightAngle = (item.FlightAngle += 0.5) % 360;
            }
        }
    }
}
