using Microsoft.EntityFrameworkCore;
using CatalogService.Persistence.Context;
using CatalogService.Domain.Interfaces;
using CatalogService.Domain.Entities;

namespace CatalogService.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly CatalogServiceDbContext _dbContext;

        public Repository(CatalogServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
