using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotNetWebAPIDefault.DTOs.Todo;
using DotNetWebAPIDefault.Models;

namespace DotNetWebAPIDefault.Helpers.Request
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<TodoList, TodoListDto>().IncludeMembers(x => x.Todos);
            CreateMap<Todo, TodoListDto>();
            CreateMap<CreateTodoListRequestDto, TodoList>().ForMember( d=> d.Todos, o => o.MapFrom(s => s));
        }
    }
}