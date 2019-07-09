#if UNITY_5_3_OR_NEWER
#define NOESIS
using Noesis;
#else
using System.Windows.Media;
#endif

namespace RoverGUI.Data.Entities
{
    public class StarColor
    {
        public string Name { get; set; }

        public SolidColorBrush Color { get; set; }
    }
}
