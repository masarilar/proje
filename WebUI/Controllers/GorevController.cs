using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.Gorev;
using ModelDto.Enums;
using WebUI.Genel;

namespace WebUI.Controllers
{
    public class GorevController : UIBaseController
    {
        private readonly IValidator<DtoGorevKaydet> _gorevKayitValidator;
        private readonly IValidator<DtoGorevGuncelle> _gorevGuncelleValidator;
        public GorevController(IRestSharpRequest restSharpRequest, IValidator<DtoGorevKaydet> gorevKayitValidator, IValidator<DtoGorevGuncelle> gorevGuncelleValidator) : base(restSharpRequest)
        {
            _gorevKayitValidator = gorevKayitValidator;
            _gorevGuncelleValidator = gorevGuncelleValidator;
        }
        #region Views
        public async Task<IActionResult> KaydetView()
        {
            return View(new DtoGorevKaydet()
            {
            });
        }
        public async Task<IActionResult> ListeleView()
        {
            return View();
        }
        public async Task<PartialViewResult> GorevPopUpDuzenleView(int id)
        {
            var sonuc = await SendRequestWithoutToken<DtoGorevKaydet>("Gorev/GorevGetir", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return PartialView("_Duzenle", sonuc);
        }
        #endregion
        #region Funcs
        [HttpPost]
        public async Task<IActionResult> Kaydet(DtoGorevKaydet model)
        {
            var modelValidator = _gorevKayitValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });
            var sonuc = await SendRequestWithoutToken<int>("Gorev/GorevKaydet", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }
        [HttpPost]
        public async Task<IActionResult> Guncelle(DtoGorevGuncelle model)
        {
            var modelValidator = _gorevGuncelleValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });
            var sonuc = await SendRequestWithoutToken<int>("Gorev/GorevGuncelle", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }
        [HttpPost]
        public async Task<IActionResult> Sil(int id)
        {
            var sonuc = await SendRequestWithoutToken<int>("Gorev/GorevSil", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return Json(new { sonuc });
        }
        [HttpPost]
        public async Task<IActionResult> ListeGetir()
        {
            var liste = await SendRequestWithoutToken<List<DtoGorev>>("Gorev", RestSharp.Method.GET);
            return Json(new { recordsFiltered = liste.Count, recordsTotal = liste.Count, data = liste });
        }
        #endregion
    }
}