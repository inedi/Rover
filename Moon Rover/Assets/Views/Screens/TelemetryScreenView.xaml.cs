#if UNITY_5_3_OR_NEWER
#define NOESIS
using Noesis;
#else
using System;
using System.Windows.Controls;
#endif

namespace Rover.Views
{
    public partial class TelemetryScreenView : UserControl
    {
        public TelemetryScreenView()
        {
            InitializeComponent();
        }

#if NOESIS
        private void InitializeComponent()
        {
            GUI.LoadComponent(this, "Assets/Views/Screens/TelemetryScreenView.xaml");

        }
#endif

    }
}
