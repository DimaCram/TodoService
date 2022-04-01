using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoApiDTO.Core.Models;

namespace TodoApiDTO.BLL.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetTodoItems();
        Task<TodoItem> GetTodoItem(long id);
        Task UpdateTodoItem(TodoItem todoItem);
        Task CreateTodoItem(TodoItem todoItem);
        Task DeleteTodoItem(long id);
    }
}
