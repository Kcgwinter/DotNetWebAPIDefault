using System;
using DotNetWebAPIDefault.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DotNetWebAPIDefault.Data;

public class AppDBContext : IdentityDbContext<AppUser>
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {

    }

    public DbSet<Todo> Todos { get; set; }
    public DbSet<TodoList> TodoLists { get; set; }
    public DbSet<UserTodoList> UserTodoLists { get; set; }
    public DbSet<Storage> Storages { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole { Name = "Admin", NormalizedName="ADMIN" },
            new IdentityRole { Name = "User", NormalizedName="USER" }
        };

        builder.Entity<IdentityRole>().HasData(roles);

        builder.Entity<UserTodoList>(x => x.HasKey(p => new { p.AppUserId, p.TodoListId }));
        builder.Entity<UserTodoList>()
        .HasOne(u => u.AppUser)
        .WithMany(u => u.TodoLists)
        .HasForeignKey(u => u.AppUserId);

        builder.Entity<UserTodoList>()
        .HasOne(u => u.TodoList)
        .WithMany(u => u.TodoLists)
        .HasForeignKey(u => u.TodoListId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings =>
            warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

}
