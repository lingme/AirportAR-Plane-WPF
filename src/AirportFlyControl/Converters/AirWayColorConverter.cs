using Domain;
using System;
using System.Globalization;
using System.Windows.Data;
using Wpf=System.Windows.Media;

namespace AirportFlyControl.Converters
{
    public class AirWayColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Wpf::Brush brush = default(Wpf::Brush);
            Wpf::BrushConverter brushConverter = new Wpf.BrushConverter();
            if(value is AirWays airWay)
            {
                switch(airWay)
                {
                    case AirWays.A:
                        brush = (Wpf::Brush)brushConverter.ConvertFromString("#ffc501");
                        break;
                    case AirWays.D:
                        brush = (Wpf::Brush)brushConverter.ConvertFromString("#03df4b");
                        break;
                }
            }
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
