using BoardGamerApp.Views;

namespace BoardGamerApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    private async void NavigateToGameBoardSuggestion(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(BoardGames));
    }

    private async void NavigateToWriteAMessage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Message));
    }

    private async void NavigateBackFromBoardSuggestion(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void NavigateBackFromMessage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void NavigateToRateEvent(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(RateEvent));
    }

    private async void NavigateToSeeAppointments(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(GameAppointments));
    }
}

