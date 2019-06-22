#if UNITY_5_3_OR_NEWER
#define NOESIS
using Noesis;
#else
using System.Windows;
using System.Windows.Controls;
#endif


namespace Rover.Controls
{
    public class Gauge : ProgressBar
    {

        #region DependencyProperties

        public static readonly DependencyProperty WarningValueProperty = DependencyProperty.Register("WarningValue", typeof(double), typeof(Gauge), new UIPropertyMetadata(0.0));

        #endregion

        #region Instance properties
        
        public double WarningValue
        {
            get { return (double)GetValue(WarningValueProperty); }
            set { SetValue(WarningValueProperty, value); }
        }
        #endregion

        #region Instance methods

        public Gauge()
        {

         //   Initialized += OnInitialized;

        }

        #endregion
    }
}
