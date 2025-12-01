using System;
using DotNetWebAPIDefault.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DotNetWebAPIDefault.Data;

public class AppDBContext : IdentityDbContext<AppUser>
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {

    }

    public DbSet<Todo> Todos { get; set; }
    public DbSet<TodoList> TodoLists { get; set; }


}
