using AutoMapper;
using EXE201_Tutor_Web_API.Base.Repository;
using EXE201_Tutor_Web_API.Base.Service;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;
using EXE201_Tutor_Web_API.Repositories.OnCourseRepositoryPlace;
using EXE201_Tutor_Web_API.Repositories.OnCoursereRepositoryPlace;

namespace EXE201_Tutor_Web_API.Services.OnCourseraService
{
    public class OnCourseraService : BaseService<OnCoursera, OnCourseraDto, int>
    {
        private readonly IRepository<OnCoursera, int> _onCourseRepository;
        private readonly IMapper _mapper;
        public OnCourseraService(IRepository<OnCoursera, int> onCourseRepository, IMapper mapper, OnCourseraRepository repository) : base(onCourseRepository, mapper)
        {
            _onCourseRepository = repository;
            _mapper = mapper;
        }

       


    }
}
