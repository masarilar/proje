using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.Arac;
using ModelDto.Dtos.AracBeklemeDurum;
using ModelDto.Dtos.AracTalep;
using ModelDto.Dtos.AracTipi;
using ModelDto.Dtos.Kullanici;
using ModelDto.Dtos.Sofor;
using ModelDto.Enums;
using System.Linq;
using WebUI.Genel;

namespace WebUI.Controllers
{
    public class AracTalepController : UIBaseController
    {
        private readonly IValidator<DtoAracTalepKaydet> _aracTalepKayitValidator;
        private readonly IValidator<DtoAracTalepGuncelle> _aracTalepGuncelleValidator;
        public AracTalepController(IRestSharpRequest restSharpRequest, IValidator<DtoAracTalepKaydet> aracTalepKayitValidator, IValidator<DtoAracTalepGuncelle> aracTalepGuncelleValidator) : base(restSharpRequest)
        {
            _aracTalepKayitValidator = aracTalepKayitValidator;
            _aracTalepGuncelleValidator = aracTalepGuncelleValidator;
        }

        #region View
        public async Task SayfaVeriAta()       
        {
            var aracListesi = await SendRequestWithoutToken<List<DtoArac>>("Arac", RestSharp.Method.GET);
            ViewBag.aracListesi = aracListesi.ToSelectList("Id", "AracTipi.Adi");
            var soforListesi = await SendRequestWithoutToken<List<DtoSofor>>("Sofor", RestSharp.Method.GET);
            ViewBag.soforListesi = soforListesi.ToSelectList("Id", "Kullanici.AdSoyad");
            var aracBeklemeDurumListesi = await SendRequestWithoutToken<List<DtoAracBeklemeDurum>>("AracBeklemeDurum", RestSharp.Method.GET);
            ViewBag.aracBeklemeDurumListesi = aracBeklemeDurumListesi.ToSelectList("Id", "BeklemeDurum");
        }

        public async Task<IActionResult> KaydetView()
        {
            await SayfaVeriAta();
            return View(new DtoAracTalepKaydet()
            {
                
            });
        }
        
        public async Task<IActionResult> ListeleView()
        {
            return View();
        }

        public async Task<IActionResult> OnaylaView()
        {
            return View();
        }

        public async Task<PartialViewResult> AracTalepPopUpDuzenleView(int id)
        {
            await SayfaVeriAta();
            var sonuc = await SendRequestWithoutToken<DtoAracTalepKaydet>("AracTalep/AracTalepGetir", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return PartialView("_Duzenle", sonuc);
        }

        public async Task<PartialViewResult> OnaylanacakAracTalepPopUpDuzenleView(int id)
        {
            await SayfaVeriAta();
            var sonuc = await SendRequestWithoutToken<DtoAracTalepKaydet>("AracTalep/AracTalepGetir", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return PartialView("_OnayDuzenle", sonuc);
        }
        #endregion

        #region Function
        [HttpPost]
        public async Task<IActionResult> Kaydet(DtoAracTalepKaydet model)
        {
            model.AracTalepDurum =(int)AracTalepDurum.OnayBekliyor;
            var modelValidator = _aracTalepKayitValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });
            var sonuc = await SendRequestWithoutToken<int>("AracTalep/AracTalepKaydet", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }

        [HttpPost]
        public async Task<IActionResult> Guncelle(DtoAracTalepGuncelle model)
        {
            var modelValidator = _aracTalepGuncelleValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });
            var sonuc = await SendRequestWithoutToken<int>("AracTalep/AracTalepGuncelle", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }


        [HttpPost]
        public async Task<IActionResult> Onayla(DtoAracTalepGuncelle model)
        {
            var modelValidator = _aracTalepGuncelleValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });

            if (model.AracId != null && model.SoforId != null)
            {
                model.AracTalepDurum = (int)AracTalepDurum.Onaylandi;
                var sonuc = await SendRequestWithoutToken<int>("AracTalep/AracTalepGuncelle", RestSharp.Method.POST, RestRequestContentType.application_json, model);
                return Json(new { sonuc });
            }
            else
            {
                model.AracTalepDurum = (int)AracTalepDurum.OnayBekliyor;
                return Json(new { });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Reddet(DtoAracTalepGuncelle model)
        {
            var modelValidator = _aracTalepGuncelleValidator.Validate(model);
            if (!modelValidator.IsValid)
                return Json(new { ErrorCode = 1001, Result = modelValidator.Errors.Select(e => e.ErrorMessage) });

            model.AracTalepDurum = (int)AracTalepDurum.Reddedildi;
            var sonuc = await SendRequestWithoutToken<int>("AracTalep/AracTalepGuncelle", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }

        [HttpPost]
        public async Task<IActionResult> Sil(int id)
        {
            var sonuc = await SendRequestWithoutToken<int>("AracTalep/AracTalepSil", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            return Json(new { sonuc });
        }

        [HttpPost]
        public async Task<IActionResult> ListeGetir()
        {
            var liste = await SendRequestWithoutToken<List<DtoAracTalep>>("AracTalep", RestSharp.Method.GET);
            return Json(new { recordsFiltered = liste.Count, recordsTotal = liste.Count, data = liste });
        }

        [HttpPost]
        public async Task<IActionResult> TalepOnaylaListeGetir()
        {
            var liste = await SendRequestWithoutToken<List<DtoAracTalep>>("AracTalep", RestSharp.Method.GET);
            List<DtoAracTalep>? onaybekleyenlerlistesi = new List<DtoAracTalep>();
            foreach (var item in liste)
            {
                if ((int)item.AracTalepDurum == (int)AracTalepDurum.OnayBekliyor)
                {
                    onaybekleyenlerlistesi.Add(item);
                }
            }
            return Json(new { recordsFiltered = liste.Count, recordsTotal = liste.Count, data = onaybekleyenlerlistesi });
        }

        #endregion
    }
}
