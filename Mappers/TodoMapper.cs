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


    public static Todo toTodoFromCreate(this CreateTodoDto todoDto, int todoListId)
    {
        return new Todo
        {
            Name = todoDto.Name,
            Description = todoDto.Description,
            finished = todoDto.finished,
            TodoListId = todoListId

        };
    }
    
    public static Todo toTodoFromUpdate(this UpdateTodoDto todoDto)
    {
        return new Todo
        {
            Name = todoDto.Name,
            Description = todoDto.Description,
            finished = todoDto.finished,

        };
    }
}
