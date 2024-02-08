using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EXE201_Tutor_Web_API.Base.Repository;

namespace EXE201_Tutor_Web_API.Base.Service
{
    public class BaseService<TEntity, TEntityDto, TPrimaryKey> : IBaseService<TEntity, TEntityDto, TPrimaryKey>
        where TEntity : class
        where TEntityDto : class
    {
        private readonly IRepository<TEntity, TPrimaryKey> _repository;
        private readonly IMapper _mapper;

        public BaseService(IRepository<TEntity, TPrimaryKey> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<TEntityDto>> GetAll()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TEntityDto>>(entities);
        }

        public async Task<TEntityDto> GetById(TPrimaryKey id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TEntityDto>(entity);
        }

        public async Task<TEntityDto> Create(TEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntity>(entityDto);
            var createdEntity = await _repository.AddAsync(entity);
            return _mapper.Map<TEntityDto>(createdEntity);
        }

        public async Task<TEntityDto> Update(TPrimaryKey id, TEntityDto entityDto)
        {
            var existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null)
                throw new KeyNotFoundException($"Entity with ID {id} not found.");

            _mapper.Map(entityDto, existingEntity); // Update existing entity with data from DTO
            var updatedEntity = await _repository.UpdateAsync(existingEntity);
            return _mapper.Map<TEntityDto>(updatedEntity);
        }

        public async Task DeleteById(TPrimaryKey id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Entity with ID {id} not found.");

            await _repository.DeleteByIdAsync(id);
        }
    }
}
