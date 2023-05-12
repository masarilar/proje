using Application.Interfaces;
using Domain.Entities;
using ModelDto.Dtos.Kategori;
using Mapster;
using MapsterMapper;
using ModelDto.Enums;
using ModelDto.General;
using Application.Interfaces.Apps;
using Application.Interfaces.Repositories;

namespace Application.KategoriApps
{
    public class KategoriApp : GenericService<Kategori>, IKategoriApp
    {
        private readonly IKategoriRepository _kategoriRepository;
        private readonly IMapper _mapper;
        public KategoriApp(IRepository<Kategori> repository, IKategoriRepository kategoriRepository, IMapper mapper) : base(repository)
        {
            _kategoriRepository = kategoriRepository;
            _mapper = mapper;
        }

        public async Task<int> KategoriKaydet(DtoKategoriKaydet model) => await AddAsync(model.Map<Kategori>());

        public async Task<int> KategoriSil(int id) => await RemoveAsync(id);

        public async Task<int> KategoriGuncelle(DtoKategoriGuncelle model)
        {
            var kategori = await GetByIdAsync(model.Id);
            var sonuc = _mapper.Map(model, kategori);
            return await UpdateAsync(sonuc);
        }

        public async Task<Kategori> KategoriGetir(int id) => await GetByIdAsync(id);

        public async Task<List<Kategori>> KategoriListesiGetir()
        {
            var sonuc = await _kategoriRepository.GetAllListAsync();
            //var sonuc = await GetAllAsync();
            return sonuc.ToList();
        }
        public async Task<List<Kategori>> KategoriListesiGetir(KategoriTipleri kategoriTip) {
            var sonuc = _kategoriRepository.GetAllListAsync(e => e.KategoriTipId == (int)kategoriTip);
            return sonuc.ToList();
        }
    }
}
