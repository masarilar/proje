using Application.Interfaces;
using Application.Interfaces.Apps;
using Domain.Entities;
using MapsterMapper;
using ModelDto.Dtos.Calisma;
using ModelDto.General;

namespace Application.CalismaApps
{
    public class CalismaApp : GenericService<CalismaTur>, ICalismaApp
    {
        private readonly IMapper _mapper;
        public CalismaApp(IRepository<CalismaTur> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;   
        }

        public async Task<int> CalismaKaydet(DtoCalismaTurKaydet model) => await AddAsync(model.Map<CalismaTur>());
        public async Task<int> CalismaGuncelle(DtoCalismaTurGuncelle model)
        {
            var calismaTur = await GetByIdAsync(model.Id);
            var sonuc = _mapper.Map(model, calismaTur);
            return await UpdateAsync(sonuc);
        }
        public async Task<int> CalismaSil(int id) => await RemoveAsync(id);
        public async Task<CalismaTur> CalismaGetir(int id) => await GetByIdAsync(id);
        public async Task<List<CalismaTur>> CalismaListesiGetir()
        {
            var sonuc = await GetAllAsync();
            return sonuc.ToList();
        }
    }
}
