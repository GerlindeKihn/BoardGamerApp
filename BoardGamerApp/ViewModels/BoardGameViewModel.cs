using BoardGamerApp.Models;

namespace BoardGamerApp.ViewModels;

public class BoardGameViewModel : BaseViewModel
{
    public BoardGameViewModel(Game game)
    {
        Title = game.Title;
        Image = game.Image;
        Votes = game.Votes;
        IsVoted = game.IsVoted;
    }

    public string Image { get; }

    private int votes;
    public int Votes {
        get { return votes; }
        set { SetProperty(ref votes, value, nameof(Votes)); }
    }
    
    private bool isVoted;
    public bool IsVoted {
        get { return isVoted; }
        set {
            SetProperty(ref isVoted, value, nameof(IsVoted));
            ButtonColor = GetColor(isVoted ? "Primary" : "Gray100");
        }
    }

    private Color buttonColor;
    public Color ButtonColor {
        get { return buttonColor; }
        set { SetProperty(ref buttonColor, value, nameof(ButtonColor)); }
    }

    private static Color GetColor(string color) =>
        Application.Current.Resources.TryGetValue(color, out var result) ? (Color)result : default;
}
