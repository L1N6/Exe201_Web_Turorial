using EXE201_Tutor_Web_API.Base;
using EXE201_Tutor_Web_API.Base.Service;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EXE201_Tutor_Web_API.Controllers
{
    {
        public UserController(IBaseService<User, UserDto, int> baseService) : base(baseService)
        {
        }
            
        
    }

}
