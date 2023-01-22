using System.Globalization;

namespace BoardGamerApp;

public partial class App : Application
{
	public App()
	{
		CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("de-DE");
		InitializeComponent();

		MainPage = new AppShell();
	}
}
