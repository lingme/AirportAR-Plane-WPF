using System.Windows;
using Domain.Models;
using Domain.AsyncCollection;
using System.Windows.Controls;

namespace AirportFlyControl.Dependencys
{
    public class ProxyObject : ListBoxItem 
    {
        public object ProxyFromFrame
        {
            get { return (object)GetValue(ProxyFromFrameProperty); }
            set { SetValue(ProxyFromFrameProperty, value); }
        }

        public static readonly DependencyProperty ProxyFromFrameProperty =
            DependencyProperty.Register("ProxyFromFrame", typeof(object), typeof(ProxyObject), new PropertyMetadata(new object()));

        public object ProxyToFrame
        {
            get { return (object)GetValue(ProxyToFrameProperty); }
            set { SetValue(ProxyToFrameProperty, value); }
        }

        public static readonly DependencyProperty ProxyToFrameProperty =
            DependencyProperty.Register("ProxyToFrame", typeof(object), typeof(ProxyObject), new PropertyMetadata(new object()));
    }
}
