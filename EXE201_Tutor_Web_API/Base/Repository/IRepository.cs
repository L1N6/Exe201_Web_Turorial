﻿namespace EXE201_Tutor_Web_API.Base.Repository
{
    public interface IRepository<TEntity, TPrimaryKey>
        where TEntity : class
    {
        public IQueryable<TEntity> GetAll();
        Task<TEntity> GetByIdAsync(TPrimaryKey id); // Change id type to TPrimaryKey
        Task<TEntity> AddAsync(TEntity entity); // Change return type to Task<TEntity>
        Task<TEntity> UpdateAsync(TEntity entity); // Change return type to Task<TEntity>
        Task DeleteByIdAsync(TPrimaryKey id); // Change parameter type to TPrimaryKey
    }
}

