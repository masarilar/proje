using Domain.Entities;
using ModelDto.Dtos.Arac;

namespace Application.Interfaces.Apps
{
    public interface IAracApp
    {
        Task<int> AracKaydet(DtoAracKaydet model);
        Task<int> AracGuncelle(DtoAracGuncelle model);
        Task<int> AracSil(int id);
        Task<List<Arac>> AracListesiGetir();
        Task<DtoAracGuncelle> AracGetir(int id);
    }
}
