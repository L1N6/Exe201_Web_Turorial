using AutoMapper;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;

namespace EXE201_Tutor_Web_API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TEntity, TEntityDto>().ReverseMap();

            CreateMap<Student, StudentDTO>(); // Configure mapping from Source to Destination
            CreateMap<StudentDTO, Student>(); // Configure mapping from Destination to Source
        }
    }
}
