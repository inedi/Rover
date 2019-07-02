#if UNITY_5_3_OR_NEWER
using UnityEngine;
using Float = System.Single;
#else
using Float = System.Double;
#endif
using Rover.Mvvm;

namespace Rover.ViewModels
{
    public sealed class HudOptionsScreenViewModel : ViewModelBase
    {
        public float ExposureStars
        {
            get { return GetValue<float>(); }
            set
            {
                if (SetValue(value))
                {
#if UNITY_5_3_OR_NEWER
                    RenderSettings.skybox.SetFloat("_Exposure", value);
#endif
                }
            }
        }

        public float ExposureFigures
        {
            get { return GetValue<float>(); }
            set
            {
                if (SetValue(value))
                {
#if UNITY_5_3_OR_NEWER
                    RenderSettings.skybox.SetFloat("_Exposure2", value);
#endif
                }
            }
        }

        public float ExposureGrid
        {
            get { return GetValue<float>(); }
            set
            {
                if (SetValue(value))
                {
#if UNITY_5_3_OR_NEWER
                    RenderSettings.skybox.SetFloat("_Exposure3", value);
#endif
                }
            }
        }

        public HudOptionsScreenViewModel()
        {
           // ExposureFigures = 2.2;
        }
    }
}
