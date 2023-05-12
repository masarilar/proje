using Domain.Entities;
using ModelDto.Dtos.Duyuru;
using ModelDto.Enums;

namespace Application.Interfaces.Apps
{
    public interface IDuyuruApp
    {
        Task<int> DuyuruKaydet(DtoDuyuruKaydet model);
        Task<int> DuyuruGuncelle(DtoDuyuruGuncelle model);
        Task<int> DuyuruSil(int id);
        Task<DtoDuyuruGuncelle> DuyuruGetir(int id);
        Task<List<Duyuru>> DuyuruListesiGetir();
        Task<List<Duyuru>> DuyuruListesiGetir(KategoriTipleri kategoriTip);
    }
}
