using Application.Interfaces;
using Application.Interfaces.Apps;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Mapster;
using MapsterMapper;
using ModelDto.Dtos.Dosya;
using ModelDto.Dtos.Duyuru;
using ModelDto.Enums;
using ModelDto.General;

namespace Application.DuyuruApps
{
    public class DuyuruApp : GenericService<Duyuru>, IDuyuruApp {
        private readonly IDuyuruRepository _duyuruRepository;
        private readonly IDosyaRepository _dosyaRepository;
        private readonly IMapper _mapper;
        public DuyuruApp(IRepository<Duyuru> repository, IDuyuruRepository duyuruRepository, IMapper mapper, IDosyaRepository dosyaRepository) : base(repository) {
            _duyuruRepository = duyuruRepository;
            _mapper = mapper;
            _dosyaRepository = dosyaRepository;
        }

        public async Task<DtoDuyuruGuncelle> DuyuruGetir(int id) {
            var duyuru = await GetByIdAsync(id);
            var duyuruDosyasi = _dosyaRepository.GetAllListAsync(e => e.RefTip == ReferansTipleri.Duyuru && e.RefId == duyuru.Id);
            var sonuc = duyuru.Map<DtoDuyuruGuncelle>();
            if (duyuruDosyasi is not null)
                sonuc.YuklenmisDosya = duyuruDosyasi.Map<List<DtoDosya>>();
            return sonuc;
        }
        public async Task<int> DuyuruGuncelle(DtoDuyuruGuncelle model) {
            var duyuru = await GetByIdAsync(model.Id);
            var sonuc = _mapper.Map(model, duyuru);
            if (duyuru.Id > 0 && model.DosyaYukle != null && !string.IsNullOrEmpty(model.AnaResim)) {
                var dosyaYukle = new DtoDosya() {
                    Adi = model.DosyaYukle.DosyaAdi,
                    Yol = model.AnaResim,
                    Uzanti = model.DosyaYukle.DosyaUzantisi,
                    RefTip = ReferansTipleri.Duyuru,
                    RefId = duyuru.Id
                };
                await _dosyaRepository.AddAsync(dosyaYukle.Map<Dosya>());
            }
            return await UpdateAsync(sonuc);
        }
        public async Task<int> DuyuruKaydet(DtoDuyuruKaydet model) {
            var duyuruId = await AddAsync(model.Map<Duyuru>());
            if (duyuruId > 0 && model.DosyaYukle != null && !string.IsNullOrEmpty(model.AnaResim)) {
                var dosyaYukle = new DtoDosya() {
                    Adi = model.DosyaYukle.DosyaAdi,
                    Yol = model.AnaResim,
                    Uzanti = model.DosyaYukle.DosyaUzantisi,
                    RefTip = ReferansTipleri.Duyuru,
                    RefId = duyuruId
                };
                await _dosyaRepository.AddAsync(dosyaYukle.Map<Dosya>());
            }
            return duyuruId;
        }
        public async Task<List<Duyuru>> DuyuruListesiGetir() {
            var sonuc = await _duyuruRepository.GetAllListAsync();
            return sonuc.ToList();
        }
        public async Task<List<Duyuru>> DuyuruListesiGetir(KategoriTipleri kategoriTip) {
            var sonuc = _duyuruRepository.GetAllListAsync(e => e.Kategori.KategoriTipId == (int)kategoriTip
                                                            && (e.YayinTarih.Date <= DateTime.Now.Date && e.YayinBitisTarih.Date >= DateTime.Now.Date));
            return sonuc.ToList();
        }
        public async Task<int> DuyuruSil(int id) => await RemoveAsync(id);
    }
}
