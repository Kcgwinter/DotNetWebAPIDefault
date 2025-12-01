using System;
using DotNetWebAPIDefault.DTOs.Todo;
using DotNetWebAPIDefault.Models;

namespace DotNetWebAPIDefault.Interfaces;

public interface ITodoRepository
{
    Task<List<Todo>> GetAllAsync();
    Task<Todo?> GetByIdAsync(int id);
    Task<Todo> CreateAsync(Todo todoModel);
    Task<Todo?> UpdateAsync(int id, Todo todoDto);
    Task<Todo?> DeleteAsync(int id);

}
