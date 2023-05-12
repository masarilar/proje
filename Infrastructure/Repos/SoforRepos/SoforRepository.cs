using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos.SoforRepos
{
    public class SoforRepository : Repository<Sofor>, ISoforRepository
    {
        public SoforRepository(IApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public IQueryable<Sofor> GetAllListAsync(Func<Sofor, bool> predicate)
             => _applicationDbContext.Soforler.AsNoTracking()
            .Include(e => e.Kullanici).Where(predicate).AsQueryable();

        public async Task<IQueryable<Sofor>> GetAllListAsync() => _applicationDbContext.Soforler.Include(e => e.Kullanici).AsNoTracking();

    }
}
