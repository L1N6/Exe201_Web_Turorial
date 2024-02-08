using AutoMapper;
using EXE201_Tutor_Web_API.Base;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EXE201_Tutor_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly IMapper _mapper;
        public AccessController(IMapper mapper) {
            _mapper = mapper;
        }
        [HttpGet]
      
        public IActionResult getAccount()
        {
            Student s = new Student
            {
                BirthDay = DateTime.Now,
                Name = "DoThanh",
                Age = 12
            };

            _mapper.Map<StudentDTO>(s);

            return Ok(s);
        }
    }
}
