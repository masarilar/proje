using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.Dosya;
using ModelDto.Enums;
using RestSharp;
using WebUI.Genel;

namespace WebUI.Controllers {
    public class DosyaController : UIBaseController {
        private readonly IWebHostEnvironment _env;
        public DosyaController(IRestSharpRequest restSharpRequest, IWebHostEnvironment env) : base(restSharpRequest) {
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> DosyaIndir(int id) {
            var dosya = await SendRequestWithoutToken<DtoDosya>("Dosya/DosyaGetir", Method.POST, RestRequestContentType.application_json, id);
            var dosyasBytes = System.IO.File.ReadAllBytes(Path.Combine(_env.WebRootPath, $"uploaded_files/{dosya.Yol}"));
            return File(dosyasBytes, "application/octet-stream", dosya.Adi);
        }

        [HttpPost]
        public async Task<IActionResult> DosyaSil(int id) {
            var sonuc = await SendRequestWithoutToken<int>("Dosya/DosyaSil", Method.POST, RestRequestContentType.application_json, id);
            return Json(new { sonuc });
        }
    }
}