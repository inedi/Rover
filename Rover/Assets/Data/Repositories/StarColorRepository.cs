#if UNITY_5_3_OR_NEWER
#define NOESIS
using Noesis;
#else
using System.Windows.Media;
#endif
using System.Collections.Generic;
using RoverGUI.Data.Entities;

namespace RoverGUI.Data.Repositories
{
    internal static class StarColorRepository
    {
        private static List<StarColor> _starColors;

        internal static List<StarColor> StarColors
        {
            get { return _starColors; }
        }

        internal static void Load()
        {
            _starColors = new List<StarColor>();

            // SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            _starColors.Add(new StarColor { Name = "Default", Color = new SolidColorBrush(Color.FromRgb(128, 128, 128)) });
            _starColors.Add(new StarColor { Name = "Red", Color = new SolidColorBrush(Colors.Red) });
            _starColors.Add(new StarColor { Name = "Green", Color = new SolidColorBrush(Colors.Green) });

           
        }
    }
}
