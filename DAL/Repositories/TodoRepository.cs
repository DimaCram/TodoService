using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApiDTO.Core.Models;
using TodoApiDTO.DAL.Context;
using TodoApiDTO.DAL.Interfaces;

namespace TodoApiDTO.DAL.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _todoContext;

        public TodoRepository(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public async Task CreateTodoItem(TodoItem todoItem)
        {
            _todoContext.TodoItems.Add(todoItem);
            await _todoContext.SaveChangesAsync();
        }

        public async Task DeleteTodoItem(long id)
        {
            var todoItem = await _todoContext.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                throw new Exception("Todo item not found");
            }

            _todoContext.TodoItems.Remove(todoItem);
            await _todoContext.SaveChangesAsync();
        }

        public async Task<TodoItem> GetTodoItem(long id)
        {
            return await _todoContext.TodoItems.FindAsync(id);
        }

        public async Task<IEnumerable<TodoItem>> GetTodoItems()
        {
            return await _todoContext.TodoItems.ToListAsync();
        }

        public async Task UpdateTodoItem(TodoItem todoItem)
        {
            _todoContext.Entry(todoItem).State = EntityState.Modified;
            await _todoContext.SaveChangesAsync();
        }
    }
}
