using Domain.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AirportFlyControl.Dependencys
{
    public class StoryboardHelper : DependencyObject
    {
        public static bool GetCustomAnimation(DependencyObject obj)
        {
            return (bool)obj.GetValue(CustomAnimationProperty);
        }

        public static void SetCustomAnimation(DependencyObject obj, bool value)
        {
            obj.SetValue(CustomAnimationProperty, value);
        }

        public static readonly DependencyProperty CustomAnimationProperty = DependencyProperty.RegisterAttached(
            "CustomAnimation",
            typeof(bool),
            typeof(StoryboardHelper),
            new PropertyMetadata(false, BeginIfPropertyChangedCallback));

        private static void BeginIfPropertyChangedCallback(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            if (s is ListBoxItem listBoxItem)
            {
                if (listBoxItem.DataContext is AircraftAR aircraftAR)
                {
                    var canvas = (Canvas)VisualTreeHelper.GetParent(listBoxItem);
                    if (canvas.IsLoaded)
                    {
                        var leftAnimation = GenerateDoubleAnimation(
                            MatchAnimationFrameScope(aircraftAR.FromFrame.X, canvas.ActualWidth, listBoxItem.ActualWidth),
                            MatchAnimationFrameScope(aircraftAR.ToFrame.X, canvas.ActualWidth, listBoxItem.ActualWidth),
                            TimeSpan.FromSeconds(aircraftAR.MessageInterval));

                        var topAnimation = GenerateDoubleAnimation(
                           MatchAnimationFrameScope(aircraftAR.FromFrame.Y, canvas.ActualHeight, listBoxItem.ActualHeight),
                           MatchAnimationFrameScope(aircraftAR.ToFrame.Y, canvas.ActualHeight, listBoxItem.ActualHeight),
                           TimeSpan.FromSeconds(aircraftAR.MessageInterval));

                        SetAnimationStoryboard(leftAnimation, Canvas.LeftProperty, listBoxItem);
                        SetAnimationStoryboard(topAnimation, Canvas.TopProperty, listBoxItem);

                        BeginAnimationStoryboard(leftAnimation,topAnimation);
                    }
                }
            }
        }

        static double MatchAnimationFrameScope(double x, double canvasWidth, double itemWidth)
        {
            return canvasWidth * x - itemWidth / 2;
        }

        static DoubleAnimation GenerateDoubleAnimation(double? from, double? to, Duration duration)
        {
            return new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = duration
            };
        }

        static void SetAnimationStoryboard(DoubleAnimation doubleAnimation, DependencyProperty property, DependencyObject @object)
        {
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(property));
            Storyboard.SetTarget(doubleAnimation, @object);
        }

        static void BeginAnimationStoryboard(params DoubleAnimation[] animations)
        {
            var storyboard = new Storyboard();
            foreach (var item in animations)
            {
                storyboard.Children.Add(item);
            }
            storyboard.Begin();
        }
    }
}
