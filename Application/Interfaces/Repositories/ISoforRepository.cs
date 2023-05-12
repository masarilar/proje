using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface ISoforRepository : IRepository<Sofor>
    {
        Task<IQueryable<Sofor>> GetAllListAsync();
        IQueryable<Sofor> GetAllListAsync(Func<Sofor, bool> predicate);
    }
}
