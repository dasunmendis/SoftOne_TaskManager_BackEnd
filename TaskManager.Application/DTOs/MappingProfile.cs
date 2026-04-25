using AutoMapper;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskItem, TaskDto>().ReverseMap();
        }
    }
}
