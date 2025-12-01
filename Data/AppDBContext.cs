using System;
using DotNetWebAPIDefault.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DotNetWebAPIDefault.Data;

public class AppDBContext : IdentityDbContext<AppUser>
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {

    }

    public DbSet<Todo> Todos { get; set; }
    public DbSet<TodoList> TodoLists { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole { Name = "Admin", NormalizedName="ADMIN" },
            new IdentityRole { Name = "User", NormalizedName="USER" }
        };

        builder.Entity<IdentityRole>().HasData(roles);

    }

}
