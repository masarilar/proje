using Application.Interfaces;
using Application.Interfaces.Apps;
using Domain.Entities;
using Mapster;
using MapsterMapper;
using ModelDto.Dtos.KategoriTip;
using ModelDto.General;

namespace Application.KategoriTipApps
{
    public class KategoriTipApp : GenericService<KategoriTip>, IKategoriTipApp
    {
        private readonly IMapper _mapper;
        public KategoriTipApp(IRepository<KategoriTip> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }
        public async Task<int> KategoriTipKaydet(DtoKategoriTipKaydet model) => await AddAsync(model.Map<KategoriTip>());
        public async Task<int> KategoriTipGuncelle(DtoKategoriTipGuncelle model) 
        {
            var kategoriTip = await GetByIdAsync(model.Id);
            var sonuc = _mapper.Map(model, kategoriTip);
            return await UpdateAsync(sonuc);
        } 
        public async Task<int> KategoriTipSil(int id) => await RemoveAsync(id);
        public async Task<KategoriTip> KategoriTipGetir(int id) => await GetByIdAsync(id);
        public async Task<List<KategoriTip>> KategoriTipListesiGetir()
        {
            var sonuc = await GetAllAsync();
            return sonuc.ToList();
        }
    }
}
