using AutoMapper;
using EXE201_Tutor_Web_API.Base.Repository;
using EXE201_Tutor_Web_API.Base.Service;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;
using EXE201_Tutor_Web_API.Repositories.Interfaces;

namespace EXE201_Tutor_Web_API.Services.Implements
{
    public class UserService : BaseService<User, UserDto, int>
    {
        public UserService(IRepository<User, int> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
