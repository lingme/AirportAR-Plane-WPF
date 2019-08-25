using Domain.AsyncCollection;
using Domain.Models;
using System.Windows;
using System.Windows.Controls;

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
