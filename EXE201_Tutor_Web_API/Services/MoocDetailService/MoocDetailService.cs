using AutoMapper;
using EXE201_Tutor_Web_API.Base.Repository;
using EXE201_Tutor_Web_API.Base.Service;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;
using EXE201_Tutor_Web_API.Repositories.MoocDetailRepositoryPlace;

namespace EXE201_Tutor_Web_API.Services.MoocDetailService
{
    public class MoocDetailService : BaseService<MoocDetail, MoocDetailDto, int>
    {
        private readonly IRepository<MoocDetail, int> _moocDetailRepository;
        private readonly IMapper _mapper;
        public MoocDetailService(IRepository<MoocDetail, int> moocDetailrepository, IMapper mapper, MoocDetailRepository repository) : base(moocDetailrepository, mapper)
        {
            _moocDetailRepository = repository;
            _mapper = mapper;
        }
    }
}
