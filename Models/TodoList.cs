using System;

namespace DotNetWebAPIDefault.Models;

public class TodoList : BaseModel
{
    public required string Name { get; set; }
    public List<Todo>? Todos { get; set; }
}
