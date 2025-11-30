using DotNetWebAPIDefault.Data;
using DotNetWebAPIDefault.Mappers;
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
    }
}
