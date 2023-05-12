using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.AracBeklemeDurum;
using ModelDto.Enums;
using WebUI.Genel;

namespace WebUI.Controllers
{
    public class AracBeklemeDurumController : UIBaseController
    {
        private readonly IValidator<DtoAracBeklemeDurumKaydet> _aracBeklemeDurumKayitValidator;
        private readonly IValidator<DtoAracBeklemeDurumGuncelle> _aracBekelemeDurumGuncelleValidator;
        public AracBeklemeDurumController(IRestSharpRequest restSharpRequest, IValidator<DtoAracBeklemeDurumKaydet> aracBeklemeDurumKayitValidator, IValidator<DtoAracBeklemeDurumGuncelle> aracBeklemeDurumGuncelleValidator) : base(restSharpRequest)
        {
            _aracBeklemeDurumKayitValidator = aracBeklemeDurumKayitValidator;
            _aracBekelemeDurumGuncelleValidator = aracBeklemeDurumGuncelleValidator;
        }
        public async Task SayfaVeriAta()
        {

        }

        #region
        public async Task<IActionResult> KaydetView()
        {
            await SayfaVeriAta();
            return View(new DtoAracBeklemeDurumKaydet()
            {
            });
        }

        public async Task<IActionResult> ListeleView()
        {
            return View();
        }

        public async Task<PartialViewResult> AracBeklemeDurumPopUpDuzenleView(int id)
        {
            await SayfaVeriAta();
            var sonuc = await SendRequestWithoutToken<DtoAracBeklemeDurumKaydet>("AracBeklemeDurum/AracBeklemeDurumGetir", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return PartialView("_Duzenle", sonuc);
        }
        #endregion

        #region
        [HttpPost]
        public async Task<IActionResult> Kaydet(DtoAracBeklemeDurumKaydet model)
        {
            var modelValidator = _aracBeklemeDurumKayitValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });
            var sonuc = await SendRequestWithoutToken<int>("AracBeklemeDurum/AracBeklemeDurumKaydet", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }

        [HttpPost]
        public async Task<IActionResult> Guncelle(DtoAracBeklemeDurumGuncelle model)
        {
            var modelValidator = _aracBekelemeDurumGuncelleValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });
            var sonuc = await SendRequestWithoutToken<int>("AracBeklemeDurum/AracBeklemeDurumGuncelle", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }

        [HttpPost]
        public async Task<IActionResult> Sil(int id)
        {
            var sonuc = await SendRequestWithoutToken<int>("AracBeklemeDurum/AracBeklemeDurumSil", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return Json(new { sonuc });
        }

        [HttpPost]
        public async Task<IActionResult> ListeGetir()
        {
            var liste = await SendRequestWithoutToken<List<DtoAracBeklemeDurum>>("AracBeklemeDurum", RestSharp.Method.GET);
            return Json(new { recordsFiltered = liste.Count, recordsTotal = liste.Count, data = liste });
        }
        #endregion

    }
}