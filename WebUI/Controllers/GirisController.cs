using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.Kullanici;
using ModelDto.Enums;
using WebUI.Genel;

namespace WebUI.Controllers
{
    public class GirisController : UIBaseController
    {
        public GirisController(IRestSharpRequest restSharpRequest) : base(restSharpRequest)
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KullaniciGiris(DtoKullaniciGiris model)
        {
            var sonuc = await SendRequestWithoutToken<int>("Kullanici/KullaniciGiris", RestSharp.Method.POST, RestRequestContentType.application_json, model);
            return Json(new { sonuc });
        }
    }
}
