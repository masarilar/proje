using Domain.Entities;
using ModelDto.Dtos.Sofor;

namespace Application.Interfaces.Apps
{
    public interface ISoforApp
    {
        Task<int> SoforKaydet(DtoSoforKaydet model);
        Task<int> SoforGuncelle(DtoSoforGuncelle model);
        Task<int> SoforSil(int id);
        Task<List<Sofor>> SoforListesiGetir();
        Task<DtoSoforGuncelle> SoforGetir(int id);
    }
}
