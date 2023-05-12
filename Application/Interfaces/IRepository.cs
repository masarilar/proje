namespace Application.Interfaces
{
    public interface IRepository<T>
    {
        Task<int> AddAsync(T entity);
        Task<IQueryable<int>> AddRangeAsync(IEnumerable<T> entities);
        Task<int> RemoveAsync(T entity);
        Task<IQueryable<int>> RemoveRangeAsync(IEnumerable<T> entites);
        Task<int> RemoveAsync(int id);
        Task<IQueryable<int>> RemoveRangeAsync(List<int> idList);
        Task<int> UpdateAsync(T entity);
        Task<IQueryable<int>> UpdateRangeAsync(IEnumerable<T> entities);
        Task<T> GetByIdAsync(int id);
        Task<IQueryable<T>> GetAllAsync();
        Task<int> SaveChangesAsync();
        //Task<int> CommitDatabase(bool state = true);
    }
}
