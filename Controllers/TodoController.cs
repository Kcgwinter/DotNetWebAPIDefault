using DotNetWebAPIDefault.DTOs.Todo;
using DotNetWebAPIDefault.Helpers;
using DotNetWebAPIDefault.Interfaces;
using DotNetWebAPIDefault.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebAPIDefault.Controllers
{
    public class TodoController(ITodoRepository todoRepo, ITodoListRepository todolistRepo) : BaseApiController
    {
        private readonly ITodoRepository _todoRepo = todoRepo;
        private readonly ITodoListRepository _todolistRepo = todolistRepo;

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery]QueryObject query)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState); 
            
            var todos = await _todoRepo.GetAllAsync(query);
            var todoDto = todos.Select(s => s.ToTodoDto());
            return Ok(todoDto);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var todo = await _todoRepo.GetByIdAsync(id);
            if (todo == null) return NotFound();
            return Ok(todo.ToTodoDto());
        }

        [HttpPost("{todoListId:int}")]
        public async Task<IActionResult> Create([FromRoute] int todoListId, [FromBody] CreateTodoDto todoDto)
        {
            if(!await _todolistRepo.TodoListExists(todoListId)) return BadRequest("Todolist does not exists");

            var todo = todoDto.toTodoFromCreate(todoListId);
            await _todoRepo.CreateAsync(todo);
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo.ToTodoDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTodoDto update)
        {

            var existingTodo = await _todoRepo.UpdateAsync(id, update.toTodoFromUpdate());
            if (existingTodo == null) return NotFound("Todo not found");

            return Ok(existingTodo.ToTodoDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var todo = await _todoRepo.DeleteAsync(id);
            if (todo == null) return NotFound("Comment not found");
            return NoContent(); //Default for Delete Response oK
        }
    }
}
