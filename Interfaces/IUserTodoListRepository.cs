using System;
using DotNetWebAPIDefault.Models;

namespace DotNetWebAPIDefault.Interfaces;

public interface IUserTodoListRepository
{
    Task<List<TodoList>> GetTodoLists(AppUser user);
    Task<UserTodoList> CreateAsync(UserTodoList userTodoList);

    Task<UserTodoList> DeleteAsync(AppUser user, string name);
}
