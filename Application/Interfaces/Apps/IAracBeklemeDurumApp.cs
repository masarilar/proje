using Domain.Entities;
using ModelDto.Dtos.AracBeklemeDurum;
using ModelDto.Dtos.Birim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Apps
{
    public interface IAracBeklemeDurumApp
    {
        Task<int> AracBeklemeDurumKaydet(DtoAracBeklemeDurumKaydet model);
        Task<int> AracBeklemeDurumGuncelle(DtoAracBeklemeDurumGuncelle model);
        Task<int> AracBeklemeDurumSil(int id);
        Task<List<AracBeklemeDurum>> AracBeklemeDurumListesiGetir();
        Task<AracBeklemeDurum> AracBeklemeDurumGetir(int id);
    }
}
