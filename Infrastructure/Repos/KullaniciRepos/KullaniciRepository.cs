using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ModelDto.Dtos.Kullanici;

namespace Infrastructure.Repos.KullaniciRepos
{
    public class KullaniciRepository : Repository<Kullanici>, IKullaniciRepository
    {
        public KullaniciRepository(IApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
        public IQueryable<Kullanici> GetAllListAsync(Func<Kullanici, bool> predicate)
            => _applicationDbContext.Kullanicilar.AsNoTracking()
            .Include(e => e.Birim).Where(predicate).AsQueryable().Include(e => e.Gorev).Where(predicate).AsQueryable().Include(e => e.CalismaTur).Where(predicate).AsQueryable();

        public async Task<IQueryable<Kullanici>> GetAllListAsync()
            => _applicationDbContext.Kullanicilar.Include(e => e.Birim).Include(e => e.Gorev).Include(e => e.CalismaTur).AsNoTracking();

        public async Task<Kullanici> KullaniciGirisAsync(DtoKullaniciGiris model)
            => await _applicationDbContext.Kullanicilar.FirstOrDefaultAsync(e => e.Eposta == model.Eposta && e.Parola == model.Parola);
        
    }
}
