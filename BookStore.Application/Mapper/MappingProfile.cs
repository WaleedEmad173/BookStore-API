using AutoMapper;
using BookStore.Application.DTOs.Category;
using BookStore.Domain.Entities;

namespace BookStore.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
