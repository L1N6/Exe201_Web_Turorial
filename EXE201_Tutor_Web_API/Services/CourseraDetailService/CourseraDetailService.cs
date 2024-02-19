using AutoMapper;
using EXE201_Tutor_Web_API.Base.Repository;
using EXE201_Tutor_Web_API.Base.Service;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;
using EXE201_Tutor_Web_API.Repositories.CourseraRepositoryPlace;
using EXE201_Tutor_Web_API.Repositories.DetailRepositoryPlace;

namespace EXE201_Tutor_Web_API.Services.CourseraDetailService
{
    public class CourseraDetailService : BaseService<CourseraDetail, CourseraDetailDto, int>
    {
        private readonly IRepository<CourseraDetail, int> _courseraDetailRepository;
        private readonly IMapper _mapper;
        public CourseraDetailService(IRepository<CourseraDetail, int> courseraDetailrepository, IMapper mapper, CourseraDetailRepository repository ) : base(courseraDetailrepository, mapper)
        {
            _courseraDetailRepository = repository;
            _mapper = mapper;

        }
    }
}
