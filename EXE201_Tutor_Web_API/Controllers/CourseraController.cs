using AutoMapper;
using EXE201_Tutor_Web_API.Base;
using EXE201_Tutor_Web_API.Base.Repository;
using EXE201_Tutor_Web_API.Base.Service;
using EXE201_Tutor_Web_API.Dto;
using EXE201_Tutor_Web_API.Entites;
using EXE201_Tutor_Web_API.Repositories.CourseraRepositoryPlace;
using EXE201_Tutor_Web_API.Repositories.OnCoursereRepositoryPlace;
using EXE201_Tutor_Web_API.Services.CourseraService;
using EXE201_Tutor_Web_API.Services.OnCourseraService;
using Extension.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;
using static EXE201_Tutor_Web_API.Constant.Enum;
using System.Net;
using Newtonsoft.Json;
using EXE201_Tutor_Web_API.Dto.FilterDto;

namespace EXE201_Tutor_Web_API.Controllers
{
    public class CourseraController : Controller
    {
        private readonly CourseraRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseraController(CourseraRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }


        [HttpGet("GetAllCoursera")]
        public async Task<ActionResult<CommonResultDto<List<CourseraDto>>>> GetAllCoursera()
        {
            try
            {
                var courserasWithDetails = await _courseRepository.GetAll()
                    .Include(c => c.CourseraDetails)
                        .ThenInclude(cd => cd.Moocs)
                            .ThenInclude(m => m.MoocDetails)
                    .ToListAsync();
                var courserasDto = _mapper.Map<List<CourseraDto>>(courserasWithDetails);
                
                // Configure JsonSerializerOptions to handle object cycles
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                };

                // Serialize the result using JsonSerializerOptions
                var result = System.Text.Json.JsonSerializer.Serialize(courserasDto, options);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return new CommonResultDto<List<CourseraDto>>
                {
                    IsSuccessful = false,
                    ErrorMessage = ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError,
                    MessageCode = MessageCode.Exeption
                };
            }
        }

        [HttpPost("GetCourseraBySearch")]
        public async Task<ActionResult<CommonResultDto<IEnumerable<CourseraDto>>>> GetCourseraBySearch(CourseraFilterDto filter)
        {
            try
            {
                var courserasWithDetails = await _courseRepository.GetAll()
                    .Include(c => c.CourseraDetails)
                        .ThenInclude(cd => cd.Moocs)
                            .ThenInclude(m => m.MoocDetails)
                    .Where(x =>
                        (filter.CourseraId == null || x.CourseraId == filter.CourseraId) &&
                        (string.IsNullOrEmpty(filter.Name) || x.Name.Contains(filter.Name)) &&
                        (filter.Date == null || x.Date == filter.Date) &&
                        (string.IsNullOrEmpty(filter.Description) || x.Description.Contains(filter.Description)))
                    .ToListAsync();
                var courserasDto = _mapper.Map<List<CourseraDto>>(courserasWithDetails);
                // Your other logic here

                // Configure JsonSerializerOptions to handle object cycles
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                };

                // Serialize the result using JsonSerializerOptions
                var result = System.Text.Json.JsonSerializer.Serialize(courserasDto, options);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
