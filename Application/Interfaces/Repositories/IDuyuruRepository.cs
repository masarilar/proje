using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IDuyuruRepository : IRepository<Duyuru>
    {
        Task<IQueryable<Duyuru>> GetAllListAsync();
        IQueryable<Duyuru> GetAllListAsync(Func<Duyuru, bool> predicate);
    }
}
