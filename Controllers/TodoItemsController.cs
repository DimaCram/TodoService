using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Models;
using TodoApiDTO.BLL.Interfaces;
using TodoApiDTO.Core.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITodoService _todoService;

        public TodoItemsController(IMapper mapper, ITodoService todoService)
        {
            _mapper = mapper;
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
        {
            var todoItems = _mapper.Map<IEnumerable<TodoItemDTO>>(await _todoService.GetTodoItems());
            return Ok(todoItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long id)
        {
            var todoItem = _mapper.Map<TodoItemDTO>(await _todoService.GetTodoItem(id));

            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(long id, TodoItemDTO todoItemDTO)
        {
            var todoItem = await _todoService.GetTodoItem(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            todoItem.Name = todoItemDTO.Name;
            todoItem.IsComplete = todoItemDTO.IsComplete;

            await _todoService.UpdateTodoItem(todoItem);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemDTO>> CreateTodoItem(TodoItemDTO todoItemDTO)
        {
            var todoItem = _mapper.Map<TodoItem>(todoItemDTO);
            await _todoService.CreateTodoItem(todoItem);

            return CreatedAtAction(
                nameof(GetTodoItem),
                new { id = todoItem.Id },
                todoItemDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            await _todoService.DeleteTodoItem(id);

            return NoContent();
        }
    }
}
