using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.Kullanici;
using ModelDto.Dtos.Sofor;
using ModelDto.Enums;
using WebUI.Genel;

namespace WebUI.Controllers
{
    public class SoforController : UIBaseController
    {
        private readonly IDosyaServis _dosyaServis;
        private readonly IValidator<DtoSoforKaydet> _soforKayitValidator;
        private readonly IValidator<DtoSoforGuncelle> _soforGuncelleValidator;
        public SoforController(IRestSharpRequest restSharpRequest, IDosyaServis dosyaServis, IValidator<DtoSoforKaydet> soforKayitValidator, IValidator<DtoSoforGuncelle> soforGuncelleValidator) : base(restSharpRequest)
        {
            _dosyaServis = dosyaServis;
            _soforKayitValidator = soforKayitValidator;
            _soforGuncelleValidator = soforGuncelleValidator;
        }

        public async Task SayfaVeriAta()
        {
            var kullaniciListesi = await SendRequestWithoutToken<List<DtoKullanici>>("Kullanici", RestSharp.Method.GET);
            ViewBag.kullaniciListesi = kullaniciListesi.ToSelectList("Id", "AdSoyad");
        }

        #region
        public async Task<IActionResult> KaydetView()
        {
            await SayfaVeriAta();
            return View(new DtoSoforGuncelle());
        }

        public async Task<IActionResult> ListeleView()
        {
            return View();
        }

        public async Task<PartialViewResult> SoforPopUpDuzenleView(int id)
        {
            await SayfaVeriAta();
            var sonuc = await SendRequestWithoutToken<DtoSoforGuncelle>("Sofor/SoforGetir", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return PartialView("_Duzenle", sonuc);
        }
        #endregion

        #region
        [HttpPost]
        public async Task<IActionResult> Kaydet(DtoSoforKaydet model)
        {
            if (model.DosyaYukle is not null)
            {
                var dosyaKayitSonuc = await _dosyaServis.DosyaKaydet(model.DosyaYukle.Dosya, model.DosyaYukle.DosyaUzantisi);
                model.Resim = dosyaKayitSonuc.RelativePath.Replace("\\", "/");
            }
            var modelValidator = _soforKayitValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });
            var sonuc = await SendRequestWithoutToken<int>("Sofor/SoforKaydet", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }

        [HttpPost]
        public async Task<IActionResult> Guncelle(DtoSoforGuncelle model)
        {
            var modelValidator = _soforGuncelleValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });
            if (model.DosyaYukle is not null)
            {
                var dosyaKayitSonuc = await _dosyaServis.DosyaKaydet(model.DosyaYukle.Dosya, model.DosyaYukle.DosyaUzantisi);
                model.Resim = dosyaKayitSonuc.RelativePath.Replace("\\", "/");
            }
           
            var sonuc = await SendRequestWithoutToken<int>("Sofor/SoforGuncelle", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }

        [HttpPost]
        public async Task<IActionResult> Sil(int id)
        {
            var sonuc = await SendRequestWithoutToken<int>("Sofor/SoforSil", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return Json(new { sonuc });
        }

        [HttpPost]
        public async Task<IActionResult> ListeGetir()
        {
            var liste = await SendRequestWithoutToken<List<DtoSofor>>("Sofor", RestSharp.Method.GET);
            return Json(new { recordsFiltered = liste.Count, recordsTotal = liste.Count, data = liste });
        }
        #endregion
    }
}
