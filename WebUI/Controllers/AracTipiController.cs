using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.AracTipi;
using ModelDto.Enums;
using WebUI.Genel;

namespace WebUI.Controllers
{
    public class AracTipiController : UIBaseController
    {
        private readonly IValidator<DtoAracTipiKaydet> _aracTipiKayitValidator;
        private readonly IValidator<DtoAracTipiGuncelle> _aracTipiGuncelleValidator;
        public AracTipiController(IRestSharpRequest restSharpRequest, IValidator<DtoAracTipiKaydet> aracTipiKayitValidator, IValidator<DtoAracTipiGuncelle> aracTipiGuncelleValidator) : base(restSharpRequest)
        {
            _aracTipiKayitValidator = aracTipiKayitValidator;
            _aracTipiGuncelleValidator = aracTipiGuncelleValidator;
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
            return View(new DtoAracTipiKaydet()
            {
                Adi = ""
            });
        }

        public async Task<IActionResult> ListeleView()
        {
            return View();
        }

        public async Task<PartialViewResult> AracTipiPopUpDuzenleView(int id)
        {
            await SayfaVeriAta();
            var sonuc = await SendRequestWithoutToken<DtoAracTipiKaydet>("AracTipi/AracTipiGetir", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return PartialView("_Duzenle", sonuc);
        }

        #endregion

        #region
        [HttpPost]
        public async Task<IActionResult> Kaydet(DtoAracTipiKaydet model)
        {
            var modelValidator = _aracTipiKayitValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });
            var sonuc = await SendRequestWithoutToken<int>("AracTipi/AracTipiKaydet", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }

        [HttpPost]
        public async Task<IActionResult> Guncelle(DtoAracTipiGuncelle model)
        {
            var modelValidator = _aracTipiGuncelleValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });
            var sonuc = await SendRequestWithoutToken<int>("AracTipi/AracTipiGuncelle", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }

        [HttpPost]
        public async Task<IActionResult> Sil(int id)
        {
            var sonuc = await SendRequestWithoutToken<int>("AracTipi/AracTipiSil", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return Json(new { sonuc });
        }

        [HttpPost]
        public async Task<IActionResult> ListeGetir()
        {
            var liste = await SendRequestWithoutToken<List<DtoAracTipi>>("AracTipi", RestSharp.Method.GET);
            return Json(new { recordsFiltered = liste.Count, recordsTotal = liste.Count, data = liste });
        }

        #endregion
    }
}
