using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetWebAPIDefault.Models;

[Table("Todos")]
public class Todo : BaseModel
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public bool finished { get; set; } = false;

    // Realationship (Reverse to TodoList)
    public int? TodoListId { get; set; }
    public TodoList? TodoList { get; set; }


}
