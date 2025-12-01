using DotNetWebAPIDefault.DTOs.Todo;
using DotNetWebAPIDefault.Interfaces;
using DotNetWebAPIDefault.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebAPIDefault.Controllers
{
    public class TodoController(ITodoRepository todoRepo, Data.AppDBContext context) : BaseApiController
    {

        private readonly Data.AppDBContext _context = context;
        private readonly ITodoRepository _todoRepo = todoRepo;

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var todos = await _todoRepo.GetAllAsync();
            var todoDto = todos.Select(s => s.ToTodoDto());
            return Ok(todoDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var todo = await _todoRepo.GetByIdAsync(id);
            if (todo == null) return NotFound();
            return Ok(todo.ToTodoDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTodoRequestDto todoDto)
        {
            var todo = todoDto.toTodoFromCreate();
            await _context.Todos.AddAsync(todo);
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo.ToTodoDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTodoRequestDto update)
        {
            var existingTodo = await _todoRepo.UpdateAsync(id, update);
            if (existingTodo == null) return NotFound();

            return Ok(existingTodo.ToTodoDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var todo = await _todoRepo.DeleteAsync(id);
            if (todo == null) return NotFound();
            return NoContent(); //Default for Delete Response oK
        }
    }
}
