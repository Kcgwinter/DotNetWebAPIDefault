using System;

namespace DotNetWebAPIDefault.DTOs.Todo;

public class TodoListDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public List<TodoDto>? Todos { get; set; }

}
