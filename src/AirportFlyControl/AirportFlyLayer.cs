using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Domain.Models;
using Domain.AsyncCollection;

namespace AirportFlyControl
{
    public class AirportFlyLayer : Control
    {
        public AsyncObservableCollection<AircraftAR> AirSources
        {
            get { return (AsyncObservableCollection<AircraftAR>)GetValue(AirSourcesProperty); }
            set { SetValue(AirSourcesProperty, value); }
        }

        public static readonly DependencyProperty AirSourcesProperty = DependencyProperty.Register(
            nameof(AirSources), 
            typeof(AsyncObservableCollection<AircraftAR>), 
            typeof(AirportFlyLayer), 
            new PropertyMetadata(new AsyncObservableCollection<AircraftAR>()));

        static AirportFlyLayer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AirportFlyLayer), new FrameworkPropertyMetadata(typeof(AirportFlyLayer)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

    }
}
