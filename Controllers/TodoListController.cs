using DotNetWebAPIDefault.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var todosLists = _context.TodoLists.ToList();
            return Ok(todosLists);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var todoList = _context.TodoLists.Find(id);
            if (todoList == null) return NotFound();

            return Ok(todoList);
        }
    }
}
