using AppMVC.Application.Dto.ToDo;
using AppMVC.Domain.Entities;
using AutoMapper;

namespace AppMVC.Application.Mappers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ToDoItem, ToDoItemDto>();
    }
}