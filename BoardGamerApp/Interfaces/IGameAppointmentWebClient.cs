using BoardGamerApp.Models;

namespace BoardGamerApp.Interfaces;

public interface IGameAppointmentWebClient
{
    Task<GameAppointment> GetNextAppointment();
    Task<List<GameAppointment>> GetGameAppointments();
}