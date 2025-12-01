using System;
using Microsoft.AspNetCore.Identity;

namespace DotNetWebAPIDefault.Models;

public class AppUser : IdentityUser
{
    public List<UserTodoList> TodoLists { get; set; } = new List<UserTodoList>();
}
