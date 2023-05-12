using Domain.Entities;
using ModelDto.Dtos.Kullanici;

namespace Application.Interfaces.Apps
{
    public interface IKullaniciApp
    {
        Task<int> KullaniciKaydet(DtoKullaniciKaydet model);
        Task<int> KullaniciSil(int id);
        Task<int> KullaniciGuncelle(DtoKullaniciGuncelle model);
        Task<DtoKullaniciGuncelle> KullaniciGetir(int id);
        Task<List<Kullanici>> KullaniciListesiGetir();
        Task<int> KullaniciGiris(DtoKullaniciGiris model);
        Task<DtoKullaniciGuncelle> KullaniciProfiliGetir(int id);
    
    }
}