using System;
using DotNetWebAPIDefault.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetWebAPIDefault.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {

    }

    public DbSet<Todo> Todos { get; set; }
    public DbSet<TodoList> TodoLists { get; set; }

}
