using BoardGamerApp.Enums;

namespace BoardGamerApp.Models;

public class EventRating
{
    public string HostName { get; set; }
    public DateTime LastEvent { get; set; }

    public Rating? Host { get; set; }
    public Rating? Dinner { get; set; }
    public Rating? Evening { get; set; }
}