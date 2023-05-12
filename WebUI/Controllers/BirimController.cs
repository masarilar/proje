using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.Birim;
using ModelDto.Enums;
using WebUI.Genel;

namespace WebUI.Controllers
{
    public class BirimController : UIBaseController
    {
        private readonly IValidator<DtoBirimKaydet> _birimKayitValidator;
        private readonly IValidator<DtoBirimGuncelle> _birimGuncelleValidator;
        public BirimController(IRestSharpRequest restSharpRequest, IValidator<DtoBirimKaydet> birimKayitValidator, IValidator<DtoBirimGuncelle> birimGuncelleValidator) : base(restSharpRequest)
        {
            _birimKayitValidator = birimKayitValidator;
            _birimGuncelleValidator = birimGuncelleValidator;
        }

        public async Task SayfaVeriAta()
        {
            var birimListesi = await SendRequestWithoutToken<List<DtoBirim>>("Birim", RestSharp.Method.GET);
            ViewBag.birimListesi = birimListesi.ToSelectList("Id", "Adi");
        }

        #region
        public async Task<IActionResult> KaydetView()
        {
            await SayfaVeriAta();
            return View(new DtoBirimKaydet()
            {
            });
        }

        public async Task<IActionResult> ListeleView()
        {
            return View();
        }

        public async Task<PartialViewResult> BirimPopUpDuzenleView(int id)
        {
            await SayfaVeriAta();
            var sonuc = await SendRequestWithoutToken<DtoBirimKaydet>("Birim/BirimGetir", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return PartialView("_Duzenle", sonuc);
        }
        #endregion

        #region
        [HttpPost]
        public async Task<IActionResult> Kaydet(DtoBirimKaydet model)
        {
            var modelValidator = _birimKayitValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });
            var sonuc = await SendRequestWithoutToken<int>("Birim/BirimKaydet", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }

        [HttpPost]
        public async Task<IActionResult> Guncelle(DtoBirimGuncelle model)
        {
            if (model.Id != model.UstBirimId)
            {
                var modelValidator = _birimGuncelleValidator.Validate(model);
                if (!modelValidator.IsValid)
                    return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });
                var sonuc = await SendRequestWithoutToken<int>("Birim/BirimGuncelle", RestSharp.Method.POST, RestRequestContentType.application_json, model);
                return Json(new { sonuc });
            }
            else
            {
                return Json(new { });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Sil(int id)
        {
            var sonuc = await SendRequestWithoutToken<int>("Birim/BirimSil", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return Json(new { sonuc });
        }

        [HttpPost]
        public async Task<IActionResult> ListeGetir()
        {
            var liste = await SendRequestWithoutToken<List<DtoBirim>>("Birim", RestSharp.Method.GET);
            return Json(new { recordsFiltered = liste.Count, recordsTotal = liste.Count, data = liste });
        }
        #endregion

    }
}
