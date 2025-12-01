using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetWebAPIDefault.DTOs.Todo;

public class UpdateTodoListRequestDto
{

    [Required]
    public required string Name { get; set; }
}
