namespace EXE201_Tutor_Web_API.Base.Repository
{
    public interface IRepository<TEntity, TPrimaryKey>
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TPrimaryKey id); // Change id type to TPrimaryKey
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteByIdAsync(TPrimaryKey id); // Change parameter type to TPrimaryKey
        Task SaveChangesAsync();
    }
}
