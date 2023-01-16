using BoardGamerApp.Enums;
using BoardGamerApp.Interfaces;
using BoardGamerApp.Models;

namespace BoardGamerApp.ViewModels;

public class EventRatingViewModel : BaseViewModel
{
    private string title;
    public string Title
    {
        get { return title; }
        set { SetProperty(ref title, value, nameof(Title)); }
    }

    private string hostName;
    public string HostName
    {
        get { return hostName; }
        set { SetProperty(ref hostName, value, nameof(HostName)); }
    }

    private DateTime lastEvent;

    public DateTime LastEvent
    {
        get { return lastEvent; }
        set { SetProperty(ref lastEvent, value, nameof(LastEvent)); }
    }

    public EventRatingViewModel(IRatingWebClient ratingWebClient)
    {
        Title = "Bewertung";

        HostRating = new();
        DinnerRating = new();
        EveningRating = new();

        GetRating = new(async () =>
        {
            EventRating rating = await ratingWebClient.GetRating();

            HostName = rating.HostName;
            LastEvent = rating.LastEvent;

            HostRating.Value = rating.Host;
            DinnerRating.Value = rating.Host;
            HostRating.Value = rating.Host;
        });

        SetHostRating = new(async rating =>
        {
            HostRating.Value = rating;
            await SaveValues();
        });

        SetDinnerRating = new(async rating =>
        {
            DinnerRating.Value = rating;
            await SaveValues();
        });

        SetEveningRating = new(async rating =>
        {
            EveningRating.Value = rating;
            await SaveValues();
        });

        Task SaveValues() => ratingWebClient.SaveRating(new()
        {
            HostName = HostName,
            LastEvent = LastEvent,
            Host = HostRating.Value,
            Dinner = DinnerRating.Value,
            Evening = EveningRating.Value
        });
    }

    public RatingViewModel HostRating { get; }
    public RatingViewModel DinnerRating { get; }
    public RatingViewModel EveningRating { get; }

    public Command GetRating { get; }

    public Command<Rating> SetHostRating { get; }
    public Command<Rating> SetDinnerRating { get; }
    public Command<Rating> SetEveningRating { get; }
}