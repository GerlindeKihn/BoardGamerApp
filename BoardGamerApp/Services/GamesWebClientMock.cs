using BoardGamerApp.Interfaces;
using BoardGamerApp.Models;

namespace BoardGamerApp.Services;

public class GamesWebClientMock : IGamesWebClient
{
    private static readonly List<Game> Games = new()
    {
        new() {Title = "Monopoly", Image = "monopoly.jpg", Votes = 2, IsVoted = true },
        new() {Title = "Siedler von Catan", Image = "catan.jpg", Votes = 3, IsVoted = false },
        new() {Title = "Risiko", Image = "risiko.jpg", Votes = 1, IsVoted = false },
    };

    public Task<List<Game>> GetGames()
    {
        return Task.FromResult(Games);
    }

    public Task<Game> SaveGame(string title, bool isVoted)
    {
        Game game = Games.SingleOrDefault(game => game.Title == title); 
        
        if(game == null)
        {
            game = new()
            {
                Title = title,
                Image = "gamerandompicture.jpg",
                Votes = 0,
                IsVoted = false
            };
            Games.Add(game);
        };

        if (isVoted && !game.IsVoted) game.Votes++;
        if (!isVoted && game.IsVoted) game.Votes--;
        
        game.IsVoted = isVoted;

        return Task.FromResult(game);
    }
}
