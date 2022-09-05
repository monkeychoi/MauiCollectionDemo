using CollectionDemo.Views;

namespace CollectionDemo;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("tododetail", typeof(TodoDetailView));
    }
}
