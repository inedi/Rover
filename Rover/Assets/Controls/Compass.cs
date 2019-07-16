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
#if NOESIS
        private const float Degree = 4.8f;
        private float offset;
#else
        private const double Degree = 4.8;
        private double offset;
#endif

        #region Properties
#if NOESIS
        public static readonly DependencyProperty AngleProperty = DependencyProperty.Register("Angle", typeof(float), typeof(Compass), new UIPropertyMetadata(0.0, OnAnglePropertyChanged));
        public float Angle
        {
            get { return (float)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }
        private static void OnAnglePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Compass)d).AngleChanged((float)e.NewValue);
        }

        public static readonly DependencyProperty SmoothValueProperty = DependencyProperty.Register("SmoothValue", typeof(float), typeof(Compass), new UIPropertyMetadata(0.0));

        public float SmoothValue
        {
            get { return (float)GetValue(SmoothValueProperty); }
            set { SetValue(SmoothValueProperty, value); }
        }
#else
        public static readonly DependencyProperty AngleProperty = DependencyProperty.Register("Angle", typeof(double), typeof(Compass), new UIPropertyMetadata(0.0, OnAnglePropertyChanged));
        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }
        private static void OnAnglePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Compass)d).AngleChanged((double)e.NewValue);
        }

        public static readonly DependencyProperty SmoothValueProperty = DependencyProperty.Register("SmoothValue", typeof(double), typeof(Compass), new UIPropertyMetadata(0.0));
        public double SmoothValue
        {
            get { return (double)GetValue(SmoothValueProperty); }
            set { SetValue(SmoothValueProperty, value); }
        }
#endif

        #endregion


        public Compass()
        {
            SmoothValue = -5 * Degree - 2; // 5 - смещение на дополнительные 5 град нарисованные чтобы текст "0" рисовался ок -2 - половина ширины указателя
        }

#if NOESIS
        private void AngleChanged(float value)
        {
            if (float.IsNaN(value))
                return;

            offset = (value % 360) * Degree - 5 * Degree - 2;// 5 - смещение на дополнительные 5 град нарисованныеслева от 0 чтобы текст "0" рисовался ок -2 - половина ширины указателя

            SmoothValue = offset;
        }
#else
        private void AngleChanged(double value)
        {
            if (double.IsNaN(value))
                return;

            offset = (value % 360) * Degree - 5 * Degree - 2;// 5 - смещение на дополнительные 5 град нарисованныеслева от 0 чтобы текст "0" рисовался ок -2 - половина ширины указателя

            SmoothValue = offset;
        }
#endif
    }
}
