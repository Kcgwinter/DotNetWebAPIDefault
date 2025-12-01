using System;
using DotNetWebAPIDefault.Models;

namespace DotNetWebAPIDefault.DTOs.Todo;

public class TodoDto
{

    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public bool finished { get; set; } = false;

    // Realationship (Reverse to TodoList)
    public int? TodoListId { get; set; }
}
