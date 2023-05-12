using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.Duyuru;
using ModelDto.Dtos.Kategori;
using ModelDto.Enums;
using WebUI.Genel;

namespace WebUI.Controllers
{
    public class DuyuruController : UIBaseController
    {
        private readonly IDosyaServis _dosyaServis;
        private readonly IValidator<DtoDuyuruKaydet> _duyuruKayitValidator;
        private readonly IValidator<DtoDuyuruGuncelle> _duyuruGuncelleValidator;
        public DuyuruController(IRestSharpRequest restSharpRequest, IDosyaServis dosyaServis, IValidator<DtoDuyuruKaydet> duyuruKayitValidator, IValidator<DtoDuyuruGuncelle> duyuruGuncelleValidator) : base(restSharpRequest)
        {
            _dosyaServis = dosyaServis;
            _duyuruKayitValidator = duyuruKayitValidator;
            _duyuruGuncelleValidator = duyuruGuncelleValidator;
        }
        public async Task SayfaVeriAta()
        {
            var kategoriListesi = await SendRequestWithoutToken<List<DtoKategori>>("Kategori", RestSharp.Method.GET);
            ViewBag.kategoriListesi = kategoriListesi.ToSelectList("Id", "Ad");
        }
        #region Views
        public async Task<IActionResult> KaydetView()
        {
            await SayfaVeriAta();
            return View(new DtoDuyuruGuncelle() {                
                SliderGoster = (int)DuyuruSliderGoster.Goster,
                YorumEkle = (int)DuyuruYorumEkle.YorumEkle,
                Begenme = (int)DuyuruBegenme.Begen
            });
        }
        public async Task<IActionResult> ListeleView()
        {
            return View();
        }
        public async Task<PartialViewResult> DuyuruPopUpDuzenleView(int id)
        {
            await SayfaVeriAta();
            var sonuc = await SendRequestWithoutToken<DtoDuyuruGuncelle>("Duyuru/DuyuruGetir", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return PartialView("_Duzenle", sonuc);
        }
        #endregion
        #region Funcs
        [HttpPost]
        public async Task<IActionResult> Kaydet(DtoDuyuruKaydet model)
        {
            if (model.DosyaYukle is not null)
            {
                var dosyaKayitSonuc = await _dosyaServis.DosyaKaydet(model.DosyaYukle.Dosya, model.DosyaYukle.DosyaUzantisi);
                model.AnaResim = dosyaKayitSonuc.RelativePath.Replace("\\", "/");
            }
            var modelValidator = _duyuruKayitValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });
            var sonuc = await SendRequestWithoutToken<int>("Duyuru/DuyuruKaydet", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }
        [HttpPost]
        public async Task<IActionResult> Guncelle(DtoDuyuruGuncelle model)
        {
            var modelValidator = _duyuruGuncelleValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });
            if (model.DosyaYukle is not null)
            {
                var dosyaKayitSonuc = await _dosyaServis.DosyaKaydet(model.DosyaYukle.Dosya, model.DosyaYukle.DosyaUzantisi);
                model.AnaResim = dosyaKayitSonuc.RelativePath.Replace("\\", "/");
            }
            var sonuc = await SendRequestWithoutToken<int>("Duyuru/DuyuruGuncelle", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }
        [HttpPost]
        public async Task<IActionResult> Sil(int id)
        {
            var sonuc = await SendRequestWithoutToken<int>("Duyuru/DuyuruSil", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return Json(new { sonuc });
        }
        [HttpPost]
        public async Task<IActionResult> ListeGetir()
        {
            var liste = await SendRequestWithoutToken<List<DtoDuyuru>>("Duyuru", RestSharp.Method.GET);
            return Json(new { recordsFiltered = liste.Count, recordsTotal = liste.Count, data = liste });
        }
        #endregion
    }
}