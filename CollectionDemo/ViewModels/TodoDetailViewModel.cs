using CollectionDemo.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionDemo.ViewModels
{
    [QueryProperty(nameof(TodoDetail), "TodoDetail")]
    public class TodoDetailViewModel : ObservableObject
    {
        private TodoModel _todoDetail;
        public TodoModel TodoDetail
        {
            get => _todoDetail;
            set => SetProperty(ref _todoDetail, value);
        }
    }
}
