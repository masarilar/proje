using Application.Interfaces;
using Domain.Base;
using Microsoft.EntityFrameworkCore;
using ModelDto.Enums;

namespace Infrastructure.Repos
{
    public class Repository<T> : IRepository<T> where T : class, IEntity<int>
    {
        public readonly IApplicationDbContext _applicationDbContext;
        public Repository(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<int> AddAsync(T entity)
        {
            await _applicationDbContext.Set<T>().AddAsync(entity);
            await SaveChangesAsync();
            return entity.Id;
        }
        public async Task<IQueryable<int>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _applicationDbContext.Set<T>().AddRangeAsync(entities);
            await SaveChangesAsync();
            return entities.Select(e => e.Id).AsQueryable();
        }
        public async Task<IQueryable<T>> GetAllAsync() => _applicationDbContext.Set<T>().AsNoTracking();
        public async Task<T> GetByIdAsync(int id) => await _applicationDbContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        public async Task<int> UpdateAsync(T entity)
        {
            _applicationDbContext.Set<T>().Update(entity);
            await SaveChangesAsync();
            return entity.Id;
        }
        public async Task<IQueryable<int>> UpdateRangeAsync(IEnumerable<T> entities)
        {
            _applicationDbContext.Set<T>().UpdateRange(entities);
            await SaveChangesAsync();
            return entities.Select(e => e.Id).AsQueryable();
        }
        public async Task<int> RemoveAsync(T entity)
        {
            entity.Durum = VeriDurumu.Silindi;
            return await UpdateAsync(entity);
        }
        public async Task<IQueryable<int>> RemoveRangeAsync(IEnumerable<T> entites)
        {
            entites.AsQueryable().ForEachAsync(e => e.Durum = VeriDurumu.Silindi);
            _applicationDbContext.Set<T>().UpdateRange(entites);
            return entites.Select(e => e.Id).AsQueryable();
        }
        public async Task<int> RemoveAsync(int id)
        {
            var entity = _applicationDbContext.Set<T>().FirstOrDefault(e => e.Id == id);
            if (entity is not null)
                return await RemoveAsync(entity);
            else
                throw new Exception("Entity not exist.");
        }
        public async Task<IQueryable<int>> RemoveRangeAsync(List<int> idList)
        {
            var entities = _applicationDbContext.Set<T>().Where(e => idList.Contains(e.Id));
            if (entities.Count() is not 0)
                return await RemoveRangeAsync(entities);
            else
                throw new Exception("Entities not exist");
        }
        public async Task<int> SaveChangesAsync() => await _applicationDbContext.SaveChangesAsync();        
    }
}
