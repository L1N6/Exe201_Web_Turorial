using EXE201_Tutor_Web_API.Base;
using EXE201_Tutor_Web_API.Base.Service;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;
using EXE201_Tutor_Web_API.Services.UserServicePlace;
using Extension.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static EXE201_Tutor_Web_API.Constant.Enum;

namespace EXE201_Tutor_Web_API.Controllers
{
    public class UserController : CrudControllerBase<User, UserDto, int>
    {
        private readonly UserService _baseservice;

        public UserController(IBaseService<User, UserDto, int> baseService, UserService service) : base(baseService)
        {
            _service = service;
        }


        [HttpGet("{email}")]
        public async Task<ActionResult<CommonResultDto<UserDto>>> GetByUserByEmail(string email)
        {
            try
            {
                var result = await _baseservice.GetUserByEmail(email);
               

                if (result != null)
                {
                    return new CommonResultDto<UserDto>
                    {
                        IsSuccessful = true,
                        ErrorMessage = string.Empty,
                        StatusCode = System.Net.HttpStatusCode.OK,
                        DataResult = result
                    };
                }
                else
                {
                    return new CommonResultDto<UserDto>
                    {
                        IsSuccessful = false,
                        ErrorMessage = EnumExtensionMethods.GetEnumDescription(MessageCode.NotFound),
                        StatusCode = System.Net.HttpStatusCode.OK,
                        DataResult = result,
                        MessageCode = MessageCode.NoContent
                    };
                }
            }
            catch (Exception ex)
            {
                return new CommonResultDto<UserDto>
                {
                    IsSuccessful = true,
                    ErrorMessage = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.OK,
                    MessageCode = MessageCode.Exeption
                };
            }
        }
    }

}
