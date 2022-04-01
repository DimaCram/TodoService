using AutoMapper;
using TodoApi.Models;
using TodoApiDTO.Core.Models;

namespace TodoApiDTO.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoItem, TodoItemDTO>().ReverseMap();
        }
    }
}
