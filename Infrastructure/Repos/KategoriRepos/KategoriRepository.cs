using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos.KategoriRepos
{
    public class KategoriRepository : Repository<Kategori>, IKategoriRepository
    {
        public KategoriRepository(IApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        public IQueryable<Kategori> GetAllListAsync(Func<Kategori, bool> predicate)
        => _applicationDbContext.Kategoriler.AsNoTracking()
        .Include(e => e.KategoriTip).Where(predicate).AsQueryable();

        public async Task<IQueryable<Kategori>> GetAllListAsync() => _applicationDbContext.Kategoriler.Include(e => e.KategoriTip).AsNoTracking();
    }
}
