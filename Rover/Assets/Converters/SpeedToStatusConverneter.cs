#if UNITY_5_3_OR_NEWER
#define NOESIS
using Noesis;
#else
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
#endif
using System;
using System.Globalization;
using RoverGUI.Data.Entities;

namespace RoverGUI.Converters
{
    public sealed class SpeedToStatusConverneter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
#if NOESIS
            var speed = (float)value;
#else
            var speed = (double)value;
#endif

            if (speed > 45)
                return GaugeStatus.Danger;

            if (speed > 35)
                return GaugeStatus.Warning;

            if (parameter!=null)
                return GaugeStatus.Off;


            return GaugeStatus.Normal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
