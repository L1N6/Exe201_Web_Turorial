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
        private readonly UserRepository _userRepository; // Change IRepository<User, int> to UserRepository
        private readonly IMapper _mapper;

        public UserService(UserRepository userRepository, IMapper mapper) // Change IRepository<User, int> to UserRepository
            : base(userRepository, mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            var entity = _userRepository.GetAll().Where(x => x.Email == email).FirstOrDefault(); // Call UserRepository specific method
            return _mapper.Map<UserDto>(entity);
        }
    }
}
