using BoardGamerApp.Interfaces;
using BoardGamerApp.Services;
using BoardGamerApp.ViewModels;
using BoardGamerApp.Views;
using Microsoft.Extensions.Logging;

namespace BoardGamerApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
        builder.Services.AddTransient<BoardGames>();
        builder.Services.AddTransient<BoardGamesViewModel>();
        builder.Services.AddSingleton<IGamesWebClient, GamesWebClientMock>();

        builder.Services.AddTransient<Views.Messages>();
        builder.Services.AddTransient<MessagesViewModel>();
        builder.Services.AddSingleton<IMessagesWebClient, MessagesWebClientMock>();

		builder.Services.AddTransient<RateEvent>();
		builder.Services.AddTransient<EventRatingViewModel>();
		builder.Services.AddSingleton<IRatingWebClient, RatingWebClientMock>();

        builder.Services.AddTransient<GameAppointments>();
        builder.Services.AddTransient<GameAppointmentsViewModel>();
        builder.Services.AddSingleton<IGameAppointmentWebClient, GameAppointmentWebClientMock>();

        return builder.Build();
	}
}
