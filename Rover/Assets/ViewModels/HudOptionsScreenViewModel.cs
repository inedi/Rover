#if UNITY_5_3_OR_NEWER
using UnityEngine;
using Noesis;
using Float = System.Single;
#else
using Float = System.Double;
using System.Windows.Media;
#endif
using System.Collections.Generic;
using RoverGUI.Mvvm;
using RoverGUI.Data.Repositories;
using RoverGUI.Data.Entities;


namespace RoverGUI.ViewModels
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

        public List<StarColor> StarColors
        {
            get { return GetValue<List<StarColor>>(); }
            set { SetValue(value); }
        }
#if UNITY_5_3_OR_NEWER
        public UnityEngine.Color StarColor
        {
            get { return GetValue<UnityEngine.Color>(); }
            set
            {
                if (SetValue(value))
                {
                    RenderSettings.skybox.SetColor("_Tint", value);
                }
            }
        }
#endif

        public SolidColorBrush StarSelectedBrush
        {
            get { return GetValue<SolidColorBrush>(); }
            set { SetValue(value); }
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
            //load sky exposures settings
            ExposureStars = 1f;
            ExposureFigures = 0f;
            ExposureGrid = 0f;

            // load sky colors settings
            StarColorRepository.Load();
            StarColors = StarColorRepository.StarColors;
        }
    }
}
