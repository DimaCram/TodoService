using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApiDTO.Core.Models;

namespace TodoApiDTO.DAL.Interfaces
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoItem>> GetTodoItems();
        Task<TodoItem> GetTodoItem(long id);
        Task UpdateTodoItem(TodoItem todoItem);
        Task CreateTodoItem(TodoItem todoItem);
        Task DeleteTodoItem(long id);
    }
}
