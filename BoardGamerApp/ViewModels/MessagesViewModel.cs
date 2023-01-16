using BoardGamerApp.Interfaces;
using BoardGamerApp.Models;
using System.Collections.ObjectModel;

namespace BoardGamerApp.ViewModels
{
    public class MessagesViewModel : BaseViewModel
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value, nameof(Title)); }
        }

        private string newMessage;
        public string NewMessage
        {
            get { return newMessage; }
            set { SetProperty(ref newMessage, value, nameof(NewMessage)); }
        }

        public MessagesViewModel(IMessagesWebClient messagesWebClient)
        {
            Title = "Nachrichten";
            Messages = new();

            GetMessages = new(async() =>
            {
                List<Message> messages = await messagesWebClient.GetMessages();
                foreach (MessageViewModel message in messages.Select(message => new MessageViewModel(message))) Messages.Add(message);
            });

            SendMessage = new(async () =>
            {
                if (string.IsNullOrEmpty(newMessage)) return;
                Message message = await messagesWebClient.CreateMessage(newMessage);

                Messages.Add(new(message));
                NewMessage = string.Empty;
            });
        }

        public ObservableCollection<MessageViewModel> Messages { get; }

        public Command GetMessages { get; }
        public Command SendMessage { get; }
    }
}
