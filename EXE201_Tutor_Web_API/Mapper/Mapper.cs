using AutoMapper;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;

namespace EXE201_Tutor_Web_API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Configure mapping of Student entity
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();

            // Configure mapping of Teacher entity
            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherDto, Teacher>();

            // Configure mapping of Coursera entity
            CreateMap<Coursera, CourseraDto>();
            CreateMap<CourseraDto, Coursera>();

            // Configure mapping of CourseraDetail entity
            CreateMap<CourseraDetail, CourseraDetailDto>();
            CreateMap<CourseraDetailDto, CourseraDetail>();

            // Configure mapping of Mooc entity
            CreateMap<Mooc, MoocDto>();
            CreateMap<MoocDto, Mooc>();

            // Configure mapping of MoocDetail entity
            CreateMap<MoocDetail, MoocDetailDto>();
            CreateMap<MoocDetailDto, MoocDetail>();

            // Configure mapping of OnCourse entity
            CreateMap<OnCoursera, OnCourseraDto>();
            CreateMap<OnCourseraDto, OnCoursera>();

            // Configure mapping of OnCourseDetail entity
            CreateMap<OnCourseraDetail, OnCourseraDetailDto>();
            CreateMap<OnCourseraDetailDto, OnCourseraDetail>();

            // Configure mapping of OnMooc entity
            CreateMap<OnMooc, OnMoocDto>();
            CreateMap<OnMoocDto, OnMooc>();

            // Configure mapping of OnMoocDetail entity
            CreateMap<OnMoocDetail, OnMoocDetailDto>();
            CreateMap<OnMoocDetailDto, OnMoocDetail>();

        }
    }
}
