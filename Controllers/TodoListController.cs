using DotNetWebAPIDefault.Data;
using DotNetWebAPIDefault.DTOs.Todo;
using DotNetWebAPIDefault.Mappers;
using DotNetWebAPIDefault.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetWebAPIDefault.Controllers
{
    public class TodoListController : BaseApiController
    {
        private readonly AppDBContext _context;

        public TodoListController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todosLists = await _context.TodoLists.ToListAsync();
            var todoListDto = todosLists.Select(s => s.ToTodoListDto());
            return Ok(todoListDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var todoList = await _context.TodoLists.FindAsync(id);
            if (todoList == null) return NotFound();

            return Ok(todoList.ToTodoListDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTodoListRequestDto todoListDto)
        {
            var todoList = todoListDto.toTodoListFromCreate();
            await _context.TodoLists.AddAsync(todoList);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = todoList.Id }, todoList.ToTodoListDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTodoListRequestDto update)
        {
            var todoList = await _context.TodoLists.FirstOrDefaultAsync(x => x.Id == id);

            if (todoList == null) return NotFound();

            todoList.Name = update.Name;
            await _context.SaveChangesAsync();
            return Ok(todoList.ToTodoListDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var todoList = await  _context.TodoLists.FirstOrDefaultAsync(x => x.Id == id);
            if (todoList == null) return NotFound();

            _context.Remove(todoList);
            await _context.SaveChangesAsync();

            return NoContent(); //Default for Delete Response oK
        }
    }
}
