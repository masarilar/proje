using Application.DosyaApps;
using Application.Interfaces.Apps;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.Kullanici;

namespace WebApi.Controllers
{
    public class KullaniciController : ApiControllerBase
    {
        private IKullaniciApp _kullaniciApp { get; set; }

        public KullaniciController(IKullaniciApp kullaniciApp)
        {
            _kullaniciApp = kullaniciApp;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> KullaniciKaydet(DtoKullaniciKaydet model)
        {
            return Ok(await _kullaniciApp.KullaniciKaydet(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> KullaniciSil([FromBody] int id)
        {
            return Ok(await _kullaniciApp.KullaniciSil(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> KullaniciGuncelle(DtoKullaniciGuncelle model)
        {
            return Ok(await _kullaniciApp.KullaniciGuncelle(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> KullaniciGetir([FromBody]int id)
        {
            return Ok(await _kullaniciApp.KullaniciGetir(id));
        }

        [HttpGet]
        public async Task<IActionResult> KullaniciListesiGetir()
        {
            return Ok(await _kullaniciApp.KullaniciListesiGetir());
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> KullaniciGiris(DtoKullaniciGiris model)
        {
            return Ok(await _kullaniciApp.KullaniciGiris(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> KullaniciProfiliGetir([FromBody] int id)
        {
            return Ok(await _kullaniciApp.KullaniciProfiliGetir(id));
        }


    }
}
