using BoardGamerApp.Models;

namespace BoardGamerApp.Interfaces;

public interface IGamesWebClient
{
    Task<List<Game>> GetGames();
    Task<Game> SaveGame(string title, bool isVoted);
}
