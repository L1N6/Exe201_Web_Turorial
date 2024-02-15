using AutoMapper;
using EXE201_Tutor_Web_API.Base.Repository;
using EXE201_Tutor_Web_API.Base.Service;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;
using EXE201_Tutor_Web_API.Repositories.OnMoocDetailRepositoryPlace;

namespace EXE201_Tutor_Web_API.Services.OnMoocDetailService
{
    public class OnMoocDetailService : BaseService<OnMoocDetail, OnMoocDetailDto, int>
    {
        private readonly IRepository<OnMoocDetail, int> _onMoocDetailRepository;
        private readonly IMapper _mapper;
        public OnMoocDetailService(IRepository<OnMoocDetail, int> onMoocDetailRepository, IMapper mapper, OnMoocDetailRepository repository) : base(onMoocDetailRepository, mapper)
        {
            _onMoocDetailRepository = onMoocDetailRepository;
            _mapper = mapper;
        }
    }
}
