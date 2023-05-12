using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repos.DosyaRepos
{
    public class DosyaRepository : Repository<Dosya>, IDosyaRepository
    {
        public DosyaRepository(IApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        public IQueryable<Dosya> GetAllListAsync(Func<Dosya, bool> predicate)
            => _applicationDbContext.Dosyalar.AsNoTracking().Where(predicate).AsQueryable();

        public async Task<Dosya> GetAsync(Expression<Func<Dosya, bool>> predicate) => await _applicationDbContext.Dosyalar.FirstOrDefaultAsync(predicate);
    }
}
