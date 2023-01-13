using BoardGamerApp.Interfaces;
using BoardGamerApp.Models;

namespace BoardGamerApp.Services;

internal class MessagesWebClientMock : IMessagesWebClient
{
    private static readonly List<Message> Messages = new()
    {
        new() {Text = "Die Pizzen sind für heute Abend schon bestellt!", Sender = "Gusti", TimeStamp = DateTime.Now.AddMinutes(-90)},
        new() {Text = "Wunderbar! Bin schon gespannt, wie die vom neuen Lokal sind :)", Sender = "Du", TimeStamp = DateTime.Now.AddMinutes(-83)},
        new() {Text = "Ich bring noch Knabberzeugs mit.", Sender = "Rudi", TimeStamp = DateTime.Now.AddMinutes(-73)},
        new() {Text = "Freu mich auf den Spieleabend! Bis nachher :-)", Sender = "Lizzy", TimeStamp = DateTime.Now.AddMinutes(-68)},
    };

    public Task<Message> CreateMessage(string text)
    {
        Message message = new() { Text = text, Sender = "Du", TimeStamp = DateTime.Now };
        Messages.Add(message);

        return Task.FromResult(message);
    }

    public Task<List<Message>> GetMessages()
    {
        return Task.FromResult(Messages);
    }
}
