using DotNetWebAPIDefault.Data;
using DotNetWebAPIDefault.DTOs.Todo;
using DotNetWebAPIDefault.Interfaces;
using DotNetWebAPIDefault.Mappers;
using DotNetWebAPIDefault.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetWebAPIDefault.Controllers
{
    public class TodoListController(ITodoListRepository todoListRepo, AppDBContext context) : BaseApiController
    {
        private readonly AppDBContext _context = context;
        private readonly ITodoListRepository _todoListRepo = todoListRepo;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todosLists = await _todoListRepo.GetAllAsync();
            var todoListDto = todosLists.Select(s => s.ToTodoListDto());
            return Ok(todoListDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var todoList = await _todoListRepo.GetByIdAsync(id);
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

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTodoListRequestDto update)
        {
            var existingTodoList = await _todoListRepo.UpdateAsync(id, update);
            await _context.SaveChangesAsync();
            if (existingTodoList == null) return NotFound();

            return Ok(existingTodoList.ToTodoListDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var todoList = await _todoListRepo.DeleteAsync(id);
            await _context.SaveChangesAsync();
            if (todoList == null) return NotFound();
            return NoContent(); //Default for Delete Response oK
        }
    }
}
