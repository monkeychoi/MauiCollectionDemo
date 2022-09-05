using CollectionDemo.ViewModels;

namespace CollectionDemo.Views;

public partial class TodoListView : ContentPage
{
	public TodoListView(TodoListViewModel todoListViewModel)
	{
		InitializeComponent();
		BindingContext = todoListViewModel;
	}
}