using BoardGamerApp.ViewModels;

namespace BoardGamerApp.Views;

public partial class BoardGames : ContentPage
{
	public BoardGames(BoardGamesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

		viewModel.GetGames.Execute(this);
	}
}