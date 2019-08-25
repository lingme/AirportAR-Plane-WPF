using Domain.AsyncCollection;
using Domain.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Domain;

namespace MainShell
{
    [AddINotifyPropertyChangedInterface]
    public class MainWindowVM
    {
        public AsyncObservableCollection<AircraftAR> AircraftList { get; set; } = new AsyncObservableCollection<AircraftAR>();

        public IReadOnlyDictionary<int, Tuple<AirWays, VertexCoord,double>> AircraftDic = new Dictionary<int, Tuple<AirWays, VertexCoord, double>>
        {
            { 0, new Tuple<AirWays, VertexCoord, double>(AirWays.A,new VertexCoord(0.96,0.93),90) },
            { 1, new Tuple<AirWays, VertexCoord, double>(AirWays.A,new VertexCoord(0.97,0.1),0) },
            { 2, new Tuple<AirWays, VertexCoord, double>(AirWays.D,new VertexCoord(0.04,0.1),270) },
            { 3, new Tuple<AirWays, VertexCoord, double>(AirWays.D,new VertexCoord(0.04,0.93),180) }
        };

        public MainWindowVM()
        {
            AircraftList.Add(new AircraftAR {
                FlightNumber = "MU6543",
                AirWay = AirWays.A,
                Vertex = new VertexCoord(0.04, 0.93),
                FlightAngle = 90
            }) ;

            Observable.Interval(TimeSpan.FromSeconds(5)).Subscribe(RunInfo);
        }

        private int offSet = 0;
        void RunInfo(long p)
        {
            var data = AircraftDic[offSet%AircraftDic.Count];
            foreach (var item in AircraftList)
            {
                item.AirWay = data.Item1;
                item.Vertex = data.Item2;
                item.FlightAngle = data.Item3;
            }
            offSet++;
        }
    }
}
