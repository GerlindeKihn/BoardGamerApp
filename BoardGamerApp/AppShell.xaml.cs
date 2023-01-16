using BoardGamerApp.Views;

namespace BoardGamerApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(BoardGames), typeof(BoardGames));
        Routing.RegisterRoute(nameof(Views.Messages), typeof(Views.Messages));
    }
}
