using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.Kullanici;
using ModelDto.Enums;
using WebUI.Genel;

namespace WebUI.Controllers
{
    public class AdresDefteriController : UIBaseController
    {        
        public AdresDefteriController(IRestSharpRequest restSharpRequest) : base(restSharpRequest)
        {            
        }

        public async Task<IActionResult> ListeleView()
        {
            return View();
        }

        public async Task<IActionResult> KullaniciListesiGetir()
        {
            var liste = await SendRequestWithoutToken<List<DtoKullanici>>("Kullanici", RestSharp.Method.GET);
            foreach (var item in liste)
            {
                item.Resim = $"/uploaded_files/{item.Resim}";
            }
            return Json(new { recordsFiltered = liste.Count, recordsTotal = liste.Count, data = liste });
        }

        [HttpPost]
        public async Task<IActionResult> AdresDefteriDatatable(DtoKullaniciGuncelle model)
        {
            var sonuc = await SendRequestWithoutToken<DtoKullaniciGuncelle>("Kullanici/KullaniciGirisBeyza", RestSharp.Method.POST, RestRequestContentType.application_json,model);
            return Json(new { sonuc });
        }

    }
}
