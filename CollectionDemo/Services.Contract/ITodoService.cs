using CollectionDemo.Models;

namespace CollectionDemo.Services.Contract
{
    public interface ITodoService
    {
        Task<List<TodoModel>> GetTodoList();
    }
}
