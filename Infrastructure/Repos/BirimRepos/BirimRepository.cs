using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos.BirimRepos
{
    public class BirimRepository : Repository<Birim>, IBirimRepository
    {
        public BirimRepository(IApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public IQueryable<Birim> GetAllListAsync(Func<Birim, bool> predicate)
           => _applicationDbContext.Birimler.AsNoTracking()
           .Include(e => e.UstBirim).Where(predicate).AsQueryable();

        public async Task<IQueryable<Birim>> GetAllListAsync() => _applicationDbContext.Birimler.Include(e => e.UstBirim).AsNoTracking();
    }
}
