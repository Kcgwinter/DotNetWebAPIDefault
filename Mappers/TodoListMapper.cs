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
            Name = todoListModel.Name,
            Todos = todoListModel.Todos
        };
    }
}
