using Application.Interfaces;
using Application.Interfaces.Apps;
using Domain.Entities;
using ModelDto.Dtos.AracTipi;
using ModelDto.General;

namespace Application.AracTipiApps
{
    public class AracTipiApp : GenericService<AracTipi>, IAracTipiApp
    {
        public AracTipiApp(IRepository<AracTipi> repository) : base(repository)
        {
        }

        public async Task<int> AracTipiKaydet(DtoAracTipiKaydet model) => await AddAsync(model.Map<AracTipi>());
        public async Task<int> AracTipiGuncelle(DtoAracTipiGuncelle model) => await UpdateAsync(model.Map<AracTipi>());
        public async Task<int> AracTipiSil(DtoAracTipiSil model) => await RemoveAsync(model.Id);
        public async Task<List<AracTipi>> AracTipiListesiGetir()
        {
            var liste= await GetAllAsync();
            return liste.ToList();
        }
        public async Task<AracTipi> AracTipiGetir(int id)
        {
            var ArabaTipiGetir = await GetByIdAsync(id);
            return ArabaTipiGetir;
        }
        public async Task<int> AracTipiSil(int id) => await RemoveAsync(id);
    }
}
