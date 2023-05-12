using Domain.Entities;
using ModelDto.Dtos.Kategori;
using ModelDto.Enums;

namespace Application.Interfaces.Apps
{
    public interface IKategoriApp
    {
        Task<int> KategoriKaydet(DtoKategoriKaydet model);
        Task<int> KategoriSil(int id);
        Task<int> KategoriGuncelle(DtoKategoriGuncelle model);
        Task<Kategori> KategoriGetir(int id);
        Task<List<Kategori>> KategoriListesiGetir();
        Task<List<Kategori>> KategoriListesiGetir(KategoriTipleri kategoriTip);
    }
}
