using System;
using DotNetWebAPIDefault.Data;
using DotNetWebAPIDefault.DTOs.Todo;
using DotNetWebAPIDefault.Helpers;
using DotNetWebAPIDefault.Interfaces;
using DotNetWebAPIDefault.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetWebAPIDefault.Repository;

public class TodoRepository(AppDBContext context) : ITodoRepository
{

    private readonly AppDBContext _context = context;


    public async Task<List<Todo>> GetAllAsync(QueryObject query)
    {
        var todos = _context.Todos.Include(c => c.AppUser).AsQueryable();
        if (!string.IsNullOrWhiteSpace(query.Name))
            todos = todos.Where(t => t.Name.Contains(query.Name));

        if(!query.Finished == null)
        {
            todos = todos.Where(t => t.finished == query.Finished);
        }

        return await todos.ToListAsync();
    }

    public async Task<Todo?> GetByIdAsync(int id)
    {
        return await _context.Todos.Include(c => c.AppUser).FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Todo> CreateAsync(Todo todoModel)
    {
        await _context.Todos.AddAsync(todoModel);
        await _context.SaveChangesAsync();
        return todoModel;
    }

    public async Task<Todo?> UpdateAsync(int id, Todo todoDto)
    {
        var existingTodo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
        if (existingTodo is null) return null;

        existingTodo.Name = todoDto.Name;
        existingTodo.Description = todoDto.Description;
        existingTodo.finished = todoDto.finished;
        await _context.SaveChangesAsync();
        return existingTodo;

    }

    public async Task<Todo?> DeleteAsync(int id)
    {
        var todoModel = await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
        if (todoModel is null) return null;
        _context.Todos.Remove(todoModel);

        await _context.SaveChangesAsync();

        return todoModel;
    }
}
