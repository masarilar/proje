using Application.Interfaces;
using Application.Interfaces.Apps;
using Application.Interfaces.Repositories;
using Domain.Entities;
using MapsterMapper;
using ModelDto.Dtos.Dosya;
using ModelDto.Dtos.Sofor;
using ModelDto.Enums;
using ModelDto.General;

namespace Application.SoforApps
{
    public class SoforApp : GenericService<Sofor>, ISoforApp
    {
        private readonly ISoforRepository _soforRepository;
        private readonly IMapper _mapper;
        private readonly IDosyaRepository _dosyaRepository;
        public SoforApp(IRepository<Sofor> repository, ISoforRepository soforRepository, IMapper mapper, IDosyaRepository dosyaRepository) : base(repository)
        {
            _soforRepository = soforRepository;
            _mapper = mapper;
            _dosyaRepository = dosyaRepository;
        }
        public async Task<int> SoforKaydet(DtoSoforKaydet model)
        {
            var soforId = await AddAsync(model.Map<Sofor>());
            if (soforId > 0 && model.DosyaYukle != null && !string.IsNullOrEmpty(model.Resim))
            {
                var dosyaYukle = new DtoDosya()
                {
                    Adi = model.DosyaYukle.DosyaAdi,
                    Yol = model.Resim,
                    Uzanti = model.DosyaYukle.DosyaUzantisi,
                    RefTip = ReferansTipleri.Sofor,
                    RefId = soforId
                };
                await _dosyaRepository.AddAsync(dosyaYukle.Map<Dosya>());
            }
            return soforId;
        }
        //public async Task<int> SoforGuncelle(DtoSoforGuncelle model) => await UpdateAsync(model.Map<Sofor>());
        public async Task<int> SoforGuncelle(DtoSoforGuncelle model)
        {
            var sofor = await GetByIdAsync(model.Id);
            var sonuc = _mapper.Map(model, sofor);
            if (sofor.Id > 0 && model.DosyaYukle != null && !string.IsNullOrEmpty(model.Resim))
            {
                var dosyaYukle = new DtoDosya()
                {
                    Adi = model.DosyaYukle.DosyaAdi,
                    Yol = model.Resim,
                    Uzanti = model.DosyaYukle.DosyaUzantisi,
                    RefTip = ReferansTipleri.Sofor,
                    RefId = sofor.Id
                };
                await _dosyaRepository.AddAsync(dosyaYukle.Map<Dosya>());
            }
            return await UpdateAsync(sonuc);
        }
        public async Task<int> SoforSil(DtoSoforSil model) => await RemoveAsync(model.Id);
        public async Task<List<Sofor>> SoforListesiGetir()
        {
            var sonuc = await _soforRepository.GetAllListAsync();
            //var liste = await GetAllAsync();
            return sonuc.ToList();
        }
        public async Task<DtoSoforGuncelle> SoforGetir(int id)
        {
            var sofor = await GetByIdAsync(id);
            var soforDosyasi = _dosyaRepository.GetAllListAsync(e => e.RefTip == ReferansTipleri.Sofor && e.RefId == sofor.Id);
            var sonuc = sofor.Map<DtoSoforGuncelle>();
            if (soforDosyasi is not null)
                sonuc.YuklenmisDosya = soforDosyasi.Map<List<DtoDosya>>();
            return sonuc;
        }
        public async Task<int> SoforSil(int id) => await RemoveAsync(id);
    }
}
