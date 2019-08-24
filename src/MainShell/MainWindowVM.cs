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
                FlightNumber = "MU6543",
                AirWay = Domain.AirWays.A,
                Vertex = new VertexCoord(0, 100),
                FlightAngle = 0
            }) ;

            Observable.Interval(TimeSpan.FromSeconds(2)).Subscribe(RunInfo);
        }

        async void RunInfo(long p)
        {
            foreach (var item in AircraftList)
            {
                item.Vertex = new VertexCoord(item.Vertex.X+500, item.Vertex.Y+0.2);
            }
        }
    }
}
