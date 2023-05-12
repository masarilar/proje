using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.Arac;
using ModelDto.Dtos.AracTipi;
using ModelDto.Enums;
using WebUI.Genel;

namespace WebUI.Controllers
{
    public class AracController : UIBaseController
    {
        private readonly IDosyaServis _dosyaServis;
        private readonly IValidator<DtoAracKaydet> _aracKayitValidator;
        private readonly IValidator<DtoAracGuncelle> _aracGuncelleValidator;

        public AracController(IRestSharpRequest restSharpRequest, IDosyaServis dosyaServis, IValidator<DtoAracKaydet> aracKayitValidator, IValidator<DtoAracGuncelle> aracGuncelleValidator) : base(restSharpRequest)
        {
            _dosyaServis = dosyaServis;
            _aracKayitValidator = aracKayitValidator;
            _aracGuncelleValidator = aracGuncelleValidator;
        }

        public async Task SayfaVeriAta()
        {
            var aracTipiListesi = await SendRequestWithoutToken<List<DtoAracTipi>>("AracTipi", RestSharp.Method.GET);
            ViewBag.aracTipiListesi = aracTipiListesi.ToSelectList("Id", "Adi");
        }

        #region
        public async Task<IActionResult> KaydetView()
        {
            await SayfaVeriAta();
            return View(new DtoAracGuncelle()
            {
                //DemirbasDurumu = (int)AracDemirbasDurumu.Kiralık,
                //KilometredeBakimaGider = (int)AracKilometredeBakimaGider.OnBesBinKm,
                Resimleri = "ARAC TEST"
            });
        }

        public async Task<IActionResult> ListeleView()
        {
            return View();
        }

        public async Task<PartialViewResult> AracPopUpDuzenleView(int id)
        {
            await SayfaVeriAta();
            var sonuc = await SendRequestWithoutToken<DtoAracGuncelle>("Arac/AracGetir", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return PartialView("_Duzenle", sonuc);
        }
        #endregion

        #region
        [HttpPost]
        public async Task<IActionResult> Kaydet(DtoAracKaydet model)
        {
            if (model.DosyaYukle is not null)
            {
                var dosyaKayitSonuc = await _dosyaServis.DosyaKaydet(model.DosyaYukle.Dosya, model.DosyaYukle.DosyaUzantisi);
                model.Resimleri = dosyaKayitSonuc.RelativePath.Replace("\\", "/");
            }
            var modelValidator = _aracKayitValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });
            var sonuc = await SendRequestWithoutToken<int>("Arac/AracKaydet", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }

        [HttpPost]
        public async Task<IActionResult> Guncelle(DtoAracGuncelle model)
        {
            var modelValidator = _aracGuncelleValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });
            if (model.DosyaYukle is not null)
            {
                var dosyaKayitSonuc = await _dosyaServis.DosyaKaydet(model.DosyaYukle.Dosya, model.DosyaYukle.DosyaUzantisi);
                model.Resimleri = dosyaKayitSonuc.RelativePath.Replace("\\", "/");
            } 
            var sonuc = await SendRequestWithoutToken<int>("Arac/AracGuncelle", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }

        [HttpPost]
        public async Task<IActionResult> Sil(int id)
        {
            var sonuc = await SendRequestWithoutToken<int>("Arac/AracSil", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return Json(new { sonuc });
        }

        [HttpPost]
        public async Task<IActionResult> ListeGetir()
        {
            var liste = await SendRequestWithoutToken<List<DtoArac>>("Arac", RestSharp.Method.GET);
            return Json(new { recordsFiltered = liste.Count, recordsTotal = liste.Count, data = liste });
        }
        #endregion
    }
}
