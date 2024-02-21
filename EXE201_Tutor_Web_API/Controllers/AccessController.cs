using AutoMapper;
using EXE201_Tutor_Web_API.Base;
using EXE201_Tutor_Web_API.Database;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;
using Extension.Domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EXE201_Tutor_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DbContext _context;
        public AccessController(IMapper mapper, Exe201_Tutor_Context context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<CommonResultDto<IEnumerable<string>>>> GetAll()
        {
            try
            {
                var result = _context.SaveChanges() ;
                return Ok(new CommonResultDto<IEnumerable<string>>("Nice"));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new CommonResultDto<IEnumerable<string>>(ex.Message));
            }
        }


    }
}
