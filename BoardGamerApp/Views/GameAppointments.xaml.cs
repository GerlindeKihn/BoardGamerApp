using BoardGamerApp.ViewModels;

namespace BoardGamerApp.Views;

public partial class GameAppointments : ContentPage
{
	public GameAppointments(GameAppointmentsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;

        viewModel.GetGameAppointments.Execute(this);
    }
}