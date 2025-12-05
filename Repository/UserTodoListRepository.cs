using System;
using DotNetWebAPIDefault.Data;
using DotNetWebAPIDefault.Interfaces;
using DotNetWebAPIDefault.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DotNetWebAPIDefault.Repository;

public class UserTodoListRepository(AppDBContext context) : IUserTodoListRepository
{

    private readonly AppDBContext _context = context;

    public async Task<UserTodoList> CreateAsync(UserTodoList userTodoList)
    {
        await _context.UserTodoLists.AddAsync(userTodoList);
        await _context.SaveChangesAsync();

        return userTodoList;
    }

    public async Task<UserTodoList> DeleteAsync(AppUser user, string name)
    {
        var userTodoListModel = await _context.UserTodoLists.FirstOrDefaultAsync(x => x.AppUserId == user.Id && x.TodoList!.Name.ToLower() == name.ToLower());
        if(userTodoListModel == null) throw new NotImplementedException(); //TODO: Fix throw not implemented exception

        _context.UserTodoLists.Remove(userTodoListModel);
        await _context.SaveChangesAsync();

        return userTodoListModel;
    }

    public async Task<List<TodoList>> GetTodoLists(AppUser user)
    {
        return await _context.UserTodoLists.Where(u => u.AppUserId == user.Id).Select(tl => new TodoList
        {
            Id = tl.TodoListId,
            Name = tl.TodoList!.Name

        }).ToListAsync();
    }
}
