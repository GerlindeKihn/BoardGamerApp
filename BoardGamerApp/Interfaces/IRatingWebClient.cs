using BoardGamerApp.Models;

namespace BoardGamerApp.Interfaces;

public interface IRatingWebClient
{
    Task<EventRating> GetRating();
    Task<EventRating> SaveRating(EventRating eventRating);
}