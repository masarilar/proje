using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IKategoriRepository : IRepository<Kategori>
    {
        Task<IQueryable<Kategori>> GetAllListAsync();
        IQueryable<Kategori> GetAllListAsync(Func<Kategori, bool> predicate);
    }
}
