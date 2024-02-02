namespace EXE201_Tutor_Web_API.Base
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Create(T entity);
        void Update(T entity);
        void Delete(object id);
        void Delete(T entity);
    }
}
