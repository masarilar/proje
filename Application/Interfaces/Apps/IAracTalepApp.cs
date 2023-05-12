using Domain.Entities;
using ModelDto.Dtos.AracTalep;

namespace Application.Interfaces.Apps
{
    public interface IAracTalepApp :IRepository<AracTalep>
    {
        Task<int> AracTalepKaydet(DtoAracTalepKaydet model);
        Task<int> AracTalepGuncelle(DtoAracTalepGuncelle model);
        Task<int> AracTalepSil(int id);
        Task<List<AracTalep>> AracTalepListesiGetir();
        Task<AracTalep> AracTalepGetir(int id);
    }
}
