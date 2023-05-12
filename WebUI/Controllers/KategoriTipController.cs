using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.KategoriTip;
using ModelDto.Enums;
using WebUI.Genel;

namespace WebUI.Controllers
{
    public class KategoriTipController : UIBaseController
    {
        private readonly IValidator<DtoKategoriTipKaydet> _kategoriTipKayitValidator;
        private readonly IValidator<DtoKategoriTipGuncelle> _kategoriTipGuncelleValidator;
        public KategoriTipController(IRestSharpRequest restSharpRequest, IValidator<DtoKategoriTipKaydet> kategoriTipKayitValidator, IValidator<DtoKategoriTipGuncelle> kategoriTipGuncelleValidator) : base(restSharpRequest)
        {
            _kategoriTipKayitValidator = kategoriTipKayitValidator;
            _kategoriTipGuncelleValidator = kategoriTipGuncelleValidator;
        }
        #region Views
        public async Task<IActionResult> KaydetView()
        {
            return View(new DtoKategoriTipKaydet()
            {
            });
        }
        public async Task<IActionResult> ListeleView()
        {
            return View();
        }
        public async Task<PartialViewResult> KategoriTipPopUpDuzenleView(int id)
        {
            var sonuc = await SendRequestWithoutToken<DtoKategoriTipKaydet>("KategoriTip/KategoriTipGetir", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return PartialView("_Duzenle", sonuc);
        }
        #endregion
        #region Funcs
        [HttpPost]
        public async Task<IActionResult> Kaydet(DtoKategoriTipKaydet model)
        {
            var modelValidator = _kategoriTipKayitValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });
            var sonuc = await SendRequestWithoutToken<int>("KategoriTip/KategoriTipKaydet", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }
        [HttpPost]
        public async Task<IActionResult> Guncelle(DtoKategoriTipGuncelle model)
        {
            var modelValidator = _kategoriTipGuncelleValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });
            var sonuc = await SendRequestWithoutToken<int>("KategoriTip/KategoriTipGuncelle", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }
        [HttpPost]
        public async Task<IActionResult> Sil(int id)
        {
            var sonuc = await SendRequestWithoutToken<int>("KategoriTip/KategoriTipSil", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return Json(new { sonuc });
        }
        [HttpPost]
        public async Task<IActionResult> ListeGetir()
        {
            var liste = await SendRequestWithoutToken<List<DtoKategoriTip>>("KategoriTip", RestSharp.Method.GET);
            return Json(new { recordsFiltered = liste.Count, recordsTotal = liste.Count, data = liste });
        }
        #endregion
    }
}
