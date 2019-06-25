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

        public static readonly DependencyProperty WarningValueProperty = DependencyProperty.Register("WarningValue", typeof(int), typeof(Gauge), new UIPropertyMetadata(0));



        #endregion

        #region Instance properties

        public int WarningValue
        {
            get { return (int)GetValue(WarningValueProperty); }
            set { SetValue(WarningValueProperty, value); }
        }

        #endregion

        #region Instance methods

        private static void OnWarningValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var percentagePresenter = (Gauge)d;
            percentagePresenter.OnWarningValueChanged((double)e.NewValue);
        }

        public Gauge()
        {
            //_smoothValueAnimation = new DoubleAnimation
            //{
            //    BeginTime = new TimeSpan(0, 0, 0, 0, 300),
            //    Duration = TimeSpan.FromMilliseconds(AnimationSpeed),
            //    FillBehavior = FillBehavior.HoldEnd,
            //    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            //};
            //_smoothValueAnimation.Completed += OnSmoothValueAnimationCompleted;
            //_smoothValueStoryboard.Children.Add(_smoothValueAnimation);

            //Storyboard.SetTarget(_smoothValueAnimation, this);
            //Storyboard.SetTargetProperty(_smoothValueAnimation, new PropertyPath(SmoothValueProperty));

        }
//#if NOESIS
//        public void OnApplyTemplate()
//        {
           
//        }
//#else
//        public override void OnApplyTemplate()
//        {
//            base.OnApplyTemplate();
//        }
//#endif

        public void OnWarningValueChanged(double newValue)
        {
            //if (double.IsNaN(newValue))
            //    return;

            //if (_smoothValueAnimationStarted)
            //{
            //    _smoothValueStoryboard.Stop();
            //}

            //_smoothValueAnimation.From = SmoothValue;
            //_smoothValueAnimation.To = newValue;
            //_smoothValueStoryboard.Begin(this);

            //_smoothValueAnimationStarted = true;
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
