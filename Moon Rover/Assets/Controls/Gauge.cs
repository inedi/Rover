#if UNITY_5_3_OR_NEWER
#define NOESIS
using Noesis;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
#endif

namespace Rover.Controls
{
    public class Gauge : Control
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


        }

        private void CalculateNewDemensions(double width)
        {
            //_centerPoint = new Point(width / 2.0, width / 2.0);

            //_radius = _centerPoint.X - Thickness / 2.0;
            //_valueArcSegment.Size = new Size(_radius, _radius);

            //_valuePathFigure.StartPoint = new Point(
            //    Math.Cos(AngleCoordinateRotation - AngleOffset) * _radius + _centerPoint.X,
            //    -Math.Sin(AngleCoordinateRotation - AngleOffset) * _radius + _centerPoint.Y);

            //_backgroundArcSegment.Point = CalculateEndpoint(100.0);


        }
#endregion
    }
}
