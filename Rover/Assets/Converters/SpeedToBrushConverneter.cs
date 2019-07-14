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


namespace RoverGUI.Converters
{
    public sealed class SpeedToBrushConverneter : IValueConverter
    {
        public Brush NormalBrush { get; set; }

        public Brush WarningBrush { get; set; }

        public Brush FailureBrush { get; set; }

        public Brush ForegroundBrush { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
#if NOESIS
            var securityPercentage = (float)value;
#else
            var securityPercentage = (double)value;
#endif

            if (securityPercentage > 45)
                return FailureBrush;

            if (securityPercentage > 35)
                return WarningBrush;

            if (parameter!=null)
                return ForegroundBrush;


            return NormalBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
