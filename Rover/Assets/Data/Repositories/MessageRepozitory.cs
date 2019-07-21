using System.Collections.Generic;
using System.Collections.ObjectModel;
using RoverGUI.Data.Entities;

namespace RoverGUI.Data.Repositories
{
    internal static class MessageRepozitory
    {
        internal static ObservableCollection<MessageModel> Messages { get; private set; }

        internal static void Load()
        {
            Messages = new ObservableCollection<MessageModel>();

            Messages.Add(new MessageModel { Message = "Mark, this is Vincent Kapoor. We've been watching you since SOL 54. The whole world rooting for you. Amazing job, getting Pathfinder. We're working on rescule plans. Meantime we're putting together a supply mission to keep you fed until Ares 4 arrives.",
                                            IsIncoming = true });
            Messages.Add(new MessageModel { Message = "Glad to hear it. Really looking forward not dying.",
                                            IsIncoming = false });
            Messages.Add(new MessageModel { Message = "How's the crew? What did they say when they found out I was alive?",
                                            IsIncoming = false });
            Messages.Add(new MessageModel { Message = "RU receiving? Mark.",
                                            IsIncoming = false });
            Messages.Add(new MessageModel { Message = "We haven't told the crew you are alive yet. We need them to concentrate on the mission.",
                                            IsIncoming = true });

        }
    }
}
