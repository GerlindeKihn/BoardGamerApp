using BoardGamerApp.Interfaces;
using BoardGamerApp.Models;
using System.Collections.ObjectModel;

namespace BoardGamerApp.ViewModels;

public class BoardGamesViewModel : BaseViewModel
{
    private string title;
    public string Title
    {
        get { return title; }
        set { SetProperty(ref title, value, nameof(Title)); }
    }

    private string newGame;
    public string NewGame
    {
        get { return newGame; }
        set { SetProperty(ref newGame, value, nameof(NewGame)); }
    }

    public BoardGamesViewModel(IGamesWebClient webClient)
    {
        Title = "Spiele";
        Games = new();

        GetGames = new(async() =>
        {
            List<Game> games = await webClient.GetGames();
            foreach (var game in games.Select(game => new BoardGameViewModel(game))) Games.Add(game);
        });

        AddGame = new(async () =>
        {
            if(string.IsNullOrEmpty(newGame)) return;
            if(Games.Any(game => game.Title == newGame)) return;

            Game game = await webClient.SaveGame(newGame, isVoted: true);
            Games.Add(new(game));
            NewGame = string.Empty;
        });

        VoteGame = new(async game =>
        {
            Game result = await webClient.SaveGame(game.Title, isVoted: !game.IsVoted);

            game.IsVoted = result.IsVoted;
            game.Votes = result.Votes;
        });
    }

    public ObservableCollection<BoardGameViewModel> Games { get; }

    public Command GetGames { get; }
    public Command AddGame { get; }
    public Command<BoardGameViewModel> VoteGame { get; }
}
