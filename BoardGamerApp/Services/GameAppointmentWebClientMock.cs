using BoardGamerApp.Interfaces;
using BoardGamerApp.Models;

namespace BoardGamerApp.Services;

public class GameAppointmentWebClientMock : IGameAppointmentWebClient
{
    private static readonly List<GameAppointment> GameAppointments = new()
    {
        new() {Name = "Anton", Street = "Spielstraße 321", Place = "91827 Brettspielhausen", NextEvent = DateTime.Now},
        new() {Name = "Du", Street = "Monopolyweg 5", Place = "91827 Brettspielhausen", NextEvent = DateTime.Now.AddDays(7)},
        new() {Name = "Lizzy", Street = "Spielfeld 9", Place = "91826 Brettspieldörfle", NextEvent = DateTime.Now.AddDays(14)},
        new() {Name = "Gusti", Street = "Spaßplatz 1", Place = "91825 Brettspielstadt", NextEvent = DateTime.Now.AddDays(21)},
        new() {Name = "Anton", Street = "Spielstraße 321", Place = "91827 Brettspielhausen", NextEvent = DateTime.Now.AddDays(28)},
        new() {Name = "Du", Street = "Monopolyweg 5", Place = "91827 Brettspielhausen", NextEvent = DateTime.Now.AddDays(35)},
        new() {Name = "Lizzy", Street = "Spielfeld 9", Place = "91826 Brettspieldörfle", NextEvent = DateTime.Now.AddDays(42)},
        new() {Name = "Gusti", Street = "Spaßplatz 1", Place = "91825 Brettspielstadt", NextEvent = DateTime.Now.AddDays(49)},
    };

    public Task<GameAppointment> GetNextAppointment()
    {
        GameAppointment gameAppointment = GameAppointments.MinBy(gameAppointment => gameAppointment.NextEvent);
        return Task.FromResult(gameAppointment);
    }

    public Task<List<GameAppointment>> GetGameAppointments()
    {
        return Task.FromResult(GameAppointments);
    }
}