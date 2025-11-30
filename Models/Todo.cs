using System;

namespace DotNetWebAPIDefault.Models;

public class Todo : BaseModel
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public bool finished { get; set; } = false;

    // Realationship (Reverse to TodoList)
    public int? TodoListId { get; set; }
    public TodoList? TodoList { get; set; }

}
