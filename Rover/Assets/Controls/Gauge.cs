#if UNITY_5_3_OR_NEWER
#define NOESIS
using Noesis;
using Float = System.Single;
using EventArgs = Noesis.EventArgs;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Float = System.Double;
#endif
using System;


namespace RoverGUI.Controls
{
    public class Gauge : Control
    {
        private const string ValuePathName = "PART_Value";
        private const string BackgroundPathName = "Part_PathBackground";
        private const int AnimationSpeed = 700;

        private double FullAngle;

        private Point centerPoint;
        private Point startPoint;
        private Point endPoint;
        private double radius;

        private Point centerPointBackground;
        private Point startPointBackground;
        private Point endPointBackground;
        private double radiusBackground;

        private byte isLargeArc;
        private byte isLargeArcBackground;

        private Path pathValue;
        private Path pathBackground;
        
        private readonly DoubleAnimation smoothValueAnimation;
        private readonly Storyboard smoothValueStoryboard = new Storyboard();
        private bool smoothValueAnimationStarted;

        #region Properties

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(Gauge), new UIPropertyMetadata(0.0, OnValueChanged));

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

#if NOESIS
        public static readonly DependencyProperty SmoothValueProperty = DependencyProperty.Register("SmoothValue", typeof(float), typeof(Gauge), new UIPropertyMetadata(0.0, OnSmoothValueChanged));

        public float SmoothValue
        {
            get { return (float)GetValue(SmoothValueProperty); }
            set { SetValue(SmoothValueProperty, value); }
        }
#else
        public static readonly DependencyProperty SmoothValueProperty = DependencyProperty.Register("SmoothValue", typeof(double), typeof(Gauge), new UIPropertyMetadata(0.0, OnSmoothValueChanged));

        public double SmoothValue
        {
            get { return (double)GetValue(SmoothValueProperty); }
            set { SetValue(SmoothValueProperty, value); }
        }
#endif

        public static readonly DependencyProperty DataValueProperty = DependencyProperty.Register("DataValue", typeof(string), typeof(Gauge), new UIPropertyMetadata(""));

        public string DataValue
        {
            get { return (string)GetValue(DataValueProperty); }
            set { SetValue(DataValueProperty, value); }
        }

        public static readonly DependencyProperty DataBackgroundProperty = DependencyProperty.Register("DataBackground", typeof(string), typeof(Gauge), new UIPropertyMetadata(""));

        public string DataBackground
        {
            get { return (string)GetValue(DataBackgroundProperty); }
            set { SetValue(DataBackgroundProperty, value); }
        }

        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(double), typeof(Gauge), new UIPropertyMetadata(90.0, OnValueChanged));

        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public static readonly DependencyProperty AngleOffsetProperty = DependencyProperty.Register("AngleOffset", typeof(double), typeof(Gauge), new UIPropertyMetadata(60.0, OnValueChanged));
       
        public double AngleOffset
        {
            get
            {
                var angle = Math.PI / 180.0 * (double)GetValue(AngleOffsetProperty);
                FullAngle = 2 * Math.PI - 2 * angle;

                return angle;
            }
            set { SetValue(AngleOffsetProperty, value); }
        }

        public static readonly DependencyProperty AngleCoordinateRotationProperty = DependencyProperty.Register("AngleCoordinateRotation", typeof(double), typeof(Gauge), new UIPropertyMetadata(270.0, OnValueChanged));

        public double AngleCoordinateRotation
        {
            get { return Math.PI / 180.0 * (double)GetValue(AngleCoordinateRotationProperty); }
            set { SetValue(AngleCoordinateRotationProperty, value); }
        }

#endregion


#region Instance methods

        public Gauge()
        {
            //Initialized += OnInitialized;
            smoothValueAnimation = new DoubleAnimation
            {
                //BeginTime = new TimeSpan(0, 0, 0, 0, 0),
                Duration = TimeSpan.FromMilliseconds(AnimationSpeed),
                FillBehavior = FillBehavior.HoldEnd,
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
            };
            smoothValueAnimation.Completed += OnSmoothValueAnimationCompleted;
            smoothValueStoryboard.Children.Add(smoothValueAnimation);

            Storyboard.SetTarget(smoothValueAnimation, this);
            Storyboard.SetTargetProperty(smoothValueAnimation, new PropertyPath(SmoothValueProperty));
        }

        protected override Size MeasureOverride(Size constraint)
        {
            if(pathValue == null)
            {
                pathValue = GetTemplateChild(ValuePathName) as Path;
                pathBackground = GetTemplateChild(BackgroundPathName) as Path;
            }

            CalculateValueStartPozitions(constraint.Width - pathValue.Margin.Left - pathValue.Margin.Right);
            CalculateBackgroundPozitions(constraint.Width - pathBackground.Margin.Left - pathBackground.Margin.Right);
            SetDataBackground();
            endPoint = CalculateEndpoint(Value);
            SetDataValue();
            return constraint;
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var gauge = (Gauge)d;
            gauge.OnValueChanged((double)e.NewValue);
        }

        private static void OnSmoothValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
#if NOESIS
            ((Gauge)d).OnSmoothValueChanged((float)e.NewValue);
#else
            ((Gauge)d).OnSmoothValueChanged((double)e.NewValue);
#endif

        }

        public void OnValueChanged(double value)
        {
            if (double.IsNaN(value))
                return;

            if (value > Maximum) value = Maximum;

            if (smoothValueAnimationStarted)
            {
                smoothValueStoryboard.Stop();
            }

            smoothValueAnimation.From = (float)SmoothValue;
            smoothValueAnimation.To = (float)value;
            smoothValueStoryboard.Begin(this);
            smoothValueAnimationStarted = true;
        }

        private void OnSmoothValueChanged(double value)
        {
            endPoint = CalculateEndpoint(value * 100 / Maximum);
            SetDataValue();
        }

        private void OnSmoothValueAnimationCompleted(object sender, EventArgs e)
        {
            if (smoothValueAnimationStarted)
            {
                smoothValueAnimationStarted = false;
            }
        }

        private void CalculateValueStartPozitions(double width)
        {
            centerPoint = new Point((float)width / 2.0f, (float)width / 2.0f);

            radius = centerPoint.X - pathValue.StrokeThickness / 2.0;
           
            startPoint = new Point(
                (float)Math.Cos((float)AngleCoordinateRotation - (float)AngleOffset) * (float)radius + centerPoint.X,
                -(float)Math.Sin((float)AngleCoordinateRotation - (float)AngleOffset) * (float)radius + centerPoint.Y);
        }

        private void CalculateBackgroundPozitions(double width)
        {
            centerPointBackground = new Point((float)width / 2.0f, (float)width / 2.0f);

            radiusBackground = centerPointBackground.X - pathBackground.StrokeThickness / 2.0;
            startPointBackground = new Point(
                (float)Math.Cos((float)AngleCoordinateRotation - (float)AngleOffset) * (float)radiusBackground + centerPointBackground.X,
                -(float)Math.Sin((float)AngleCoordinateRotation - (float)AngleOffset) * (float)radiusBackground + centerPointBackground.Y);

            endPointBackground = CalculateEndpointBackground(100.0);
        }

        private Point CalculateEndpoint(double value)
        {
            var angle = value / 100.0 * FullAngle;
          
            if (angle > Math.PI)
            {
                isLargeArc = 1;
            }
            else
            {
                isLargeArc = 0;
            }

            angle = AngleCoordinateRotation - AngleOffset - angle;

            return new Point(
                (float)Math.Cos(angle) * (float)radius + centerPoint.X,
                -(float)Math.Sin(angle) * (float)radius + centerPoint.Y);
        }

        private Point CalculateEndpointBackground(double value)
        {
            var angle = value / 100.0 * FullAngle;

            if (angle > Math.PI)
            {
                isLargeArcBackground = 1;
            }
            else
            {
                isLargeArcBackground = 0;
            }

            angle = AngleCoordinateRotation - AngleOffset - angle;

            return new Point(
                (float)Math.Cos(angle) * (float)radiusBackground + centerPointBackground.X,
                -(float)Math.Sin(angle) * (float)radiusBackground + centerPointBackground.Y);
        }

        private void SetDataValue()
        {
            DataValue = "M " 
                + startPoint.X.ToString("0.0000", System.Globalization.CultureInfo.GetCultureInfo("en-US"))
                + "," 
                + startPoint.Y.ToString("0.0000", System.Globalization.CultureInfo.GetCultureInfo("en-US"))
                + " A " 
                + radius.ToString("0.0000", System.Globalization.CultureInfo.GetCultureInfo("en-US"))
                + "," 
                + radius.ToString("0.0000", System.Globalization.CultureInfo.GetCultureInfo("en-US"))
                + " 0 " 
                + isLargeArc 
                + " 1 " 
                + endPoint.X.ToString("0.0000", System.Globalization.CultureInfo.GetCultureInfo("en-US"))
                + "," 
                + endPoint.Y.ToString("0.0000", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
        }

        private void SetDataBackground()
        {
            DataBackground = "M "
                + startPointBackground.X.ToString("0.0000", System.Globalization.CultureInfo.GetCultureInfo("en-US"))
                + "," 
                + startPointBackground.Y.ToString("0.0000", System.Globalization.CultureInfo.GetCultureInfo("en-US"))
                + " A "
                + radiusBackground.ToString("0.0000", System.Globalization.CultureInfo.GetCultureInfo("en-US"))
                + ","
                + radiusBackground.ToString("0.0000", System.Globalization.CultureInfo.GetCultureInfo("en-US"))
                + " 0 "
                + isLargeArcBackground
                + " 1 " 
                + endPointBackground.X.ToString("0.0000", System.Globalization.CultureInfo.GetCultureInfo("en-US"))
                + ","
                + endPointBackground.Y.ToString("0.0000", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
        }
#endregion
    }
}
