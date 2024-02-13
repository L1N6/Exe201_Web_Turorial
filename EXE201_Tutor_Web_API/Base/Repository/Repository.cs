using System.Threading.Tasks;
using EXE201_Tutor_Web_API.Base.Repository;
using EXE201_Tutor_Web_API.Database;
using Microsoft.EntityFrameworkCore;

namespace EXE201_Tutor_Web_API.Base.Repository
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        private readonly Exe201_Tutor_Context _context;
        private readonly DbSet<TEntity> _dbSet;

        {
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(TPrimaryKey id)
        {
            return await _dbSet.FindAsync(id);
        }

        {
            await _dbSet.AddAsync(entity);
            await SaveChangesAsync(); // Ensure changes are saved immediately after adding
            return entity;
        }

        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteByIdAsync(TPrimaryKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
                _dbSet.Remove(entity);

            await SaveChangesAsync(); // Ensure changes are saved immediately after deletion
        }

        {
        }
    }
}
