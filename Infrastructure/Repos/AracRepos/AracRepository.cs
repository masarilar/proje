using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repos.AracRepos
{
    public class AracRepository : Repository<Arac>, IAracRepository
    {
        public AracRepository(IApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public IQueryable<Arac> GetAllListAsync(Func<Arac, bool> predicate)
            => _applicationDbContext.Araclar.AsNoTracking()
            .Include(e => e.AracTipi).Where(predicate).AsQueryable();

        public async Task<IQueryable<Arac>> GetAllListAsync() => _applicationDbContext.Araclar.Include(e => e.AracTipi).AsNoTracking();

    }
}
