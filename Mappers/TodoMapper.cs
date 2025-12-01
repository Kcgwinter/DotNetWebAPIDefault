using System;
using DotNetWebAPIDefault.DTOs.Todo;
using DotNetWebAPIDefault.Models;

namespace DotNetWebAPIDefault.Mappers;

public static class TodoMapper
{
    public static TodoDto ToTodoDto(this Todo todoModel)
    {
        return new TodoDto
        {
            Id = todoModel.Id,
            Name = todoModel.Name,
            Description = todoModel.Description,
            finished = todoModel.finished
        };
    }


    public static Todo toTodoFromCreate(this CreateTodoRequestDto createTodoListDto)
    {
        return new Todo
        {
            Name = createTodoListDto.Name,
            Description = createTodoListDto.Description,
            finished = createTodoListDto.finished
        };
    }
}
