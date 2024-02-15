using AutoMapper;
using EXE201_Tutor_Web_API.Base.Repository;
using EXE201_Tutor_Web_API.Base.Service;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;
using EXE201_Tutor_Web_API.Repositories.UserRepositoryPlace;
using Extension.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EXE201_Tutor_Web_API.Services.UserServicePlace
{
    public class UserService : BaseService<User, UserDto, int>
    {
        private readonly IRepository<User, int> _userRepository;
        private readonly IMapper _mapper;
        public UserService(IRepository<User, int> userRepository, IMapper mapper,UserRepository repository) : base(userRepository, mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            var entity =  _userRepository.GetAll().Where(x=>x.Email == email).FirstOrDefault();
            return _mapper.Map<UserDto>(entity);
        }

        // Now you can use _userRepository in your UserService class
        // For example, you can define additional methods that utilize _userRepository
    }
}
