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
    public class RoverProgressBar : ProgressBar
    {
        public static readonly DependencyProperty StatusProperty = DependencyProperty.Register("Status", typeof(GaugeStatus), typeof(RoverProgressBar), new UIPropertyMetadata(GaugeStatus.Normal));
        public GaugeStatus Status
        {
            get { return (GaugeStatus)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }
    }
}
