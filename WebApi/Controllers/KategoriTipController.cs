using Application.Interfaces.Apps;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.KategoriTip;

namespace WebApi.Controllers
{
    public class KategoriTipController : ApiControllerBase
    {
        private IKategoriTipApp _kategoriTipApp { get; set; }
        public KategoriTipController(IKategoriTipApp kategoriTipApp)
        {
            _kategoriTipApp = kategoriTipApp;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> KategoriTipKaydet(DtoKategoriTipKaydet model)
        {
            return Ok(await _kategoriTipApp.KategoriTipKaydet(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> KategoriTipSil([FromBody] int id)
        {
            return Ok(await _kategoriTipApp.KategoriTipSil(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> KategoriTipGuncelle(DtoKategoriTipGuncelle model)
        {
            return Ok(await _kategoriTipApp.KategoriTipGuncelle(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> KategoriTipGetir([FromBody] int id)
        {
            return Ok(await _kategoriTipApp.KategoriTipGetir(id));
        }

        [HttpGet]
        public async Task<IActionResult> KategoriTipListesiGetir()
        {
            return Ok(await _kategoriTipApp.KategoriTipListesiGetir());
        }
    }
}
