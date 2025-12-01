using System;
using DotNetWebAPIDefault.DTOs.Todo;
using DotNetWebAPIDefault.Models;

namespace DotNetWebAPIDefault.Interfaces;

public interface ITodoListRepository
{
    Task<List<TodoList>> GetAllAsync();
    Task<TodoList?> GetByIdAsync(int id);
    Task<TodoList> CreateAsync(TodoList todoListModel);
    Task<TodoList?> UpdateAsync(int id, UpdateTodoListRequestDto todolistDto);
    Task<TodoList?> DeleteAsync(int id);

    Task<bool> TodoListExists(int id);
}
