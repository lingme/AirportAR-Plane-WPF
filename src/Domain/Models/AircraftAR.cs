using PropertyChanged;
using System;

namespace Domain.Models
{
    [AddINotifyPropertyChangedInterface]
    public class AircraftAR
    {
        public string FlightNumber { get; set; }

        public AirWays AirWay { get; set; }

        public VertexCoord Vertex
        {
            get => ToFrame;
            set
            {
                FromFrame.X = ToFrame.X;
                FromFrame.Y = ToFrame.Y;
                ToFrame.X = value.X;
                ToFrame.Y = value.Y;

                MessageInterval = (DateTime.Now - FrameTime).TotalSeconds;
                FrameTime = DateTime.Now;

                BeginFlyAnimation = !BeginFlyAnimation;
            }
        }

        public VertexCoord FromFrame { get; private set; } = new VertexCoord();

        public VertexCoord ToFrame { get; private set; } = new VertexCoord();

        public DateTime FrameTime { get; private set; } = DateTime.Now;

        public double MessageInterval { get; private set; }

        public double FlightAngle { get; set; }

        public bool IsShowFlightNumber { get; set; } = true;

        public bool IsShowAirWay { get; set; } = true;

        public bool BeginFlyAnimation { get; set; }
    }
}
