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
    public class Gauge : Control
    {
        private const string ValuePathName = "PART_Value";
        private const string BackgroundPathName = "Part_PathBackground";
        private const int AnimationSpeed = 700;

        private double ValueOffset;
        private double ValuePercent;

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

        private byte isPozitiveArc=1;

        private Path pathValue;
        private Path pathBackground;
        
        private readonly DoubleAnimation smoothValueAnimation;
        private readonly Storyboard smoothValueStoryboard = new Storyboard();
        private bool smoothValueAnimationStarted;

        #region Properties

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(Gauge), new UIPropertyMetadata(0.0, OnValuePropertyChanged));
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Gauge)d).OnValueChanged((double)e.NewValue);
        }

#if NOESIS
        public static readonly DependencyProperty SmoothValueProperty = DependencyProperty.Register("SmoothValue", typeof(float), typeof(Gauge), new UIPropertyMetadata(0.0, OnSmoothValuePropertyChanged));

        public float SmoothValue
        {
            get { return (float)GetValue(SmoothValueProperty); }
            set { SetValue(SmoothValueProperty, value); }
        }
#else
        public static readonly DependencyProperty SmoothValueProperty = DependencyProperty.Register("SmoothValue", typeof(double), typeof(Gauge), new UIPropertyMetadata(0.0, OnSmoothValuePropertyChanged));
        public double SmoothValue
        {
            get { return (double)GetValue(SmoothValueProperty); }
            set { SetValue(SmoothValueProperty, value); }
        }
#endif
        private static void OnSmoothValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
#if NOESIS
            ((Gauge)d).OnSmoothValueChanged((float)e.NewValue);
#else
            ((Gauge)d).OnSmoothValueChanged((double)e.NewValue);
#endif
        }

        public static readonly DependencyProperty ValueForegroundProperty = DependencyProperty.Register("ValueForeground", typeof(Brush), typeof(Gauge), new UIPropertyMetadata(Brushes.White));
        public Brush ValueForeground
        {
            get { return (Brush)GetValue(ValueForegroundProperty); }
            set { SetValue(ValueForegroundProperty, value); }
        }

        public static readonly DependencyProperty AngleValueProperty = DependencyProperty.Register("AngleValue", typeof(double), typeof(Gauge), new UIPropertyMetadata(0.0));
        public double AngleValue
        {
            get { return (double)GetValue(AngleValueProperty); }
            set { SetValue(AngleValueProperty, value); }
        }



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


        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(double), typeof(Gauge), new UIPropertyMetadata(100.0, OnMaximumPropertyChanged));
        public double Maximum
        {
            get {return (double)GetValue(MaximumProperty);}
            set { SetValue(MaximumProperty, value); }
        }
        private static void OnMaximumPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Gauge)d).CalculatePozitions();
        }

        public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(double), typeof(Gauge), new UIPropertyMetadata(0.0, OnMinimumPropertyChanged));
        public double Minimum
        {
            get {return (double)GetValue(MinimumProperty);}
            set { SetValue(MinimumProperty, value); }
        }
        private static void OnMinimumPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Gauge)d).CalculatePozitions();
        }


        public static readonly DependencyProperty AngleCoordinateRotationProperty = DependencyProperty.Register("AngleCoordinateRotation", typeof(double), typeof(Gauge), new UIPropertyMetadata(270.0, OnAngleCoordinateRotationPropertyChanged));
        public double AngleCoordinateRotation
        {
            get { return Math.PI / 180.0 * (double)GetValue(AngleCoordinateRotationProperty); }
            set { SetValue(AngleCoordinateRotationProperty, value); }
        }
        private static void OnAngleCoordinateRotationPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Gauge)d).CalculatePozitions();
        }


        public static readonly DependencyProperty AngleProperty = DependencyProperty.Register("Angle", typeof(double), typeof(Gauge), new UIPropertyMetadata(30.0, OnAnglePropertyChanged));
        public double Angle
        {
            get { return Math.PI / 180.0 * (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }
        private static void OnAnglePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Gauge)d).CalculatePozitions();
        }

        public static readonly DependencyProperty StatusProperty = DependencyProperty.Register("Status", typeof(GaugeStatus), typeof(Gauge), new UIPropertyMetadata(GaugeStatus.Normal, OnAnglePropertyChanged));
        public GaugeStatus Status
        {
            get { return (GaugeStatus)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }

        #endregion


        #region Instance methods

        public Gauge()
        {
            //Initialized += OnInitialized; // инициализация вместо MeasureOverride ? OnApplyTemplate отсутсвует
            smoothValueAnimation = new DoubleAnimation
            {
                //BeginTime = new TimeSpan(0, 0, 0, 0, 100), // задержка анимации при необходимости
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
            if (pathValue == null)
            {
                pathValue = GetTemplateChild(ValuePathName) as Path;
                pathBackground = GetTemplateChild(BackgroundPathName) as Path;
            }

            CalculatePozitions();

            return constraint;
        }

        private void CalculatePozitions()
        {
            if (pathValue==null)
                return;

            if (Minimum < 0)
            {
                ValueOffset = Math.Abs(Minimum) * 100 / (Maximum - Minimum) / 100.0 * Angle;
            }
            else
            {
                ValueOffset = 0;
            }

            CalculateBackgroundStartPozitions(Width - pathBackground.Margin.Left - pathBackground.Margin.Right);
            CalculateValueStartPozition(Width - pathValue.Margin.Left - pathValue.Margin.Right);
        }

       

        public void OnValueChanged(double value)
        {
            if (double.IsNaN(value))
                return;

            if (value > Maximum) value = Maximum;
            if (value < Minimum) value = Minimum;

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
            if (double.IsNaN(value))
                return;

            if (value > Maximum) value = Maximum;
            if (value < Minimum) value = Minimum;

            endPoint = CalculateEndpoint(value);
            SetDataValue();
        }

        private void OnSmoothValueAnimationCompleted(object sender, EventArgs e)
        {
            if (smoothValueAnimationStarted)
            {
                smoothValueAnimationStarted = false;
            }
        }

        private Point CalculateEndpoint(double value)
        {
            if(Minimum>0)
            {
                ValuePercent = (value - Minimum) * 100 / (Maximum - Minimum);
            }
            else
            {
                ValuePercent = (value) * 100 / (Maximum - Minimum);
            }

            var angle = ValuePercent / 100 * Angle;


            if (Math.Abs(angle) > Math.PI)
            {
                isLargeArc = 1;
            }
            else
            {
                isLargeArc = 0;
            }

            if(value >= 0)
            {
                isPozitiveArc = 1;
            }
            else
            {
                isPozitiveArc = 0;
            }

            angle = AngleCoordinateRotation - ValueOffset - angle;

            AngleValue = angle / Math.PI * -180;

            return new Point(
                (float)Math.Cos(angle) * (float)radius + centerPoint.X,
                -(float)Math.Sin(angle) * (float)radius + centerPoint.Y);
        }

        private void CalculateValueStartPozition(double width)
        {
            centerPoint = new Point((float)width / 2.0f, (float)width / 2.0f);

            radius = centerPoint.X - pathValue.StrokeThickness / 2.0;

            startPoint = new Point(
                (float)Math.Cos((float)(AngleCoordinateRotation - ValueOffset)) * (float)radius + centerPoint.X,
                -(float)Math.Sin((float)(AngleCoordinateRotation - ValueOffset)) * (float)radius + centerPoint.Y);

        }

        private void CalculateBackgroundStartPozitions(double width)
        {
            centerPointBackground = new Point((float)width / 2.0f, (float)width / 2.0f);

            radiusBackground = centerPointBackground.X - pathBackground.StrokeThickness / 2.0;

            startPointBackground = new Point(
                (float)Math.Cos((float)AngleCoordinateRotation) * (float)radiusBackground + centerPointBackground.X,
                -(float)Math.Sin((float)AngleCoordinateRotation) * (float)radiusBackground + centerPointBackground.Y);

            endPointBackground = new Point(
               (float)Math.Cos(AngleCoordinateRotation - Angle) * (float)radiusBackground + centerPointBackground.X,
               -(float)Math.Sin(AngleCoordinateRotation - Angle) * (float)radiusBackground + centerPointBackground.Y);

            if (Angle > Math.PI)
            {
                isLargeArcBackground = 1;
            }
            else
            {
                isLargeArcBackground = 0;
            }

            SetDataBackground();
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
                + " " 
                + isPozitiveArc
                + " "
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
