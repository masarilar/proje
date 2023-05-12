using Application.Interfaces.Apps;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.Duyuru;
using ModelDto.Enums;

namespace WebApi.Controllers
{
    public class DuyuruController : ApiControllerBase {
        private IDuyuruApp _duyuruApp { get; set; }
        public DuyuruController(IDuyuruApp duyuruApp) {
            _duyuruApp = duyuruApp;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> DuyuruKaydet(DtoDuyuruKaydet model) {
            return Ok(await _duyuruApp.DuyuruKaydet(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> DuyuruGuncelle(DtoDuyuruGuncelle model) {
            return Ok(await _duyuruApp.DuyuruGuncelle(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> DuyuruSil([FromBody] int id) {
            return Ok(await _duyuruApp.DuyuruSil(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> DuyuruGetir([FromBody] int id) {
            return Ok(await _duyuruApp.DuyuruGetir(id));
        }

        [HttpGet]
        public async Task<IActionResult> DuyuruListesiGetir() {
            return Ok(await _duyuruApp.DuyuruListesiGetir());
        }

        [HttpPost]
        public async Task<IActionResult> DuyuruListesiGetir([FromBody] KategoriTipleri kategoriTip) {
            return Ok(await _duyuruApp.DuyuruListesiGetir(kategoriTip));
        }
    }
}
