using AutoMapper;
using EXE201_Tutor_Web_API.Base.Repository;
using EXE201_Tutor_Web_API.Base.Service;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;
using EXE201_Tutor_Web_API.Repositories.OnCourseDetailRepositoryPlace;
using EXE201_Tutor_Web_API.Repositories.OnCourseRepositoryPlace;

namespace EXE201_Tutor_Web_API.Services.OnCourseDetailService
{
    public class OnCourseDetailService : BaseService<OnCourseDetail, OnCourseDetailDto, int>
    {
        private readonly IRepository<OnCourseDetail, int> _onCourseDetailRepository;
        private readonly IMapper _mapper;
        public OnCourseDetailService(IRepository<OnCourseDetail, int> onCourseDetailRepository, IMapper mapper, OnCourseDetailRepository repository) : base(onCourseDetailRepository, mapper)
        {
            _onCourseDetailRepository = repository;
            _mapper = mapper;
        }
    }
}
