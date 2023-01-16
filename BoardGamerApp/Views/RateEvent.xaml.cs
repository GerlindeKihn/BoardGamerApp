using BoardGamerApp.ViewModels;

namespace BoardGamerApp.Views;

public partial class RateEvent : ContentPage
{
	public RateEvent(EventRatingViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;

        viewModel.GetRating.Execute(this);
    }
}