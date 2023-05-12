using Application.Interfaces;
using Application.Interfaces.Apps;
using Application.Interfaces.Repositories;
using Domain.Entities;
using MapsterMapper;
using ModelDto.Dtos.Arac;
using ModelDto.Dtos.Dosya;
using ModelDto.Enums;
using ModelDto.General;

namespace Application.AracApps
{
    public class AracApp : GenericService<Arac>, IAracApp
    {
        private readonly IAracRepository _aracRepository;
        private readonly IMapper _mapper;
        private readonly IDosyaRepository _dosyaRepository;
        public AracApp(IRepository<Arac> repository, IAracRepository aracRepository, IMapper mapper, IDosyaRepository dosyaRepository) : base(repository)
        {
            _aracRepository = aracRepository;
            _mapper = mapper;
            _dosyaRepository = dosyaRepository;
        }
        public async Task<int> AracKaydet(DtoAracKaydet model)
        {
            var aracId = await AddAsync(model.Map<Arac>());
            if (aracId > 0 && model.DosyaYukle != null && !string.IsNullOrEmpty(model.Resimleri))
            {
                var dosyaYukle = new DtoDosya()
                {
                    Adi = model.DosyaYukle.DosyaAdi,
                    Yol = model.Resimleri,
                    Uzanti = model.DosyaYukle.DosyaUzantisi,
                    RefTip = ReferansTipleri.Arac,
                    RefId = aracId
                };
                await _dosyaRepository.AddAsync(dosyaYukle.Map<Dosya>());
            }
            return aracId;
        }
        // public async Task<int> AracGuncelle(DtoAracGuncelle model) => await UpdateAsync(model.Map<Arac>());
        public async Task<int> AracGuncelle(DtoAracGuncelle model)
        {
            var arac = await GetByIdAsync(model.Id);
            var sonuc = _mapper.Map(model, arac);
            if (arac.Id > 0 && model.DosyaYukle != null && !string.IsNullOrEmpty(model.Resimleri))
            {
                var dosyaYukle = new DtoDosya()
                {
                    Adi = model.DosyaYukle.DosyaAdi,
                    Yol = model.Resimleri,
                    Uzanti = model.DosyaYukle.DosyaUzantisi,
                    RefTip = ReferansTipleri.Arac,
                    RefId = arac.Id
                };
                await _dosyaRepository.AddAsync(dosyaYukle.Map<Dosya>());
            }
            return await UpdateAsync(sonuc);
        }
        //public async Task<int> AracSil(DtoAracSil model) => await RemoveAsync(model.Id);
        public async Task<List<Arac>> AracListesiGetir()
        {
            var sonuc = await _aracRepository.GetAllListAsync();
            //var liste = await GetAllAsync();
            return sonuc.ToList();
        }
        public async Task<DtoAracGuncelle> AracGetir(int id)
        {
            var arac = await GetByIdAsync(id);
            var aracDosyasi = _dosyaRepository.GetAllListAsync(e => e.RefTip == ReferansTipleri.Arac && e.RefId == arac.Id);
            var sonuc = arac.Map<DtoAracGuncelle>();
            if (aracDosyasi is not null)
                sonuc.YuklenmisDosya = aracDosyasi.Map<List<DtoDosya>>();
            return sonuc;
        }
        public async Task<int> AracSil(int id) => await RemoveAsync(id);
    }
}
