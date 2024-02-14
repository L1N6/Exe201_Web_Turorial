using EXE201_Tutor_Web_API.Base;
using EXE201_Tutor_Web_API.Base.Service;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;
using EXE201_Tutor_Web_API.Services.UserServicePlace;
using Microsoft.AspNetCore.Mvc;

namespace EXE201_Tutor_Web_API.Controllers
{
    public class UserController : CrudControllerBase<User, UserDto, int>
    {
        private readonly UserService _service;

        public UserController(IBaseService<User, UserDto, int> baseService, UserService service) : base(baseService)
        {
            _service = service;
        }

    }

}
