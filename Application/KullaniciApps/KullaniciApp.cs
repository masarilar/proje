using Application.Interfaces;
using Application.Interfaces.Apps;
using Application.Interfaces.Repositories;
using Domain.Entities;
using MapsterMapper;
using ModelDto.Dtos.Dosya;
using ModelDto.Dtos.Kullanici;
using ModelDto.Enums;
using ModelDto.General;

namespace Application.KullaniciApps
{
    public class KullaniciApp : GenericService<Kullanici>, IKullaniciApp
    {
        private readonly IKullaniciRepository _kullaniciRepository;
        private readonly IMapper _mapper;
        private readonly IDosyaRepository _dosyaRepository;
        public KullaniciApp(IRepository<Kullanici> repository, IKullaniciRepository kullaniciRepository, IMapper mapper, IDosyaRepository dosyaRepository) : base(repository)
        {
            _kullaniciRepository = kullaniciRepository;
            _mapper = mapper;
            _dosyaRepository = dosyaRepository;
        }
        public async Task<int> KullaniciKaydet(DtoKullaniciKaydet model)
        {
            var kullaniciId = await AddAsync(model.Map<Kullanici>());
            if (kullaniciId > 0 && model.DosyaYukle != null && !string.IsNullOrEmpty(model.Resim))
            {
                var dosyaYukle = new DtoDosya()
                {
                    Adi = model.DosyaYukle.DosyaAdi,
                    Yol = model.Resim,
                    Uzanti = model.DosyaYukle.DosyaUzantisi,
                    RefTip = ReferansTipleri.Kullanici,
                    RefId = kullaniciId
                };
                await _dosyaRepository.AddAsync(dosyaYukle.Map<Dosya>());
            }
            return kullaniciId;
        }

        public async Task<int> KullaniciSil(int id) => await RemoveAsync(id);

        public async Task<int> KullaniciGuncelle(DtoKullaniciGuncelle model)
        {
            var kullanici = await GetByIdAsync(model.Id);
            var sonuc = _mapper.Map(model, kullanici);
            if (kullanici.Id > 0 && model.DosyaYukle != null && !string.IsNullOrEmpty(model.Resim))
            {
                var dosyaYukle = new DtoDosya()
                {
                    Adi = model.DosyaYukle.DosyaAdi,
                    Yol = model.Resim,
                    Uzanti = model.DosyaYukle.DosyaUzantisi,
                    RefTip = ReferansTipleri.Kullanici,
                    RefId = kullanici.Id
                };
                await _dosyaRepository.AddAsync(dosyaYukle.Map<Dosya>());
            }
            return await UpdateAsync(sonuc);
        }

        //public async Task<Kullanici> KullaniciGetir(int id) => await GetByIdAsync(id);

        public async Task<List<Kullanici>> KullaniciListesiGetir()
        {
            var sonuc = await _kullaniciRepository.GetAllListAsync();
            //var sonuc = await GetAllAsync();
            return sonuc.ToList();
        }

        public async Task<int> KullaniciGiris(DtoKullaniciGiris model)
        {
            var kullaniciGiris = await _kullaniciRepository.KullaniciGirisAsync(model);
            if (kullaniciGiris != null && kullaniciGiris.Id > 0)
                return kullaniciGiris.Id;
            else
                return 0;

        }
        public async Task<DtoKullaniciGuncelle> KullaniciProfiliGetir(int id)
        {
            var kullanici = await GetByIdAsync(id);
            var kullaniciDosyasi = _dosyaRepository.GetAllListAsync(e => e.RefTip == ReferansTipleri.Kullanici && e.RefId == kullanici.Id);
            var sonuc = kullanici.Map<DtoKullaniciGuncelle>();
            if (kullaniciDosyasi is not null)
                sonuc.YuklenmisDosya = kullaniciDosyasi.Map<List<DtoDosya>>();
            return sonuc;
        }

        public async Task<DtoKullaniciGuncelle> KullaniciGetir(int id)
        {
            var kullanici = await GetByIdAsync(id);
            var kullaniciDosyasi = _dosyaRepository.GetAllListAsync(e => e.RefTip == ReferansTipleri.Kullanici && e.RefId == kullanici.Id);
            var sonuc = kullanici.Map<DtoKullaniciGuncelle>();
            if (kullaniciDosyasi is not null)
                sonuc.YuklenmisDosya = kullaniciDosyasi.Map<List<DtoDosya>>();
            return sonuc;
        }

    }
}
