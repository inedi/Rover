#if UNITY_5_3_OR_NEWER
#define NOESIS
using Noesis;
using UnityEngine;
#else
using System;
using System.Windows.Controls;
#endif
using RoverGUI.ViewModels;

namespace RoverGUI.Views
{
    public partial class HudOptionsScreenView : UserControl
    {
        HudOptionsScreenViewModel _context = new HudOptionsScreenViewModel();
        public HudOptionsScreenView()
        {
            DataContext = _context;
            InitializeComponent();
        }

#if NOESIS
        private void InitializeComponent()
        {
            Noesis.GUI.LoadComponent(this, "Assets/Views/Screens/HudOptionsScreenView.xaml");
            
        }
#endif
    }
}
