using CollectionDemo.Models;
using CollectionDemo.Services.Contract;
using System.Text.Json;

namespace CollectionDemo.Services
{
    public class TodoService : ServiceBase, ITodoService
    {
        
        public TodoService()
        {
            
        }

        public async Task<List<TodoModel>> GetTodoList()
        {
            var todoList = new List<TodoModel>();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    todoList = JsonSerializer.Deserialize<List<TodoModel>>(content, _serializerOptions);
                }
            }

            return todoList;
        }
    }
}
