using BoardGamerApp.Interfaces;
using BoardGamerApp.Models;

namespace BoardGamerApp.Services;

public class RatingWebClientMock : IRatingWebClient
{
    private static EventRating EventRating = new()
    {
        HostName = "Gusti",
        LastEvent = DateTime.Now.AddDays(-7)
    };

    public Task<EventRating> GetRating()
    {
        return Task.FromResult(EventRating);
    }

    public Task<EventRating> SaveRating(EventRating eventRating)
    {
        EventRating.Host = eventRating.Host;
        EventRating.Dinner = eventRating.Dinner;
        EventRating.Evening = eventRating.Evening;

        return GetRating();
    }
}