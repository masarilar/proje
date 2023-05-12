using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.Birim;
using ModelDto.Dtos.Calisma;
using ModelDto.Dtos.Dosya;
using ModelDto.Dtos.Gorev;
using ModelDto.Dtos.Kullanici;
using ModelDto.Enums;
using WebUI.Genel;

namespace WebUI.Controllers
{
    public class KullaniciController : UIBaseController
    {
        private readonly IDosyaServis _dosyaServis;
        private readonly IValidator<DtoKullaniciKaydet> _kullaniciKayitValidator;
        private readonly IValidator<DtoKullaniciGuncelle> _kullaniciGuncelleValidator;
        public KullaniciController(IRestSharpRequest restSharpRequest, IDosyaServis dosyaServis, IValidator<DtoKullaniciKaydet> kullaniciKayitValidator, IValidator<DtoKullaniciGuncelle> kullaniciGuncelleValidator) : base(restSharpRequest)
        {
            _dosyaServis = dosyaServis;
            _kullaniciKayitValidator = kullaniciKayitValidator;
            _kullaniciGuncelleValidator = kullaniciGuncelleValidator;
        }
        public async Task SayfaVeriAta()
        {
            var gorevListesi = await SendRequestWithoutToken<List<DtoGorev>>("Gorev", RestSharp.Method.GET);
            ViewBag.gorevListesi = gorevListesi.ToSelectList("Id", "Adi");
            var calismaListesi = await SendRequestWithoutToken<List<DtoCalismaTur>>("Calisma", RestSharp.Method.GET);
            ViewBag.calismaListesi = calismaListesi.ToSelectList("Id", "Adi");
            var birimListesi = await SendRequestWithoutToken<List<DtoBirim>>("Birim", RestSharp.Method.GET);
            ViewBag.birimListesi = birimListesi.ToSelectList("Id", "Adi");
        }
        #region Views
        public async Task<IActionResult> KaydetView()
        {
            await SayfaVeriAta();
            return View(new DtoKullaniciGuncelle() { });
        }
        public async Task<IActionResult> ListeleView()
        {
            return View();
        }
        public async Task<PartialViewResult> KullaniciPopUpDuzenleView(int id)
        {
            await SayfaVeriAta();
            var sonuc = await SendRequestWithoutToken<DtoKullaniciGuncelle>("Kullanici/KullaniciGetir", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return PartialView("_Duzenle", sonuc);
        }

        public async Task<PartialViewResult> KullaniciProfiliPopUpDuzenleView(int id)
        {
            id = 134;//Daha sonra kaldırılacak.
            await SayfaVeriAta();
            var sonuc = await SendRequestWithoutToken<DtoKullaniciGuncelle>("Kullanici/KullaniciProfiliGetir", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return PartialView("_Duzenle", sonuc);
        }
        #endregion
        #region Funcs
        [HttpPost]
        public async Task<IActionResult> Kaydet(DtoKullaniciKaydet model)
        {

            if (model.DosyaYukle is not null)
            {
                var dosyaKayitSonuc = await _dosyaServis.DosyaKaydet(model.DosyaYukle.Dosya, model.DosyaYukle.DosyaUzantisi);
                model.Resim = dosyaKayitSonuc.RelativePath.Replace("\\", "/");
            }
            model.AdSoyad = $"{model.Ad} {model.Soyad}";

            var modelValidator = _kullaniciKayitValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });

            var sonuc = await SendRequestWithoutToken<int>("Kullanici/KullaniciKaydet", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }
        [HttpPost]
        public async Task<IActionResult> Guncelle(DtoKullaniciGuncelle model)
        {
            model.AdSoyad = $"{model.Ad} {model.Soyad}";
            var modelValidator = _kullaniciGuncelleValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });

            if (model.DosyaYukle is not null)
            {
                var dosyaKayitSonuc = await _dosyaServis.DosyaKaydet(model.DosyaYukle.Dosya, model.DosyaYukle.DosyaUzantisi);
                model.Resim = dosyaKayitSonuc.RelativePath.Replace("\\", "/");
            }
            var sonuc = await SendRequestWithoutToken<int>("Kullanici/KullaniciGuncelle", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }
        [HttpPost]
        public async Task<IActionResult> Sil(int id)
        {
            var sonuc = await SendRequestWithoutToken<int>("Kullanici/KullaniciSil", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return Json(new { sonuc });
        }
        [HttpPost]
        public async Task<IActionResult> ListeGetir()
        {
            var liste = await SendRequestWithoutToken<List<DtoKullanici>>("Kullanici", RestSharp.Method.GET);
            return Json(new { recordsFiltered = liste.Count, recordsTotal = liste.Count, data = liste });
        }

        #endregion
    }
}
