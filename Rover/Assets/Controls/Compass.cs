#if UNITY_5_3_OR_NEWER
#define NOESIS
using Noesis;
using Float = System.Single;
using EventArgs = Noesis.EventArgs;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Float = System.Double;
#endif
using System;
using RoverGUI.Data.Entities;

namespace RoverGUI.Controls
{
    public class Compass : Control
    {
#region Properties

        public static readonly DependencyProperty AngleProperty = DependencyProperty.Register("Angle", typeof(double), typeof(Compass), new UIPropertyMetadata(0.0, OnAnglePropertyChanged));
        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }
        private static void OnAnglePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Compass)d).CalculatePozitions();
        }

        private void CalculatePozitions()
        {
           // throw new NotImplementedException();
        }

        #endregion

        public Compass()
        {

        }
    }
}
