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

#if UNITY_5_3_OR_NEWER

        private UnityEngine.Color starColor;
        private UnityEngine.Color figureColor;
        private UnityEngine.Color gridColor;

#endif

        public List<StarColor> StarColors
        {
            get { return GetValue<List<StarColor>>(); }
            set { SetValue(value); }
        }

        public List<StarColor> FigureColors
        {
            get { return GetValue<List<StarColor>>(); }
            set { SetValue(value); }
        }

        public List<StarColor> GridColors
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

        public UnityEngine.Color FigureColor
        {
            get { return GetValue<UnityEngine.Color>(); }
            set
            {
                if (SetValue(value))
                {
                    RenderSettings.skybox.SetColor("_Tint2", value);
                }
            }
        }

        public UnityEngine.Color GridColor
        {
            get { return GetValue<UnityEngine.Color>(); }
            set
            {
                if (SetValue(value))
                {
                    RenderSettings.skybox.SetColor("_Tint3", value);
                }
            }
        }
#endif

        public SolidColorBrush StarBrush
        {
            get { return GetValue<SolidColorBrush>(); }
            set
            {
                if (SetValue(value))
                {
#if UNITY_5_3_OR_NEWER
                    starColor = new Color32(value.Color.R, value.Color.G, value.Color.B, 255);
                    StarColor = starColor;
#endif
                }

            }
        }

        public SolidColorBrush FigureBrush
        {
            get { return GetValue<SolidColorBrush>(); }
            set
            {
                if (SetValue(value))
                {
#if UNITY_5_3_OR_NEWER
                    figureColor = new Color32(value.Color.R, value.Color.G, value.Color.B, 255);
                    FigureColor = figureColor;
#endif
                }

            }
        }

        public SolidColorBrush GridBrush
        {
            get { return GetValue<SolidColorBrush>(); }
            set
            {
                if (SetValue(value))
                {
#if UNITY_5_3_OR_NEWER
                    gridColor = new Color32(value.Color.R, value.Color.G, value.Color.B, 255);
                    GridColor = gridColor;
#endif
                }

            }
        }

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
            //load sky exposures settings
            ExposureStars = 1f;
            ExposureFigures = 0f;
            ExposureGrid = 0f;

            // load sky colors settings
            StarColorRepository.Load();
            StarColors = StarColorRepository.StarColors;
            FigureColors = StarColorRepository.StarColors;
            GridColors = StarColorRepository.StarColors;


        }
    }
}
