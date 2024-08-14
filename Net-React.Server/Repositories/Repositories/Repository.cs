using Microsoft.EntityFrameworkCore;
using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Net_React.Server.Repositories.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ECommerceSampContext _context;
        public Repository(ECommerceSampContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByIdAsync(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
            }
        }
    }
}
