using Domain.Entities;
using ModelDto.Dtos.Birim;

namespace Application.Interfaces.Apps
{
    public interface IBirimApp
    {
        Task<int> BirimKaydet(DtoBirimKaydet model);
        Task<int> BirimGuncelle(DtoBirimGuncelle model);
        Task<int> BirimSil(int id);
        Task<List<Birim>> BirimListesiGetir();
        Task<Birim> BirimGetir(int id);
    }
}
