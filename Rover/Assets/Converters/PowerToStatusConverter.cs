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
    public sealed class PowerToStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
#if NOESIS
            var pover = (float)value;
#else
            var pover = (double)value;
#endif

            if (pover > 170)
                return GaugeStatus.Danger;

            if (pover > 150)
                return GaugeStatus.Warning;

            if (pover < 0)
                return GaugeStatus.Recuperate;

            if (parameter != null)
                return GaugeStatus.Off;
           

            return GaugeStatus.Normal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
