using Domain.Entities;
using ModelDto.Dtos.KategoriTip;

namespace Application.Interfaces.Apps
{
    public interface IKategoriTipApp
    {
        Task<int> KategoriTipKaydet(DtoKategoriTipKaydet model);
        Task<int> KategoriTipGuncelle(DtoKategoriTipGuncelle model);
        Task<int> KategoriTipSil(int id);
        Task<KategoriTip> KategoriTipGetir(int id);
        Task<List<KategoriTip>> KategoriTipListesiGetir();
    }
}
