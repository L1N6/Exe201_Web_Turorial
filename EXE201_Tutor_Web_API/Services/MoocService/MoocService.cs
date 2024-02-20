using AutoMapper;
using EXE201_Tutor_Web_API.Base.Repository;
using EXE201_Tutor_Web_API.Base.Service;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;
using EXE201_Tutor_Web_API.Repositories.MoocRepositoryPlace;

namespace EXE201_Tutor_Web_API.Services.MoocService
{
    public class MoocService : BaseService<Mooc, MoocDto, int>
    {
        private readonly IRepository<Mooc, int> _moocRepository;
        private readonly IMapper _mapper;
        public MoocService(IRepository<Mooc, int> moocRepository, IMapper mapper, MoocRepository repository) : base(moocRepository, mapper)
        {
            _moocRepository= repository;
            _mapper= mapper;
        }
    }
}
