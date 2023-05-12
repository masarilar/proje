using Domain.Entities;
using ModelDto.Dtos.Gorev;

namespace Application.Interfaces.Apps
{
    public interface IGorevApp
    {
        Task<int> GorevKaydet(DtoGorevKaydet model);
        Task<int> GorevGuncelle(DtoGorevGuncelle model);
        Task<int> GorevSil(int id);
        Task<Gorev> GorevGetir(int id);
        Task<List<Gorev>> GorevListesiGetir();
    }
}
