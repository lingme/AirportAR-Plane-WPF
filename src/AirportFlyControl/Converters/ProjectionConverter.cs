using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AirportFlyControl.Converters
{
    public class ProjectionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var amount = default(double);
            if(values.Count()==3 && values[0] is double scale && values[1] is double active && values[2] is double width)
            {
                amount = active * scale - width / 2d;
            }
            return amount;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
