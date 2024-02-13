﻿using EXE201_Tutor_Web_API.Base.Service;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;

namespace EXE201_Tutor_Web_API.Repositories.Interfaces
{
    public interface IUserService : IBaseService<User, UserDto, int>
    {
        
    }
}
