using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.Kategori;
using ModelDto.Dtos.KategoriTip;
using ModelDto.Enums;
using WebUI.Genel;

namespace WebUI.Controllers
{
    public class KategoriController : UIBaseController
    {
        private readonly IValidator<DtoKategoriKaydet> _kategoriKayitValidator;
        private readonly IValidator<DtoKategoriGuncelle> _kategoriGuncelleValidator;
        public KategoriController(IRestSharpRequest restSharpRequest, IValidator<DtoKategoriKaydet> kategoriKayitValidator, IValidator<DtoKategoriGuncelle> kategoriGuncelleValidator) : base(restSharpRequest)
        {
            _kategoriKayitValidator = kategoriKayitValidator;
            _kategoriGuncelleValidator = kategoriGuncelleValidator;
        }
        public async Task SayfaVeriAta()
        {
            var kategoriTipListesi = await SendRequestWithoutToken<List<DtoKategoriTip>>("KategoriTip", RestSharp.Method.GET);
            ViewBag.kategoriTipListesi = kategoriTipListesi.ToSelectList("Id", "TipAdi");
        }
        #region Views
        public async Task<IActionResult> KaydetView()
        {
            await SayfaVeriAta();
            return View(new DtoKategoriKaydet()
            {
            });
        }
        public async Task<IActionResult> ListeleView()
        {
            return View();
        }
        public async Task<PartialViewResult> KategoriPopUpDuzenleView(int id)
        {
            await SayfaVeriAta();
            var sonuc = await SendRequestWithoutToken<DtoKategoriKaydet>("Kategori/KategoriGetir", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return PartialView("_Duzenle", sonuc);
        }
        #endregion
        #region Funcs
        [HttpPost]
        public async Task<IActionResult> Kaydet(DtoKategoriKaydet model)
        {
            var modelValidator = _kategoriKayitValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });
            var sonuc = await SendRequestWithoutToken<int>("Kategori/KategoriKaydet", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }
        [HttpPost]
        public async Task<IActionResult> Guncelle(DtoKategoriGuncelle model)
        {
            var modelValidator = _kategoriGuncelleValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });
            var sonuc = await SendRequestWithoutToken<int>("Kategori/KategoriGuncelle", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }
        [HttpPost]
        public async Task<IActionResult> Sil(int id)
        {
            var sonuc = await SendRequestWithoutToken<int>("Kategori/KategoriSil", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return Json(new { sonuc });
        }
        [HttpPost]
        public async Task<IActionResult> ListeGetir()
        {
            var liste = await SendRequestWithoutToken<List<DtoKategori>>("Kategori", RestSharp.Method.GET);
            return Json(new { recordsFiltered = liste.Count, recordsTotal = liste.Count, data = liste });
        }
        #endregion
    }
}
