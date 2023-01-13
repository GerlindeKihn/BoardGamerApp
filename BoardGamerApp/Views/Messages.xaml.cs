using BoardGamerApp.ViewModels;

namespace BoardGamerApp.Views;

public partial class Messages : ContentPage
{
	public Messages(MessagesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

		viewModel.GetMessages.Execute(this);
	}
}