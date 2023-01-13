using BoardGamerApp.Models;

namespace BoardGamerApp.ViewModels;

public class MessageViewModel : BaseViewModel
{
    public MessageViewModel(Message message)
    {
        Text = message.Text;
        TimeStamp = message.TimeStamp;
        Sender = message.Sender;
    }

    public string Text { get; }
    public DateTime TimeStamp { get; }
    public string Sender { get; }

    public int Position 
    {
        get { return Sender == "Du" ? 1 : 0; } }

    public CornerRadius Radius 
    {
        get { return Sender == "Du" ? new(20, 20, 20, 0) : new(0, 20, 20, 20); }
    }
}
