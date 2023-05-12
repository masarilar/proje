using Domain.Entities;
using ModelDto.Dtos.Calisma;

namespace Application.Interfaces.Apps
{
    public interface ICalismaApp
    {
        Task<int> CalismaKaydet(DtoCalismaTurKaydet model);
        Task<int> CalismaGuncelle(DtoCalismaTurGuncelle model);
        Task<int> CalismaSil(int id);
        Task<CalismaTur> CalismaGetir(int id);
        Task<List<CalismaTur>> CalismaListesiGetir();
    }
}
