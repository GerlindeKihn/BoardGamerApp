namespace BoardGamerApp.Models;

public class Game
{
    public string Title { get; set; }
    public string Image { get; set; }
    public int Votes { get; set; }
    public bool IsVoted { get; set; }
}
