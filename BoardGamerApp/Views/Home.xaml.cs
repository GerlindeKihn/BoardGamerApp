using BoardGamerApp.ViewModels;

namespace BoardGamerApp.Views;

public partial class Home : ContentPage
{
    public Home(HomeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

        viewModel.GetNextEvent.Execute(this);
    }
}