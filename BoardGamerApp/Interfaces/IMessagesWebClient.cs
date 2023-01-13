using BoardGamerApp.Models;

namespace BoardGamerApp.Interfaces;

public interface IMessagesWebClient
{
    Task<List<Message>> GetMessages();
    Task<Message> CreateMessage(string text);
}
