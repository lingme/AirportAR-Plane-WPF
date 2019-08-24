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

namespace AirportFlyControl
{
    public class AirportFlyLayer : Control
    {
        public ObservableCollection<AircraftAR> AirSources
        {
            get { return (ObservableCollection<AircraftAR>)GetValue(AirSourcesProperty); }
            set { SetValue(AirSourcesProperty, value); }
        }

        public static readonly DependencyProperty AirSourcesProperty = DependencyProperty.Register(
            nameof(AirSources), 
            typeof(ObservableCollection<AircraftAR>), 
            typeof(AirportFlyLayer), 
            new PropertyMetadata(new ObservableCollection<AircraftAR>()));

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
