using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetWebAPIDefault.DTOs.Todo;

public class UpdateTodoDto
{

    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Description { get; set; }
    public bool finished { get; set; } = false;

    // Realationship (Reverse to TodoList)
    public int? TodoListId { get; set; }
}
