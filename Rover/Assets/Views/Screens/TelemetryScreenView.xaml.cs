#if UNITY_5_3_OR_NEWER
#define NOESIS
using Noesis;
#else
using System;
using System.Windows.Controls;
#endif
using RoverGUI.ViewModels;

namespace RoverGUI.Views
{
    
    public partial class TelemetryScreenView : UserControl
    {
        TelemetryScreenViewModel _context = new TelemetryScreenViewModel();
        public TelemetryScreenView()
        {
            DataContext = _context;
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
