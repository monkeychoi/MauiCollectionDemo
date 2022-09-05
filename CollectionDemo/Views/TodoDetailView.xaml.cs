using CollectionDemo.ViewModels;

namespace CollectionDemo.Views;

public partial class TodoDetailView : ContentPage
{
	public TodoDetailView(TodoDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}