using CollectionDemo.Models;
using CollectionDemo.Services.Contract;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace CollectionDemo.ViewModels
{
    public class TodoListViewModel : ObservableObject
    {
        #region Properites
        public ObservableCollection<TodoModel> TodoList { get; set; } = new ObservableCollection<TodoModel>();        

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        #endregion

        private readonly ITodoService _todoService;

        #region Commands

        private RelayCommand _refreshCommand;
        public RelayCommand RefreshCommand => _refreshCommand ??= new RelayCommand(() =>
        {
            IsRefreshing = false;
            GetTodoList();
        });

        private RelayCommand<TodoModel> _selectedItemCommand;
        public RelayCommand<TodoModel> SelectedItemCommand => _selectedItemCommand ??= new RelayCommand<TodoModel>(async (todoDetail) =>
        {
            //await App.Current.MainPage.DisplayAlert("선택된 학생", "선택된 학생 이름은 " + studentDetail.Name, "OK");

            var navParam = new Dictionary<string, object>
            {
                { "TodoDetail",  todoDetail }
            };

            await Shell.Current.GoToAsync("tododetail", navParam);
        });

        #endregion

        public TodoListViewModel(ITodoService todoService)
        {
            _todoService = todoService;
            GetTodoList();
        }

        private void GetTodoList()
        {
            IsBusy = true;

            //var todoList = await _todoService.GetTodoList();
            //TodoList.Clear();
            //foreach (var todo in todoList)
            //{
            //    TodoList.Add(todo);
            //}
            //IsBusy = false;

            Task.Run(async () =>
            {
                var todoList = await _todoService.GetTodoList();

                Application.Current.Dispatcher.Dispatch(() =>
                {
                    TodoList.Clear();
                    foreach (var todo in todoList)
                    {
                        TodoList.Add(todo);
                    }
                    IsBusy = false;
                });
            });
        }
    }
}
