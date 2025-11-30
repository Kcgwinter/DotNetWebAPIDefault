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
        public IActionResult GetAll()
        {
            var todosLists = _context.TodoLists.ToList().Select(s => s.ToTodoListDto());
            return Ok(todosLists);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var todoList = _context.TodoLists.Find(id);
            if (todoList == null) return NotFound();

            return Ok(todoList.ToTodoListDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateTodoListRequestDto todoListDto)
        {
            var todoList = todoListDto.toTodoListFromCreate();
            _context.TodoLists.Add(todoList);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = todoList.Id }, todoList.ToTodoListDto());
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateTodoListRequestDto update)
        {
            var todoList = _context.TodoLists.FirstOrDefault(x => x.Id == id);

            if (todoList == null) return NotFound();

            todoList.Name = update.Name;
            _context.SaveChanges();
            return Ok(todoList.ToTodoListDto());
        }

    }
}
