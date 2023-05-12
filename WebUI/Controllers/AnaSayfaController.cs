using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.Duyuru;
using ModelDto.Dtos.Kategori;
using ModelDto.Enums;
using WebUI.Genel;

namespace WebUI.Controllers {
    public class AnaSayfaController : UIBaseController {
        public AnaSayfaController(IRestSharpRequest restSharpRequest) : base(restSharpRequest) {
        }

        public async Task<IActionResult> HaberDetay(int id) {
            var haberModel = await SendRequestWithoutToken<DtoDuyuru>("Duyuru/DuyuruGetir", RestSharp.Method.POST, RestRequestContentType.application_json, id);
            var kategoriler = await SendRequestWithoutToken<List<DtoKategori>>("Kategori", RestSharp.Method.POST, RestRequestContentType.application_json, KategoriTipleri.Haber);
            ViewBag.kategoriListesi = kategoriler;
            return View(haberModel);
        }
        public async Task<IActionResult> Index() {
            ViewBag.tumDuyuruButonGosterme = false;
            var haberListesi = await SendRequestWithoutToken<List<DtoDuyuru>>("Duyuru", RestSharp.Method.POST, RestRequestContentType.application_json, KategoriTipleri.Haber);
            ViewBag.haberListe = haberListesi.OrderBy(e => e.SliderSirasi).ToList();
            var duyuruListesi = await SendRequestWithoutToken<List<DtoDuyuruLocalStorage>>("Duyuru", RestSharp.Method.POST, RestRequestContentType.application_json, KategoriTipleri.Duyuru);
            ViewBag.duyuruListe = duyuruListesi.OrderByDescending(e => e.YayinTarih).Take(1).ToList();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DuyurulariGetir() {
            var duyuruListesi = await SendRequestWithoutToken<List<DtoDuyuruLocalStorage>>("Duyuru", RestSharp.Method.POST, RestRequestContentType.application_json, KategoriTipleri.Duyuru);
            ViewBag.duyuruListe = duyuruListesi.OrderByDescending(e => e.YayinTarih).ToList();
            ViewBag.tumDuyuruButonGosterme = true;
            return PartialView("_Duyuru");
        }
        [HttpGet]
        public async Task<IActionResult> DogumGunleriGetir() {
            //var kategoriListesi = await SendRequestWithoutToken<List<DtoKategori>>("Kategori", RestSharp.Method.GET);//Kullanıcı tablosu gelince oradan çekilecek veriler.
            var list = new List<object>() {
                new { imgYol = "/assets/media/avatars/300-1.jpg", ad = "Mehmet Ali", soyad = "SARILAR" },
                new { imgYol = "/assets/media/avatars/300-10.jpg", ad = "Zehra", soyad = "SARILAR" },
                new { imgYol = "/assets/media/avatars/300-12.jpg", ad = "Merve", soyad = "SARILAR" },
                new { imgYol = "/assets/media/avatars/300-11.jpg", ad = "Bilal", soyad = "SARILAR" },
            };
            return Json(new { liste = list, storageGuncellemeTarih = "02.20.2023" /*DateTime.Now.ToString("MM.dd.yyyy")*/});
        }
    }
}
