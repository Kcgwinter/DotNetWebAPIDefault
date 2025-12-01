using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetWebAPIDefault.Models;

[Table("TodoLists")]
public class TodoList : BaseModel
{
    public required string Name { get; set; }
    public List<Todo>? Todos { get; set; }
    public List<UserTodoList> TodoLists { get; set; } = new List<UserTodoList>();
}
