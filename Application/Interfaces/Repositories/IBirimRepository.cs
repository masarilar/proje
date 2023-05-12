using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IBirimRepository : IRepository<Birim>
    {
        Task<IQueryable<Birim>> GetAllListAsync();
        IQueryable<Birim> GetAllListAsync(Func<Birim, bool> predicate);
    }
}
