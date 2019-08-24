using PropertyChanged;

namespace Domain.Models
{
    [AddINotifyPropertyChangedInterface]
    public class VertexCoord
    {
        public VertexCoord() { }

        public VertexCoord(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public double X { get; set; }
        public double Y { get; set; }
    }
}
