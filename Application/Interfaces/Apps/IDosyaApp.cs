using ModelDto.Dtos.Dosya;

namespace Application.Interfaces.Apps
{
    public interface IDosyaApp
    {
        Task<DtoDosya> DosyaGetir(int id);
        Task<int> DosyaSil(int id);
    }
}
