using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApiDTO.BLL.Interfaces;
using TodoApiDTO.Core.Models;
using TodoApiDTO.DAL.Interfaces;

namespace TodoApiDTO.BLL.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task CreateTodoItem(TodoItem todoItem)
        {
            if (todoItem == null)
                throw new ArgumentException();

            await _todoRepository.CreateTodoItem(todoItem);
        }

        public async Task DeleteTodoItem(long id)
        {
            await _todoRepository.DeleteTodoItem(id);
        }

        public async Task<TodoItem> GetTodoItem(long id)
        {
            return await _todoRepository.GetTodoItem(id);
        }

        public Task<IEnumerable<TodoItem>> GetTodoItems()
        {
            return _todoRepository.GetTodoItems();
        }

        public async Task UpdateTodoItem(TodoItem todoItem)
        {
            if (todoItem == null)
                throw new ArgumentException();

            await _todoRepository.UpdateTodoItem(todoItem);
        }
    }
}
