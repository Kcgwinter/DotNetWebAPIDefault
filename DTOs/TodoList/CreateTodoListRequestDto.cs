using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetWebAPIDefault.DTOs.Todo;

public class CreateTodoListRequestDto
{
    [Required]
    public required string Name { get; set; }

}
