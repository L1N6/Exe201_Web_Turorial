using AutoMapper;
using EXE201_Tutor_Web_API.Base.Repository;
using EXE201_Tutor_Web_API.Base.Service;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;
using EXE201_Tutor_Web_API.Repositories.OnCourseRepositoryPlace;

namespace EXE201_Tutor_Web_API.Services.OnCourseService
{
    public class OnCourseService : BaseService<OnCourse, OnCourseDto, int>
    {
        private readonly IRepository<OnCourse, int> _onCourseRepository;
        private readonly IMapper _mapper;
        public OnCourseService(IRepository<OnCourse, int> onCourseRepository, IMapper mapper, OnCourseraRepository repository) : base(onCourseRepository, mapper)
        {
            _onCourseRepository = repository;
            _mapper = mapper;
        }
    }
}
