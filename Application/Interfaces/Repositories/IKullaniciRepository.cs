using Domain.Entities;
using ModelDto.Dtos.Kullanici;

namespace Application.Interfaces.Repositories
{
    public interface IKullaniciRepository : IRepository<Kullanici>
    {
        Task<IQueryable<Kullanici>> GetAllListAsync();
        IQueryable<Kullanici> GetAllListAsync(Func<Kullanici, bool> predicate);
        Task<Kullanici> KullaniciGirisAsync(DtoKullaniciGiris model);
       
    }
}
