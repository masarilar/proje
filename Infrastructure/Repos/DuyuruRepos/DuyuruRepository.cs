using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos.DuyuruRepos
{
    public class DuyuruRepository : Repository<Duyuru>, IDuyuruRepository
    {
        public DuyuruRepository(IApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public IQueryable<Duyuru> GetAllListAsync(Func<Duyuru, bool> predicate)
            => _applicationDbContext.Duyurular.AsNoTracking()
            .Include(e => e.Kategori).Where(predicate).AsQueryable();
        public async Task<IQueryable<Duyuru>> GetAllListAsync() => _applicationDbContext.Duyurular.Include(e => e.Kategori).AsNoTracking();

    }
}
