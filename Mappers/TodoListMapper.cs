using System;
using DotNetWebAPIDefault.DTOs.Todo;
using DotNetWebAPIDefault.Models;

namespace DotNetWebAPIDefault.Mappers;

public static class TodoListMapper
{
    public static TodoListDto ToTodoListDto(this TodoList todoListModel)
    {
        return new TodoListDto
        {
            Id = todoListModel.Id,
            Name = todoListModel.Name,
            Todos = todoListModel == null ? todoListModel.Todos.Select(c => c.ToTodoDto()).ToList() : null,
        };
    }

    public static TodoList toTodoListFromCreate(this CreateTodoListRequestDto createTodoListDto)
    {
        return new TodoList
        {
            Name = createTodoListDto.Name
        };
    }
}
