#if UNITY_5_3_OR_NEWER
#define NOESIS
using Noesis;
using Float = System.Single;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Float = System.Double;
#endif
using System.ComponentModel;
using System;


namespace RoverGUI.Controls
{
    //панель из 2010-го, просто тест Custom-панелей в Noesis
    public class RadialPanel : Panel
    {
        public enum AlignmentOptions { Left, Center, Right };

        public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register("Radius", typeof(double), typeof(RadialPanel), new PropertyMetadata(RadialPanel.RadiusChanged));
        public static readonly DependencyProperty AngleItemProperty = DependencyProperty.Register("AngleItem", typeof(double), typeof(RadialPanel), new PropertyMetadata(RadialPanel.AngleItemChanged));
        public static readonly DependencyProperty StartAngleProperty = DependencyProperty.Register("StartAngle", typeof(double), typeof(RadialPanel), new PropertyMetadata(RadialPanel.StartAngleChanged));
        public static readonly DependencyProperty AlignmentProperty = DependencyProperty.Register("Alignment", typeof(AlignmentOptions), typeof(RadialPanel), new PropertyMetadata(RadialPanel.AlignmentChanged));


        [Category("Radial Panel")]
        public double Radius
        {
            get { return (double)this.GetValue(RadialPanel.RadiusProperty); }
            set { this.SetValue(RadialPanel.RadiusProperty, value); }
        }

        [Category("Radial Panel")]
        public double AngleItem
        {
            get { return (double)this.GetValue(RadialPanel.AngleItemProperty); }
            set { this.SetValue(RadialPanel.AngleItemProperty, value); }
        }

        [Category("Radial Panel")]
        public double StartAngle
        {
            get { return (double)this.GetValue(RadialPanel.StartAngleProperty); }
            set { this.SetValue(RadialPanel.StartAngleProperty, value); }
        }

        [Category("Radial Panel")]
        public AlignmentOptions Alignment
        {
            get { return (AlignmentOptions)this.GetValue(RadialPanel.AlignmentProperty); }
            set { this.SetValue(RadialPanel.AlignmentProperty, value); }
        }

        private static void RadiusChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { ((RadialPanel)sender).Refresh(); }
        private static void AngleItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { ((RadialPanel)sender).Refresh(); }
        private static void StartAngleChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { ((RadialPanel)sender).Refresh(); }
        private static void AlignmentChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { ((RadialPanel)sender).Refresh(); }


        protected override Size MeasureOverride(Size availableSize)
        {
            Size resultSize = new Size(0, 0);

            foreach (UIElement child in this.Children)
            {
                child.Measure(availableSize);
                resultSize.Width = Math.Max(resultSize.Width, child.DesiredSize.Width);
                resultSize.Height = Math.Max(resultSize.Height, child.DesiredSize.Height);
            }

            resultSize.Width =
                double.IsPositiveInfinity(availableSize.Width) ?
                resultSize.Width : availableSize.Width;

            resultSize.Height =
                double.IsPositiveInfinity(availableSize.Height) ?
                resultSize.Height : availableSize.Height;

            return resultSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            this.Refresh();
            return base.ArrangeOverride(finalSize);
        }

        private void Refresh()
        {
            int count = 0;
            if (double.IsNaN(this.Width))
            {
                this.Width = 200;
            }
            if (double.IsNaN(this.Height))
            {
                this.Height = 200;
            }

            foreach (FrameworkElement element in this.Children)
            {
                RotateTransform r = new RotateTransform();
                double alignX = 0;
                double alignY = 0;
                switch (this.Alignment)
                {
                    case AlignmentOptions.Left:
                        alignX = 0;
                        alignY = 0;
                        break;
                    case AlignmentOptions.Center:
                        alignX = element.DesiredSize.Width / 2;
                        alignY = element.DesiredSize.Height / 2;
                        break;
                    case AlignmentOptions.Right:
                        alignX = element.DesiredSize.Width;
                        alignY = element.DesiredSize.Height;
                        break;
                }
                r.CenterX = (float)alignX;
                r.CenterY = (float)alignY;
                r.Angle = ((float)AngleItem * count++) - (float)StartAngle;
                element.RenderTransform = r;
                double x = this.Radius * Math.Cos(Math.PI * r.Angle / 180);
                double y = this.Radius * Math.Sin(Math.PI * r.Angle / 180);

                if (!(double.IsNaN(this.Width)) && !(double.IsNaN(this.Height)) && !(double.IsNaN(alignX)) && !(double.IsNaN(alignY)) && !(double.IsNaN(element.DesiredSize.Width)) && !(double.IsNaN(element.DesiredSize.Height)))
                {
                    element.Arrange(new Rect((float)x + (float)Width / 2 - (float)alignX, (float)y + (float)Height / 2 - (float)alignY, element.DesiredSize.Width, element.DesiredSize.Height));
                }
            }
        }
    }
}