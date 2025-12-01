using DotNetWebAPIDefault.Data;
using DotNetWebAPIDefault.Extensions;
using DotNetWebAPIDefault.Interfaces;
using DotNetWebAPIDefault.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace DotNetWebAPIDefault.Controllers
{
    public class UserTodoListsController(
        UserManager<AppUser> userManager,
         ITodoListRepository todoListRepository,
          IUserTodoListRepository userTodoListRepository) : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly ITodoListRepository _todoListRepository = todoListRepository;
        private readonly IUserTodoListRepository _userTodoListRepository = userTodoListRepository;


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserTodoLists()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var userTodoLists = await _userTodoListRepository.GetTodoLists(appUser);

            return Ok(userTodoLists);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddTodoList(string todoListName)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var todoList = await _todoListRepository.GetByNameAsync(todoListName);

            if (todoList == null) return NotFound("Todo list not found");

            var userTodoList = await _userTodoListRepository.GetTodoLists(appUser);

            if (userTodoList.Any(e => e.Name.ToLower() == todoListName.ToLower())) return BadRequest("Cannot add same todolist to user");

            var newUserTodoList = new UserTodoList
            {
                TodoListId = todoList.Id,
                AppUserId = appUser.Id
            };

            await _userTodoListRepository.CreateAsync(newUserTodoList);

            if (newUserTodoList == null)
            {
                return BadRequest("Cannot create User-TodoList");
            }
            else
            {
                return Ok($"Successfully added {todoListName} to user's todolist");
            }

        }


        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteAsync(string todoListName)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var todoList = await _userTodoListRepository.GetTodoLists(appUser);

            var filterUserTodoList = todoList.Where(x => x.Name.ToLower() == todoListName.ToLower());

            if (filterUserTodoList.Count() == 1)
            {
                await _userTodoListRepository.DeleteAsync(appUser, todoListName);
            }
            else
            {
                return BadRequest("Todolist is not in your list");
            }
            return Ok($"Successfully removed {todoListName} from user's todo)list");
        }

    }
}
