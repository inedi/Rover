using RoverGUI.Mvvm;

namespace RoverGUI.ViewModels
{
    public sealed class TelemetryScreenViewModel : ViewModelBase
    {
        public bool IsHandBrake
        {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }

        public int Speed
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

//        public int Speed { get; set; }


        public TelemetryScreenViewModel()
        {
            IsHandBrake = false;
        }

    }
}
