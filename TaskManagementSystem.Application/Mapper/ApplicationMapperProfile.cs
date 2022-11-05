using AutoMapper;
using TaskManagementSystem.Application.Dto;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Mapper
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<TaskDto, Duty>().ReverseMap();
            CreateMap<CommentDto, Comment>().ReverseMap();
        }

    }


}
