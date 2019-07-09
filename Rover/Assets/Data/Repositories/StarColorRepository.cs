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
        internal static List<StarColor> StarColors { get; private set; }

        internal static void Load()
        {
            StarColors = new List<StarColor>();

            // SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            StarColors.Add(new StarColor { Name = "Default", Color = new SolidColorBrush(Colors.White) });
            StarColors.Add(new StarColor { Name = "Red", Color = new SolidColorBrush(Colors.Red) });
            StarColors.Add(new StarColor { Name = "Green", Color = new SolidColorBrush(Colors.Green) });
            StarColors.Add(new StarColor { Name = "Blue", Color = new SolidColorBrush(Colors.Blue) });

        }
    }
}
