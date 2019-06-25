using Rover.Mvvm;

namespace Rover.ViewModels
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
           // Speed = 13.2d;
        }

    }
}
