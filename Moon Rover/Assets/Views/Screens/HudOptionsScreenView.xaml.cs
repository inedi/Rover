#if UNITY_5_3_OR_NEWER
#define NOESIS
using Noesis;
using UnityEngine;
#else
using System;
using System.Windows.Controls;
#endif
using Rover.ViewModels;

namespace Rover.Views
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

            _context.ExposureStars = RenderSettings.skybox.GetFloat("_Exposure"); 
            _context.ExposureFigures = RenderSettings.skybox.GetFloat("_Exposure2"); 
            _context.ExposureGrid = RenderSettings.skybox.GetFloat("_Exposure3"); 
        }
#endif
    }
}
