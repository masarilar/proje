using Application.Interfaces.Apps;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.Kategori;
using ModelDto.Enums;

namespace WebApi.Controllers
{
    public class KategoriController : ApiControllerBase
    {
        private IKategoriApp _kategoriApp { get; set; }

        public KategoriController(IKategoriApp kategoriApp)
        {
            _kategoriApp = kategoriApp;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> KategoriKaydet(DtoKategoriKaydet model)
        {
            return Ok(await _kategoriApp.KategoriKaydet(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> KategoriSil([FromBody] int id)
        {
            return Ok(await _kategoriApp.KategoriSil(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> KategoriGuncelle(DtoKategoriGuncelle model)
        {
            return Ok(await _kategoriApp.KategoriGuncelle(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> KategoriGetir([FromBody] int id)
        {
            return Ok(await _kategoriApp.KategoriGetir(id));
        }

        [HttpGet]
        public async Task<IActionResult> KategoriListesiGetir()
        {
            return Ok(await _kategoriApp.KategoriListesiGetir());
        }

        [HttpPost]
        public async Task<IActionResult> KategoriListesiGetir([FromBody] KategoriTipleri kategoriTip) {
            return Ok(await _kategoriApp.KategoriListesiGetir(kategoriTip));
        }
    }
}
