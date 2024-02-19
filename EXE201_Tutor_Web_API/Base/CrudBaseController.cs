using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using EXE201_Tutor_Web_API.Base.Service;
using Extension.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using static EXE201_Tutor_Web_API.Constant.Enum;

namespace EXE201_Tutor_Web_API.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public class CrudControllerBase<TEntity, TEntityDto, TPrimaryKey> : ControllerBase
        where TEntity : class
        where TEntityDto : class
    {
        private readonly IBaseService<TEntity, TEntityDto, TPrimaryKey> _baseService;

        public CrudControllerBase(IBaseService<TEntity, TEntityDto, TPrimaryKey> baseService)
        {
            _baseService = baseService ?? throw new ArgumentNullException(nameof(baseService));
        }

        [HttpGet]
        public async Task<ActionResult<CommonResultDto<IEnumerable<TEntityDto>>>> GetAll()
        {
            try
            {
                var result =  _baseService.GetAll();
                return Ok(new CommonResultDto<IEnumerable<TEntityDto>>(result));
            }
            catch (Exception ex)
            {
                return new CommonResultDto<IEnumerable<TEntityDto>>
                {
                    IsSuccessful = true,
                    ErrorMessage = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.OK,
                    MessageCode = MessageCode.Exeption
                };
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommonResultDto<TEntityDto>>> GetById(TPrimaryKey id)
        {
            try
            {
                var result = await _baseService.GetById(id);
                if (result == null)
                    return NotFound(new CommonResultDto<TEntityDto>("Resource not found"));
                return Ok(new CommonResultDto<TEntityDto>(result));
                
            }
            catch (Exception ex)
            {
                return new CommonResultDto<TEntityDto>
                {
                    IsSuccessful = true,
                    ErrorMessage = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.OK,
                    MessageCode = MessageCode.Exeption
                };
            }
        }

        [HttpPost]
        public async Task<ActionResult<CommonResultDto<TEntityDto>>> Create(TEntityDto entityDto)
        {
            try
            {
                var result = await _baseService.Create(entityDto);
                return Ok(new CommonResultDto<TEntityDto>(result));
            }
            catch (Exception ex)
            {
                return new CommonResultDto<TEntityDto>
                {
                    IsSuccessful = true,
                    ErrorMessage = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.OK,
                    MessageCode = MessageCode.Exeption
                };
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CommonResultDto<TEntityDto>>> Update(TPrimaryKey id, TEntityDto entityDto)
        {
            try
            {
                var result = await _baseService.Update(id, entityDto);
                return Ok(new CommonResultDto<TEntityDto>(result));
            }
            catch (Exception ex)
            {
                return new CommonResultDto<TEntityDto>
                {
                    IsSuccessful = true,
                    ErrorMessage = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.OK,
                    MessageCode = MessageCode.Exeption
                };
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CommonResultDto<TEntityDto>>> DeleteById(TPrimaryKey id)
        {
            try
            {
                await _baseService.DeleteById(id);
                return Ok(new CommonResultDto<TEntityDto>("Entity deleted successfully"));
            }
            catch (Exception ex)
            {
                return new CommonResultDto<TEntityDto>
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
