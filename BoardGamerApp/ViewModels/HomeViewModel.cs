using BoardGamerApp.Interfaces;
using BoardGamerApp.Models;

namespace BoardGamerApp.ViewModels;

public class HomeViewModel : BaseViewModel
{
    private string title;
    public string Title
    {
        get { return title; }
        set { SetProperty(ref title, value, nameof(Title)); }
    }

    private string name;
    public string Name
    {
        get { return name; }
        set { SetProperty(ref name, value, nameof(Name)); }
    }

    private string street;
    public string Street
    {
        get { return street; }
        set { SetProperty(ref street, value, nameof(Street)); }
    }

    private string place;
    public string Place
    {
        get { return place; }
        set { SetProperty(ref place, value, nameof(Place)); }
    }

    private DateTime nextEvent;
    public DateTime NextEvent
    {
        get { return nextEvent; }
        set { SetProperty(ref nextEvent, value, nameof(NextEvent)); }
    }

    public HomeViewModel(IGameAppointmentWebClient webClient) 
    {
        Title = "Home";
        GetNextEvent = new(async () =>
        {
            GameAppointment nextGameAppointment = await webClient.GetNextAppointment();

            Name = nextGameAppointment.Name;
            Street = nextGameAppointment.Street;
            Place = nextGameAppointment.Place;
            NextEvent = nextGameAppointment.NextEvent;
        });
    }

    public Command GetNextEvent { get; }
}