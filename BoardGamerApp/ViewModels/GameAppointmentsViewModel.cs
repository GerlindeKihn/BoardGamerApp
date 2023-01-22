using BoardGamerApp.Interfaces;
using BoardGamerApp.Models;
using System.Collections.ObjectModel;

namespace BoardGamerApp.ViewModels;

public class GameAppointmentsViewModel : BaseViewModel
{
    private string title;
    public string Title
    {
        get { return title; }
        set { SetProperty(ref title, value, nameof(Title)); }
    }

    public GameAppointmentsViewModel(IGameAppointmentWebClient webClient)
    {
        Title = "Spieltermine";
        GameAppointments = new();

        GetGameAppointments = new(async () =>
        {
            List<GameAppointment> gameAppointments = await webClient.GetGameAppointments();
            gameAppointments.ForEach(GameAppointments.Add);
        });
    }

    public ObservableCollection<GameAppointment> GameAppointments { get; }

    public Command GetGameAppointments { get; }
}
