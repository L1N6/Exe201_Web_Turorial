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

        public BaseService(IRepository<TEntity, TPrimaryKey> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<TEntityDto>> GetAll()
        {
            var entities = await _repository.GetAllAsync();
            // You would need to map your entities to DTOs here before returning.
            throw new NotImplementedException();
        }

        public async Task<TEntityDto> GetById(TPrimaryKey id)
        {
            var entity = await _repository.GetByIdAsync(id);
            // You would need to map your entity to DTO here before returning.
            throw new NotImplementedException();
        }

        public async Task<TEntityDto> Create(TEntityDto entityDto)
        {
            // You would need to map your DTO to entity here before passing it to the repository.
            throw new NotImplementedException();
        }

        public async Task<TEntityDto> Update(TPrimaryKey id, TEntityDto entityDto)
        {
            var existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null)
                throw new KeyNotFoundException($"Entity with ID {id} not found.");

            // You would need to update the existing entity with data from the DTO and save changes.
            throw new NotImplementedException();
        }

        public async Task DeleteById(TPrimaryKey id)
        {
            await _repository.DeleteByIdAsync(id);
        }
    }
}
