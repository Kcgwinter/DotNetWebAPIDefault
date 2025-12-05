using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetWebAPIDefault.Models;

[Table("UserTodoList")]
public class UserTodoList
{
    public required string AppUserId { get; set; }
    public int TodoListId { get; set; }
    public AppUser? AppUser { get; set; }
    public TodoList? TodoList { get; set; }
}
