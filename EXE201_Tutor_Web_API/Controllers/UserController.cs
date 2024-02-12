using EXE201_Tutor_Web_API.Base;
using EXE201_Tutor_Web_API.Base.Service;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;
using Microsoft.AspNetCore.Mvc;

namespace EXE201_Tutor_Web_API.Controllers
{
    public class UserController : CrudControllerBase<User, UserDto, int>
    {
        public UserController(IBaseService<User, UserDto, int> baseService) : base(baseService)
        {
        }
            
        
    }
}
