
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.Calisma;
using ModelDto.Enums;
using WebUI.Genel;

namespace WebUI.Controllers
{
    public class CalismaController : UIBaseController
    {
        private readonly IValidator<DtoCalismaTurKaydet> _calismaTurKayitValidator;
        private readonly IValidator<DtoCalismaTurGuncelle> _calismaTurGuncelleValidator;
        public CalismaController(IRestSharpRequest restSharpRequest, IValidator<DtoCalismaTurKaydet> calismaTurKayitValidator, IValidator<DtoCalismaTurGuncelle> calismaTurGuncelleValidator) : base(restSharpRequest)
        {
            _calismaTurKayitValidator = calismaTurKayitValidator;
            _calismaTurGuncelleValidator = calismaTurGuncelleValidator;
        }
        #region Views
        public async Task<IActionResult> KaydetView()
        {
            return View(new DtoCalismaTurKaydet()
            {
            });
        }
        public async Task<IActionResult> ListeleView()
        {
            return View();
        }
        public async Task<PartialViewResult> CalismaPopUpDuzenleView(int id)
        {
            var sonuc = await SendRequestWithoutToken<DtoCalismaTurKaydet>("Calisma/CalismaGetir", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return PartialView("_Duzenle", sonuc);
        }
        #endregion
        #region Funcs
        [HttpPost]
        public async Task<IActionResult> Kaydet(DtoCalismaTurKaydet model)
        {
            var modelValidator = _calismaTurKayitValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });
            var sonuc = await SendRequestWithoutToken<int>("Calisma/CalismaKaydet", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }
        [HttpPost]
        public async Task<IActionResult> Guncelle(DtoCalismaTurGuncelle model)
        {
            var modelValidator = _calismaTurGuncelleValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });
            var sonuc = await SendRequestWithoutToken<int>("Calisma/CalismaGuncelle", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }
        [HttpPost]
        public async Task<IActionResult> Sil(int id)
        {
            var sonuc = await SendRequestWithoutToken<int>("Calisma/CalismaSil", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return Json(new { sonuc });
        }
        [HttpPost]
        public async Task<IActionResult> ListeGetir()
        {
            var liste = await SendRequestWithoutToken<List<DtoCalismaTur>>("Calisma", RestSharp.Method.GET);
            return Json(new { recordsFiltered = liste.Count, recordsTotal = liste.Count, data = liste });
        }
        #endregion
    }
}
