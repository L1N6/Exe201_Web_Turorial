using AutoMapper;
using EXE201_Tutor_Web_API.Base.Repository;
using EXE201_Tutor_Web_API.Base.Service;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;

namespace EXE201_Tutor_Web_API.Services.UserServicePlace
{
    public class UserService : BaseService<User, UserDto, int>
    {
        private readonly IRepository<User, int> _userRepository;

        public UserService(IRepository<User, int> userRepository, IMapper mapper) : base(userRepository, mapper)
        {
            _userRepository = userRepository;
        }

        // Now you can use _userRepository in your UserService class
        // For example, you can define additional methods that utilize _userRepository
    }
}
