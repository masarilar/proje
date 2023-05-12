using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IAracRepository : IRepository<Arac>
    {
        Task<IQueryable<Arac>> GetAllListAsync();
        IQueryable<Arac> GetAllListAsync(Func<Arac, bool> predicate);
    }
}
