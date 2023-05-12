using Domain.Entities;
using ModelDto.Dtos.AracTipi;

namespace Application.Interfaces.Apps
{
    public interface IAracTipiApp
    {
        Task<int> AracTipiKaydet(DtoAracTipiKaydet model);
        Task<int> AracTipiGuncelle(DtoAracTipiGuncelle model);
        Task<int> AracTipiSil(int id);
        Task<List<AracTipi>> AracTipiListesiGetir();
        Task<AracTipi> AracTipiGetir(int id);
    }
}
