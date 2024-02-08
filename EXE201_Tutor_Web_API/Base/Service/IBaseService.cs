namespace EXE201_Tutor_Web_API.Base.Service
{
    public interface IBaseService<TEntity, TEntityDto, TPrimaryKey>
         where TEntity : class
         where TEntityDto : class
    {
        Task<IEnumerable<TEntityDto>> GetAll();
        Task<TEntityDto> GetById(TPrimaryKey id);
        Task<TEntityDto> Create(TEntityDto entityDto);
        Task<TEntityDto> Update(TPrimaryKey id, TEntityDto entityDto);
        Task DeleteById(TPrimaryKey id); // Changed from DeleteAsync(TEntity entity)
    }
}
