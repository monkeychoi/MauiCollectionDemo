using CollectionDemo.Services;
using CollectionDemo.Services.Contract;
using CollectionDemo.ViewModels;
using CollectionDemo.Views;

namespace CollectionDemo;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});		

		// Service
		builder.Services.AddSingleton<ITodoService, TodoService>();

		// Views
		builder.Services.AddSingleton<TodoListView>();
        builder.Services.AddTransient<TodoDetailView>();

        // View Model
        builder.Services.AddSingleton<TodoListViewModel>();
        builder.Services.AddTransient<TodoDetailViewModel>();

        return builder.Build();
	}
}
