using System.Collections.Generic;
using RoverGUI.Mvvm;
using RoverGUI.Data.Repositories;
using RoverGUI.Data.Entities;
using System.Collections.ObjectModel;

namespace RoverGUI.ViewModels
{
    public sealed class ChatScreenViewModel : ViewModelBase
    {
        public ObservableCollection<MessageModel> Messages
        {
            get { return GetValue<ObservableCollection<MessageModel>>(); }
            set { SetValue(value); }
        }

        public ChatScreenViewModel()
        {
            // load messages
            MessageRepozitory.Load();
            Messages = MessageRepozitory.Messages;
        }
    }
}
