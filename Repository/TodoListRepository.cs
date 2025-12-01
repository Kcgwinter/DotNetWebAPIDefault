using System;
using DotNetWebAPIDefault.Data;
using DotNetWebAPIDefault.DTOs.Todo;
using DotNetWebAPIDefault.Interfaces;
using DotNetWebAPIDefault.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace DotNetWebAPIDefault.Repository;

public class TodoListRepository(AppDBContext context) : ITodoListRepository
{
    private readonly AppDBContext _context = context;


    public async Task<List<TodoList>> GetAllAsync()
    {
        return await _context.TodoLists.ToListAsync();
    }

    public async Task<TodoList?> GetByIdAsync(int id)
    {
        return await _context.TodoLists.FindAsync(id);

    }


    public async Task<TodoList> CreateAsync(TodoList todoListModel)
    {
        await _context.TodoLists.AddAsync(todoListModel);
        await _context.SaveChangesAsync();
        return todoListModel;
    }

    public async Task<TodoList?> UpdateAsync(int id, UpdateTodoListRequestDto todolistDto)
    {
        var existingTodoList = await _context.TodoLists.FirstOrDefaultAsync(x => x.Id == id);

        if (existingTodoList == null) return null;

        existingTodoList.Name = todolistDto.Name;

        await _context.SaveChangesAsync();

        return existingTodoList;

    }

    public async Task<TodoList?> DeleteAsync(int id)
    {
        var todoListModel = await GetByIdAsync(id);
        if (todoListModel == null) return null;
        _context.TodoLists.Remove(todoListModel);
        await _context.SaveChangesAsync();

        return todoListModel;
    }
}
