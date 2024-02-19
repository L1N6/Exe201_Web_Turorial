using AutoMapper;
using EXE201_Tutor_Web_API.Base.Repository;
using EXE201_Tutor_Web_API.Base.Service;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;
using EXE201_Tutor_Web_API.Repositories.OnMoocRepositoryPlace;

namespace EXE201_Tutor_Web_API.Services.OnMoocService
{
    public class OnMoocService : BaseService<OnMooc, OnMoocDto, int>
    {
        private readonly IRepository<OnMooc, int> _repository;
        private readonly IMapper _mapper;   
        public OnMoocService(IRepository<OnMooc, int> onMoocRepository, IMapper mapper, OnMoocRepository repository) : base(onMoocRepository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
